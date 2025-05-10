using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace CoffeeSell.Ulti
{
    public static class ImageCache
    {
        private static readonly Dictionary<string, Image> _cache = new Dictionary<string, Image>();

        public static Image GetImage(string path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
                return null;

            if (_cache.ContainsKey(path))
                return _cache[path];

            try
            {
                Image img = Image.FromFile(path);
                _cache[path] = img;
                return img;
            }
            catch
            {
                return null;
            }
        }

        public static void ClearCache()
        {
            foreach (var img in _cache.Values)
                img.Dispose();

            _cache.Clear();
        }
    }
}
