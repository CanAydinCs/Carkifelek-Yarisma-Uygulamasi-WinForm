using System;
using System.IO;
using System.Windows.Forms;

namespace BiyolojiÇarkıFelek
{
    public partial class SoruEkle : Form
    {
        public SoruEkle()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "" || textBox2.Text == null || textBox2.Text == "")
                MessageBox.Show("Gerekli Alanlar Boş Bırakılamaz!");
            else
            {
                StreamWriter yaz = File.AppendText(Application.StartupPath + "\\Sorular.txt");
                yaz.WriteLine(textBox2.Text + ";" + textBox1.Text);
                yaz.Close();

                textBox1.Text = "";
                textBox2.Text = "";

                MessageBox.Show("Kelime Başarı İle Eklendi");
            }
        }

        private void SoruEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
