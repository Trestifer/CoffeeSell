using System;
using System.Drawing;
using System.IO;

namespace CoffeeSell.Ulti
{
    public class PhotoFunction
    {
       
        private static readonly string ImageFolder = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Images"
        );

        // Load ảnh từ file (tên ảnh là file name: food_5.jpg)
        public static Image LoadImage(string fileName)
        {
            try
            {
                string fullPath = Path.Combine(ImageFolder, fileName);
                if (File.Exists(fullPath))
                    return Image.FromFile(fullPath);

                return Image.FromFile(Path.Combine(ImageFolder, "no_image.png"));
            }
            catch
            {
                return null;
            }
        }

        // Lưu ảnh vào thư mục Images, trả về tên file đã lưu
        public static string SaveImageToImagesFolder(string sourcePath, int foodId)
        {
            try
            {
                if (!Directory.Exists(ImageFolder))
                    Directory.CreateDirectory(ImageFolder);

                string ext = Path.GetExtension(sourcePath);
                string fileName = $"food_{foodId}{ext}";
                string destPath = Path.Combine(ImageFolder, fileName);

                File.Copy(sourcePath, destPath, overwrite: true);
                return fileName; // ví dụ: food_5.jpg
            }
            catch
            {
                return "no_image.png";
            }
        }
    }
}
