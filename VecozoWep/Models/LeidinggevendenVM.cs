using BusnLogicVecozo;

namespace VecozoWep.Models
{
    public class LeidinggevendenVM
    {
        public string Voornaam { get; private set; }
        public string? Tussenvoegsel { get; private set; }
        public string Achternaam { get; private set; }
        public int UserID { get; private set; }
        public List<MedewerkerVM> Medewerkers { get; set; }

        public LeidinggevendenVM(string voornaam, string? tussenvoegsel, string achternaam, int userID)
        {
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            UserID = userID;
        }

        public LeidinggevendenVM(LeidingGevende admin)
        {
            Voornaam = admin.Voornaam;
            Tussenvoegsel = admin.Tussenvoegsel;
            Achternaam = admin.Achternaam;
            UserID = admin.UserID;
        }

        public LeidinggevendenVM()
        {

        }
    }
}
