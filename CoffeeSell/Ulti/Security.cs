using System.Security.Cryptography;
using System.Text;

public static class Security
{
    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();

            foreach (byte b in hash)
            {
                builder.Append(b.ToString("x2")); // hex format
            }

            return builder.ToString();
        }
    }
}
