using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using SkiaSharp;
using System.Diagnostics;
using CoffeeSell.ObjClass;
using CoffeeSell.BO;

namespace CoffeeSell.Ulti
{
    public class PhotoFunction
    {
        // ✅ Đường dẫn tới thư mục Images trong thư mục gốc của project
        private static readonly string ImageFolder = Path.Combine(
            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,"Images"
        );

        // 📌 Load ảnh từ file (nếu không có thì load fallback ảnh mặc định)
        public static Image LoadImage(string fileName)
        {
            try
            {
                string fullPath = Path.Combine(ImageFolder, fileName);
                if (File.Exists(fullPath))
                    return Image.FromFile(fullPath);

                // fallback ảnh mặc định nếu không tìm thấy
                return Image.FromFile(Path.Combine(ImageFolder, "no_image.png"));
            }
            catch
            {
                return null;
            }
        }

        // 📌 Lưu ảnh mới vào thư mục Images, trả về tên file ảnh để lưu trong CSDL
        public static string SaveImageToImagesFolder(string sourcePath, int foodId)
        {
            try
            {
                if (!Directory.Exists(ImageFolder))
                    Directory.CreateDirectory(ImageFolder);

                string ext = Path.GetExtension(sourcePath);
                string uniqueId = DateTime.Now.ToString("yyyyMMddHHmmssfff"); // thời gian chính xác đến mili giây
                string fileName = $"food_{foodId}_{uniqueId}{ext}";
                string destPath = Path.Combine(ImageFolder, fileName);

                File.Copy(sourcePath, destPath, overwrite: true);
                return fileName; // ví dụ: "food_5_20240510144502123.jpg"
            }
            catch
            {
                return "no_image.png";
            }
        }


        public static string GenerateReceipt(Receipt receipt,string LoginName, Customer customer)
        {
            int width = 400;
            int height = 620 + (receipt.Items.Count * 40);
            // ✅ Create path like in SaveImageToImagesFolder
            string receiptFolder = Path.Combine(ImageFolder, "receipt");
            if (!Directory.Exists(receiptFolder))
                Directory.CreateDirectory(receiptFolder);

            string uniqueId = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string fileName = $"receipt_{receipt.id}_{uniqueId}.png";
            string filePath = Path.Combine(receiptFolder, fileName);

            using (SKBitmap bitmap = new SKBitmap(width, height))
            using (SKCanvas canvas = new SKCanvas(bitmap))
            {
                SKTypeface boldTypeface = SKTypeface.FromFamilyName("Arial", SKFontStyleWeight.Bold, SKFontStyleWidth.Normal, SKFontStyleSlant.Upright);
                SKTypeface italicTypeface = SKTypeface.FromFamilyName("Arial", SKFontStyleWeight.Normal, SKFontStyleWidth.Normal, SKFontStyleSlant.Italic);
                string theLine = "----------------------------------------------------------------------------------------------------------------";
                canvas.Clear(SKColors.White);  // Set background to white

                SKPaint textPaint = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 20,
                    IsAntialias = true,
                    TextAlign = SKTextAlign.Center // Center text alignment
                };
                SKPaint textPaintB = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 20,
                    IsAntialias = true,
                    TextAlign = SKTextAlign.Left, // Center text alignment
                    Typeface = boldTypeface
                };
                SKPaint line = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 7,
                    IsAntialias = true,
                    TextAlign = SKTextAlign.Center, // Center text alignment
                    Typeface = boldTypeface
                };
                SKPaint slogan = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 20,
                    IsAntialias = true,
                    TextAlign = SKTextAlign.Center, // Center text alignment
                    Typeface = italicTypeface
                };
                SKPaint smallerBoldFont = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 11,
                    IsAntialias = true,
                    TextAlign = SKTextAlign.Center,
                    Typeface = boldTypeface,
                    StrokeWidth = 1.5f
                };
                SKPaint shopName = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 33,
                    IsAntialias = true,
                    TextAlign = SKTextAlign.Center,
                    Typeface = boldTypeface,
                    StrokeWidth = 1.5f
                };

                int centerX = width / 2; // Center X position
                int y = 40;

                // Centered Shop Details
                canvas.DrawText("CoffeeHome", centerX, y, shopName);
                y += 30;
                canvas.DrawText($"D/c: 8 Tống Hữu Định, Thảo Điền, Tp.HCM", centerX, y, smallerBoldFont);
                y += 15;
                canvas.DrawText(theLine, centerX, y, line);
                y += 25;
                canvas.DrawText("HÓA ĐƠN SỐ: ", 80, y, textPaintB);
                canvas.DrawText($"{receipt.id}", 270, y, textPaint);



                textPaint.TextAlign = SKTextAlign.Left;
                y += 40;
                canvas.DrawText($"Ngày xuất: ", 15, y, textPaintB);
                canvas.DrawText(DateTime.Now.ToString("dd/MM/yyyy hh:mm"), 115, y, textPaint);

                y += 30;
                canvas.DrawText("Thu ngân: ", 15, y, textPaintB);
                canvas.DrawText(LoginName, 120, y, textPaint);
                y += 30;
                canvas.DrawText("KH:", 15, y, textPaintB);
                if (customer.GetCustomerId() == -1)
                {
                    customer.SetNameCustomer("");
                }
                canvas.DrawText(customer.GetNameCustomer(), 50, y, textPaint);
                y += 30;
                canvas.DrawText("Hạng TV:", 15, y, textPaintB);
                string rank = "Chưa có";
                int point = customer.GetPoints();
                Ranking r = BOCustomer.GetRanking();
                if (point >= r.KiemCuong)
                    rank = "Kim Cương";
                else if (point >= r.Vang)
                    rank = "Vàng";
                else if (point >= r.Bac)
                    rank = "Bạc";
                else if (point >= r.Dong)
                    rank = "Đồng";
                
                canvas.DrawText(rank, 120, y, textPaint);
                canvas.DrawText($"{point} points", 250, y, textPaint);


                y += 20;
                // Header
                line.TextAlign = SKTextAlign.Left;
                textPaint.TextAlign = SKTextAlign.Left; // Left-align product details
                canvas.DrawText("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", 0, y, line);
                y += 25;
                canvas.DrawText("SL", width - 180, y, textPaintB);
                canvas.DrawText("ĐƠN GIÁ", width - 120, y, textPaintB);
                canvas.DrawText("SẢN PHẨM", width - 350, y, textPaintB);

                canvas.DrawText("STT", 10, y, textPaint);
                y += 25;
                canvas.DrawText("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", 0, y, line);
                y += 30;

                // Draw product list
                int count = 1;
                foreach (var item in receipt.Items)
                {
                    if (string.IsNullOrWhiteSpace(item.name) || item.quantity <= 0) continue;

                    canvas.DrawText($"{count}", 15, y, textPaint);
                    canvas.DrawText(item.name, 45, y, textPaint);
                    canvas.DrawText($"{item.quantity}", width - 175, y, textPaint); // Align quantity
                    canvas.DrawText($"{item.price * item.quantity:F2}", width - 120, y, textPaint); // Align price
                    y += 30;
                    count++;
                }
                canvas.DrawText("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", 0, y, line);

                textPaintB.TextSize = 27;
                y += 20;
                canvas.DrawText($"{receipt.totalPrice:F2}", width - 120, y, textPaint);
                y += 30;
                canvas.DrawText($"-{receipt.totalDiscount:F2}", width - 128, y, textPaint);
                y += 15;
                canvas.DrawText("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", 0, y, line);
                y += 30;
                canvas.DrawText("Tổng cộng: ", 20, y, textPaint);
                canvas.DrawText($"{receipt.finalPrice:F2}", width - 122, y, textPaintB);
                y += 50;
                canvas.DrawText($"Nhận:", 20, y, textPaint);
                canvas.DrawText($"{receipt.receive:F2}", width - 120, y, textPaintB);

                y += 30;
                canvas.DrawText($"-{receipt.finalPrice:F2}", width - 128, y, textPaint);
                y += 30;
                canvas.DrawText($"Trả:", 20, y, textPaint);
                canvas.DrawText($"{receipt.changeDue:F2}", width - 120, y, textPaintB);
                y += 50;

                // Centered WiFi Info & Slogan
                textPaint.TextAlign = SKTextAlign.Center;
                canvas.DrawText($"WiFi: TheBoys || Pass: xincamon", centerX, y, smallerBoldFont);
                y += 30;
                canvas.DrawText("Cảm ơn quý khách", centerX, y, slogan);

                using (FileStream fs = File.OpenWrite(filePath))
                {
                    bitmap.Encode(fs, SKEncodedImageFormat.Png, 100);
                }
            }

            OpenImage(filePath);

            return Path.Combine("receipt", fileName);
        }

        public static void OpenImageByName(string fileName)
        {
            try
            {
                string fullPath = Path.Combine(ImageFolder, fileName);
                if (File.Exists(fullPath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = fullPath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    // Optional: fallback to "no_image.png" if file is missing
                    string fallbackPath = Path.Combine(ImageFolder, "no_image.png");
                    if (File.Exists(fallbackPath))
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = fallbackPath,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error opening image: {ex.Message}");
            }
        }

        private static void OpenImage(string filePath)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            });
        }
    }
}
