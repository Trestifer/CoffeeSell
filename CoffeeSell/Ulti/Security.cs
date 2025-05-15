using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

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
    public static async Task<string> RegisterFace(string name, string base64Image)
    {
        using (var client = new HttpClient())
        {
            var payload = new { name = name, image = base64Image };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://127.0.0.1:5000/register", content);
            return await response.Content.ReadAsStringAsync(); // JSON string
        }
    }
    public static async Task<string> RecognizeFace(string base64Image)
    {
        using (var client = new HttpClient())
        {
            var payload = new { image = base64Image };
            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://127.0.0.1:5000/recognize", content);
            return await response.Content.ReadAsStringAsync(); // JSON string
        }
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
