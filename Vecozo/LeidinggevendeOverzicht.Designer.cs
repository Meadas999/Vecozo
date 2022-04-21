namespace VecozoWinForms
{
    partial class LeidinggevendeOverzicht
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
            this.lbxMatch = new System.Windows.Forms.ListBox();
            this.btnZoeken = new System.Windows.Forms.Button();
            this.tbZoekOpdracht = new System.Windows.Forms.TextBox();
            this.rbtnMedewerker = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnVaardigheid = new System.Windows.Forms.RadioButton();
            this.lbxMedewerkerSkills = new System.Windows.Forms.ListBox();
            this.btnAlleMedewerkers = new System.Windows.Forms.Button();
            this.btnAlleVaardigheden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxMatch
            // 
            this.lbxMatch.FormattingEnabled = true;
            this.lbxMatch.ItemHeight = 20;
            this.lbxMatch.Location = new System.Drawing.Point(285, 84);
            this.lbxMatch.Name = "lbxMatch";
            this.lbxMatch.Size = new System.Drawing.Size(244, 244);
            this.lbxMatch.TabIndex = 0;
            this.lbxMatch.SelectedIndexChanged += new System.EventHandler(this.lbxMatch_SelectedIndexChanged);
            // 
            // btnZoeken
            // 
            this.btnZoeken.Location = new System.Drawing.Point(69, 252);
            this.btnZoeken.Name = "btnZoeken";
            this.btnZoeken.Size = new System.Drawing.Size(136, 51);
            this.btnZoeken.TabIndex = 1;
            this.btnZoeken.Text = "Zoek";
            this.btnZoeken.UseVisualStyleBackColor = true;
            this.btnZoeken.Click += new System.EventHandler(this.btnZoeken_Click);
            // 
            // tbZoekOpdracht
            // 
            this.tbZoekOpdracht.Location = new System.Drawing.Point(69, 207);
            this.tbZoekOpdracht.Name = "tbZoekOpdracht";
            this.tbZoekOpdracht.Size = new System.Drawing.Size(125, 27);
            this.tbZoekOpdracht.TabIndex = 2;
            // 
            // rbtnMedewerker
            // 
            this.rbtnMedewerker.AutoSize = true;
            this.rbtnMedewerker.Location = new System.Drawing.Point(16, 113);
            this.rbtnMedewerker.Name = "rbtnMedewerker";
            this.rbtnMedewerker.Size = new System.Drawing.Size(112, 24);
            this.rbtnMedewerker.TabIndex = 3;
            this.rbtnMedewerker.TabStop = true;
            this.rbtnMedewerker.Text = "Medewerker";
            this.rbtnMedewerker.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zoekopdracht:";
            // 
            // rbtnVaardigheid
            // 
            this.rbtnVaardigheid.AutoSize = true;
            this.rbtnVaardigheid.Location = new System.Drawing.Point(156, 113);
            this.rbtnVaardigheid.Name = "rbtnVaardigheid";
            this.rbtnVaardigheid.Size = new System.Drawing.Size(110, 24);
            this.rbtnVaardigheid.TabIndex = 5;
            this.rbtnVaardigheid.TabStop = true;
            this.rbtnVaardigheid.Text = "Vaardigheid";
            this.rbtnVaardigheid.UseVisualStyleBackColor = true;
            // 
            // lbxMedewerkerSkills
            // 
            this.lbxMedewerkerSkills.FormattingEnabled = true;
            this.lbxMedewerkerSkills.ItemHeight = 20;
            this.lbxMedewerkerSkills.Location = new System.Drawing.Point(545, 84);
            this.lbxMedewerkerSkills.Name = "lbxMedewerkerSkills";
            this.lbxMedewerkerSkills.Size = new System.Drawing.Size(244, 244);
            this.lbxMedewerkerSkills.TabIndex = 6;
            this.lbxMedewerkerSkills.SelectedIndexChanged += new System.EventHandler(this.lbxMedewerkerSkills_SelectedIndexChanged);
            // 
            // btnAlleMedewerkers
            // 
            this.btnAlleMedewerkers.Location = new System.Drawing.Point(12, 12);
            this.btnAlleMedewerkers.Name = "btnAlleMedewerkers";
            this.btnAlleMedewerkers.Size = new System.Drawing.Size(136, 51);
            this.btnAlleMedewerkers.TabIndex = 7;
            this.btnAlleMedewerkers.Text = "Alle Medwerkers";
            this.btnAlleMedewerkers.UseVisualStyleBackColor = true;
            this.btnAlleMedewerkers.Click += new System.EventHandler(this.btnAlleMedewerkers_Click);
            // 
            // btnAlleVaardigheden
            // 
            this.btnAlleVaardigheden.Location = new System.Drawing.Point(174, 12);
            this.btnAlleVaardigheden.Name = "btnAlleVaardigheden";
            this.btnAlleVaardigheden.Size = new System.Drawing.Size(136, 51);
            this.btnAlleVaardigheden.TabIndex = 8;
            this.btnAlleVaardigheden.Text = "Alle Vaardigeheden";
            this.btnAlleVaardigheden.UseVisualStyleBackColor = true;
            this.btnAlleVaardigheden.Click += new System.EventHandler(this.btnAlleVaardigheden_Click);
            // 
            // LeidinggevendeOverzicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 352);
            this.Controls.Add(this.btnAlleVaardigheden);
            this.Controls.Add(this.btnAlleMedewerkers);
            this.Controls.Add(this.lbxMedewerkerSkills);
            this.Controls.Add(this.rbtnVaardigheid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbtnMedewerker);
            this.Controls.Add(this.tbZoekOpdracht);
            this.Controls.Add(this.btnZoeken);
            this.Controls.Add(this.lbxMatch);
            this.Name = "LeidinggevendeOverzicht";
            this.Text = "LeidinggevendeOverzicht";
            this.Load += new System.EventHandler(this.LeidinggevendeOverzicht_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbxMatch;
        private Button btnZoeken;
        private TextBox tbZoekOpdracht;
        private RadioButton rbtnMedewerker;
        private Label label1;
        private RadioButton rbtnVaardigheid;
        private ListBox lbxMedewerkerSkills;
        private Button btnAlleMedewerkers;
        private Button btnAlleVaardigheden;
    }
}