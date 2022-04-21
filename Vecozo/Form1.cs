using System;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusnLogicVecozo;

namespace VecozoWinForms
{
    public partial class Form1 : Form
    {
        //Medewerker jan;
        //Rating? rating;
        
        public Form1(Medewerker med)
        {
            InitializeComponent();
            jan = med;
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if(CheckIfRbtnIsChecked() != null && ZijnAlleVeldenIngevoerd())
            {
                database.VoegVaardigheidToe(jan, tbVaardigheid.Text, tbType.Text, (int)rating.Score, tbBeschrijving.Text); 
                ((VaardighedenOverzicht)this.Owner).UpdateLbxVaardigheden();
                ClearAllFields();
                NaarDeOverzichtForm();
            }
        }

        //private List<Control> IngevuldeVelden()
        //{
        //    List<Control> list = new List<Control>();
        //    foreach(Control control in this.Controls)
        //    {
        //        RadioButton? rbtn = control as RadioButton;
        //        if(control.Tag != null && control.Text != "" || rbtn != null && rbtn.Checked)
        //        {
        //            list.Add(control);
        //            Rating ratTest = new RatTest(control.Text, Convert.ToInt32(rbtn.Tag.ToString()));
        //        }
        //    }
        //    return list;
        //}

        //private void UpdateVaardigheid()
        //{
        //    Vaardigheid vaar = new Vaardigheid("naam");
        //    Rating rating = new Rating("beschrijving",3,DateTime.Now);
        //    foreach(var control in IngevuldeVelden())
        //    {
        //        RadioButton rbtn = control as RadioButton;
        //        if(control.Tag.ToString() == "Naam")
        //        {
        //            vaar.Naam = control.Text;
        //            vaardigheidContainer.Update(vaar);
        //        }
        //        else if(control.)
        //        {

        //        }
        //    }
        //}
        private void NaarDeOverzichtForm()
        {
            this.Hide();
        }

        private RadioButton? CheckIfRbtnIsChecked()
        {
            foreach(RadioButton rbtn in gbScore.Controls.OfType<RadioButton>())
            {
                if (rbtn.Checked)
                    return rbtn;
            }
            return null;
        }

        private void Rbtn_MouseHover(object sender, EventArgs e)
        {
            RadioButton? rb = sender as RadioButton;
            ToolTip toolTip = new ToolTip();
            if (rb != null && rb.Tag != null)
            {
                rating = new((Score.Scores)Enum.Parse(typeof(Score.Scores), rb.Tag.ToString()));
                toolTip.SetToolTip(rb, rating.GetScoreBeschrijving(Convert.ToInt32(rb.Tag)));
            }
        }

        private void ClearAllFields()
        {
            tbBeschrijving.Text = "";
            tbVaardigheid.Text = "";
            foreach (RadioButton rbtn in gbScore.Controls.OfType<RadioButton>())
                rbtn.Checked = false;
        }

        private bool ZijnAlleVeldenIngevoerd()
        {
            foreach(TextBox tb in Controls.OfType<TextBox>())
            {
                if (tb.Text == "")
                    return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tbBeschrijving_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbVaardigheid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}