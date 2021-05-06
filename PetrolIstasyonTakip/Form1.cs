using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetrolIstasyonTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {}

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //kullanılacak değişkenler formload üzerine tanımlanır.
        //depodaki yakıtlar D_ ile yazıldı
        //depoya eklenen yakıtlar E_ ile yazıldı
        //fiyat yakıtlar F_ile yazıldı
        //satılan yakıtlar S_ile yazıldı

        private double D_benzin95 = 0;
        private double D_benzin97 = 0;
        private double D_dizel = 0;
        private double D_euroDizel = 0;
        private double D_lpg = 0;

        private double E_benzin95 = 0;
        private double E_benzin97 = 0;
        private double E_dizel = 0;
        private double E_euroDizel = 0;
        private double E_lpg = 0;

        private double F_benzin95 = 0;
        private double F_benzin97 = 0;
        private double F_dizel = 0;
        private double F_euroDizel = 0;
        private double F_lpg = 0;

        private double S_benzin95 = 0;
        private double S_benzin97 = 0;
        private double S_dizel = 0;
        private double S_euroDizel = 0;
        private double S_lpg = 0;

        private string[] depoBilgileri;
        private string[] fiyatBilgileri;

        private void txtDepoOku()
        {
            //Application.startup bin/debug klasörü demektir.
            //depo.txt dosyasındaki tüm satırları oku demek.
            depoBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            D_benzin95 = Convert.ToDouble(depoBilgileri[0]);
            D_benzin97 = Convert.ToDouble(depoBilgileri[1]);
            D_dizel = Convert.ToDouble(depoBilgileri[2]);
            D_euroDizel = Convert.ToDouble(depoBilgileri[3]);
            D_lpg = Convert.ToDouble(depoBilgileri[4]);

        }
        private void txtDepoYaz()
        {
            label6.Text = D_benzin95.ToString("N");
            label7.Text = D_benzin97.ToString("N");
            label8.Text = D_dizel.ToString("N");
            label9.Text = D_euroDizel.ToString("N");
            label10.Text = D_lpg.ToString("N");

        }

        private void txtFiyatOku()
        {
            fiyatBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            F_benzin95 =Convert.ToDouble(fiyatBilgileri[0]);
            F_benzin97 = Convert.ToDouble(fiyatBilgileri[1]);
            F_dizel = Convert.ToDouble(fiyatBilgileri[2]);
            F_euroDizel = Convert.ToDouble(fiyatBilgileri[3]);
            F_lpg = Convert.ToDouble(fiyatBilgileri[4]);


        }
        private void txtFiyatYaz()
        {
            label15.Text = F_benzin95.ToString("N");
            label16.Text = F_benzin97.ToString("N");
            label17.Text = F_dizel.ToString("N");
            label18.Text = F_euroDizel.ToString("N");
            label19.Text = F_lpg.ToString("N");

        }

        private void progressBarGuncelle()
        {
            progressBar1.Value = Convert.ToInt16(D_benzin95);
            progressBar2.Value = Convert.ToInt16(D_benzin97);
            progressBar3.Value = Convert.ToInt16(D_dizel);
            progressBar4.Value = Convert.ToInt16(D_euroDizel);
            progressBar5.Value = Convert.ToInt16(D_lpg);

        }

        private void numericUpDownValue()
        {   //sayılacak yakıt miktarı depodaki yakıt miktarını geçmesin...

            numericUpDown1.Maximum = decimal.Parse(D_benzin95.ToString());  //decimal olarak tutulur
            numericUpDown2.Maximum = decimal.Parse(D_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(D_dizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(D_euroDizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(D_lpg.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "AKARYAKIT OTOMASYONU";     //formun text başlığını değiştirir

            progressBar1.Maximum = 1000;            //progress bar kaça bölünecek.
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;
            
            txtDepoOku();
            txtDepoYaz();

            txtFiyatOku();
            txtFiyatYaz();

            progressBarGuncelle();

            numericUpDownValue();

            //combobox doldurma işlemi
            //dropdown style özelliğini list yaptık. dışardan veri girişi yapılamasın diye.
            string[] yakitTurleri =
            {
                "Benzin(95)",
                "Benzin(97)",
                "Dizel",
                "EuroDizel",
                "Lpg"
            };
            comboBox1.Items.AddRange(yakitTurleri);

            //numericupdownlar pasif olsun. comboboxtan seçildiğinde aktif olsun.
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            //virgülden sonra iki basamak görünsün
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;
            //kaçar kaçar artacak_hata almamak için sonuna M koyulur.
            numericUpDown1.Increment = 0.1M;
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;
            //dışarıdan veri girilemesin.
            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {   //hata yakalama yapısı. try bölümü çalışmazsa catch çalışsın
            try
            {
                E_benzin95 = Convert.ToDouble(textBox1.Text);       //textbox a girilen değer eklenen benzindir
                if (1000<(D_benzin95+E_benzin95) || E_benzin95<=0)  //depo ile eklenenin toplamı 1000den fazla olamaz
                {
                    textBox1.Text = "HATA!";
                }else
                {
                    depoBilgileri[0] = Convert.ToString(D_benzin95 + E_benzin95);   //işlem başarılı ise txtyi güncelle
                }
            }
            catch (Exception)
            {
                textBox1.Text = "HATA!";    //yukarıdaki kritelerin hiçbiri olmazsa HATA mesajı ver
                
            }

            try
            {
                E_benzin97 = Convert.ToDouble(textBox2.Text);       //textbox a girilen değer eklenen benzindir
                if (1000 < (D_benzin97 + E_benzin97) || E_benzin97 <= 0)  //depo ile eklenenin toplamı 1000den fazla olamaz
                {
                    textBox2.Text = "HATA!";
                }
                else
                {
                    depoBilgileri[1] = Convert.ToString(D_benzin97 + E_benzin97);   //işlem başarılı ise txtyi güncelle
                }
            }
            catch (Exception)
            {
                textBox2.Text = "HATA!";    //yukarıdaki kritelerin hiçbiri olmazsa HATA mesajı ver

            }

            try
            {
                E_dizel = Convert.ToDouble(textBox3.Text);       //textbox a girilen değer eklenen benzindir
                if (1000 < (D_dizel + E_dizel) || E_dizel <= 0)  //depo ile eklenenin toplamı 1000den fazla olamaz
                {
                    textBox3.Text = "HATA!";
                }
                else
                {
                    depoBilgileri[2] = Convert.ToString(D_dizel + E_dizel);   //işlem başarılı ise txtyi güncelle
                }
            }
            catch (Exception)
            {
                textBox3.Text = "HATA!";    //yukarıdaki kritelerin hiçbiri olmazsa HATA mesajı ver

            }

            try
            {
                E_euroDizel = Convert.ToDouble(textBox4.Text);       //textbox a girilen değer eklenen benzindir
                if (1000 < (D_euroDizel + E_benzin95) || E_euroDizel <= 0)  //depo ile eklenenin toplamı 1000den fazla olamaz
                {
                    textBox4.Text = "HATA!";
                }
                else
                {
                    depoBilgileri[3] = Convert.ToString(D_euroDizel + E_euroDizel);   //işlem başarılı ise txtyi güncelle
                }
            }
            catch (Exception)
            {
                textBox4.Text = "HATA!";    //yukarıdaki kritelerin hiçbiri olmazsa HATA mesajı ver

            }

            try
            {
                E_lpg = Convert.ToDouble(textBox5.Text);       //textbox a girilen değer eklenen benzindir
                if (1000 < (D_lpg + E_lpg) || E_benzin95 <= 0)  //depo ile eklenenin toplamı 1000den fazla olamaz
                {
                    textBox5.Text = "HATA!";
                }
                else
                {
                    depoBilgileri[4] = Convert.ToString(D_lpg + E_lpg);   //işlem başarılı ise txtyi güncelle
                }
            }
            catch (Exception)
            {
                textBox5.Text = "HATA!";    //yukarıdaki kritelerin hiçbiri olmazsa HATA mesajı ver

            }

            //yukarıdaki yeni değerler depo.txt içerisine yazılır
            System.IO.File.WriteAllLines(Application.StartupPath+"\\depo.txt",depoBilgileri);
            txtDepoOku();           //son güncel veriler düzenlenmeli
            txtDepoYaz();           //o yüzden metotlar tekrar çalıştırılır.
            progressBarGuncelle();
            numericUpDownValue();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                F_benzin95 = F_benzin95 + (F_benzin95 * Convert.ToDouble(textBox10.Text) / 100);
                fiyatBilgileri[0] = Convert.ToString(F_benzin95);
                textBox10.Text = "Güncellendi!";
            }
            catch (Exception)
            {
                textBox10.Text = "Hata!";
            }

            try
            {
                F_benzin97 = F_benzin97 + (F_benzin97 * Convert.ToDouble(textBox8.Text) / 100);
                fiyatBilgileri[0] = Convert.ToString(F_benzin97);
                textBox8.Text = "Güncellendi!";
            }
            catch (Exception)
            {
                textBox8.Text = "Hata!";
            }

            try
            {
                F_dizel = F_dizel + (F_dizel * Convert.ToDouble(textBox9.Text) / 100);
                fiyatBilgileri[0] = Convert.ToString(F_dizel);
                textBox9.Text = "Güncellendi!";
            }
            catch (Exception)
            {
                textBox9.Text = "Hata!";
            }

            try
            {
                F_euroDizel = F_euroDizel + (F_euroDizel * Convert.ToDouble(textBox7.Text) / 100);
                fiyatBilgileri[0] = Convert.ToString(F_euroDizel);
                textBox7.Text = "Güncellendi!";
            }
            catch (Exception)
            {
                textBox7.Text = "Hata!";
            }

            try
            {
                F_lpg = F_lpg + (F_benzin95 * Convert.ToDouble(textBox6.Text) / 100);
                fiyatBilgileri[0] = Convert.ToString(F_lpg);
                textBox6.Text = "Güncellendi!";
            }
            catch (Exception)
            {
                textBox6.Text = "Hata!";
            }

            //fiyatBilgileri dizisinin elemanlarını txt ye yaz
            System.IO.File.WriteAllLines(Application.StartupPath+"\\fiyat.txt",fiyatBilgileri);
            txtFiyatYaz();
            txtFiyatYaz();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text== "Benzin(95)")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;

            }

            else if (comboBox1.Text == "Benzin(97)")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;

            }

            else if (comboBox1.Text == "Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;

            }

            else if (comboBox1.Text == "EuroDizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;

            }

            else if (comboBox1.Text == "Lpg")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;

            }

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label30.Text = "______";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //double a dönüştürme işlemi_decimali önce stringe sonra double dönüştürebiliriz
            S_benzin95 = double.Parse(numericUpDown1.Value.ToString());
            S_benzin97 = double.Parse(numericUpDown2.Value.ToString());
            S_dizel = double.Parse(numericUpDown3.Value.ToString());
            S_euroDizel = double.Parse(numericUpDown4.Value.ToString());
            S_lpg = double.Parse(numericUpDown5.Value.ToString());

            if (numericUpDown1.Enabled == true)
            {
                D_benzin95 = D_benzin95 - S_benzin95;
                label30.Text = Convert.ToString(S_benzin95 * F_benzin95);
            }
            else if (numericUpDown2.Enabled == true)
            {
                D_benzin97 = D_benzin97 - S_benzin97;
                label30.Text = Convert.ToString(S_benzin97 * F_benzin97);
            }
            else if (numericUpDown3.Enabled == true)
            {
                D_dizel = D_dizel - S_dizel;
                label30.Text = Convert.ToString(S_dizel * F_dizel);
            }
            else if (numericUpDown4.Enabled == true)
            {
                D_euroDizel = D_euroDizel - S_euroDizel;
                label30.Text = Convert.ToString(S_euroDizel * F_euroDizel);
            }
            else if (numericUpDown5.Enabled == true)
            {
                D_lpg = D_lpg - S_lpg;
                label30.Text = Convert.ToString(S_lpg * F_lpg);
            }

            depoBilgileri[0] = Convert.ToString(D_benzin95);
            depoBilgileri[1] = Convert.ToString(D_benzin97);
            depoBilgileri[2] = Convert.ToString(D_dizel);
            depoBilgileri[3] = Convert.ToString(D_euroDizel);
            depoBilgileri[4] = Convert.ToString(D_lpg);

            System.IO.File.WriteAllLines(Application.StartupPath+"\\depo.txt",depoBilgileri);

            txtDepoOku();
            txtDepoYaz();
            progressBarGuncelle();
            numericUpDownValue();

            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;


        }
    }
}
