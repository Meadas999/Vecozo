using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class RatingDTO
    {
        public int Id { get; }
        public ScoreDTO Score { get; }
        public string ScoreBeschrijving { get; }
        public string Beschrijving { get; }
        public DateTime LaatsteDatum { get; set; }
    }
}
