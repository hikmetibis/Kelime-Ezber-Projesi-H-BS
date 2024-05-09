using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Save_My_Data.addUserControl;
using Save_My_Data.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Save_My_Data
{
    public partial class Dashboard : Form
    {
        int maxKid = 0;
        List<Form> acikFormlar = new List<Form>();
        int dogruSayisi = -1;
        int yanlisSayisi = -1;

        public Dashboard()
        {
            InitializeComponent();
            panel1.MouseDown += Panel_MouseDown;
            panel1.MouseMove += Panel_MouseMove;
            panel1.MouseUp += Panel_MouseUp;
        }

        static Settings pub = new Settings();
        public MySqlConnection db = new MySqlConnection(pub.__DBString);
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataAdapter adtr;
        public MySqlDataReader dr;
        public DataSet ds;
        public int kid = Properties.Settings.Default.id;



        // Çıkış işlemi
        private void cikis_Click(object sender, EventArgs e)
        {
            // Çıkış yapmak isteyip istemediğini kullanıcıya sor
            DialogResult result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kullanıcı Evet'i seçtiyse
            if (result == DialogResult.Yes)
            {
                // Tüm açık formları kapat
                CloseAllForms();

                // Kullanıcıya mesaj ver
                MessageBox.Show("Çıkış yapılıyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 2 saniye bekleyip sonra Login ekranına yönlendir
                Thread thread = new Thread(new ThreadStart(OpenLoginForm));
                thread.Start();
            }
        }

        // Tüm açık formları kapatma işlemi
        private void CloseAllForms()
        {
            // Ana formun ana formu dışındaki tüm formları kapat
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form.GetType() != typeof(Dashboard))
                {
                    form.Close();
                }
            }
        }

        // Login ekranını açma işlemi
        private void OpenLoginForm()
        {
            Thread.Sleep(1000); // 1 saniye bekle
            Application.Run(new Login()); // Login ekranını aç
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblVer.Text = Properties.Settings.Default.kullanici;
            lblName.Text = Properties.Settings.Default.isim;
        }

        // Bağlantıyı kapat
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Programı sonlandırmak istediğinize emin misiniz ?", "Kelime Oyunu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelcontainer.Controls.Clear();
            panelcontainer.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void testet_Click(object sender, EventArgs e)
        {
            testet uc = new testet();
            addUserControl(uc);
        }

        private void anasayfa_Click(object sender, EventArgs e)
        {
            home uc = new home();
            addUserControl(uc);
        }
        private bool istatistikAdded = false;
        private void Istatiklik_Click(object sender, EventArgs e)
        {
            if (!istatistikAdded) // Eğer istatistik daha önce eklenmediyse
            {
                istatislikk uc = new istatislikk(dogruSayisi, yanlisSayisi);
                addUserControl(uc);
                istatistikAdded = true; // Artık istatistik eklendiğini işaretleyelim
            }
            else // Eğer istatistik zaten eklenmişse
            {
                MessageBox.Show("İstatistik zaten eklenmiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        public void OpenHome()
        {
            home uc = new home();
            addUserControl(uc);
        }
        public void DarmaDuman()
        {
            istatislikk uc = new istatislikk(dogruSayisi, yanlisSayisi);
            addUserControl(uc);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
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