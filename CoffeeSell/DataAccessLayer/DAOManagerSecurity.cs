using System;
using System.Data;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOManagerSecurity : DAO
    {
        public bool UpdateManagerSecurityByLoginName(string loginName, string encodingFace)
        {
            string cmString = "UPDATE ManagerSecurity " +
                              "SET EncodingFace = @EncodingFace " +
                              "WHERE LoginName = @LoginName";

            try
            {
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new[] { "@EncodingFace", "@LoginName" },
                    new object[]
                    {
                encodingFace,
                loginName
                    });

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating EncodingFace by LoginName: {ex.Message}");
                return false;
            }
        }

        public int CreateManagerSecurity(ManagerSecurity manager)
        {
            // 1. Insert into EmailSecurity table first
            string insertEmailSecurity = @"
        INSERT INTO EmailSecurity (Email, IsConfirmed, CurrentOTP, OTPExpired)
        OUTPUT INSERTED.EmailId
        VALUES (@Email, @IsConfirmed, @CurrentOTP, @OTPExpired)";

            try
            {
                object emailIdObj = ExecuteScalar(
                    insertEmailSecurity,
                    new[] { "@Email", "@IsConfirmed", "@CurrentOTP", "@OTPExpired" },
                    new object[]
                    {
                manager.GetEmail(),
                manager.GetIsConfirmed(),
                manager.GetCurrentOTP(),
                manager.GetOTPExpired()
                    });

                if (emailIdObj == null)
                    return -1;

                int emailId = Convert.ToInt32(emailIdObj);

                // 2. Insert into ManagerSecurity with EmailId
                string insertManager = @"
            INSERT INTO ManagerSecurity (LoginName, EncodingFace, EmailId)
            OUTPUT INSERTED.EmailId
            VALUES (@LoginName, @EncodingFace, @EmailId)";

                object managerIdObj = ExecuteScalar(
                    insertManager,
                    new[] { "@LoginName", "@EncodingFace", "@EmailId" },
                    new object[]
                    {
                manager.GetLoginName(),
                manager.GetEncodingFace(),
                emailId
                    });

                return managerIdObj != null ? Convert.ToInt32(managerIdObj) : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating manager security: {ex.Message}");
                return -1;
            }
        }


        public ManagerSecurity GetManagerSecurityByLoginName(string loginName)
        {
            string cmString = "SELECT LoginName, EncodingFace FROM ManagerSecurity WHERE LoginName = @LoginName";

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
                    ManagerSecurity temp = new ManagerSecurity();
                    temp.SetLoginName( loginName );
                    temp.SetEncodingFace(row["EncodingFace"].ToString());
                    return temp;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching manager security: {ex.Message}");
                return null;
            }
        }

        public bool DeleteManagerSecurity(int id)
        {
            string cmString = "DELETE FROM ManagerSecurity WHERE Id = @Id";

            try
            {
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { id }
                );

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting manager security: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllManagerSecurities()
        {
            string cmString = "SELECT * FROM ManagerSecurity";
            DataTable dt = new DataTable();

            try
            {
                dt = ExecuteQuery(cmString);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching all manager securities: {ex.Message}");
            }

            return dt;
        }
    }
}
