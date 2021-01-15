
namespace HalfLifeInstaller
{
    partial class formSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSettings));
            this.btnSaveRun = new System.Windows.Forms.Button();
            this.chkPrefix = new System.Windows.Forms.CheckBox();
            this.chkBackground = new System.Windows.Forms.CheckBox();
            this.cmbGames = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAlignment = new System.Windows.Forms.ComboBox();
            this.cmbFonts = new System.Windows.Forms.ComboBox();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.cmbFontSize = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnResetFontSize = new System.Windows.Forms.Button();
            this.btnResetFont = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveRun
            // 
            this.btnSaveRun.Location = new System.Drawing.Point(10, 344);
            this.btnSaveRun.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveRun.Name = "btnSaveRun";
            this.btnSaveRun.Size = new System.Drawing.Size(266, 36);
            this.btnSaveRun.TabIndex = 0;
            this.btnSaveRun.Text = "Kaydet ve Çalıştır";
            this.btnSaveRun.UseVisualStyleBackColor = true;
            this.btnSaveRun.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkPrefix
            // 
            this.chkPrefix.AutoSize = true;
            this.chkPrefix.Location = new System.Drawing.Point(4, 24);
            this.chkPrefix.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkPrefix.Name = "chkPrefix";
            this.chkPrefix.Size = new System.Drawing.Size(207, 17);
            this.chkPrefix.TabIndex = 1;
            this.chkPrefix.Text = "Konuşmacının başına isim eklensin mi?";
            this.chkPrefix.UseVisualStyleBackColor = true;
            // 
            // chkBackground
            // 
            this.chkBackground.AutoSize = true;
            this.chkBackground.Location = new System.Drawing.Point(4, 44);
            this.chkBackground.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkBackground.Name = "chkBackground";
            this.chkBackground.Size = new System.Drawing.Size(194, 17);
            this.chkBackground.TabIndex = 3;
            this.chkBackground.Text = "Altyazının arkaplanı siyah olsun mu?";
            this.chkBackground.UseVisualStyleBackColor = true;
            // 
            // cmbGames
            // 
            this.cmbGames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGames.FormattingEnabled = true;
            this.cmbGames.Location = new System.Drawing.Point(4, 17);
            this.cmbGames.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbGames.Name = "cmbGames";
            this.cmbGames.Size = new System.Drawing.Size(164, 21);
            this.cmbGames.TabIndex = 4;
            this.cmbGames.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbGames);
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(273, 47);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ayarları Değiştirilecek Oyun Seçimi:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbAlignment);
            this.groupBox2.Controls.Add(this.chkPrefix);
            this.groupBox2.Controls.Add(this.chkBackground);
            this.groupBox2.Location = new System.Drawing.Point(10, 60);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(274, 90);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Altyazı Ayarları";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Yazı yerleşimi hangi tafa olsun?";
            // 
            // cmbAlignment
            // 
            this.cmbAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlignment.FormattingEnabled = true;
            this.cmbAlignment.Items.AddRange(new object[] {
            "Sağ",
            "Sol",
            "Orta"});
            this.cmbAlignment.Location = new System.Drawing.Point(168, 64);
            this.cmbAlignment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbAlignment.Name = "cmbAlignment";
            this.cmbAlignment.Size = new System.Drawing.Size(92, 21);
            this.cmbAlignment.TabIndex = 5;
            this.cmbAlignment.SelectedIndexChanged += new System.EventHandler(this.cmbAlignment_SelectedIndexChanged);
            // 
            // cmbFonts
            // 
            this.cmbFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFonts.FormattingEnabled = true;
            this.cmbFonts.Location = new System.Drawing.Point(64, 23);
            this.cmbFonts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbFonts.Name = "cmbFonts";
            this.cmbFonts.Size = new System.Drawing.Size(151, 21);
            this.cmbFonts.TabIndex = 7;
            this.cmbFonts.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // txtPreview
            // 
            this.txtPreview.Enabled = false;
            this.txtPreview.Location = new System.Drawing.Point(0, 89);
            this.txtPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPreview.Multiline = true;
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.Size = new System.Drawing.Size(271, 97);
            this.txtPreview.TabIndex = 8;
            this.txtPreview.Text = "Black Mesa\'ya hoş geldiniz.";
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFontSize.FormattingEnabled = true;
            this.cmbFontSize.Location = new System.Drawing.Point(64, 47);
            this.cmbFontSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(151, 21);
            this.cmbFontSize.TabIndex = 9;
            this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnResetFontSize);
            this.groupBox3.Controls.Add(this.btnResetFont);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbFonts);
            this.groupBox3.Controls.Add(this.txtPreview);
            this.groupBox3.Controls.Add(this.cmbFontSize);
            this.groupBox3.Location = new System.Drawing.Point(8, 154);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(270, 186);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Yazı Tipi Ayarları";
            // 
            // btnResetFontSize
            // 
            this.btnResetFontSize.Location = new System.Drawing.Point(219, 48);
            this.btnResetFontSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResetFontSize.Name = "btnResetFontSize";
            this.btnResetFontSize.Size = new System.Drawing.Size(41, 21);
            this.btnResetFontSize.TabIndex = 14;
            this.btnResetFontSize.Text = "Sıfırla";
            this.btnResetFontSize.UseVisualStyleBackColor = true;
            this.btnResetFontSize.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnResetFont
            // 
            this.btnResetFont.Location = new System.Drawing.Point(219, 23);
            this.btnResetFont.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResetFont.Name = "btnResetFont";
            this.btnResetFont.Size = new System.Drawing.Size(41, 21);
            this.btnResetFont.TabIndex = 13;
            this.btnResetFont.Text = "Sıfırla";
            this.btnResetFont.UseVisualStyleBackColor = true;
            this.btnResetFont.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Örnek";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Boyut:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Yazı Tipi:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(286, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 366);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 388);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveRun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "formSettings";
            this.Text = "Half-Life: CaptionMod Ayarları";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveRun;
        private System.Windows.Forms.CheckBox chkPrefix;
        private System.Windows.Forms.CheckBox chkBackground;
        private System.Windows.Forms.ComboBox cmbGames;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbFonts;
        private System.Windows.Forms.TextBox txtPreview;
        private System.Windows.Forms.ComboBox cmbFontSize;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnResetFontSize;
        private System.Windows.Forms.Button btnResetFont;
        private System.Windows.Forms.ComboBox cmbAlignment;
        private System.Windows.Forms.Label label4;
    }
}

