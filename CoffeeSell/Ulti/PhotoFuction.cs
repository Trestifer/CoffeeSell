using System;
using System.Drawing;
using System.IO;

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

    }
}
