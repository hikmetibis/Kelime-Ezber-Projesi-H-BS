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

namespace Save_My_Data.addUserControl
{
    public partial class home : UserControl
    {
        int maxKid = 0;
        List<Form> acikFormlar = new List<Form>();
        public home()
        {
            InitializeComponent();
            GetMaxKid();
        }

        static Settings pub = new Settings();
        public MySqlConnection db = new MySqlConnection(pub.__DBString);
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataAdapter adtr;
        public MySqlDataReader dr;
        public DataSet ds;
        public int kid = Properties.Settings.Default.id;

        private void home_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
            contextMenuStrip1 = new ContextMenuStrip();

            // "Sil" öğesini oluştur ve tıklama olayını belirle
            ToolStripMenuItem silMenuItem = new ToolStripMenuItem("Sil");
            silMenuItem.Click += SilMenuItem_Click;

            // ContextMenuStrip'e öğeleri ekle
            contextMenuStrip1.Items.Add(silMenuItem);

            // DataGridView kontrolüyle ContextMenuStrip'i ilişkilendir
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void GetMaxKid()
        {
            try
            {
                db.Open();
                string query = "SELECT MAX(kid) FROM kelimeler";
                MySqlCommand command = new MySqlCommand(query, db);
                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    maxKid = Convert.ToInt32(result);
                    kid = maxKid + 1; // Maksimum kid değerine 1 ekleyerek yeni kid değeri oluştur
                }
                else
                {
                    // Veritabanında hiç kayıt yoksa veya tüm kayıtlar silinmişse kid değerini sıfırdan başlat
                    kid = 1;
                }
                db.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("kid değeri alınırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void veriListele()
        {
            try
            {
                // Veritabanı bağlantısını aç
                db.Open();

                // Veritabanından tüm kelimeleri seçen sorguyu hazırla
                string query = "SELECT kid, En, Tr, Kategori FROM kelimeler";

                // Sorguyu ve bağlantıyı kullanarak bir MySqlCommand nesnesi oluştur
                MySqlCommand command = new MySqlCommand(query, db);

                // Verileri okumak için bir MySqlDataAdapter ve bir DataTable oluştur
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                // Verileri DataTable'a doldur
                adapter.Fill(dataTable);

                // DataGridView'e DataTable'ı bağla
                dataGridView1.DataSource = dataTable;

                // DataGridView için stil ve renk ayarları
                dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dataGridView1.BackgroundColor = Color.White;

                // Kolon başlıkları için stil ve renk ayarları
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.EnableHeadersVisualStyles = false;

                // Otomatik boyutlandırma
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Hizalama
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Satır yüksekliğini ayarla
                dataGridView1.RowTemplate.Height = 30;

                // Veritabanı bağlantısını kapat
                db.Close();
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show("Veri listelenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                // Bağlantıyı kapat (eğer açılmışsa)
                if (db.State == ConnectionState.Open)
                {
                    db.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kategori değerini otomatik olarak belirle
                string kategori = "1"; // Örneğin, varsayılan olarak "1" olarak ayarlanmıştır.

                // Maksimum kid değerini al
                GetMaxKid();

                db.Open();
                cmd = new MySqlCommand("INSERT INTO kelimeler(kid, En, Tr, Kategori) VALUES (@kid, @En, @Tr, @Kategori)", db);
                cmd.Parameters.AddWithValue("@kid", kid);
                cmd.Parameters.AddWithValue("@Tr", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@En", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Kategori", kategori); // Kategori değeri otomatik olarak "1" olarak atanır
                cmd.ExecuteNonQuery();
                db.Close();

                // Başarılı ekleme mesajı göster
                MessageBox.Show("Bilgi başarıyla eklendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Verileri tekrar listele
                veriListele();
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void listelebutton_Click(object sender, EventArgs e)
        {
            try
            {
                // DataGridView'in veri kaynağını temizle
                dataGridView1.DataSource = null;

                // Veriler yüklenirken bilgi mesajı göster
                MessageBox.Show("Veriler yükleniyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Verileri hızlı bir şekilde yükle
                DataTable dataTable = await LoadDataAsync();

                // DataGridView'e verileri bağla
                dataGridView1.DataSource = dataTable;

                // Verilerin başarıyla listelendiğine dair bilgi mesajı göster
                MessageBox.Show("Veriler başarıyla listelendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SilMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["kid"].Value);
                using (MySqlConnection db = new MySqlConnection(pub.__DBString))
                {
                    db.Open();
                    using (MySqlCommand cmd = new MySqlCommand("DELETE FROM kelimeler WHERE kid = @kid", db))
                    {
                        cmd.Parameters.AddWithValue("@kid", id);
                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Silme işlemi başarıyla gerçekleştirildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            veriListele();
                        }
                        else
                        {
                            MessageBox.Show("Silme işlemi başarısız oldu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void CallListelebuttonClick()
        {
            EventArgs args = new EventArgs();
            listelebutton_Click(null, args);
        }


        private async Task<DataTable> LoadDataAsync()
        {
            DataTable dataTable = new DataTable();

            try
            {
                // Veritabanı bağlantısını aç
                db.Open();

                // Veritabanından tüm kelimeleri seçen sorguyu hazırla
                string query = "SELECT kid, En, Tr, Kategori FROM kelimeler";

                // Sorguyu ve bağlantıyı kullanarak bir MySqlCommand nesnesi oluştur
                MySqlCommand command = new MySqlCommand(query, db);

                // Verileri okumak için bir MySqlDataAdapter ve bir DataTable oluştur
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                // Verileri DataTable'a doldur
                await Task.Run(() => adapter.Fill(dataTable));
                // DataGridView için stil ve renk ayarları
                dataGridView1.DefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dataGridView1.BackgroundColor = Color.White;

                // Kolon başlıkları için stil ve renk ayarları
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.EnableHeadersVisualStyles = false;

                // Otomatik boyutlandırma
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Hizalama
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Satır yüksekliğini ayarla
                dataGridView1.RowTemplate.Height = 30;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Veritabanı bağlantısını kapat
                if (db.State == ConnectionState.Open)
                {
                    db.Close();
                }
            }

            return dataTable;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
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
}
