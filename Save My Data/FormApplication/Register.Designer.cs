namespace Save_My_Data
{
    partial class Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuThinButton21 = new ns1.BunifuThinButton2();
            this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.username = new ns1.BunifuMaterialTextbox();
            this.email = new ns1.BunifuMaterialTextbox();
            this.password = new ns1.BunifuMaterialTextbox();
            this.captcha = new ns1.BunifuMaterialTextbox();
            this.repassword = new ns1.BunifuMaterialTextbox();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.registerbtn = new ns1.BunifuThinButton2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.captchalbl = new ns1.BunifuCustomLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.security = new ns1.BunifuMaterialTextbox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.bunifuThinButton21);
            this.panel1.Controls.Add(this.bunifuCustomLabel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Location = new System.Drawing.Point(599, -4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 542);
            this.panel1.TabIndex = 12;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Register_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 20;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.White;
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.White;
            this.bunifuThinButton21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "GİRİŞ YAP";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.White;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 20;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.White;
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.White;
            this.bunifuThinButton21.Location = new System.Drawing.Point(49, 267);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(203, 62);
            this.bunifuThinButton21.TabIndex = 24;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuThinButton21.Click += new System.EventHandler(this.bunifuThinButton21_Click);
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(89, 243);
            this.bunifuCustomLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(120, 18);
            this.bunifuCustomLabel2.TabIndex = 25;
            this.bunifuCustomLabel2.Text = "Hesabın Var mı ?";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.White;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(253, 4);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(27, 31);
            this.linkLabel1.TabIndex = 24;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "x";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // username
            // 
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.username.HintForeColor = System.Drawing.Color.Empty;
            this.username.HintText = "Kullanıcı adı";
            this.username.isPassword = false;
            this.username.LineFocusedColor = System.Drawing.Color.Black;
            this.username.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.username.LineMouseHoverColor = System.Drawing.Color.Black;
            this.username.LineThickness = 3;
            this.username.Location = new System.Drawing.Point(45, 92);
            this.username.Margin = new System.Windows.Forms.Padding(5);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(477, 42);
            this.username.TabIndex = 1;
            this.username.Tag = "";
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // email
            // 
            this.email.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.email.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.email.HintForeColor = System.Drawing.Color.Empty;
            this.email.HintText = "E-mail";
            this.email.isPassword = false;
            this.email.LineFocusedColor = System.Drawing.Color.Black;
            this.email.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.email.LineMouseHoverColor = System.Drawing.Color.Black;
            this.email.LineThickness = 3;
            this.email.Location = new System.Drawing.Point(45, 155);
            this.email.Margin = new System.Windows.Forms.Padding(5);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(477, 42);
            this.email.TabIndex = 2;
            this.email.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // password
            // 
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.password.HintForeColor = System.Drawing.Color.Empty;
            this.password.HintText = "Password";
            this.password.isPassword = true;
            this.password.LineFocusedColor = System.Drawing.Color.Black;
            this.password.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.password.LineMouseHoverColor = System.Drawing.Color.Black;
            this.password.LineThickness = 3;
            this.password.Location = new System.Drawing.Point(45, 262);
            this.password.Margin = new System.Windows.Forms.Padding(5);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(477, 42);
            this.password.TabIndex = 4;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // captcha
            // 
            this.captcha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.captcha.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.captcha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.captcha.HintForeColor = System.Drawing.Color.Empty;
            this.captcha.HintText = "Captcha";
            this.captcha.isPassword = false;
            this.captcha.LineFocusedColor = System.Drawing.Color.Black;
            this.captcha.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.captcha.LineMouseHoverColor = System.Drawing.Color.Black;
            this.captcha.LineThickness = 3;
            this.captcha.Location = new System.Drawing.Point(45, 379);
            this.captcha.Margin = new System.Windows.Forms.Padding(5);
            this.captcha.Name = "captcha";
            this.captcha.Size = new System.Drawing.Size(247, 42);
            this.captcha.TabIndex = 6;
            this.captcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // repassword
            // 
            this.repassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.repassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.repassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.repassword.HintForeColor = System.Drawing.Color.Empty;
            this.repassword.HintText = "Password";
            this.repassword.isPassword = true;
            this.repassword.LineFocusedColor = System.Drawing.Color.Black;
            this.repassword.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.repassword.LineMouseHoverColor = System.Drawing.Color.Black;
            this.repassword.LineThickness = 3;
            this.repassword.Location = new System.Drawing.Point(45, 314);
            this.repassword.Margin = new System.Windows.Forms.Padding(5);
            this.repassword.Name = "repassword";
            this.repassword.Size = new System.Drawing.Size(477, 42);
            this.repassword.TabIndex = 5;
            this.repassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(198, 44);
            this.bunifuCustomLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(182, 29);
            this.bunifuCustomLabel1.TabIndex = 20;
            this.bunifuCustomLabel1.Text = "Hesap Oluştur";
            // 
            // registerbtn
            // 
            this.registerbtn.ActiveBorderThickness = 1;
            this.registerbtn.ActiveCornerRadius = 20;
            this.registerbtn.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.registerbtn.ActiveForecolor = System.Drawing.Color.Red;
            this.registerbtn.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.registerbtn.BackColor = System.Drawing.Color.DarkGray;
            this.registerbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("registerbtn.BackgroundImage")));
            this.registerbtn.ButtonText = "ÜYE OL";
            this.registerbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerbtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.registerbtn.IdleBorderThickness = 1;
            this.registerbtn.IdleCornerRadius = 20;
            this.registerbtn.IdleFillColor = System.Drawing.Color.White;
            this.registerbtn.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.registerbtn.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.registerbtn.Location = new System.Drawing.Point(137, 443);
            this.registerbtn.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.registerbtn.Name = "registerbtn";
            this.registerbtn.Size = new System.Drawing.Size(303, 62);
            this.registerbtn.TabIndex = 8;
            this.registerbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.registerbtn.Click += new System.EventHandler(this.registerbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(101, 159);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // captchalbl
            // 
            this.captchalbl.AutoSize = true;
            this.captchalbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.captchalbl.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.captchalbl.Location = new System.Drawing.Point(342, 389);
            this.captchalbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.captchalbl.Name = "captchalbl";
            this.captchalbl.Size = new System.Drawing.Size(126, 32);
            this.captchalbl.TabIndex = 7;
            this.captchalbl.Text = "AA99QQ";
            this.captchalbl.Click += new System.EventHandler(this.captchalbl_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // security
            // 
            this.security.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.security.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.security.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.security.HintForeColor = System.Drawing.Color.Empty;
            this.security.HintText = "Kimlik numarası";
            this.security.isPassword = false;
            this.security.LineFocusedColor = System.Drawing.Color.Black;
            this.security.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.security.LineMouseHoverColor = System.Drawing.Color.Black;
            this.security.LineThickness = 3;
            this.security.Location = new System.Drawing.Point(45, 210);
            this.security.Margin = new System.Windows.Forms.Padding(5);
            this.security.Name = "security";
            this.security.Size = new System.Drawing.Size(477, 42);
            this.security.TabIndex = 3;
            this.security.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(880, 538);
            this.Controls.Add(this.security);
            this.Controls.Add(this.captchalbl);
            this.Controls.Add(this.registerbtn);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.captcha);
            this.Controls.Add(this.repassword);
            this.Controls.Add(this.password);
            this.Controls.Add(this.email);
            this.Controls.Add(this.username);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(880, 538);
            this.MinimumSize = new System.Drawing.Size(880, 538);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "16";
            this.Load += new System.EventHandler(this.Register_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Register_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ns1.BunifuMaterialTextbox username;
        private ns1.BunifuMaterialTextbox email;
        private ns1.BunifuMaterialTextbox password;
        private ns1.BunifuMaterialTextbox captcha;
        private ns1.BunifuMaterialTextbox repassword;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuThinButton2 registerbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ns1.BunifuCustomLabel captchalbl;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private ns1.BunifuThinButton2 bunifuThinButton21;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.Timer timer1;
        private ns1.BunifuMaterialTextbox security;
    }
}