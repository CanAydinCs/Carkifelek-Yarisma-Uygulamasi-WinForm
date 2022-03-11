using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BiyolojiÇarkıFelek
{
    public partial class SoruFormu : Form
    {
        public SoruFormu()
        {
            InitializeComponent();
        }

        int enfazlatakım, simdikiTakım, felekPuanDurumu;
        int felekPosition;
        string ozelDurum = "";
        int carkSayac;
        int secilen;
        int kelimeSayac;
        int onceki_kelime;


        List<string> cevap = new List<string>(), sorular = new List<string>();

        void KelimeBilindi()
        {
            lblTakım1ToplamPuan.Text = (Convert.ToInt32(lblTakım1ToplamPuan.Text) + Convert.ToInt32(lblTakım1BuEl.Text)).ToString();
            lblTakım2ToplamPuan.Text = (Convert.ToInt32(lblTakım2ToplamPuan.Text) + Convert.ToInt32(lblTakım2BuEl.Text)).ToString();
            lblTakım3ToplamPuan.Text = (Convert.ToInt32(lblTakım3ToplamPuan.Text) + Convert.ToInt32(lblTakım3BuEl.Text)).ToString();
            lblTakım4ToplamPuan.Text = (Convert.ToInt32(lblTakım4ToplamPuan.Text) + Convert.ToInt32(lblTakım4BuEl.Text)).ToString();
            lblTakım5ToplamPuan.Text = (Convert.ToInt32(lblTakım5ToplamPuan.Text) + Convert.ToInt32(lblTakım5BuEl.Text)).ToString();
            lblTakım6ToplamPuan.Text = (Convert.ToInt32(lblTakım6ToplamPuan.Text) + Convert.ToInt32(lblTakım6BuEl.Text)).ToString();

            switch (simdikiTakım)
            {
                case 1:
                    lblTakım1ToplamBilinenKelimeler.Text = (Convert.ToInt32(lblTakım1ToplamBilinenKelimeler.Text) + 1).ToString(); break;
                case 2:
                    lblTakım2ToplamBilinenKelimeler.Text = (Convert.ToInt32(lblTakım2ToplamBilinenKelimeler.Text) + 1).ToString(); break;
                case 3:
                    lblTakım3ToplamBilinenKelimeler.Text = (Convert.ToInt32(lblTakım3ToplamBilinenKelimeler.Text) + 1).ToString(); break;
                case 4:
                    lblTakım4ToplamBilinenKelimeler.Text = (Convert.ToInt32(lblTakım4ToplamBilinenKelimeler.Text) + 1).ToString(); break;
                case 5:
                    lblTakım5ToplamBilinenKelimeler.Text = (Convert.ToInt32(lblTakım5ToplamBilinenKelimeler.Text) + 1).ToString(); break;
                case 6:
                    lblTakım6ToplamBilinenKelimeler.Text = (Convert.ToInt32(lblTakım6ToplamBilinenKelimeler.Text) + 1).ToString(); break;
                default:
                    break;
            }

            lblTakım1BuEl.Text = "0";
            lblTakım2BuEl.Text = "0";
            lblTakım3BuEl.Text = "0";
            lblTakım4BuEl.Text = "0";
            lblTakım5BuEl.Text = "0";
            lblTakım6BuEl.Text = "0";

            MessageBox.Show("Tebrikler! " + simdikiTakım + ". Takım Kelimeyi Doğru Bildi!", "Oyun Bitti", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            pnlSoru.Controls.Clear();
        }

        void SimdikiTakımUpdate()
        {
            simdikiTakım++;
            if (simdikiTakım > enfazlatakım)
                simdikiTakım = 1;
            lblTakımSıra.Text = simdikiTakım.ToString();
        }

        private void BtnFelek_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btnFelek.Enabled = false;
            lblFelekPuan.Text = "Çark Şu An Dönüyor...";

            Random rast = new Random();
            felekPosition = rast.Next(1, 10);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            carkSayac += 1;
            if (carkSayac > 9)
                carkSayac = 0;
            pictureBox1.ImageLocation = Application.StartupPath + "\\ResimDosyaları\\felek" + carkSayac + ".jpg";

            if (felekPosition >= 100)
            {
                switch (carkSayac)
                {
                    case 0:
                        felekPuanDurumu = 200; ozelDurum = "puan"; break;
                    case 1:
                        felekPuanDurumu = 0; ozelDurum = "pas"; break;
                    case 2:
                        felekPuanDurumu = 100; ozelDurum = "puan"; break;
                    case 3:
                        felekPuanDurumu = 0; ozelDurum = "iflas"; break;
                    case 4:
                        felekPuanDurumu = 700; ozelDurum = "puan"; break;
                    case 5:
                        felekPuanDurumu = 0; ozelDurum = "iflas"; break;
                    case 6:
                        felekPuanDurumu = 300; ozelDurum = "puan"; break;
                    case 7:
                        felekPuanDurumu = 200; ozelDurum = "puan"; break;
                    case 8:
                        felekPuanDurumu = 0; ozelDurum = "pas"; break;
                    case 9:
                        felekPuanDurumu = 400; ozelDurum = "puan"; break;
                }

                lblFelekPuan.Text = felekPuanDurumu.ToString();

                switch (ozelDurum)
                {
                    case "puan":
                        lblFelekPuan.Text = felekPuanDurumu.ToString();
                        btnAra.Enabled = true;
                        btnKelimeTahmin.Enabled = true;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        break;
                    case "pas":
                        SimdikiTakımUpdate();
                        btnFelek.Enabled = true;
                        break;
                    case "iflas":
                        btnFelek.Enabled = true;

                        switch (simdikiTakım)
                        {
                            case 1:
                                lblTakım1BuEl.Text = "0"; break;
                            case 2:
                                lblTakım2BuEl.Text = "0"; break;
                            case 3:
                                lblTakım3BuEl.Text = "0"; break;
                            case 4:
                                lblTakım4BuEl.Text = "0"; break;
                            case 5:
                                lblTakım5BuEl.Text = "0"; break;
                            case 6:
                                lblTakım6BuEl.Text = "0"; break;
                            default:
                                break;
                        }

                        SimdikiTakımUpdate(); break;
                }

                timer1.Enabled = false;
            }

            Random rastgele = new Random();

            timer1.Interval = felekPosition * 10;
            felekPosition += rastgele.Next(1, 15);

        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "")
                MessageBox.Show("Yukarıdaki Boş Alana Bir Değer Giriniz!");
            else
            {
                bool bilindi = false;
                bool bitti = true;
                for (int i = 0; i < cevap[secilen].Length; i++)
                {
                    if (cevap[secilen][i].ToString().ToUpper() == textBox1.Text.ToUpper())
                    {
                        kelimeSayac++;

                        bitti = (cevap[secilen].Length == kelimeSayac);
                        

                         switch (simdikiTakım)
                        {
                            case 1:
                                lblTakım1BuEl.Text = (Convert.ToInt32(lblTakım1BuEl.Text) + felekPuanDurumu).ToString();
                                break;
                            case 2:
                                lblTakım2BuEl.Text = (Convert.ToInt32(lblTakım2BuEl.Text) + felekPuanDurumu).ToString();
                                break;
                            case 3:
                                lblTakım3BuEl.Text = (Convert.ToInt32(lblTakım3BuEl.Text) + felekPuanDurumu).ToString();
                                break;
                            case 4:
                                lblTakım4BuEl.Text = (Convert.ToInt32(lblTakım4BuEl.Text) + felekPuanDurumu).ToString();
                                break;
                            case 5:
                                lblTakım5BuEl.Text = (Convert.ToInt32(lblTakım5BuEl.Text) + felekPuanDurumu).ToString();
                                break;
                            case 6:
                                lblTakım6BuEl.Text = (Convert.ToInt32(lblTakım6BuEl.Text) + felekPuanDurumu).ToString();
                                break;
                            default:
                                break;
                        }

                        Label lbl1 = new Label();
                        lbl1.Text = cevap[secilen][i].ToString(); ;
                        lbl1.Visible = true;
                        lbl1.BackColor = Color.White;
                        lbl1.ForeColor = Color.Black;
                        lbl1.Width = 50;
                        lbl1.Height = 150;
                        lbl1.Font = new Font(lbl1.Font.FontFamily, 25);
                        Point nokta1 = new Point(i * 100 + 25, 25);
                        lbl1.Location = nokta1;
                        pnlSoru.Controls.Add(lbl1);

                        if (bitti)
                        {
                            KelimeBilindi();
                            bilindi = true;
                        }
                    }
                }

                textBox1.Text = "";
                textBox1.Enabled = false;
                textBox2.Text = "";
                textBox2.Enabled = false;
                btnAra.Enabled = false;
                btnKelimeTahmin.Enabled = false;
                if (bilindi)
                    btnDegistir.Enabled = true;
                else
                    btnFelek.Enabled = true;

                SimdikiTakımUpdate();
            }
        }

        private void BtnKelimeTahmin_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == null || textBox2.Text == "")
                MessageBox.Show("Lütfen Bir Kelime Giriniz!");
            else
            {
                if (textBox2.Text.ToUpper() == cevap[secilen].ToUpper())
                {
                    KelimeBilindi();
                    btnDegistir.Enabled = true;
                }
                else
                {
                    MessageBox.Show(". Takım Kelimeyi Yanlış Tahmin Etti!");
                    btnFelek.Enabled = true;
                }
                SimdikiTakımUpdate();

                textBox2.Text = "";
                textBox1.Text = "";
                textBox2.Enabled = false;
                textBox1.Enabled = false;
                btnKelimeTahmin.Enabled = false;
                btnAra.Enabled = false;
            }
        }

        private void BtnDegistir_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            label8.Visible = true;
            lblTakımSıra.Visible = true;

            Random rast = new Random();
            while (secilen == onceki_kelime)
                secilen = rast.Next(0, cevap.Count);
            int kelimeUzunluk = cevap[secilen].Length;

            pnlSoru.Visible = true;
            pnlSoru.Width = 100 * kelimeUzunluk;

            kelimeSayac = 0;
            
            foreach (char i in cevap[secilen])
            {
                if (i == ' ')
                    kelimeSayac++;
            }

            for (int i = 1; i < kelimeUzunluk; i++)
            {
                Label lbl1 = new Label();
                lbl1.Width = 5;
                lbl1.Height = 200;
                Point nokta1 = new Point(i * 100, 0);
                lbl1.Location = nokta1;
                lbl1.Visible = true;
                lbl1.Text = "";
                lbl1.BackColor = Color.Black;
                pnlSoru.Controls.Add(lbl1);
            }

            lblInformations.Text = sorular[secilen];

            btnDegistir.Enabled = false;
            btnFelek.Enabled = true;
            onceki_kelime = secilen;
        }

        private void SoruFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void SoruFormu_Load(object sender, EventArgs e)
        {
            StreamReader oku = new StreamReader(Application.StartupPath + "\\takım.txt");
            enfazlatakım = Convert.ToInt32(oku.ReadLine());
            oku.Close();

            int[] yoket = new int[6 - enfazlatakım];

            for (int i = 6; i > enfazlatakım; i--)
                yoket[6 - i] = i;

            foreach (Control item in panel1.Controls)
                if (item.Name.StartsWith("pnl"))
                    foreach (int i in yoket)
                        if (item.Name.EndsWith(i.ToString()))
                            foreach (Control it in item.Controls)
                                it.Visible = false;

            pictureBox1.ImageLocation = Application.StartupPath + "\\ResimDosyaları\\felek0.jpg";
            felekPuanDurumu = 200;
            simdikiTakım = 1;
            carkSayac = 0;

            StreamReader sorularıOku = new StreamReader(Application.StartupPath + "\\Sorular.txt");
            string satir = sorularıOku.ReadLine();
            List<string> anlik = new List<string>();
            while (satir != null && satir != "")
            {
                anlik.Add(satir);
                satir = sorularıOku.ReadLine();
            }
            sorularıOku.Close();

            foreach (string i in anlik)
            {
                cevap.Add(i.Split(';')[0]);
                sorular.Add(i.Split(';')[1]);
            }
        }
    }
}
