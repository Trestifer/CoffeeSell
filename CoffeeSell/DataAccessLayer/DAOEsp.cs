using CoffeeSell.ObjClass;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.DataAccessLayer
{
    internal class DAOEsp : DAO
    {
        public string CreateDeviced(ESP esp)
        {
            // Kiểm tra đầu vào ESP có hợp lệ không
            if (esp == null || string.IsNullOrEmpty(esp.DeviceId) || string.IsNullOrEmpty(esp.AssignedMAC))
            {
                return "Dữ liệu thiết bị không hợp lệ (DeviceId hoặc AssignedMAC bị thiếu).";
            }

            string cmString = @"
                INSERT INTO Esp8266 (DeviceId, AssignedMAC)
                VALUES (@DeviceId, @AssignedMAC)";

            try
            {
                // Gọi phương thức ExecuteNonQuery từ lớp DAO cơ sở
                // Nó sẽ tự động tạo, mở, đóng kết nối và xử lý SqlCommand.
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new string[] { "@DeviceId", "@AssignedMAC" },
                    new object[] { esp.DeviceId, esp.AssignedMAC }
                );

                if (rowsAffected > 0)
                {
                    return "Success"; // Chèn thành công
                }
                else
                {
                    return "Không có hàng nào được chèn. Có thể DeviceId đã tồn tại (nếu là khóa chính) hoặc lỗi khác.";
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex) // Sử dụng Microsoft.Data.SqlClient.SqlException
            {
                System.Diagnostics.Debug.WriteLine($"CreateDeviced SQL error: {sqlex.Message} (Error Code: {sqlex.Number})");
                return $"Lỗi cơ sở dữ liệu: {sqlex.Message}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateDeviced general error: {ex.Message}");
                return $"Lỗi không xác định: {ex.Message}";
            }
        }

        public string DeleteDeviced(string deviceId)
        {
            // Kiểm tra đầu vào DeviceId có hợp lệ không
            if (string.IsNullOrEmpty(deviceId))
            {
                return "Device ID không được để trống để xóa.";
            }

            string cmString = @"
                DELETE FROM Esp8266
                WHERE DeviceId = @DeviceId";

            try
            {
                // Gọi phương thức ExecuteNonQuery từ lớp DAO cơ sở để thực hiện lệnh DELETE
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new string[] { "@DeviceId" },
                    new object[] { deviceId }
                );

                if (rowsAffected > 0)
                {
                    return "Success"; // Xóa thành công
                }
                else
                {
                    // Nếu rowsAffected là 0, có nghĩa là không có bản ghi nào khớp với DeviceId này
                    return "Không tìm thấy thiết bị để xóa.";
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteDeviced SQL error: {sqlex.Message} (Error Code: {sqlex.Number})");
                return $"Lỗi cơ sở dữ liệu: {sqlex.Message}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteDeviced general error: {ex.Message}");
                return $"Lỗi không xác định: {ex.Message}";
            }
        }

        public string UpdateDeviced(ESP esp)
        {
            // Kiểm tra đầu vào
            if (esp == null || string.IsNullOrEmpty(esp.DeviceId) || string.IsNullOrEmpty(esp.AssignedMAC))
            {
                return "Dữ liệu thiết bị không hợp lệ để cập nhật (DeviceId hoặc AssignedMAC bị thiếu).";
            }

            string cmString = @"
                UPDATE ESP8266
                SET AssignedMAC = @AssignedMAC
                WHERE DeviceId = @DeviceId";

            try
            {
                // Gọi phương thức ExecuteNonQuery từ lớp DAO cơ sở
                int rowsAffected = ExecuteNonQuery(
                    cmString,
                    new string[] { "@AssignedMAC", "@DeviceId" }, // Thứ tự của tham số quan trọng khi khai báo
                    new object[] { esp.AssignedMAC, esp.DeviceId }
                );

                if (rowsAffected > 0)
                {
                    return "Success"; // Cập nhật thành công
                }
                else
                {
                    // Nếu rowsAffected là 0, có nghĩa là không có bản ghi nào khớp với DeviceId này
                    return "Không tìm thấy thiết bị để cập nhật.";
                }
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateDeviced SQL error: {sqlex.Message} (Error Code: {sqlex.Number})");
                return $"Lỗi cơ sở dữ liệu: {sqlex.Message}";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateDeviced general error: {ex.Message}");
                return $"Lỗi không xác định: {ex.Message}";
            }
        }
        public DataTable GetAllDevices()
        {
            string query = "SELECT DeviceId, AssignedMAC FROM Esp8266";
            try
            {
                DataTable dt = ExecuteQuery(query);
                return dt;
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllDevices SQL error: {sqlex.Message} (Error Code: {sqlex.Number})");
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllDevices general error: {ex.Message}");
                return null;
            }
        }
        public DataTable GetAllDeviceIds()
        {
            string query = "SELECT DeviceId FROM ESP8266";
            try
            {
                DataTable dt = ExecuteQuery(query);
                return dt;
            }
            catch (Microsoft.Data.SqlClient.SqlException sqlex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllDeviceIds SQL error: {sqlex.Message} (Error Code: {sqlex.Number})");
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllDeviceIds general error: {ex.Message}");
                return null;
            }
        }
    }
}
