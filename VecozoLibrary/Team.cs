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
        public string Kleur { get; }
        public string Taak { get; }
        public float GemRating { get; }
        public List<Medewerker> GroepLeden { get; } = new List<Medewerker>();

        public Team(string kleur, string taak)
        {
            this.Kleur = kleur;
            this.Taak = taak;
        }

        public Team(TeamDTO dto)
        {
            this.Kleur = dto.Kleur;
            this.Taak = dto.Taak;
            this.GemRating = dto.GemRating;
            this.GroepLeden = dto.GroepLeden.Select(x => new Medewerker(x)).ToList();

        }


        public override string ToString()
        {
            return $"Teamkleur: {this.Kleur}\nTaak: {this.Taak}";
        }

    }
}
