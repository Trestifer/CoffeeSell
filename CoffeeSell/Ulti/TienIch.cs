using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeSell.Ulti
{
    internal class TienIch
    {
        private ErrorProvider errorProvider = new ErrorProvider();

        
        
        // Chỉ cho nhập số nguyên
        public void NhapInt(TextBox txt, int min = int.MinValue, int max = int.MaxValue)
        {
            if (!long.TryParse(txt.Text, out long value))
            {
                txt.Text = "";
            }
            else
            {
                if (value < min) txt.Text = min.ToString();
                if (value > max) txt.Text = max.ToString();
            }
            txt.SelectionStart = txt.Text.Length;
        }

        // Chỉ cho nhập số thực (float/double)
        public void NhapFloat(TextBox txt, float min = float.MinValue, float max = float.MaxValue)
        {
            if (!double.TryParse(txt.Text, out double value))
            {
                txt.Text = "";
            }
            else
            {
                if (value < min) txt.Text = min.ToString();
                if (value > max) txt.Text = max.ToString();
            }
            txt.SelectionStart = txt.Text.Length;
        }

        // Chỉ cho nhập chữ cái (không số và ký tự đặc biệt)
        public void NhapChuAlphabet(TextBox txt, int max = 255)
        {
            if (txt.Text.Length == 0) return;

            char last = txt.Text[^1];
            if ((!char.IsLetter(last) && last != ' ' && last != '\'') || txt.Text.Length > max)
            {
                txt.Text = txt.Text[..^1]; // bỏ ký tự cuối
                txt.SelectionStart = txt.Text.Length;
            }
        }

        // Giới hạn độ dài chuỗi, không kiểm tra nội dung
        public void NhapChu(TextBox txt, int max = 255)
        {
            if (txt.Text.Length > max)
            {
                txt.Text = txt.Text[..^1];
                txt.SelectionStart = txt.Text.Length;
            }
        }

        // Chỉ cho nhập số, không ký tự
        public void NhapSo(TextBox txt, int max = 255)
        {
            if (txt.Text.Length == 0) return;

            char last = txt.Text[^1];
            if (!char.IsDigit(last) || txt.Text.Length > max)
            {
                txt.Text = txt.Text[..^1];
                txt.SelectionStart = txt.Text.Length;
            }
        }
    }
}

