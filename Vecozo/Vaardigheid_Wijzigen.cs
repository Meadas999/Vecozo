using BusnLogicVecozo;
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
    public partial class Vaardigheid_Wijzigen : Form
    {
        MedewerkerDTO med;
        Rating? rating;
        VaardigheidDTO vaardigheid;
        Database database = new Database();
        internal Vaardigheid_Wijzigen(MedewerkerDTO med,VaardigheidDTO vaardigheid)
        {
            InitializeComponent();
            this.med = med;
            this.vaardigheid = vaardigheid;
        }

        private void vaardighedenOverzichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rbtn_MouseHover(object sender, EventArgs e)
        {
            RadioButton? rbtn = sender as RadioButton;
            ToolTip toolTip = new ToolTip();
            if(rbtn != null && rbtn.Tag!=null)
            {
                rating = new((Score)Enum.Parse(typeof(Score), rbtn.Tag.ToString()));
                toolTip.SetToolTip(rbtn, rating.GetScoreBeschrijving(Convert.ToInt32(rbtn.Tag)));
            }

        }

        private void Vaardigheid_Wijzigen_Load(object sender, EventArgs e)
        {
            HoudAangepasteGegevensBij();
        }

        private void HoudAangepasteGegevensBij()
        {
            if(database.GetVaardigheidVanMedewerker(vaardigheid) != null)
            {
                lbgegevens.Text = database.GetVaardigheidVanMedewerker(vaardigheid).ToString();
            }
            else
            {
                lbgegevens.Text = "Vaardigheid is verwijderd";
            }
            ((VaardighedenOverzicht)this.Owner).UpdateLbxVaardigheden();
            lbMedGegevens.Text = med.ToString();
        }
        private void btnRating_Click(object sender, EventArgs e)
        {
            if (GevinkteRadioButton() != null)
                database.UpdateRatingVanVaardigheid(med, vaardigheid,Convert.ToInt32(GevinkteRadioButton().Tag));
            HoudAangepasteGegevensBij();
        }

        private RadioButton? GevinkteRadioButton()
        {
            foreach(RadioButton? radioButton in gbScore.Controls.OfType<RadioButton>())
                if(radioButton.Checked)
                    return radioButton;
            return null;
        }

        private void btnNaam_Click(object sender, EventArgs e)
        {
            if (tbVaardigheid.Text != "")
                database.UpdateNaamVanVaarigheid(med, vaardigheid, tbVaardigheid.Text);
            HoudAangepasteGegevensBij();
        }

        private void btnBeschrijving_Click(object sender, EventArgs e)
        {
            if (tbBeschrijving.Text != "")
                database.UpdateBeschrijvingVanVaardigheid(med, vaardigheid, tbBeschrijving.Text);
            HoudAangepasteGegevensBij();
        }

        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Weer je zeker dat je deze vaardigheid" +
                $" wilt verwijderen!\n\n{vaardigheid}","Vaardigeheid verwijderen",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                database.VerwijderVaarigheidVanMedewerker(med,vaardigheid);
            HoudAangepasteGegevensBij();
        }

        private void tbVaardigheid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
