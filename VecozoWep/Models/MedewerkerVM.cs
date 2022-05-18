using BusnLogicVecozo;

namespace VecozoWep.Models
{
    public class MedewerkerVM
    {
        public string Voornaam { get; private set; }
        public string? Tussenvoegsel { get; private set; }
        public string Achternaam { get; private set; }
        public int UserID { get; private set; }
        public Team? MijnTeam { get; set; }
        public List<VaardigheidVM> vaardigheden { get; set; }

        public MedewerkerVM(string voornaam, string? tussenvoegsel, string achternaam, int userID, Team? mijnTeam)
        {
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            UserID = userID;
            MijnTeam = mijnTeam;
        }
        public MedewerkerVM(Medewerker medewerker)
        {
            Voornaam = medewerker.Voornaam;
            Tussenvoegsel = medewerker.Tussenvoegsel;
            Achternaam = medewerker.Achternaam;
            UserID = medewerker.UserID;
            MijnTeam = medewerker.MijnTeam;
        }
        public MedewerkerVM()
        {

        }

        public string GetFullName()
        {
            return $"{Voornaam} {Tussenvoegsel} {Achternaam}";
        }
    }
}
