namespace Autokauppa.view
{
    partial class MainMenu
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
            this.btnSeuraava = new System.Windows.Forms.Button();
            this.gbAuto = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPolttoaine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbVari = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMalli = new System.Windows.Forms.ComboBox();
            this.dtpPaiva = new System.Windows.Forms.DateTimePicker();
            this.tbMittarilukema = new System.Windows.Forms.TextBox();
            this.tbTilavuus = new System.Windows.Forms.TextBox();
            this.tbHinta = new System.Windows.Forms.TextBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMerkki = new System.Windows.Forms.ComboBox();
            this.btnEdellinen = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testaaTietokantaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLisaa = new System.Windows.Forms.Button();
            this.btnPoista = new System.Windows.Forms.Button();
            this.btnTallenna = new System.Windows.Forms.Button();
            this.btnPeruuta = new System.Windows.Forms.Button();
            this.gbAuto.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSeuraava
            // 
            this.btnSeuraava.Location = new System.Drawing.Point(83, 185);
            this.btnSeuraava.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeuraava.Name = "btnSeuraava";
            this.btnSeuraava.Size = new System.Drawing.Size(70, 27);
            this.btnSeuraava.TabIndex = 31;
            this.btnSeuraava.Text = "Seuraava";
            this.btnSeuraava.UseVisualStyleBackColor = true;
            this.btnSeuraava.Click += new System.EventHandler(this.btnSeuraava_Click);
            // 
            // gbAuto
            // 
            this.gbAuto.Controls.Add(this.label8);
            this.gbAuto.Controls.Add(this.label7);
            this.gbAuto.Controls.Add(this.label6);
            this.gbAuto.Controls.Add(this.label5);
            this.gbAuto.Controls.Add(this.label4);
            this.gbAuto.Controls.Add(this.cbPolttoaine);
            this.gbAuto.Controls.Add(this.label3);
            this.gbAuto.Controls.Add(this.cbVari);
            this.gbAuto.Controls.Add(this.label2);
            this.gbAuto.Controls.Add(this.cbMalli);
            this.gbAuto.Controls.Add(this.dtpPaiva);
            this.gbAuto.Controls.Add(this.tbMittarilukema);
            this.gbAuto.Controls.Add(this.tbTilavuus);
            this.gbAuto.Controls.Add(this.tbHinta);
            this.gbAuto.Controls.Add(this.tbId);
            this.gbAuto.Controls.Add(this.label1);
            this.gbAuto.Controls.Add(this.cbMerkki);
            this.gbAuto.Location = new System.Drawing.Point(9, 29);
            this.gbAuto.Margin = new System.Windows.Forms.Padding(2);
            this.gbAuto.Name = "gbAuto";
            this.gbAuto.Padding = new System.Windows.Forms.Padding(2);
            this.gbAuto.Size = new System.Drawing.Size(426, 153);
            this.gbAuto.TabIndex = 18;
            this.gbAuto.TabStop = false;
            this.gbAuto.Text = "Auton tiedot";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Moottorin Tilavuus:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Mittarilukema:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Pvm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Hinta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Polttoaine:";
            // 
            // cbPolttoaine
            // 
            this.cbPolttoaine.FormattingEnabled = true;
            this.cbPolttoaine.Location = new System.Drawing.Point(308, 95);
            this.cbPolttoaine.Margin = new System.Windows.Forms.Padding(2);
            this.cbPolttoaine.Name = "cbPolttoaine";
            this.cbPolttoaine.Size = new System.Drawing.Size(92, 21);
            this.cbPolttoaine.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Väri:";
            // 
            // cbVari
            // 
            this.cbVari.FormattingEnabled = true;
            this.cbVari.Location = new System.Drawing.Point(308, 70);
            this.cbVari.Margin = new System.Windows.Forms.Padding(2);
            this.cbVari.Name = "cbVari";
            this.cbVari.Size = new System.Drawing.Size(92, 21);
            this.cbVari.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Malli:";
            // 
            // cbMalli
            // 
            this.cbMalli.FormattingEnabled = true;
            this.cbMalli.Location = new System.Drawing.Point(308, 46);
            this.cbMalli.Margin = new System.Windows.Forms.Padding(2);
            this.cbMalli.Name = "cbMalli";
            this.cbMalli.Size = new System.Drawing.Size(92, 21);
            this.cbMalli.TabIndex = 25;
            // 
            // dtpPaiva
            // 
            this.dtpPaiva.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPaiva.Location = new System.Drawing.Point(107, 47);
            this.dtpPaiva.Margin = new System.Windows.Forms.Padding(2);
            this.dtpPaiva.Name = "dtpPaiva";
            this.dtpPaiva.Size = new System.Drawing.Size(112, 20);
            this.dtpPaiva.TabIndex = 21;
            this.dtpPaiva.ValueChanged += new System.EventHandler(this.dtpPaiva_ValueChanged);
            // 
            // tbMittarilukema
            // 
            this.tbMittarilukema.Location = new System.Drawing.Point(107, 71);
            this.tbMittarilukema.Margin = new System.Windows.Forms.Padding(2);
            this.tbMittarilukema.Name = "tbMittarilukema";
            this.tbMittarilukema.Size = new System.Drawing.Size(112, 20);
            this.tbMittarilukema.TabIndex = 22;
            // 
            // tbTilavuus
            // 
            this.tbTilavuus.Location = new System.Drawing.Point(107, 95);
            this.tbTilavuus.Margin = new System.Windows.Forms.Padding(2);
            this.tbTilavuus.Name = "tbTilavuus";
            this.tbTilavuus.Size = new System.Drawing.Size(112, 20);
            this.tbTilavuus.TabIndex = 23;
            this.tbTilavuus.TextChanged += new System.EventHandler(this.tbTilavuus_TextChanged);
            // 
            // tbHinta
            // 
            this.tbHinta.Location = new System.Drawing.Point(107, 23);
            this.tbHinta.Margin = new System.Windows.Forms.Padding(2);
            this.tbHinta.Name = "tbHinta";
            this.tbHinta.Size = new System.Drawing.Size(112, 20);
            this.tbHinta.TabIndex = 20;
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(308, 120);
            this.tbId.Margin = new System.Windows.Forms.Padding(2);
            this.tbId.Name = "tbId";
            this.tbId.ReadOnly = true;
            this.tbId.Size = new System.Drawing.Size(92, 20);
            this.tbId.TabIndex = 29;
            this.tbId.TextChanged += new System.EventHandler(this.tbId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Automerkki:";
            // 
            // cbMerkki
            // 
            this.cbMerkki.FormattingEnabled = true;
            this.cbMerkki.Location = new System.Drawing.Point(308, 22);
            this.cbMerkki.Margin = new System.Windows.Forms.Padding(2);
            this.cbMerkki.Name = "cbMerkki";
            this.cbMerkki.Size = new System.Drawing.Size(92, 21);
            this.cbMerkki.TabIndex = 24;
            this.cbMerkki.SelectedIndexChanged += new System.EventHandler(this.cbMerkki_SelectedIndexChanged);
            // 
            // btnEdellinen
            // 
            this.btnEdellinen.Location = new System.Drawing.Point(9, 185);
            this.btnEdellinen.Margin = new System.Windows.Forms.Padding(2);
            this.btnEdellinen.Name = "btnEdellinen";
            this.btnEdellinen.Size = new System.Drawing.Size(70, 27);
            this.btnEdellinen.TabIndex = 30;
            this.btnEdellinen.Text = "Edellinen";
            this.btnEdellinen.UseVisualStyleBackColor = true;
            this.btnEdellinen.Click += new System.EventHandler(this.btnEdellinen_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(453, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.exitToolStripMenuItem.Text = "Tiedosto";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem1.Text = "Poistu";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testaaTietokantaaToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.aboutToolStripMenuItem.Text = "Muuta...";
            // 
            // testaaTietokantaaToolStripMenuItem
            // 
            this.testaaTietokantaaToolStripMenuItem.Name = "testaaTietokantaaToolStripMenuItem";
            this.testaaTietokantaaToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.testaaTietokantaaToolStripMenuItem.Text = "Testaa tietokantaa";
            this.testaaTietokantaaToolStripMenuItem.Click += new System.EventHandler(this.testaaTietokantaaToolStripMenuItem_Click);
            // 
            // btnLisaa
            // 
            this.btnLisaa.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnLisaa.Location = new System.Drawing.Point(368, 185);
            this.btnLisaa.Margin = new System.Windows.Forms.Padding(2);
            this.btnLisaa.Name = "btnLisaa";
            this.btnLisaa.Size = new System.Drawing.Size(67, 27);
            this.btnLisaa.TabIndex = 33;
            this.btnLisaa.Text = "Uusi";
            this.btnLisaa.UseVisualStyleBackColor = false;
            this.btnLisaa.Click += new System.EventHandler(this.btnLisaa_Click);
            // 
            // btnPoista
            // 
            this.btnPoista.BackColor = System.Drawing.Color.LightCoral;
            this.btnPoista.Location = new System.Drawing.Point(296, 185);
            this.btnPoista.Name = "btnPoista";
            this.btnPoista.Size = new System.Drawing.Size(67, 27);
            this.btnPoista.TabIndex = 32;
            this.btnPoista.Text = "Poista";
            this.btnPoista.UseVisualStyleBackColor = false;
            // 
            // btnTallenna
            // 
            this.btnTallenna.BackColor = System.Drawing.Color.YellowGreen;
            this.btnTallenna.Enabled = false;
            this.btnTallenna.Location = new System.Drawing.Point(10, 217);
            this.btnTallenna.Name = "btnTallenna";
            this.btnTallenna.Size = new System.Drawing.Size(69, 27);
            this.btnTallenna.TabIndex = 34;
            this.btnTallenna.Text = "Tallenna";
            this.btnTallenna.UseVisualStyleBackColor = false;
            this.btnTallenna.Click += new System.EventHandler(this.btnTallenna_Click);
            // 
            // btnPeruuta
            // 
            this.btnPeruuta.BackColor = System.Drawing.Color.LightCoral;
            this.btnPeruuta.Enabled = false;
            this.btnPeruuta.Location = new System.Drawing.Point(83, 217);
            this.btnPeruuta.Name = "btnPeruuta";
            this.btnPeruuta.Size = new System.Drawing.Size(70, 27);
            this.btnPeruuta.TabIndex = 35;
            this.btnPeruuta.Text = "Peruuta";
            this.btnPeruuta.UseVisualStyleBackColor = false;
            this.btnPeruuta.Click += new System.EventHandler(this.btnPeruuta_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 293);
            this.Controls.Add(this.btnPeruuta);
            this.Controls.Add(this.btnTallenna);
            this.Controls.Add(this.btnPoista);
            this.Controls.Add(this.btnLisaa);
            this.Controls.Add(this.btnEdellinen);
            this.Controls.Add(this.gbAuto);
            this.Controls.Add(this.btnSeuraava);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.gbAuto.ResumeLayout(false);
            this.gbAuto.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSeuraava;
        private System.Windows.Forms.GroupBox gbAuto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPolttoaine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVari;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMalli;
        private System.Windows.Forms.DateTimePicker dtpPaiva;
        private System.Windows.Forms.TextBox tbMittarilukema;
        private System.Windows.Forms.TextBox tbTilavuus;
        private System.Windows.Forms.TextBox tbHinta;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMerkki;
        private System.Windows.Forms.Button btnEdellinen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testaaTietokantaaToolStripMenuItem;
        private System.Windows.Forms.Button btnLisaa;
        private System.Windows.Forms.Button btnPoista;
        private System.Windows.Forms.Button btnTallenna;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPeruuta;
    }
}