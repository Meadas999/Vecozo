using BusnLogicVecozo;
using System.ComponentModel.DataAnnotations;
using VecozoWeb.Models;

namespace VecozoWep.Models
{
    public class MedewerkerVM
    {
        [Required]
        public string Voornaam { get; set; }
        public string? Tussenvoegsel { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Wachtwoord { get; set; }
        public int UserID { get; set; }
        public TeamVM? MijnTeam { get; set; } = new();
        public List<VaardigheidVM> vaardigheden { get; set; }
        public LeidinggevendenVM Leidinggevende { get; set; }
        public bool IsAdmin { get; set; }

        public MedewerkerVM(string voornaam, string? tussenvoegsel, string achternaam, int userID, TeamVM? mijnTeam)
        {
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            UserID = userID;
            MijnTeam = mijnTeam;
        }

        public MedewerkerVM(string email,string wachtwoord,string voornaam, string? tussenvoegsel, string achternaam,bool isAdmin)
        {
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            Email = email;
            Wachtwoord = wachtwoord;
            IsAdmin = isAdmin;
        }
        public MedewerkerVM(Medewerker medewerker)
        {
            Voornaam = medewerker.Voornaam;
            Tussenvoegsel = medewerker.Tussenvoegsel;
            Achternaam = medewerker.Achternaam;
            UserID = medewerker.UserID;
            MijnTeam = new (medewerker.MijnTeam);
        }
        public MedewerkerVM()
        {


