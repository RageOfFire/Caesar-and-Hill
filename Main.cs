using ReaLTaiizor.Controls;
using System;
using System.Windows.Forms;
using TabPage = System.Windows.Forms.TabPage;

namespace Cipher
{
    public partial class Main : Form
    {
        int value;
        public Main()
        {
            InitializeComponent();
        }

        // Nút làm mới
        public static void ResetAlls(TabPage page)
        {
            foreach (Control control in page.Controls)
            {
                if (control is DungeonTextBox textBox)
                {
                    textBox.Text = string.Empty;
                }

                if (control is DungeonRichTextBox richTextBox)
                {
                    richTextBox.Text = string.Empty;
                }
            }
        }
        // Mã hóa Caesar
        public static char Ma(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {
                return ch;
            }
            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }
        // Thao tác mã hóa
        public static string MaHoa(string input, int key)
        {
            string output = string.Empty;
            foreach (char ch in input)
                output += Ma(ch, key);
            return output;
        }
        //Thao tác giải mã
        public static string GiaiMa(string input, int key)
        {
            return MaHoa(input, 26 - key);
        }
        // Khi ấn nút mã hóa
        private void MaHoaCaesar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(BanRoCaesar.Text))
            {
                CrownMessageBox.ShowWarning("Cần nhập từ khóa để mã hóa hoặc giải mã", "Mã hóa", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                BanRoCaesar.Focus();
            }
            else if(string.IsNullOrWhiteSpace(KhoaCaesar.Text))
            {
                CrownMessageBox.ShowWarning("Cần nhập khóa để mã hóa hoặc giải mã", "Mã hóa", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                KhoaCaesar.Focus();
            }
            else if (!int.TryParse(KhoaCaesar.Text, out value))
            {
                CrownMessageBox.ShowWarning("Khóa phải là số", "Mã hóa", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                KhoaCaesar.Focus();
            }
            else if (Convert.ToInt32(KhoaCaesar.Text) > 25 || Convert.ToInt32(KhoaCaesar.Text) < 1)
            {
                CrownMessageBox.ShowWarning("Khóa vướt quá giới hạn quy định 1-25", "Mã hóa", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                KhoaCaesar.Focus();
            }
            else
            {
                KetQuaCaesar.Text = MaHoa(BanRoCaesar.Text, Convert.ToInt32(KhoaCaesar.Text));
            }
        }

        // Khi ấn nút giải mã
        private void GiaiMaCaesar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BanRoCaesar.Text))
            {
                CrownMessageBox.ShowWarning("Cần nhập từ khóa để mã hóa hoặc giải mã", "Mã hóa", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                BanRoCaesar.Focus();
            }
            else if (string.IsNullOrWhiteSpace(KhoaCaesar.Text))
            {
                CrownMessageBox.ShowWarning("Cần nhập khóa để mã hóa hoặc giải mã", "Mã hóa", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                KhoaCaesar.Focus();
            }
            else if (!int.TryParse(KhoaCaesar.Text, out value))
            {
                CrownMessageBox.ShowWarning("Khóa phải là số", "Mã hóa", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                KhoaCaesar.Focus();
            }
            else if (Convert.ToInt32(KhoaCaesar.Text) > 25 || Convert.ToInt32(KhoaCaesar.Text) < 1)
            {
                CrownMessageBox.ShowWarning("Khóa vướt quá giới hạn quy định 1-25", "Mã hóa", ReaLTaiizor.Enum.Crown.DialogButton.Ok);
                KhoaCaesar.Focus();
            }
            else
            {
                KetQuaCaesar.Text = GiaiMa(BanRoCaesar.Text, Convert.ToInt32(KhoaCaesar.Text));
            }
        }

        // Khi ấn nút làm mới
        private void ResetCaesar_Click(object sender, EventArgs e)
        {
            ResetAlls(Caesar);
        }
    }
}
