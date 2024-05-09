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
    public partial class istatislikk : UserControl
    {
        private readonly Settings pub = new Settings();
        private MySqlConnection db;
        private MySqlCommand cmd;
        private int dogruSayisi;
        private int yanlisSayisi;

        public istatislikk(int dogruSayisi, int yanlisSayisi)
        {
            InitializeComponent();
            db = new MySqlConnection(pub.__DBString);
            this.dogruSayisi = dogruSayisi;
            this.yanlisSayisi = yanlisSayisi;
            LoadPreviousResults(); // Önceki test sonuçlarını yükle
            CustomizeDataGridView();
            istatislikk_Load(this, EventArgs.Empty); // istatislikk_Load yöntemini çağır
        }

        private void istatislikk_Load(object sender, EventArgs e)
        {
            contextMenuStrip1 = new ContextMenuStrip();

            // "Sil" öğesini oluştur ve tıklama olayını belirle
            ToolStripMenuItem silMenuItem = new ToolStripMenuItem("Sil");
            silMenuItem.Click += SilMenuItem_Click;

            // ContextMenuStrip'e öğeleri ekle
            contextMenuStrip1.Items.Add(silMenuItem);

            // DataGridView kontrolüyle ContextMenuStrip'i ilişkilendir
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void LoadPreviousResults()
        {
            try
            {
                db.Open();
                string insertQuery = "INSERT INTO KelimeStats (Tarih, Saat, DogruSayisi, YanlisSayisi) VALUES (@tarih, @saat, @dogru, @yanlis)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, db);
                insertCmd.Parameters.AddWithValue("@tarih", DateTime.Now.ToString("yyyy-MM-dd"));
                insertCmd.Parameters.AddWithValue("@saat", DateTime.Now.ToString("HH:mm:ss"));
                insertCmd.Parameters.AddWithValue("@dogru", dogruSayisi);
                insertCmd.Parameters.AddWithValue("@yanlis", yanlisSayisi);
                insertCmd.ExecuteNonQuery();
                db.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına kayıt yapılırken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                db.Open();
                string selectQuery = "SELECT id, Tarih, Saat, DogruSayisi, YanlisSayisi FROM KelimeStats";
                MySqlCommand selectCmd = new MySqlCommand(selectQuery, db);
                MySqlDataAdapter adtr = new MySqlDataAdapter(selectCmd);
                DataTable dt = new DataTable();
                adtr.Fill(dt);
                dataGridView1.DataSource = dt;
                db.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Önceki test sonuçları yüklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CustomizeDataGridView()
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.RowTemplate.Height = 30;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dashboard reg = new Dashboard();
            reg.Show();
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
        private void SilMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen satırları al
                DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;

                // Eğer kullanıcı sadece bir satır seçmişse, sadece o satırı silme seçeneği göster
                if (selectedRows.Count == 1)
                {
                    // Seçili satırı al
                    DataGridViewRow selectedRow = selectedRows[0];
                    // Satırın indexini al
                    int rowIndex = selectedRow.Index;

                    // Seçili satırdaki id değerini al (varsayılan olarak görünmez bir sütun varsayılarak)
                    int id = Convert.ToInt32(selectedRow.Cells["id"].Value);

                    // Kullanıcıya bir satırı silmek isteyip istemediğini sormak için bir iletişim kutusu göster
                    DialogResult result = MessageBox.Show("Seçili satırı silmek üzeresiniz. Emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Kullanıcı evet derse, işlemi devam ettir
                    if (result == DialogResult.Yes)
                    {
                        // Seçili satırı sil
                        dataGridView1.Rows.RemoveAt(rowIndex);

                        using (MySqlConnection db = new MySqlConnection(pub.__DBString))
                        {
                            db.Open();
                            using (MySqlCommand cmd = new MySqlCommand("DELETE FROM kelimestats WHERE id = @id", db))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                int affectedRows = cmd.ExecuteNonQuery();
                                if (affectedRows > 0)
                                {
                                    MessageBox.Show("Silme işlemi başarıyla gerçekleştirildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Silme işlemi başarısız oldu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                // Eğer kullanıcı birden fazla satır seçmişse, tümünü silme seçeneği göster
                else if (selectedRows.Count > 1)
                {
                    // Kullanıcıya tüm satırları silmek isteyip istemediğini sormak için bir iletişim kutusu göster
                    DialogResult result = MessageBox.Show("Tüm satırları silmek üzeresiniz. Emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    // Kullanıcı evet derse, tüm satırları sil
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in selectedRows)
                        {
                            int id = Convert.ToInt32(row.Cells["id"].Value);
                            dataGridView1.Rows.Remove(row);

                            using (MySqlConnection db = new MySqlConnection(pub.__DBString))
                            {
                                db.Open();
                                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM kelimestats WHERE id = @id", db))
                                {
                                    cmd.Parameters.AddWithValue("@id", id);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        MessageBox.Show("Tüm satırlar başarıyla silindi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}