using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class TeamDTO
    {
        public string Kleur { get; }
        public string Taak { get; }
        public float GemRating { get; }
        public List<MedewerkerDTO> GroepLeden { get; } = new List<MedewerkerDTO>();

        public TeamDTO(string kleur, string taak, float gemRating, List<MedewerkerDTO> groepLeden)
        {
            Kleur = kleur;
            Taak = taak;
            GemRating = gemRating;
            GroepLeden = groepLeden;
        }
    }
}
