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
    public partial class LeidinggevendeOverzicht : Form
    {
        public LeidinggevendeOverzicht()
        {
            InitializeComponent();
        }

        private void btnZoeken_Click(object sender, EventArgs e)
        {
            lbxMedewerkerSkills.Items.Clear();
            lbxMatch.Items.Clear();
            if (rbtnMedewerker.Checked && tbZoekOpdracht.Text != "")
                 lbxMatch.Items.AddRange(database.ZoekOpNaam(tbZoekOpdracht.Text).ToArray());
            if (rbtnVaardigheid.Checked && tbZoekOpdracht.Text != "")
                lbxMatch.Items.AddRange(database.ZoekMedewerkerOpVaardigheid(tbZoekOpdracht.Text).ToArray());
        }

        private void btnAlleMedewerkers_Click(object sender, EventArgs e)
        {
            lbxMedewerkerSkills.Items.Clear();
            lbxMatch.Items.Clear();
            lbxMatch.Items.AddRange(database.HaalAlleMedewerkersOp().ToArray());
        }

        private void btnAlleVaardigheden_Click(object sender, EventArgs e)
        {
            lbxMatch.Items.Clear();
            lbxMedewerkerSkills.Items.Clear();
            lbxMatch.Items.AddRange(database.HaalAlleVaardighedenOp().ToArray());
        }

        private void lbxMatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbxMedewerkerSkills.Items.Clear();
            if (lbxMatch.SelectedItem is Medewerker)
            {
                lbxMedewerkerSkills.Items.AddRange(database.HaalVaardighedenVanMedewerkerOp((Medewerker)lbxMatch.SelectedItem).ToArray());
            }
            else if(lbxMatch.SelectedItem is Vaardigheid)
            {
                lbxMedewerkerSkills.Items.AddRange(database.ZoekMedewerkerOpVaardigheid(((Vaardigheid)lbxMatch.SelectedItem).Naam).ToArray());
            }
        }

        private void lbxMedewerkerSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(lbxMedewerkerSkills.SelectedItem.ToString());
        }

        private void LeidinggevendeOverzicht_Load(object sender, EventArgs e)
        {

        }
    }
}
