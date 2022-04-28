using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class TeamDTO
    {
        public int Id { get; }
        public string Kleur { get; }
        public string Taak { get; }
        public float GemRating { get; }
        public List<MedewerkerDTO> GroepLeden { get; } = new List<MedewerkerDTO>();

        public TeamDTO(int id, string kleur, string taak, float gemRating, List<MedewerkerDTO> groepLeden)
        {
            Id = id;
            Kleur = kleur;
            Taak = taak;
            GemRating = gemRating;
            GroepLeden = groepLeden;
        }
    }
}
