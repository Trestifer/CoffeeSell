using CoffeeSell.ObjClass;
using OpenCvSharp;
using System;
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
        private VideoCapture capture;
        private Mat frame;
        private Bitmap image;
        private bool isCapturing = false;

        public CameraForm(ManagerSecurity manager)
        {
            InitializeComponent();
            frame = new Mat();
            capture = new VideoCapture(0);

            if (!capture.IsOpened())
            {
                MessageBox.Show("No camera found or cannot be opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();  // Close the form immediately since no camera is available
                return;
            }
        }

        private void StartCamera()
        {
            if (!capture.IsOpened())
            {
                // Just in case StartCamera is called separately, double check
                MessageBox.Show("No camera found or cannot be opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            isCapturing = true;
            Task.Run(() =>
            {
                while (isCapturing)
                {
                    capture.Read(frame);
                    if (!frame.Empty())
                    {
                        image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                        pictureBox1.Invoke(new Action(() =>
                        {
                            pictureBox1.Image?.Dispose();
                            pictureBox1.Image = (Bitmap)image.Clone();
                        }));
                    }
                    System.Threading.Thread.Sleep(30);
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
                // Convert 'image' to Base64 here
                using var ms = new MemoryStream();
                image.Save(ms, ImageFormat.Jpeg);
                string base64String = Convert.ToBase64String(ms.ToArray());
                // Now you can send base64String to your API
                MessageBox.Show("Photo captured!");
            }
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }
    }

}
