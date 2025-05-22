using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CoffeeSell.ObjClass;
using static QRCoder.PayloadGenerator;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace CoffeeSell.DataAccessLayer
{
    public class DAOSettingConfig : DAO
    {
        public bool UpdateSettingConfig(SettingConfig config)
        {
            string cmString = @"
                UPDATE SettingConfig
                SET store_name = @StoreName,
                    address = @Address,
                    wifi = @Wifi,
                    password = @Password,
                    slogan = @Slogan,
                    bank_name = @BankName,
                    bank = @Bank,
                    bank_account_number = @BankAccountNumber";

            try
            {
                int rows = ExecuteNonQuery(
                    cmString,
                    new string[] { "@StoreName", "@Address", "@Wifi", "@Password", "@Slogan", "@BankName", "@Bank", "@BankAccountNumber" },
                    new object[]
                    {
                        config.GetStoreName(),
                        config.GetAddress(),
                        config.GetWifi(),
                        config.GetPassword(),
                        config.GetSlogan(),
                        config.GetBankName(),
                        config.GetBank(),
                        config.GetBankAccountNumber()
                    });

                return rows > 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateSettingConfig error: {ex.Message}");
                return false;
            }
        }

        public SettingConfig GetSettingConfig()
        {
            string cmString = "SELECT * FROM SettingConfig";

            try
            {
                DataTable dt = ExecuteQuery(cmString);

                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    SettingConfig config = new SettingConfig();
                    config.SetStoreName(r["store_name"].ToString());
                    config.SetAddress(r["address"].ToString());
                    config.SetWifi(r["wifi"].ToString());
                    config.SetPassword(r["password"].ToString());
                    config.SetSlogan(r["slogan"].ToString());
                    config.SetBankName(r["bank_name"].ToString());
                    config.SetBank(r["bank"].ToString());
                    config.SetBankAccountNumber(r["bank_account_number"].ToString());

                    return config;
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetSettingConfig error: {ex.Message}");
                return null;
            }
        }
    }
}