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
                Console.WriteLine($"Error updating employee email: {ex.Message}");
                return false;
            }
        }

        public int CreateEmployeeEmail(EmployeeEmail emailInfo)
        {
            string cmString = @"
                INSERT INTO EmployeeEmail (EmployeeId, Email, IsConfirmed, CurrentOTP, OTPExpired)
                OUTPUT INSERTED.EmployeeId
                VALUES (@EmployeeId, @Email, @IsConfirmed, @CurrentOTP, @OTPExpired)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@EmployeeId", "@Email", "@IsConfirmed", "@CurrentOTP", "@OTPExpired" },
                    new object[]
                    {
                        emailInfo.GetEmployeeId(),
                        emailInfo.GetEmail(),
                        emailInfo.GetIsConfirmed(),
                        emailInfo.GetCurrentOTP(),
                        emailInfo.GetOTPExpired()
                    });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating employee email: {ex.Message}");
                return -1;
            }
        }

        public EmployeeEmail GetEmployeeEmailById(int employeeId)
        {
            string cmString = "SELECT * FROM EmployeeEmail WHERE EmployeeId = @EmployeeId";

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
                Console.WriteLine($"Error fetching employee email: {ex.Message}");
                return null;
            }
        }

        public bool DeleteEmployeeEmail(int employeeId)
        {
            string cmString = "DELETE FROM EmployeeEmail WHERE EmployeeId = @EmployeeId";

            try
            {
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new string[] { "@EmployeeId" },
                    new object[] { employeeId }
                );

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting employee email: {ex.Message}");
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
                Console.WriteLine($"Error fetching all employee emails: {ex.Message}");
            }

            return dt;
        }
    }
}
