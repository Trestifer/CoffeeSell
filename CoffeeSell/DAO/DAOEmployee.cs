using CoffeeSell.ObjClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.DAO
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
                Console.WriteLine($"Error adding employee: {ex.Message}");
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
                Console.WriteLine($"Error updating employee: {ex.Message}");
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
                Console.WriteLine($"Error deleting employee: {ex.Message}");
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
                Console.WriteLine($"Error fetching employees: {ex.Message}");
                return null;
            }
        }
    }
}
