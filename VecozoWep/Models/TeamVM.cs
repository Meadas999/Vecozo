using BusnLogicVecozo;
using VecozoWep.Models;

namespace VecozoWeb.Models
{
    public class TeamVM
    {
        public int Id { get; set; }
        public string Kleur { get; set; }
        public string Taak { get; set; }
        public double GemRating { get; set; }
        public List<MedewerkerVM> GroepLeden { get; set; } = new List<MedewerkerVM>();

        public TeamVM()
        {
            
        }

        public TeamVM(int id, string kleur, string taak, float gemRating)
        {
            Id = id;
            Kleur = kleur;
            Taak = taak;
            GemRating = gemRating;
        }

        public TeamVM(Team team)
        {
            Id = team.Id;
            Kleur = team.Kleur;
            Taak = team.Taak;
            GemRating = team.GemRating;
        }

        public override string ToString()
        {
            return $"{this.Kleur}";
        }
    }
    
}
