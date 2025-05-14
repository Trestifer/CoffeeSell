using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;
using CoffeeSell.ObjClass.CoffeeSell.ObjClass;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOBillInfo : DAO
    {
        public int CreateBillInfo(BillInfo billInfo)
        {
            string cmString = @"
    INSERT INTO BillInfo (IdBill, IdFood, Quantity, foodPrice)
    OUTPUT INSERTED.Id
    VALUES (@BillId, @FoodId, @Quantity, @FoodPrice)";

            try
            {
                object result = ExecuteScalar(
                    cmString,
                    new string[] { "@BillId", "@FoodId", "@Quantity", "@FoodPrice" },
                    new object[]
                    {
                        billInfo.GetIdBill(),
                        billInfo.GetIdFood(),
                        billInfo.GetQuantity(),
                        billInfo.GetFoodPrice()
                    });

                return result != null ? Convert.ToInt32(result) : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateBillInfo error: {ex.Message}");
                return -1;
            }
        }

        public bool UpdateBillInfo(BillInfo billInfo)
        {
            string cmString = @"
                        UPDATE BillInfo
                        SET IdBill = @BillId,
                            IdFood = @FoodId,
                            Quantity = @Quantity,
                            foodPrice = @FoodPrice
                        WHERE Id = @Id";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new string[] { "@BillId", "@FoodId", "@Quantity", "@FoodPrice", "@Id" },
                    new object[]
                    {
                        billInfo.GetIdBill(),
                        billInfo.GetIdFood(),
                        billInfo.GetQuantity(),
                        billInfo.GetFoodPrice(),
                        billInfo.GetId()
                    });

                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateBillInfo error: {ex.Message}");
                return false;
            }
        }

        public bool DeleteBillInfo(int id)
        {
            string cmString = "DELETE FROM BillInfo WHERE Id = @Id";

            try
            {
                return ExecuteNonQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { id }) > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteBillInfo error: {ex.Message}");
                return false;
            }
        }

        public DataTable GetAllBillInfo()
        {
            try
            {
                return ExecuteQuery("SELECT * FROM BillInfo");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllBillInfo error: {ex.Message}");
                return new DataTable();
            }
        }

        public BillInfo GetBillInfoById(int id)
        {
            string cmString = "SELECT * FROM BillInfo WHERE Id = @Id";

            try
            {
                DataTable dt = ExecuteQuery(
                    cmString,
                    new string[] { "@Id" },
                    new object[] { id });

                if (dt.Rows.Count == 1)
                {
                    DataRow r = dt.Rows[0];
                    BillInfo bi = new BillInfo();
                    bi.SetId(Convert.ToInt32(r["Id"]));
                    bi.SetIdBill(Convert.ToInt32(r["IdBill"]));
                    bi.SetIdFood(Convert.ToInt32(r["IdFood"]));
                    bi.SetQuantity(Convert.ToInt32(r["Quantity"]));
                    bi.SetFoodPrice(Convert.ToDecimal(r["foodPrice"]));
                    return bi;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetBillInfoById error: {ex.Message}");
                return null;
            }
        }

        public int GetMaxBillInfoId()
        {
            try
            {
                object result = ExecuteScalar("SELECT ISNULL(MAX(Id), 0) FROM BillInfo");
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetMaxBillInfoId error: {ex.Message}");
                return -1;
            }
        }
        // Phương thức mới: Lấy BillInfo theo ngày, sửa lại để tham chiếu đúng DateCheckIn
        public DataTable GetBillInfoByDate(DateTime date)
        {
            string cmString = @"
                SELECT bi.* 
                FROM BillInfo bi
                JOIN Bill b ON bi.IdBill = b.BillId
                WHERE CAST(b.DateCheckIn AS DATE) = @Date";

            try
            {
                return ExecuteQuery(
                    cmString,
                    new string[] { "@Date" },
                    new object[] { date.Date }); // Đảm bảo chỉ lấy phần ngày
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetBillInfoByDate error: {ex.Message}");
                return new DataTable();
            }
        }
    }
}
