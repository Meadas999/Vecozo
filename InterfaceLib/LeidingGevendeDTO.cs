using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class LeidingGevendeDTO
    {
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string Voornaam { get; set; }
        public string? Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public int UserID { get; set; }
        public List<MedewerkerDTO> Medewerkers { get; } = new List<MedewerkerDTO>();

        public LeidingGevendeDTO(string email, string wachtwoord, string voornaam, string achternaam, int userID, string? tussenvoegsel = null)
        {
            Email = email;
            Wachtwoord = wachtwoord;
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            this.UserID = userID;
        }
        public LeidingGevendeDTO(string email, string voornaam, string achternaam, int userID, List<MedewerkerDTO> medewerkers, string? tussenvoegsel = null)
        {
            Email = email;
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            this.UserID = userID;
            Medewerkers = medewerkers;
        }

        public LeidingGevendeDTO(string wachtwoord, int userID)
        {
            Wachtwoord = wachtwoord;
            UserID = userID;
        }
    }
    
    
}
