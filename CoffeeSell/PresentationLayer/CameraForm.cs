using CoffeeSell.ObjClass;
using CoffeeSell.Ulti;
using OpenCvSharp;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeSell.PresentationLayer
{
    public partial class CameraForm : Form
    {
        private bool isRecognizing = false;
        private string recognizedName = string.Empty;
        private VideoCapture capture;
        private Mat frame;
        private Bitmap image;
        private bool isCapturing = false;
        private ManagerSecurity manager;
        public CameraForm(ManagerSecurity _manager)
        {
            this.manager = _manager;
            InitializeComponent();
            frame = new Mat();
            capture = new VideoCapture(0);

            if (!capture.IsOpened())
            {
                MessageBox.Show("No camera found or cannot be opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();  // Close the form immediately since no camera is available
                return;
            }

            takePhotoButton.Click += takePhotoButton_Click;

        }

        private void StartCamera()
        {
            if (!capture.IsOpened())
            {
                MessageBox.Show("No camera found or cannot be opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            isCapturing = true;
            Task.Run(async () =>
            {
                while (isCapturing)
                {
                    capture.Read(frame);
                    if (!frame.Empty())
                    {
                        image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                        pictureBox1.Invoke(() =>
                        {
                            pictureBox1.Image?.Dispose();
                            pictureBox1.Image = (Bitmap)image.Clone();
                        });

                        // Start recognition if enabled and not already recognized
                        if (isRecognizing && string.IsNullOrEmpty(recognizedName))
                        {
                            using var ms = new MemoryStream();
                            image.Save(ms, ImageFormat.Jpeg);
                            string base64 = Convert.ToBase64String(ms.ToArray());

                            string result = await Security.RecognizeFace(base64);
                            if (!string.IsNullOrWhiteSpace(result) && !result.Contains("unknown", StringComparison.OrdinalIgnoreCase))
                            {
                                recognizedName = result;
                                MessageBox.Show("Recognized: " + recognizedName);
                            }
                        }
                    }

                    await Task.Delay(100); // Delay to reduce CPU usage
                }
            });
        }

        private void StopCamera()
        {
            isCapturing = false;
            capture.Release();
        }

        private void takePhotoButton_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                Task.Run(async () =>
                {
                    using var ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Jpeg);
                    string base64String = Convert.ToBase64String(ms.ToArray());

                    string name = manager.GetLoginName(); 
                    string result = await Security.RegisterFace(name, base64String);

                    MessageBox.Show("Register response: " + result);
                });
                
            }
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            StartCamera();

            if (manager.GetEncodingFace()== "")
            {
                takePhotoButton.Visible = true;  // allow registration
                isRecognizing = false;
            }
            else
            {
                // Ready to recognize
                takePhotoButton.Visible = false; // hide register button
                isRecognizing = true;
            }
        }


        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }
    }

}
