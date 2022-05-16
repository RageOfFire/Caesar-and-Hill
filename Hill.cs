using ReaLTaiizor.Controls;
using System;
using System.Windows.Forms;

namespace Cipher
{
    public partial class Main : Form
    {
        // Mã hóa Hill

        public void MaHoaHillCipher(string text)
        {
            string str = text.ToLower();
            int i, j, sum, end;
            int[,] matrix = new int[25, 25];
            int[,] ans = new int[25, 1];

            char[] txt = str.ToCharArray();
            end = txt.Length;

            for (i = 0; i < end; i++)
            {
                txt[i] = Convert.ToChar(txt[i] - 'a');
            }

            Random rnd = new Random();
            for (i = 0; i < end; i++)
            {
                for (j = 0; j < end; j++)
                {
                    matrix[i, j] = rnd.Next();
                }

            }

            for (i = 0; i < end; i++)
            {
                sum = 0;
                for (j = 0; j < end; j++)
                {
                    sum += matrix[i, j] * (int)txt[j];
                }
                ans[i, 0] = sum;
            }

            for (i = 0; i < end; i++)
            {
                char cipher = (char)(((ans[i, 0]) % 26) + 97);
                KetQuaHill.Text += cipher;
            }
        }
        // Khi ấn nút mã hóa
        private void MaHoaHill_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(BanRoHill.Text))
            {
                CrownMessageBox.ShowWarning("Cần nhập từ khóa để mã hóa", "Mã hóa", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                BanRoHill.Focus();
            }
            else
            {
                KetQuaHill.Text = string.Empty;
                MaHoaHillCipher(BanRoHill.Text);
            }
        }
        // Khi ấn nút làm mới
        private void ResetHill_Click(object sender, EventArgs e)
        {
            ResetAlls(Hill);
        }
    }
}
