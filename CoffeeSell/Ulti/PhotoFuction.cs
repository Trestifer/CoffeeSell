using System;
using System.Diagnostics;
using System.IO;

namespace CoffeeSell.Ulti
{
    public class PhotoFunction
    {
        public static string ImageToBase64(string imagePath)
        {
            using (Image image = Image.FromFile(imagePath))
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
        public static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (var ms = new MemoryStream(imageBytes))
            {
                using (var original = Image.FromStream(ms))
                {
                    return new Bitmap(original); // Return a copy that doesn't depend on the stream
                }
            }
        }

    }
}
