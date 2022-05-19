using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public class Rating
    {
        public int Score { get; }
        public string Beschrijving { get; }
        public DateTime LaatsteDatum { get; set; }
        public Vaardigheid Vaardigheid { get; set; }


        public Rating(int score, string Beschrijving, DateTime datum, Vaardigheid vaardigheid)
        {
            this.Score = score;
            this.Beschrijving = Beschrijving;
            this.LaatsteDatum = datum;
            this.Vaardigheid = vaardigheid;
        }

        public Rating(RatingDTO rating)
        {
            this.Score = rating.Score;
            this.Beschrijving = rating.Beschrijving;
            this.LaatsteDatum = rating.LaatsteDatum;
            this.Vaardigheid = new Vaardigheid(rating.vaardigheidDTO);
        }
      
        public RatingDTO GetDTO()
        {
            return new RatingDTO( this.Score, this.Beschrijving, this.LaatsteDatum, Vaardigheid.GetDTO());
        }
        public override string ToString()
        {
            return $"Score: {this.Score}\n\nBeschrijving: {this.Beschrijving}nLaatstedatum: {this.LaatsteDatum}";
        }
    }
}
