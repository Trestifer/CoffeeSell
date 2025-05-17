using System;
using System.Data;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    internal class DAOEmailSecurity : DAO
    {
        public bool UpdateEmailSecurityById(EmailSecurity emailSecurity)
        {
            string cmString = @"
                UPDATE EmailSecurity
                SET Email = @Email,
                    IsConfirmed = @IsConfirmed,
                    CurrentOTP = @CurrentOTP,
                    OTPExpired = @OTPExpired
                WHERE EmailId = @EmailId";

            try
            {
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new[] { "@Email", "@IsConfirmed", "@CurrentOTP", "@OTPExpired", "@EmailId" },
                    new object[]
                    {
                        emailSecurity.GetEmail(),
                        emailSecurity.GetIsConfirmed(),
                        emailSecurity.GetCurrentOTP(),
                        emailSecurity.GetOTPExpired(),
                        emailSecurity.GetId()
                    });

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating EmailSecurity: {ex.Message}");
                return false;
            }
        }
        public EmailSecurity GetEmailSecurityByLoginName(string loginName)
        {
            string cmString = @"
        SELECT e.EmailId, e.Email, e.IsConfirmed, e.CurrentOTP, e.OTPExpired
        FROM ManagerSecurity m
        JOIN EmailSecurity e ON m.EmailId = e.EmailId
        WHERE m.LoginName = @LoginName";

            try
            {
                DataTable result = ExecuteQuery(
                    cmString,
                    new[] { "@LoginName" },
                    new object[] { loginName }
                );

                if (result.Rows.Count == 1)
                {
                    DataRow row = result.Rows[0];
                    EmailSecurity email = new EmailSecurity();
                    email.SetId(Convert.ToInt32(row["EmailId"]));
                    email.SetEmail(row["Email"].ToString());
                    email.SetIsConfirmed(Convert.ToBoolean(row["IsConfirmed"]));
                    email.SetCurrentOTP(row["CurrentOTP"].ToString());
                    email.SetOTPExpired(Convert.ToDateTime(row["OTPExpired"]));
                    return email;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching EmailSecurity by LoginName: {ex.Message}");
                return null;
            }
        }

    }
}
