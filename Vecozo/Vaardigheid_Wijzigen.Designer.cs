namespace VecozoWinForms
{
    partial class Vaardigheid_Wijzigen
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
            this.gbVaardigheidGegevens = new System.Windows.Forms.GroupBox();
            this.lbgegevens = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaardighedenOverzichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNaam = new System.Windows.Forms.Button();
            this.btnRating = new System.Windows.Forms.Button();
            this.btnBeschrijving = new System.Windows.Forms.Button();
            this.btnVerwijder = new System.Windows.Forms.Button();
            this.tbVaardigheid = new System.Windows.Forms.TextBox();
            this.tbBeschrijving = new System.Windows.Forms.TextBox();
            this.gbScore = new System.Windows.Forms.GroupBox();
            this.rbtn5Ster = new System.Windows.Forms.RadioButton();
            this.rbtn1Ster = new System.Windows.Forms.RadioButton();
            this.rbtn2Ster = new System.Windows.Forms.RadioButton();
            this.rbtn3Ster = new System.Windows.Forms.RadioButton();
            this.rbtn4Ster = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbMedewerker = new System.Windows.Forms.GroupBox();
            this.lbMedGegevens = new System.Windows.Forms.Label();
            this.gbVaardigheidGegevens.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbScore.SuspendLayout();
            this.gbMedewerker.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbVaardigheidGegevens
            // 
            this.gbVaardigheidGegevens.Controls.Add(this.lbgegevens);
            this.gbVaardigheidGegevens.Location = new System.Drawing.Point(34, 63);
            this.gbVaardigheidGegevens.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbVaardigheidGegevens.Name = "gbVaardigheidGegevens";
            this.gbVaardigheidGegevens.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbVaardigheidGegevens.Size = new System.Drawing.Size(482, 352);
            this.gbVaardigheidGegevens.TabIndex = 0;
            this.gbVaardigheidGegevens.TabStop = false;
            this.gbVaardigheidGegevens.Text = "Vaardigeid";
            // 
            // lbgegevens
            // 
            this.lbgegevens.AutoSize = true;
            this.lbgegevens.Location = new System.Drawing.Point(12, 54);
            this.lbgegevens.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbgegevens.Name = "lbgegevens";
            this.lbgegevens.Size = new System.Drawing.Size(68, 30);
            this.lbgegevens.TabIndex = 0;
            this.lbgegevens.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1269, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vaardighedenOverzichtToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(84, 34);
            this.menuToolStripMenuItem.Text = "menu";
            // 
            // vaardighedenOverzichtToolStripMenuItem
            // 
            this.vaardighedenOverzichtToolStripMenuItem.Name = "vaardighedenOverzichtToolStripMenuItem";
            this.vaardighedenOverzichtToolStripMenuItem.Size = new System.Drawing.Size(348, 40);
            this.vaardighedenOverzichtToolStripMenuItem.Text = "Vaardigheden overzicht";
            this.vaardighedenOverzichtToolStripMenuItem.Click += new System.EventHandler(this.vaardighedenOverzichtToolStripMenuItem_Click);
            // 
            // btnNaam
            // 
            this.btnNaam.Location = new System.Drawing.Point(62, 602);
            this.btnNaam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNaam.Name = "btnNaam";
            this.btnNaam.Size = new System.Drawing.Size(159, 74);
            this.btnNaam.TabIndex = 2;
            this.btnNaam.Text = "naam wijzigen";
            this.btnNaam.UseVisualStyleBackColor = true;
            this.btnNaam.Click += new System.EventHandler(this.btnNaam_Click);
            // 
            // btnRating
            // 
            this.btnRating.Location = new System.Drawing.Point(62, 867);
            this.btnRating.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRating.Name = "btnRating";
            this.btnRating.Size = new System.Drawing.Size(159, 74);
            this.btnRating.TabIndex = 3;
            this.btnRating.Text = "Rating wijzigen";
            this.btnRating.UseVisualStyleBackColor = true;
            this.btnRating.Click += new System.EventHandler(this.btnRating_Click);
            // 
            // btnBeschrijving
            // 
            this.btnBeschrijving.Location = new System.Drawing.Point(357, 602);
            this.btnBeschrijving.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBeschrijving.Name = "btnBeschrijving";
            this.btnBeschrijving.Size = new System.Drawing.Size(159, 74);
            this.btnBeschrijving.TabIndex = 4;
            this.btnBeschrijving.Text = "Beschrijving wijzigen";
            this.btnBeschrijving.UseVisualStyleBackColor = true;
            this.btnBeschrijving.Click += new System.EventHandler(this.btnBeschrijving_Click);
            // 
            // btnVerwijder
            // 
            this.btnVerwijder.Location = new System.Drawing.Point(747, 602);
            this.btnVerwijder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVerwijder.Name = "btnVerwijder";
            this.btnVerwijder.Size = new System.Drawing.Size(159, 74);
            this.btnVerwijder.TabIndex = 5;
            this.btnVerwijder.Text = "Verwijder vaardigeheid";
            this.btnVerwijder.UseVisualStyleBackColor = true;
            this.btnVerwijder.Click += new System.EventHandler(this.btnVerwijder_Click);
            // 
            // tbVaardigheid
            // 
            this.tbVaardigheid.Location = new System.Drawing.Point(68, 531);
            this.tbVaardigheid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbVaardigheid.Name = "tbVaardigheid";
            this.tbVaardigheid.Size = new System.Drawing.Size(151, 35);
            this.tbVaardigheid.TabIndex = 6;
            this.tbVaardigheid.TextChanged += new System.EventHandler(this.tbVaardigheid_TextChanged);
            // 
            // tbBeschrijving
            // 
            this.tbBeschrijving.Location = new System.Drawing.Point(350, 483);
            this.tbBeschrijving.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBeschrijving.Multiline = true;
            this.tbBeschrijving.Name = "tbBeschrijving";
            this.tbBeschrijving.Size = new System.Drawing.Size(240, 108);
            this.tbBeschrijving.TabIndex = 8;
            // 
            // gbScore
            // 
            this.gbScore.Controls.Add(this.rbtn5Ster);
            this.gbScore.Controls.Add(this.rbtn1Ster);
            this.gbScore.Controls.Add(this.rbtn2Ster);
            this.gbScore.Controls.Add(this.rbtn3Ster);
            this.gbScore.Controls.Add(this.rbtn4Ster);
            this.gbScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbScore.Location = new System.Drawing.Point(62, 736);
            this.gbScore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbScore.Name = "gbScore";
            this.gbScore.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbScore.Size = new System.Drawing.Size(928, 96);
            this.gbScore.TabIndex = 11;
            this.gbScore.TabStop = false;
            this.gbScore.Text = "Score";
            // 
            // rbtn5Ster
            // 
            this.rbtn5Ster.AutoSize = true;
            this.rbtn5Ster.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbtn5Ster.Location = new System.Drawing.Point(762, 39);
            this.rbtn5Ster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtn5Ster.Name = "rbtn5Ster";
            this.rbtn5Ster.Size = new System.Drawing.Size(118, 42);
            this.rbtn5Ster.TabIndex = 4;
            this.rbtn5Ster.TabStop = true;
            this.rbtn5Ster.Tag = "5";
            this.rbtn5Ster.Text = "5 Ster";
            this.rbtn5Ster.UseVisualStyleBackColor = true;
            this.rbtn5Ster.MouseHover += new System.EventHandler(this.rbtn_MouseHover);
            // 
            // rbtn1Ster
            // 
            this.rbtn1Ster.AutoSize = true;
            this.rbtn1Ster.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbtn1Ster.Location = new System.Drawing.Point(20, 39);
            this.rbtn1Ster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtn1Ster.Name = "rbtn1Ster";
            this.rbtn1Ster.Size = new System.Drawing.Size(118, 42);
            this.rbtn1Ster.TabIndex = 0;
            this.rbtn1Ster.TabStop = true;
            this.rbtn1Ster.Tag = "1";
            this.rbtn1Ster.Text = "1 Ster";
            this.rbtn1Ster.UseVisualStyleBackColor = true;
            this.rbtn1Ster.MouseHover += new System.EventHandler(this.rbtn_MouseHover);
            // 
            // rbtn2Ster
            // 
            this.rbtn2Ster.AutoSize = true;
            this.rbtn2Ster.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbtn2Ster.Location = new System.Drawing.Point(212, 39);
            this.rbtn2Ster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtn2Ster.Name = "rbtn2Ster";
            this.rbtn2Ster.Size = new System.Drawing.Size(118, 42);
            this.rbtn2Ster.TabIndex = 1;
            this.rbtn2Ster.TabStop = true;
            this.rbtn2Ster.Tag = "2";
            this.rbtn2Ster.Text = "2 Ster";
            this.rbtn2Ster.UseVisualStyleBackColor = true;
            this.rbtn2Ster.MouseHover += new System.EventHandler(this.rbtn_MouseHover);
            // 
            // rbtn3Ster
            // 
            this.rbtn3Ster.AutoSize = true;
            this.rbtn3Ster.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbtn3Ster.Location = new System.Drawing.Point(396, 39);
            this.rbtn3Ster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtn3Ster.Name = "rbtn3Ster";
            this.rbtn3Ster.Size = new System.Drawing.Size(118, 42);
            this.rbtn3Ster.TabIndex = 2;
            this.rbtn3Ster.TabStop = true;
            this.rbtn3Ster.Tag = "3";
            this.rbtn3Ster.Text = "3 Ster";
            this.rbtn3Ster.UseVisualStyleBackColor = true;
            this.rbtn3Ster.MouseHover += new System.EventHandler(this.rbtn_MouseHover);
            // 
            // rbtn4Ster
            // 
            this.rbtn4Ster.AutoSize = true;
            this.rbtn4Ster.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbtn4Ster.Location = new System.Drawing.Point(588, 39);
            this.rbtn4Ster.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtn4Ster.Name = "rbtn4Ster";
            this.rbtn4Ster.Size = new System.Drawing.Size(118, 42);
            this.rbtn4Ster.TabIndex = 3;
            this.rbtn4Ster.TabStop = true;
            this.rbtn4Ster.Tag = "4";
            this.rbtn4Ster.Text = "4 Ster";
            this.rbtn4Ster.UseVisualStyleBackColor = true;
            this.rbtn4Ster.MouseHover += new System.EventHandler(this.rbtn_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 466);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "naam wijzigen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 434);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 30);
            this.label2.TabIndex = 12;
            this.label2.Text = "beschrijving wijzigen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 702);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 30);
            this.label3.TabIndex = 13;
            this.label3.Text = "Rating wijzigen";
            // 
            // gbMedewerker
            // 
            this.gbMedewerker.Controls.Add(this.lbMedGegevens);
            this.gbMedewerker.Location = new System.Drawing.Point(588, 63);
            this.gbMedewerker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbMedewerker.Name = "gbMedewerker";
            this.gbMedewerker.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbMedewerker.Size = new System.Drawing.Size(489, 258);
            this.gbMedewerker.TabIndex = 1;
            this.gbMedewerker.TabStop = false;
            this.gbMedewerker.Text = " MedewerkerGegevens";
            // 
            // lbMedGegevens
            // 
            this.lbMedGegevens.AutoSize = true;
            this.lbMedGegevens.Location = new System.Drawing.Point(12, 54);
            this.lbMedGegevens.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMedGegevens.Name = "lbMedGegevens";
            this.lbMedGegevens.Size = new System.Drawing.Size(68, 30);
            this.lbMedGegevens.TabIndex = 0;
            this.lbMedGegevens.Text = "label1";
            // 
            // Vaardigheid_Wijzigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 996);
            this.Controls.Add(this.gbMedewerker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbScore);
            this.Controls.Add(this.tbBeschrijving);
            this.Controls.Add(this.tbVaardigheid);
            this.Controls.Add(this.btnVerwijder);
            this.Controls.Add(this.btnBeschrijving);
            this.Controls.Add(this.btnRating);
            this.Controls.Add(this.btnNaam);
            this.Controls.Add(this.gbVaardigheidGegevens);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Vaardigheid_Wijzigen";
            this.Text = "Vaardigheid_Wijzigen";
            this.Load += new System.EventHandler(this.Vaardigheid_Wijzigen_Load);
            this.gbVaardigheidGegevens.ResumeLayout(false);
            this.gbVaardigheidGegevens.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbScore.ResumeLayout(false);
            this.gbScore.PerformLayout();
            this.gbMedewerker.ResumeLayout(false);
            this.gbMedewerker.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox gbVaardigheidGegevens;
        private Label lbgegevens;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem vaardighedenOverzichtToolStripMenuItem;
        private Button btnNaam;
        private Button btnRating;
        private Button btnBeschrijving;
        private Button btnVerwijder;
        private TextBox tbVaardigheid;
        private TextBox tbBeschrijving;
        private GroupBox gbScore;
        private RadioButton rbtn5Ster;
        private RadioButton rbtn1Ster;
        private RadioButton rbtn2Ster;
        private RadioButton rbtn3Ster;
        private RadioButton rbtn4Ster;
        private Label label1;
        private Label label2;
        private Label label3;
        private GroupBox gbMedewerker;
        private Label lbMedGegevens;
    }
}