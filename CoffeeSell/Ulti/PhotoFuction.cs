using System;
using System.IO;

namespace CoffeeSell.Ulti
{
    public class PhotoFunction
    {
        public static string SavePhotoToUploads(string sourceFilePath)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string uploadsFolder = Path.Combine(baseDirectory, "Uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            // Generate a unique filename with timestamp or GUID
            string extension = Path.GetExtension(sourceFilePath);
            string uniqueFileName = Guid.NewGuid().ToString() + extension;

            string destFilePath = Path.Combine(uploadsFolder, uniqueFileName);
            File.Copy(sourceFilePath, destFilePath);

            return uniqueFileName; // Save this to database
        }
        public static string GetPhoto(string fileName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string uploadsFolder = Path.Combine(baseDirectory, "Uploads");
            string photoPath = Path.Combine(uploadsFolder, fileName);

            if (File.Exists(photoPath))
            {
                return photoPath;
            }

            return null; // or throw exception if preferred
        }

    }
}
