using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public class Team
    {
        public int Id { get; set; }
        public string Kleur { get; }
        public string Taak { get; }
        public double GemRating { get; }
        public List<Medewerker> GroepLeden { get; } = new List<Medewerker>();

        public Team(int id, string kleur, string taak, double gemRating)
        {
            id = Id;
            Kleur = kleur;
            Taak = taak;
            GemRating = gemRating;
        }

        public Team(TeamDTO dto)
        {
            Id = dto.Id;
            this.Kleur = dto.Kleur;
            this.Taak = dto.Taak;
            this.GemRating = dto.GemRating;
            //this.GroepLeden = dto.GroepLeden.Select(x => new Medewerker(x)).ToList();

        }


        public override string ToString()
        {
            return $"Teamkleur: {this.Kleur}\nTaak: {this.Taak}";
        }

    }
}
