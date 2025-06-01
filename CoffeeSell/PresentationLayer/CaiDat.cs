using CoffeeSell.BO;
using CoffeeSell.ObjClass;
using Guna.UI2.WinForms;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CoffeeSell
{
    public partial class CaiDat : Form
    {
        Account user;
        SettingConfig current;

        public CaiDat(Account _user)
        {
            InitializeComponent();
            this.user = _user;
            current = BOSettingConfig.Get();
            comboBox1.Items.Add("BIDV");
            comboBox1.Items.Add("Vietcombank");
            comboBox1.Items.Add("VietinBank");
            comboBox1.Items.Add("Agribank");
            comboBox1.Items.Add("Techcombank");
            comboBox1.Items.Add("MB Bank");
            comboBox1.Items.Add("Sacombank");
            comboBox1.Items.Add("ACB");
            textBox1.Text = current.GetStoreName();
            textBox2.Text = current.GetAddress();
            textBox3.Text = current.GetWifi();
            textBox4.Text = current.GetPassword();
            textBox5.Text = current.GetSlogan();
            textBox6.Text = current.GetBankName();
            textBox7.Text = current.GetBankAccountNumber();
            foreach (var item in comboBox1.Items)
            {
                if (item.ToString().ToLower() == current.GetBank())
                {
                    comboBox1.SelectedItem = item;
                    break;
                }
            }
            textBox1.TextChanged += TextBox_TextChanged;
            textBox2.TextChanged += TextBox_TextChanged;
            textBox3.TextChanged += TextBox_TextChanged;
            textBox4.TextChanged += TextBox_TextChanged;
            textBox5.TextChanged += TextBox_TextChanged;
            textBox6.TextChanged += TextBox_TextChanged;
            textBox7.TextChanged += TextBox_TextChanged;
            button1.Enabled = false;
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            SettingConfig temp = GetSetting();
            if (temp == current)
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private SettingConfig GetSetting()
        {
            SettingConfig config = new SettingConfig();

            // Map form fields to SettingConfig properties
            config.SetStoreName(textBox1.Text);               // Tên quán (Store Name)
            config.SetAddress(textBox2.Text);                // Địa chỉ (Address)
            config.SetWifi(textBox3.Text);                   // Wifi
            config.SetPassword(textBox4.Text);               // Mật khẩu (Password)
            config.SetSlogan(textBox5.Text);                 // Slogan
            config.SetBankName(textBox6.Text);               // Bank Name (same as Bank for now)
            config.SetBank(comboBox1.Text.ToLower());        // Bank (e.g., "BIDV")
            config.SetBankAccountNumber(textBox7.Text);      // Số tài khoản ngân hàng (Bank Account Number)
            return config;
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (BOSettingConfig.Update(GetSetting()))
            {
                MessageBox.Show("Lưu thành công");
                BOActivityLog.Record(user.GetLoginName(), 'E', "Đã thay đổi thông tin quán");
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
