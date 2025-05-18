using System;
using System.Data;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOEmployeeEmail : DAO
    {
        public bool UpdateEmployeeEmail(EmployeeEmail emailInfo)
        {
            string cmString = "UPDATE EmployeeEmail " +
                              "SET Email = @Email, IsConfirmed = @IsConfirmed, CurrentOTP = @CurrentOTP, OTPExpired = @OTPExpired " +
                              "WHERE EmployeeId = @EmployeeId";

            try
            {
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new string[] { "@Email", "@IsConfirmed", "@CurrentOTP", "@OTPExpired", "@EmployeeId" },
                    new object[]
                    {
                        emailInfo.GetEmail(),
                        emailInfo.GetIsConfirmed(),
                        emailInfo.GetCurrentOTP(),
                        emailInfo.GetOTPExpired(),
                        emailInfo.GetEmployeeId()
                    });

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating employee email: {ex.Message}");
                return false;
            }
        }

       
            public bool CreateEmailForEmployee(EmployeeEmail emailInfo)
            {
                try
                {
                    // Step 1: Create EmailSecurity entry
                    string insertEmailSecurity = @"
                INSERT INTO EmailSecurity (Email, IsConfirmed, CurrentOTP, OTPExpired)
                OUTPUT INSERTED.EmailId
                VALUES (@Email, @IsConfirmed, @CurrentOTP, @OTPExpired)";

                    object result = ExecuteScalar(
                        insertEmailSecurity,
                        new[] { "@Email", "@IsConfirmed", "@CurrentOTP", "@OTPExpired" },
                        new object[] {
                    emailInfo.GetEmail(),
                    emailInfo.GetIsConfirmed(),
                    emailInfo.GetCurrentOTP(),
                    emailInfo.GetOTPExpired()
                        });

                    if (result == null)
                    {
                        System.Diagnostics.Debug.WriteLine("[CreateEmailForEmployee] Failed to insert EmailSecurity.");
                        return false;
                    }

                    int emailId = Convert.ToInt32(result);

                    // Step 2: Link with EmployeeEmail
                    string insertEmployeeEmail = @"
                INSERT INTO EmployeeEmail (EmployeeId, EmailId)
                VALUES (@EmployeeId, @EmailId)";

                    int rows = ExecuteNonQuery(
                        insertEmployeeEmail,
                        new[] { "@EmployeeId", "@EmailId" },
                        new object[] {
                    emailInfo.GetEmployeeId(),
                    emailId
                        });

                    return rows > 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[CreateEmailForEmployee] Error: {ex.Message}");
                    return false;
                }
            }



        public EmployeeEmail GetEmployeeEmailById(int employeeId)
        {
            string cmString = @"
        SELECT ee.EmployeeId, es.EmailId, es.Email, es.IsConfirmed, es.CurrentOTP, es.OTPExpired
        FROM EmployeeEmail ee
        JOIN EmailSecurity es ON ee.EmailId = es.EmailId
        WHERE ee.EmployeeId = @EmployeeId";

            try
            {
                DataTable result = ExecuteQuery(
                    cmString,
                    new string[] { "@EmployeeId" },
                    new object[] { employeeId }
                );

                if (result.Rows.Count == 1)
                {
                    DataRow row = result.Rows[0];
                    return new EmployeeEmail(
                        Convert.ToInt32(row["EmailId"]),
                        Convert.ToInt32(row["EmployeeId"]),
                        row["Email"].ToString(),
                        Convert.ToBoolean(row["IsConfirmed"]),
                        row["CurrentOTP"].ToString(),
                        Convert.ToDateTime(row["OTPExpired"])
                    );
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching employee email: {ex.Message}");
                return null;
            }
        }


        public bool DeleteEmployeeEmail(int employeeId)
        {
            string getEmailIdQuery = "SELECT EmailId FROM EmployeeEmail WHERE EmployeeId = @EmployeeId";
            string deleteEmployeeEmailQuery = "DELETE FROM EmployeeEmail WHERE EmployeeId = @EmployeeId";
            string deleteEmailSecurityQuery = "DELETE FROM EmailSecurity WHERE EmailId = @EmailId";

            try
            {
                // Step 1: Get EmailId
                DataTable result = ExecuteQuery(
                    getEmailIdQuery,
                    new string[] { "@EmployeeId" },
                    new object[] { employeeId }
                );

                if (result.Rows.Count == 0)
                {
                    // No record found to delete
                    return false;
                }

                int emailId = Convert.ToInt32(result.Rows[0]["EmailId"]);

                // Step 2: Delete from EmployeeEmail
                int rowsAffectedEmployeeEmail = ExecuteNonQuery(
                    deleteEmployeeEmailQuery,
                    new string[] { "@EmployeeId" },
                    new object[] { employeeId }
                );

                // Step 3: Delete from EmailSecurity
                int rowsAffectedEmailSecurity = ExecuteNonQuery(
                    deleteEmailSecurityQuery,
                    new string[] { "@EmailId" },
                    new object[] { emailId }
                );

                return rowsAffectedEmployeeEmail > 0 && rowsAffectedEmailSecurity > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting employee email and email security: {ex.Message}");
                return false;
            }
        }


        public DataTable GetAllEmployeeEmails()
        {
            string cmString = "SELECT * FROM EmployeeEmail";
            DataTable dt = new DataTable();

            try
            {
                dt = ExecuteQuery(cmString);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching all employee emails: {ex.Message}");
            }

            return dt;
        }
        public EmailSecurity GetEmailSecurityByAccountId(int accountId)
        {
            string cmString = @"
        SELECT es.EmailId, es.Email, es.IsConfirmed, es.CurrentOTP, es.OTPExpired
        FROM EmployeeEmail ee
        JOIN EmailSecurity es ON ee.EmailId = es.EmailId
        WHERE ee.EmployeeId = @AccountId";

            try
            {
                DataTable result = ExecuteQuery(
                    cmString,
                    new[] { "@AccountId" },
                    new object[] { accountId }
                );

                if (result.Rows.Count == 1)
                {
                    DataRow row = result.Rows[0];
                    EmailSecurity emailSecurity = new EmailSecurity();
                    emailSecurity.SetId(Convert.ToInt32(row["EmailId"]));
                    emailSecurity.SetEmail(row["Email"].ToString());
                    emailSecurity.SetIsConfirmed(Convert.ToBoolean(row["IsConfirmed"]));
                    emailSecurity.SetCurrentOTP(row["CurrentOTP"].ToString());
                    emailSecurity.SetOTPExpired(Convert.ToDateTime(row["OTPExpired"]));
                    return emailSecurity;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching EmailSecurity by AccountId: {ex.Message}");
                return null;
            }
        }

    }
}
