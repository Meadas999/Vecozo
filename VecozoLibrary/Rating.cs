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
        public int Id { get; }
        public Score Score { get; }
        public string ScoreBeschrijving { get; }
        public string Beschrijving { get; }
        public DateTime LaatsteDatum { get; set; }


        public Rating(Score score, int id, string Beschrijving, DateTime datum)
        {
            this.Score = score;
            this.Id = id;
            this.Beschrijving = Beschrijving;
            this.ScoreBeschrijving = GetScoreBeschrijving((int)this.Score);
        }

        public Rating(Score score)
        {
            this.Score = score;
            this.LaatsteDatum = DateTime.Now;
        }

        public string GetScoreBeschrijving(int rating)
        {
            string beschrijving = "";
            if (rating == 1)
                beschrijving = "heel klein beetje ervaring";
            if (rating == 2)
                beschrijving = "Ik kan een eenvoudige applicaties maken met de programmeertaal";
            if (rating == 3)
                beschrijving = "Ik kan medium applicaties maken met de progammeertaal";
            if (rating == 4)
                beschrijving = "Ik kan complexe applicaties maken met de programmeertaal";
            if (rating == 5)
                beschrijving = "Ik weet alles over de programmeertaal";
            return beschrijving;
        }

        public RatingDTO GetDTO()
        {
            return new RatingDTO(this.Id, (ScoreDTO)this.Score, this.Beschrijving, this.LaatsteDatum);
        }
        public override string ToString()
        {
            return $"Score: {this.Score}\n\nBeschrijving: {this.Beschrijving}nLaatstedatum: {this.LaatsteDatum}";
        }
    }
}
