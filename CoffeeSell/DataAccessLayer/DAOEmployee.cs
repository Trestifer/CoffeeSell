using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOEmployee : DAO
    {
        // Add new employee
        public bool AddEmployee(Employee emp)
        {
            string cmString = @"INSERT INTO Employee 
                                (NameEmployee, DateOfBirth, Gender, HomeAddress, PhoneNumber, AccountId)
                                VALUES 
                                (@NameEmployee, @DateOfBirth, @Gender, @HomeAddress, @PhoneNumber, @AccountId)";
            try
            {
                int result = ExecuteNonQuery(
                    cmString,
                    new string[] { "@NameEmployee", "@DateOfBirth", "@Gender", "@HomeAddress", "@PhoneNumber", "@AccountId" },
                    new object[] {
                        emp.GetNameEmployee(),
                        emp.GetDateOfBirth(),
                        emp.GetGender(),
                        emp.GetHomeAddress(),
                        emp.GetPhoneNumber(),
                        emp.GetAccountId()
                    });

                return result > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding employee: {ex.Message}");
                return false;
            }
        }

        // Update existing employee
        public bool UpdateEmployee(Employee emp)
        {
            string cmString = @"UPDATE Employee 
                                SET NameEmployee = @NameEmployee,
                                    DateOfBirth = @DateOfBirth,
                                    Gender = @Gender,
                                    HomeAddress = @HomeAddress,
                                    PhoneNumber = @PhoneNumber
                                WHERE EmployeeId = @EmployeeId";
            try
            {
                int result = ExecuteNonQuery(
                    cmString,
                    new string[] { "@NameEmployee", "@DateOfBirth", "@Gender", "@HomeAddress", "@PhoneNumber", "@EmployeeId" },
                    new object[] {
                        emp.GetNameEmployee(),
                        emp.GetDateOfBirth(),
                        emp.GetGender(),
                        emp.GetHomeAddress(),
                        emp.GetPhoneNumber(),
                        emp.GetEmployeeId()
                    });

                return result > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating employee: {ex.Message}");
                return false;
            }
        }

        // Delete employee by ID
        public bool DeleteEmployee(int employeeId)
        {
            string cmString = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
            try
            {
                int result = ExecuteNonQuery(
                    cmString,
                    new string[] { "@EmployeeId" },
                    new object[] { employeeId });

                return result > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error deleting employee: {ex.Message}");
                return false;
            }
        }
        public DataTable GetAllEmployees()
        {
            string cmString = "SELECT * FROM Employee";
            try
            {
                DataTable result = ExecuteQuery(cmString);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching employees: {ex.Message}");
                return null;
            }
        }
        public int GetMaxEmployeeId()
        {
            string cmString = "SELECT MAX(EmployeeId) FROM Employee";
            try
            {
                object result = ExecuteScalar(cmString);
                if (result != DBNull.Value && result != null)
                    return Convert.ToInt32(result);
                else
                    return 0; // Return 0 if no employee exists
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting max EmployeeId: {ex.Message}");
                return -1;
            }
        }
        public Employee GetEmployeeByAccountId(int accountId)
        {
            string cmString = "SELECT * FROM Employee WHERE AccountId = @AccountId";
            try
            {
                DataTable result = ExecuteQuery(
                    cmString,
                    new string[] { "@AccountId" },
                    new object[] { accountId });

                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];

                    Employee emp = new Employee();
                    emp.SetEmployeeId(Convert.ToInt32(row["EmployeeId"]));
                    emp.SetNameEmployee(row["NameEmployee"].ToString());
                    emp.SetDateOfBirth(Convert.ToDateTime(row["DateOfBirth"]));
                    emp.SetGender(Convert.ToBoolean(row["Gender"]));
                    emp.SetHomeAddress(row["HomeAddress"].ToString());
                    emp.SetPhoneNumber(row["PhoneNumber"].ToString());
                    emp.SetAccountId(Convert.ToInt32(row["AccountId"]));

                    return emp;
                }

                return null; // Not found
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching employee by AccountId: {ex.Message}");
                return null;
            }
        }
        public DataTable GetAllEmployeeFullData()
        {
            string cmString = @"
        SELECT 
            e.EmployeeId,
            e.NameEmployee,
            e.DateOfBirth,
            e.Gender,
            e.HomeAddress,
            e.PhoneNumber,
            e.AccountId,
            a.LoginName,
            ee.Email
        FROM Employee e
        JOIN Account a ON e.AccountId = a.AccountId
        LEFT JOIN EmployeeEmail ee ON e.EmployeeId = ee.EmployeeId";

            try
            {
                DataTable result = ExecuteQuery(cmString);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error fetching full employee data: {ex.Message}");
                return null;
            }
        }
        public DataTable SearchEmployeeByName(string keyword)
        {
            string cmString = @"
        SELECT 
            e.EmployeeId,
            e.NameEmployee,
            e.DateOfBirth,
            e.Gender,
            e.HomeAddress,
            e.PhoneNumber,
            e.AccountId,
            a.LoginName,
            ee.Email
        FROM Employee e
        JOIN Account a ON e.AccountId = a.AccountId
        LEFT JOIN EmployeeEmail ee ON e.EmployeeId = ee.EmployeeId
        WHERE e.NameEmployee LIKE @Keyword";

            try
            {
                string searchPattern = $"%{keyword}%";
                return ExecuteQuery(
                    cmString,
                    new string[] { "@Keyword" },
                    new object[] { searchPattern });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SearchEmployeeByName error: {ex.Message}");
                return new DataTable();
            }
        }


    }
}
