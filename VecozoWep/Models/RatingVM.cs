using BusnLogicVecozo;
using InterfaceLib;
using VecozoWep.Models;

namespace VecozoWeb.Models
{
    public class RatingVM
    {
        public int Score { get; set; }
        public string Beschrijving { get; set; }
        public DateTime LaatsteDatum { get; set; }
        public VaardigheidVM Vaardigheid { get; set; }


        public RatingVM(int score, string Beschrijving, DateTime datum, VaardigheidVM vaardigheid)
        {
            this.Score = score;
            this.Beschrijving = Beschrijving;
            this.LaatsteDatum = datum;
            this.Vaardigheid = vaardigheid;
        }

        public RatingVM(Rating rating)
        {
            this.Score = rating.Score;
            this.Beschrijving = rating.Beschrijving;
            this.LaatsteDatum = rating.LaatsteDatum;
            this.Vaardigheid = new VaardigheidVM(rating.Vaardigheid.Naam,rating.Vaardigheid.Id);
        }
        public RatingVM()
        {

        }
    }
}
