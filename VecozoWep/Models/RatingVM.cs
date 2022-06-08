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
        public string vaardigheidNaam { get; set; }
        public int vaardigheidId { get; set; }
        public VaardigheidVM Vaardigheid { get; set; }


        public RatingVM(int score, string Beschrijving, DateTime datum, VecozoWep.Models.VaardigheidVM vaardigheid)
        {
            this.Score = score;
            this.Beschrijving = Beschrijving;
            this.LaatsteDatum = datum;
            this.vaardigheidNaam = vaardigheid.Naam;
            this.vaardigheidId = vaardigheid.Id;
            this.Vaardigheid = vaardigheid;
        }


        public RatingVM(Rating rating)
        {
            this.Score = rating.Score;
            this.Beschrijving = rating.Beschrijving;
            this.LaatsteDatum = rating.LaatsteDatum;
            this.Vaardigheid = new VaardigheidVM(rating.Vaardigheid.Naam,rating.Vaardigheid.Id);
        }
        public Rating GetRating()
        {
            Rating rating = new Rating(Score, Beschrijving, LaatsteDatum, Vaardigheid.GetVaardigheid());
            return rating;
        }
        public RatingVM()
        {

        }
    }
}
