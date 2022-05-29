using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class RatingDTO
    {

        public int Score { get; }
        public string ScoreBeschrijving { get; }
        public string Beschrijving { get; }
        public DateTime LaatsteDatum { get; set; }
        public VaardigheidDTO vaardigheidDTO { get; set; }

        public RatingDTO(int score, string beschrijving, DateTime laatsteDatum, VaardigheidDTO vaardigheidDTO)
        {
            Score = score;
            Beschrijving = beschrijving;
            LaatsteDatum = laatsteDatum;
            this.vaardigheidDTO = vaardigheidDTO;
        }
        public RatingDTO(int score, string beschrijving, DateTime laatsteDatum)
        {
            Score = score;
            Beschrijving = beschrijving;
            LaatsteDatum = laatsteDatum;
        }
    }
}
