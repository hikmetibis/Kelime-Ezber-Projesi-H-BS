using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Save_My_Data.addUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Save_My_Data.Controls
{
    public partial class testet : UserControl
    {
        private readonly Settings pub = new Settings();
        private MySqlConnection db;
        private MySqlCommand cmd;
        private int sure = 90;
        private int kelime = 0;
        private bool ingilizceMi = true; // Default olarak İngilizce kelime tercih edilsin
        private bool testBasladi = false; // Testin başlayıp başlamadığını takip etmek için bir değişken ekliyoruz
        private List<string> words = new List<string>();
        private List<string> translations = new List<string>();
        private int currentWordIndex = 0;
        private string cevap;
        private int kategori;
        private int dogruSayisi = 0;
        private int yanlisSayisi = 0;
        private int pasHakki = 3;

        public event EventHandler CloseFormRequested;
        public testet()
        {
            InitializeComponent();
            db = new MySqlConnection(pub.__DBString);
        }
        private void kelimegetir(int kategori, int kelimeSayisi)
        {
            try
            {
                db.Open();
                string columnName = ingilizceMi ? "En" : "Tr"; // Hangi dilde kelime sorgulanacaksa ona göre sütun adını belirle
                string query = $"SELECT En, Tr FROM Kelimeler WHERE Kategori = @kategori ORDER BY RAND() LIMIT @kelimeSayisi";
                cmd = new MySqlCommand(query, db);
                cmd.Parameters.AddWithValue("@kategori", kategori);
                cmd.Parameters.AddWithValue("@kelimeSayisi", kelimeSayisi);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    words.Clear();
                    translations.Clear();

                    while (reader.Read())
                    {
                        words.Add(reader[ingilizceMi ? "En" : "Tr"].ToString());
                        translations.Add(reader[ingilizceMi ? "Tr" : "En"].ToString()); // Çeviri, seçilen dilin tersi olacak şekilde alınıyor
                    }
                }

                ShowWord();
                db.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanından veri çekerken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowWord()
        {
            if (words.Count > 0 && currentWordIndex < words.Count)
            {
                TxtEN.Text = words[currentWordIndex];
                cevap = translations[currentWordIndex];
                label4.Text = "Kategori: " + GetKategoriAdi(kategori);
            }
            else
            {
                MessageBox.Show("Kelimeniz kalmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private string GetKategoriAdi(int kategori)
        {
            switch (kategori)
            {
                case 1:
                    return "İş Kelimeleri";
                case 2:
                    return "Duygu ve Hisler";
                default:
                    return "Bilinmeyen Kategori";
            }
        }
        private void ResetLabels()
        {
            label2.Visible = true;
            label1.Visible = true;
            label1.Text = "İngilizce";
            label2.Text = "Türkçe";
        }

        private void ResetLabelsAndTimer()
        {
            ResetLabels();
            timer1.Stop();
            sure = 90;
            LblSüre.Text = sure.ToString();
            BtnBaslat.Enabled = true;
            BtnPas.Enabled = false;
            TxtTR.Enabled = false;
        }
        private void ShowStatistics()
        {
            // İstatistikleri göstermek için istatistik kullanıcı denetimi oluştur
            istatislikk istatistikControl = new istatislikk(dogruSayisi, yanlisSayisi);

            // Mevcut kullanıcı denetimine istatistik kullanıcı denetimini ekle
            this.Controls.Clear(); // Mevcut içeriği temizle
            this.Controls.Add(istatistikControl); // İstatistik kontrolünü ekle
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (words.Count == 0)
            {
                ShowStatistics(); // Süre dolduğunda veya kelime bitince istatistikleri göster
                ResetLabelsAndTimer();
                return;
            }

            sure--;
            LblSüre.Text = sure.ToString();
            if (sure == 0)
            {
                ShowStatistics(); // Süre dolduğunda veya kelime bitince istatistikleri göster
                ResetLabelsAndTimer();
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenDashboard();
        }
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            // Dashboard formunu oluştur
            Dashboard dashboardForm = new Dashboard();

            // Dashboard formunu göster
            dashboardForm.Show();

            // testet kullanıcı denetimini içeren formu bulun
            Form parentForm = this.FindForm();

            // Eğer form bulunduysa, kapatın
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }



        private void BtnKelimeler_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
            if (dashboardForm != null)
            {
                dashboardForm.OpenHome();
            }
            else
            {
                dashboardForm = new Dashboard();
                dashboardForm.Show();
                dashboardForm.OpenHome();
            }
        }



        private void OpenDashboard()
        {
            if (testBasladi)
            {
                DialogResult result = MessageBox.Show("Verileri kaydetmek ister misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes) // Evet cevabı
                {
                    // İstatistikleri kaydetmek için gerekli kodu buraya ekleyin
                    istatislikk frm1 = new istatislikk(dogruSayisi, yanlisSayisi);
                    Hide(); // Mevcut formu gizle
                    frm1.Show();

                    MessageBox.Show("Verileriniz kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Eğer zaten açık bir Dashboard formu varsa, ona odaklan
                    Dashboard existingDashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                    if (existingDashboardForm != null)
                    {
                        existingDashboardForm.Show();
                    }
                    else // Değilse yeni bir Dashboard formu aç
                    {
                        Dashboard frmDashboard = new Dashboard();
                        frmDashboard.Show();
                    }

                    CloseFormRequested?.Invoke(this, EventArgs.Empty); // Formu kapatmak için olayı tetikle
                }
                else if (result == DialogResult.No) // Hayır cevabı
                {
                    // Eğer zaten açık bir Dashboard formu varsa, ona odaklan
                    Dashboard existingDashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
                    if (existingDashboardForm != null)
                    {
                        existingDashboardForm.Show();
                    }
                    else // Değilse yeni bir Dashboard formu aç
                    {
                        Dashboard frmDashboard = new Dashboard();
                        frmDashboard.Show();
                    }

                    CloseFormRequested?.Invoke(this, EventArgs.Empty); // Formu kapatmak için olayı tetikle
                }
                // DialogResult.Cancel ise hiçbir şey yapma, dashboard formunu göstermeye devam et
            }
            else
            {
                // Test işlemi başlamadıysa direkt olarak dashboard formuna yönlendir
                DialogResult result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        db.Open();
                        cmd = new MySqlCommand("UPDATE kullanicilar SET oturum = 0 WHERE id = @id", db);
                        cmd.Parameters.AddWithValue("@id", Properties.Settings.Default.id);
                        cmd.ExecuteNonQuery();
                        Properties.Settings.Default.id = 0;
                        Properties.Settings.Default.oturum = 0;
                        Properties.Settings.Default.Save();
                        db.Close();
                        MessageBox.Show("Çıkış işlemi başarıyla gerçekleştirildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Çıkış işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnStat_Click(object sender, EventArgs e)
        {

            Dashboard dashboardForm = Application.OpenForms.OfType<Dashboard>().FirstOrDefault();
            if (dashboardForm != null)
            {
                dashboardForm.DarmaDuman();
            }
            else
            {
                dashboardForm = new Dashboard();
                dashboardForm.Show();
                dashboardForm.DarmaDuman();
            }
        }

        private void gec_Click(object sender, EventArgs e)
        {
            if (words.Count == 0)
            {
                MessageBox.Show("Kelime bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(TxtTR.Text))
            {
                string cevapKullanici = TxtTR.Text.Trim().ToLower();
                if (cevapKullanici == cevap.ToLower())
                {
                    MessageBox.Show("Doğru!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtTR.Clear();
                    dogruSayisi++;
                    LblKelime.Text = dogruSayisi.ToString();
                }
                else
                {
                    MessageBox.Show("Yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtTR.Clear();
                    yanlisSayisi++;
                }

                currentWordIndex++;

                if (currentWordIndex >= words.Count)
                {
                    MessageBox.Show("Oyun bitti.\nToplam Doğru Sayısı: " + dogruSayisi + "\nToplam Yanlış Sayısı: " + yanlisSayisi, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowStatistics(); // Kelime bitince istatistikleri göster
                    ResetLabelsAndTimer();
                    return;
                }
                else
                {
                    kelimegetir(kategori, kelime);
                }
            }
            else
            {
                MessageBox.Show("Lütfen kelime giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnPas_Click(object sender, EventArgs e)
        {
            if (pasHakki > 0 && currentWordIndex < words.Count)
            {
                currentWordIndex++;
                if (currentWordIndex >= words.Count)
                {
                    currentWordIndex = 0;
                }

                ShowWord();
                pasHakki--;
            }
            else if (pasHakki == 0)
            {
                MessageBox.Show("Pas hakkınız kalmadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (currentWordIndex >= words.Count)
            {
                MessageBox.Show("Kelimeniz kalmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetLabelsAndTimer();
            }
        }

        private void BtnBaslat_Click(object sender, EventArgs e)
        {
            bool validInput = false;

            while (!validInput)
            {
                int sureSecim;
                string sureInput = Interaction.InputBox("Oynamak istediğiniz süreyi saniye cinsinden girin (En fazla 100 saniye):", "Süre Seçimi");

                if (string.IsNullOrEmpty(sureInput)) // İptal seçeneği kontrolü
                {
                    return; // Metodu terk eder, döngüyü sonlandırır
                }

                if (int.TryParse(sureInput, out sureSecim) && sureSecim > 0 && sureSecim <= 100)
                {
                    sure = sureSecim;
                    validInput = true;
                }
                else if (!string.IsNullOrWhiteSpace(sureInput))
                {
                    MessageBox.Show("Süre 0 ile 100 arasında olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (!validInput)
                {
                    MessageBox.Show("Geçersiz süre girişi. Lütfen geçerli bir değer giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            validInput = false;
            while (!validInput)
            {
                int kelimeSecim;
                string kelimeInput = Interaction.InputBox("Oynamak istediğiniz kelime sayısını girin:", "Kelime Sayısı Seçimi");

                if (string.IsNullOrEmpty(kelimeInput)) // İptal seçeneği kontrolü
                {
                    return; // Metodu terk eder, döngüyü sonlandırır
                }

                if (int.TryParse(kelimeInput, out kelimeSecim) && kelimeSecim > 0)
                {
                    kelime = kelimeSecim;
                    validInput = true;
                }
                else if (!string.IsNullOrWhiteSpace(kelimeInput))
                {
                    MessageBox.Show("Kelime sayısı pozitif bir tam sayı olmalıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (!validInput)
                {
                    MessageBox.Show("Geçersiz kelime sayısı girişi. Lütfen geçerli bir değer giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            DialogResult dilSecimi = MessageBox.Show("İngilizce kelimeler mi görmek istersiniz?", "Dil Seçimi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dilSecimi == DialogResult.Yes)
            {
                label2.Visible = true;
                label1.Visible = true;
                label2.Text = "Türkçe";
                label1.Text = "İngilizce";
                ingilizceMi = true;
            }
            else
            {
                label2.Visible = true;
                label1.Visible = true;
                label1.Text = "Türkçe";
                label2.Text = "İngilizce";
                ingilizceMi = false;
            }

            kategori = 1;
            kelimegetir(kategori, kelime);
            timer1.Start();
            BtnBaslat.Enabled = false;
            BtnPas.Enabled = true;
            TxtTR.Enabled = true;

            if (words.Count == 0)
            {
                MessageBox.Show("Kelime bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            currentWordIndex = 0;
            dogruSayisi = 0;
            yanlisSayisi = 0;
            LblSüre.Text = sure.ToString();
            pasHakki = 3;
            LblKelime.Text = "0";
            TxtTR.Clear();

            testBasladi = true; // Testin başladığını işaretleyelim

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenDashboard();
        }
    }
}
