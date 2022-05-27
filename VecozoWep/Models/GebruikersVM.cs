using BusnLogicVecozo;
using DALMSSQL;
using VecozoWep.Models;

namespace VecozoWeb.Models
{
    public class GebruikersVM
    {
        public List<LeidinggevendenVM> Leidinggevenden { get; set; } = new();
        public MedewerkerVM Medewerker { get; set; } = new();
        public LeidinggevendenVM Leidinggevende { get; set; } = new();
        public TeamVM Team { get; set; } = new();
        public List<TeamVM> Teams { get; set; } = new();

    }
}
