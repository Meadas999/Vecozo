using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VecozoWinForms
{
    public partial class VaardighedenOverzicht : Form
    {
        Medewerker jan;
        Database database = new Database();
        internal VaardighedenOverzicht()
        {
            InitializeComponent();
            jan = database.Inloggen("zein123@hotmail.com", "zein123");
            jan.Vaardigheden = database.HaalVaardighedenVanMedewerkerOp(jan);
            lbxVaardigheden.Items.AddRange(jan.Vaardigheden.ToArray());
        }

        private void vaardigheidToevoegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new(jan);
            form.ShowDialog(this);
        }

        private void lbxVaardigheden_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxVaardigheden.SelectedItem is Vaardigheid)
            {
                lbGegevens.Text = lbxVaardigheden.SelectedItem.ToString();
                btnUpdate.Enabled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Vaardigheid_Wijzigen vw = new(jan,(Vaardigheid)lbxVaardigheden.SelectedItem);
            vw.ShowDialog(this);
        }

        public void UpdateLbxVaardigheden()
        {
            lbxVaardigheden.Items.Clear();
            lbxVaardigheden.Items.AddRange(database.HaalVaardighedenVanMedewerkerOp(jan).ToArray());
        }
        private void VaardighedenOverzicht_Load(object sender, EventArgs e)
        {

        }
    }
}
