using System;
using System.IO;
using System.Windows.Forms;

namespace BiyolojiÇarkıFelek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == null || comboBox1.Text == "")
                MessageBox.Show("İlk Önce Takım Sayısını Seçiniz!");
            else
            {
                StreamWriter yaz = new StreamWriter(Application.StartupPath + "\\takım.txt");
                yaz.WriteLine(comboBox1.Text);
                yaz.Close();

                SoruFormu x = new SoruFormu();
                x.Show();
                this.Hide();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SoruEkle x = new SoruEkle();
            x.Show();
            this.Hide();
        }
    }
}
