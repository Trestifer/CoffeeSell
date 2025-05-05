using System.Net.Mail;
using System.Net;
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
    public static string GenerateOTP(int length = 6)
    {
        var random = new Random();
        var otp = "";

        for (int i = 0; i < length; i++)
        {
            otp += random.Next(0, 10); 
        }

        return otp;
    }

    public static bool SendOtpEmail(string toEmail, string otp)
    {
        string fromEmail = "trestifer73105@gmail.com";
        string fromPassword = "danu amqj bvqo bguk";

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(fromEmail);
        mail.To.Add(toEmail);
        mail.Subject = "Your OTP Code";
        mail.Body = $"Your OTP is: {otp}";

        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
        smtp.EnableSsl = true;

        try
        {
            smtp.Send(mail);
            System.Diagnostics.Debug.WriteLine("OTP sent successfully!");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Failed to send OTP: " + ex.Message);
            return false;
        }
        return true;
    }
}
