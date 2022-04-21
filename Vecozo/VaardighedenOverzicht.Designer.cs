using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VecozoWinForms
{
    partial class VaardighedenOverzicht
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
            this.lbxVaardigheden = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaardigheidToevoegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbVaardigheden = new System.Windows.Forms.Label();
            this.lbGegevens = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxVaardigheden
            // 
            this.lbxVaardigheden.FormattingEnabled = true;
            this.lbxVaardigheden.ItemHeight = 20;
            this.lbxVaardigheden.Location = new System.Drawing.Point(51, 89);
            this.lbxVaardigheden.Name = "lbxVaardigheden";
            this.lbxVaardigheden.Size = new System.Drawing.Size(273, 324);
            this.lbxVaardigheden.TabIndex = 0;
            this.lbxVaardigheden.SelectedIndexChanged += new System.EventHandler(this.lbxVaardigheden_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vaardigheidToevoegenToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "menu";
            // 
            // vaardigheidToevoegenToolStripMenuItem
            // 
            this.vaardigheidToevoegenToolStripMenuItem.Name = "vaardigheidToevoegenToolStripMenuItem";
            this.vaardigheidToevoegenToolStripMenuItem.Size = new System.Drawing.Size(247, 26);
            this.vaardigheidToevoegenToolStripMenuItem.Text = "Vaardigheid toevoegen";
            this.vaardigheidToevoegenToolStripMenuItem.Click += new System.EventHandler(this.vaardigheidToevoegenToolStripMenuItem_Click);
            // 
            // lbVaardigheden
            // 
            this.lbVaardigheden.AutoSize = true;
            this.lbVaardigheden.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbVaardigheden.Location = new System.Drawing.Point(48, 45);
            this.lbVaardigheden.Name = "lbVaardigheden";
            this.lbVaardigheden.Size = new System.Drawing.Size(156, 31);
            this.lbVaardigheden.TabIndex = 2;
            this.lbVaardigheden.Text = "Vaardigheden";
            // 
            // lbGegevens
            // 
            this.lbGegevens.AutoSize = true;
            this.lbGegevens.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbGegevens.Location = new System.Drawing.Point(348, 89);
            this.lbGegevens.Name = "lbGegevens";
            this.lbGegevens.Size = new System.Drawing.Size(0, 31);
            this.lbGegevens.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(339, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vaardigheid details:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(604, 340);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(149, 73);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "Update Vaardigheid";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // VaardighedenOverzicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbGegevens);
            this.Controls.Add(this.lbVaardigheden);
            this.Controls.Add(this.lbxVaardigheden);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VaardighedenOverzicht";
            this.Text = "VaardighedenOverzicht";
            this.Load += new System.EventHandler(this.VaardighedenOverzicht_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lbxVaardigheden;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem vaardigheidToevoegenToolStripMenuItem;
        private Label lbVaardigheden;
        private Label lbGegevens;
        private Label label1;
        private Button btnUpdate;
    }
}