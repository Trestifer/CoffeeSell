using CoffeeSell.ObjClass;
using CoffeeSell.Ulti;
using OpenCvSharp;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using CoffeeSell.BO;
using System.Drawing.Text; // For JSON parsing

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
        private Account user;

        public CameraForm(Account _user)
        {
            user = _user;
            manager = BOManagerSecurity.Get(_user.GetLoginName());
            InitializeComponent();
            frame = new Mat();
            capture = new VideoCapture(0);

            if (!capture.IsOpened())
            {
                MessageBox.Show("No camera found or cannot be opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            takePhotoButton.Click += takePhotoButton_Click;
            this.Load += CameraForm_Load;
            this.FormClosing += CameraForm_FormClosing;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
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
                    try
                    {
                        capture.Read(frame);

                        if (!frame.Empty())
                        {
                            image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);

                            pictureBox1.Invoke(() =>
                            {
                                try
                                {
                                    pictureBox1.Image?.Dispose();
                                    pictureBox1.Image = (Bitmap)image.Clone();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Image display error: " + ex.Message);
                                }
                            });

                            if (isRecognizing)
                            {
                                using var ms = new MemoryStream();
                                image.Save(ms, ImageFormat.Jpeg);
                                string base64 = Convert.ToBase64String(ms.ToArray());

                                string result = await Security.RecognizeFace(base64);
                                Debug.WriteLine($"Recognition result: {result}");

                                try
                                {
                                    var json = JObject.Parse(result);

                                    // Parse from first item in "matches"
                                    var match = json["matches"]?.FirstOrDefault();
                                    if (match != null)
                                    {
                                        string name = match["name"]?.ToString() ?? "unknown";
                                        double confidence = match["confidence"]?.ToObject<double>() ?? 1.0;
                                        string expectedName = manager.GetLoginName();

                                        Debug.WriteLine($"Parsed name: {name}, confidence: {confidence}");

                                        if (!string.IsNullOrEmpty(name) &&
                                            name != "unknown" &&
                                            name.Equals(expectedName, StringComparison.OrdinalIgnoreCase) &&
                                            confidence < 0.6)
                                        {
                                            isRecognizing = false;
                                            isCapturing = false;

                                            pictureBox1.Invoke(() =>
                                            {
                                                MessageBox.Show("Xác thực khuôn mặt thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.Invoke(() => this.Close());
                                                new NhapOTP(user).Show();
                                            });
                                        }
                                    }
                                    else
                                    {
                                        Debug.WriteLine("No face match found in 'matches'.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    pictureBox1.Invoke(() =>
                                    {
                                        MessageBox.Show("JSON parsing error: " + ex.Message + "\nResult: " + result);
                                    });
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Camera loop error: " + ex.Message);
                    }

                    await Task.Delay(100);
                }
            });
        }


        private void StopCamera()
        {
            isCapturing = false;
            capture.Release();
        }

        private async void takePhotoButton_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                try
                {
                    using var ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Jpeg);
                    string base64String = Convert.ToBase64String(ms.ToArray());

                    string name = manager.GetLoginName();
                    string result = await Security.RegisterFace(name, base64String);

                    try
                    {
                        var json = JObject.Parse(result);
                        string status = json["status"]?.ToString() ?? "";
                        if (status.Equals("success", StringComparison.OrdinalIgnoreCase))
                        {
                            string encoding = json["encoding"]?.ToString();

                            if (!string.IsNullOrEmpty(encoding))
                            {
                                BOManagerSecurity.Update(manager.GetLoginName(),encoding);

                                MessageBox.Show("Đăng ký khuôn mặt thành công");

                                // Only switch to recognition if registration was successful
                                isCapturing = false;
                                pictureBox1.Invoke(() =>
                                {
                                    pictureBox1.Image?.Dispose();
                                    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                                    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                                    {
                                        g.Clear(Color.Black);
                                    }
                                });

                                await Task.Delay(1000);

                                recognizedName = string.Empty;
                                isRecognizing = true;
                                StartCamera();

                                takePhotoButton.Invoke(() => takePhotoButton.Visible = false);
                            }
                            else
                            {
                                MessageBox.Show("Đăng ký thành công nhưng không nhận được encoding.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đăng ký khuôn mặt thất bại: " + result);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi đọc file Json: " + ex.Message + "\nResult: " + result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Register error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Chưa chụp được ảnh.");
            }
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            StartCamera();

            if (string.IsNullOrEmpty(manager.GetEncodingFace()))
            {
                takePhotoButton.Visible = true;
                isRecognizing = false;
            }
            else
            {
                takePhotoButton.Visible = false;
                isRecognizing = true;
            }
        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Optional
        }

        

    }
}
