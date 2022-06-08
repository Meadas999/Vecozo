using BusnLogicVecozo;
using System.ComponentModel.DataAnnotations;

namespace VecozoWep.Models
{
    public class LeidinggevendenVM
    {
        public string Voornaam { get; set; }
        public string? Tussenvoegsel { get; set; }
        public string Achternaam { get;  set; }
        public int UserID { get; set; }
        public List<MedewerkerVM> Medewerkers { get; set; }
        public bool IsAdmin { get; set; }

        public LeidinggevendenVM(string voornaam, string? tussenvoegsel, string achternaam, int userID)
        {
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            UserID = userID;
        }

        public LeidinggevendenVM(string voornaam, string? tussenvoegsel, string achternaam, bool isAdmin)
        {
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            IsAdmin = isAdmin;
        }
        
        public LeidinggevendenVM(LeidingGevende admin)
        {
            Voornaam = admin.Voornaam;
            Tussenvoegsel = admin.Tussenvoegsel;
            Achternaam = admin.Achternaam;
            UserID = admin.UserID;
        }

        //public LeidinggevendenVM(Medewerker medewerker)
        //{
        //    Voornaam = admin.Voornaam;
        //    Tussenvoegsel = admin.Tussenvoegsel;
        //    Achternaam = admin.Achternaam;
        //    UserID = admin.UserID;
        //}
        public LeidinggevendenVM()
        {

        }
        
        public override string ToString()
        {
            return $"{Voornaam} {Tussenvoegsel} {Achternaam}";
        }
    }
}

