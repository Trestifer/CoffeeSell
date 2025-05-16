using System;
using System.Data;
using CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOManagerSecurity : DAO
    {
        public bool UpdateManagerSecurity(ManagerSecurity manager)
        {
            string cmString = "UPDATE ManagerSecurity " +
                              "SET LoginName = @LoginName, EncodingFace = @EncodingFace, Email = @Email, CurrentOTP = @CurrentOTP, OTPExpired = @OTPExpired " +
                              "WHERE Id = @Id";

            try
            {
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new string[] { "@LoginName", "@EncodingFace", "@Email", "@CurrentOTP", "@OTPExpired", "@Id" },
                    new object[]
                    {
                        manager.GetLoginName(),
                        manager.GetEncodingFace(),
                        manager.GetEmail(),
                        manager.GetCurrentOTP(),
                        manager.GetOTPExpired(),
                        manager.GetId()
                    });

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating manager security: {ex.Message}");
                return false;
            }
        }

        public int CreateManagerSecurity(ManagerSecurity manager)
        {
            string cmString = @"
                INSERT INTO ManagerSecurity (LoginName, EncodingFace, Email, CurrentOTP, OTPExpired)
                OUTPUT INSERTED.Id
                VALUES (@LoginName, @EncodingFace, @Email, @CurrentOTP, @OTPExpired)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@LoginName", "@EncodingFace", "@Email", "@CurrentOTP", "@OTPExpired" },
                    new object[]
                    {
                        manager.GetLoginName(),
                        manager.GetEncodingFace(),
                        manager.GetEmail(),
                        manager.GetCurrentOTP(),
                        manager.GetOTPExpired()
                    });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error creating manager security: {ex.Message}");
                return -1;
            }
        }

        public ManagerSecurity GetManagerSecurityByLoginName(string LoginName)
        {
            string cmString = "SELECT * FROM ManagerSecurity WHERE LoginName = @LoginName";

            try
            {
                DataTable result = ExecuteQuery(
                    cmString,
                    new string[] { "@LoginName" },
                    new object[] { LoginName }
                );

                if (result.Rows.Count == 1)
                {
                    DataRow row = result.Rows[0];
                    return new ManagerSecurity(
                        Convert.ToInt32(row["Id"]),
                        row["LoginName"].ToString(),
                        row["EncodingFace"].ToString(),
                        row["Email"].ToString(),
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
