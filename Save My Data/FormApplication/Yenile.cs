using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Save_My_Data
{
    public partial class Yenile : Form
    {
        static Settings pub = new Settings();
        static MySqlConnection db = new MySqlConnection(pub.__DBString);
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataAdapter adtr;
        MySqlDataReader dr;
        DataSet ds;
        Random r = new Random();
        bool suruklenmedurumu = false;
        Point ilkkonum;

        public Yenile()
        {
            InitializeComponent();
        }

        private void ButtonDegistir_Click(object sender, EventArgs e)
        {
            string kimlikNo = kimlikno.Text;
            string yeniSifre = password.Text;

            // Kimlik numarası veya şifre boş ise hata mesajı göster
            if (string.IsNullOrWhiteSpace(kimlikNo) || string.IsNullOrWhiteSpace(yeniSifre))
            {
                MessageBox.Show("Lütfen kimlik numarası ve şifreyi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(kimlikNo))
            {
                MessageBox.Show("Lütfen kimlik numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrWhiteSpace(yeniSifre))
            {
                MessageBox.Show("Lütfen şifreyi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                db.Open();

                // Kimlik numarasına göre kullanıcıyı bulma sorgusu
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM kullanicilar WHERE kimlikno = @kimlikNo", db);
                cmd.Parameters.AddWithValue("@kimlikNo", kimlikNo);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Kullanıcı bulundu, şifresini güncelle
                        reader.Close();

                        MySqlCommand updateCmd = new MySqlCommand("UPDATE kullanicilar SET sifre = @yeniSifre WHERE kimlikno = @kimlikNo", db);
                        updateCmd.Parameters.AddWithValue("@yeniSifre", yeniSifre);
                        updateCmd.Parameters.AddWithValue("@kimlikNo", kimlikNo);

                        int affectedRows = updateCmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Şifre başarıyla değiştirildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Şifre değiştirme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz kimlik numarası veya kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.Close();
            }
        }

        private void Yenile_Load(object sender, EventArgs e)
        {
            panel1.MouseDown += Panel_MouseDown;
            panel1.MouseMove += Panel_MouseMove;
            panel1.MouseUp += Panel_MouseUp;
        }

        private void linkLabelExit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Properties.Settings.Default.id = 0;
            Properties.Settings.Default.oturum = 0;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login frm1 = new Login();
            frm1.Show();
            this.Close();
        }

        private void kayıtbutton_Click(object sender, EventArgs e)
        {
            Register frm1 = new Register();
            frm1.Show();
            this.Close();
        }

        private void girisbutton_Click(object sender, EventArgs e)
        {
            Login frm1 = new Login();
            frm1.Show();
            this.Close();
        }

        private bool isDragging = false;
        private Point lastCursorPosition;
        private Point lastFormPosition;

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPosition = Cursor.Position;
                lastFormPosition = this.Location;
                Cursor = Cursors.SizeAll; // Taşıma imleci
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int xMove = Cursor.Position.X - lastCursorPosition.X;
                int yMove = Cursor.Position.Y - lastCursorPosition.Y;
                this.Location = new Point(lastFormPosition.X + xMove, lastFormPosition.Y + yMove);
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                Cursor = Cursors.Default; // Varsayılan imleç
            }
        }



        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Register frm1 = new Register();
            frm1.Show();
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Properties.Settings.Default.id = 0;
            Properties.Settings.Default.oturum = 0;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Login frm1 = new Login();
            frm1.Show();
            this.Close();
        }

        private void bunifuThinButton22_Click_1(object sender, EventArgs e)
        {
            Register frm1 = new Register();
            frm1.Show();
            this.Close();
        }
    }
}
