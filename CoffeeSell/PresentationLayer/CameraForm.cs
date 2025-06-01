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
using System.Collections.Concurrent;


namespace CoffeeSell.PresentationLayer
{
    public partial class CameraForm : Form
    {
        private volatile bool isRecognizing = false;
        private VideoCapture capture;
        private Mat frame;
        private Bitmap image;
        private volatile bool isCapturing = false;
        private ManagerSecurity manager;
        private Account user;
        private bool goLogin;
        private volatile bool isProcessing = false;

        public CameraForm(Account _user, bool LoginCheck = false)
        {
            user = _user;
            manager = BOManagerSecurity.Get(_user.GetLoginName());
            InitializeComponent();
            frame = new Mat();
            capture = new VideoCapture(0);
            goLogin = LoginCheck;
            if (!capture.IsOpened())
            {
                MessageBox.Show("No camera found or cannot be opened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
            var frameQueue = new ConcurrentQueue<Bitmap>();
            var recognitionTokenSource = new CancellationTokenSource();
            var token = recognitionTokenSource.Token;
            var stopwatch = new Stopwatch();

            // 🚀 Start camera capture & display loop (60 FPS)
            Task.Run(async () =>
            {
                stopwatch.Start();
                while (isCapturing)
                {
                    try
                    {
                        capture.Read(frame);
                        if (!frame.Empty())
                        {
                            var bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);

                            // 🖼️ Display frame in PictureBox (UI thread)
                            if (bitmap != null)
                            {
                                try
                                {
                                    Bitmap frameCopy = (Bitmap)bitmap.Clone();
                                    _ = pictureBox1.BeginInvoke(new Action(() =>
                                    {
                                        pictureBox1.Image?.Dispose();
                                        pictureBox1.Image = frameCopy;
                                    }));
                                }
                                catch (Exception ex)
                                {
                                    Debug.WriteLine("Bitmap clone or assign error: " + ex.Message);
                                }
                            }

                            image?.Dispose();
                            image = (Bitmap)bitmap.Clone();
                            if (isRecognizing && !isProcessing)
                            {
                                frameQueue.Enqueue((Bitmap)bitmap.Clone());
                            }

                            bitmap.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Camera loop error: " + ex.Message);
                    }

                    // 🎯 60 FPS target (~16ms per frame)
                    int delay = Math.Max(0, 16 - (int)stopwatch.ElapsedMilliseconds);
                    await Task.Delay(delay);
                    stopwatch.Restart();
                }

                stopwatch.Stop();
            });

            // 🧠 Start background recognition loop
            if (isRecognizing)
            {
                Task.Run(async () =>
                {
                    while (isCapturing && !token.IsCancellationRequested)
                    {
                        if (frameQueue.TryDequeue(out var frameToProcess))
                        {
                            isProcessing = true;

                            try
                            {
                                using var ms = new MemoryStream();
                                frameToProcess.Save(ms, ImageFormat.Jpeg);
                                frameToProcess.Dispose();

                                string base64 = Convert.ToBase64String(ms.ToArray());
                                string result = await Security.RecognizeFace(base64);
                                Debug.WriteLine($"Recognition result: {result}");

                                var json = JObject.Parse(result);
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
                                        confidence < 0.6) // Change based on your logic
                                    {
                                        isRecognizing = false;
                                        isCapturing = false;
                                        recognitionTokenSource.Cancel();

                                        pictureBox1.Invoke(() =>
                                        {
                                            MessageBox.Show("Xác thực khuôn mặt thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            this.Invoke(() => this.Close());

                                            if (!goLogin)
                                                new NhapOTP(user).Show();
                                            else
                                                new TrangChu(user).Show();
                                        });
                                    }
                                }
                                else
                                {
                                    Debug.WriteLine("No match found in 'matches'.");
                                }
                            }
                            catch (Exception ex)
                            {
                                pictureBox1.Invoke(() =>
                                {
                                    MessageBox.Show("Recognition error: " + ex.Message);
                                });
                            }

                            isProcessing = false;
                        }

                        await Task.Delay(200); // 🕓 Throttle recognition speed
                    }
                }, token);
            }
        }



        private void StopCamera()
        {
            isCapturing = false;
            capture.Release();
        }

       

        private async void CameraForm_Load(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(manager.GetEncodingFace()))
            {
                takePhotoButton.Visible = true;
                isRecognizing = false;
                label1.Text = "Đăng ký khuôn mặt";
            }
            else
            {
                takePhotoButton.Visible = false;
                isRecognizing = true;
                label1.Text = "Nhận diện khuôn mặt";
            }
            StartCamera();
            Debug.WriteLine($"Button Visible: {takePhotoButton.Visible}, Enabled: {takePhotoButton.Enabled}");


        }

        private void CameraForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Optional
        }

        private async void takePhotoButton_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked");

            if (image == null)
            {
                MessageBox.Show("Chưa chụp được ảnh.");
                return;
            }

            // Offload the rest to a background thread
            await Task.Run(async () =>
            {
                try
                {
                    using var ms = new MemoryStream();
                    image.Save(ms, ImageFormat.Jpeg);
                    string base64String = Convert.ToBase64String(ms.ToArray());

                    string name = manager.GetLoginName();
                    string result = await Security.RegisterFace(name, base64String);

                    JObject json = JObject.Parse(result);
                    string status = json["status"]?.ToString() ?? "";

                    if (status.Equals("success", StringComparison.OrdinalIgnoreCase))
                    {
                        string encoding = json["encoding"]?.ToString();
                        if (!string.IsNullOrEmpty(encoding))
                        {
                            BOManagerSecurity.Update(name, encoding);

                            Invoke(() =>
                            {
                                MessageBox.Show("Đăng ký khuôn mặt thành công");

                                isCapturing = false;
                                pictureBox1.Image?.Dispose();
                                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                                {
                                    g.Clear(Color.Black);
                                }

                                this.Close();
                                new CameraForm(user).Show();
                            });
                        }
                        else
                        {
                            Invoke(() => MessageBox.Show("Đăng ký thành công nhưng không nhận được encoding."));
                        }
                    }
                    else
                    {
                        Invoke(() => MessageBox.Show("Đăng ký khuôn mặt thất bại: " + result));
                    }
                }
                catch (Exception ex)
                {
                    Invoke(() => MessageBox.Show("Lỗi: " + ex.Message));
                }
            });
        }

    }
}
