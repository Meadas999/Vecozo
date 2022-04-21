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

        public LeidingGevendeDTO(string email, string wachtwoord, string voornaam, string? tussenvoegsel, string achternaam, int userID)
        {
            Email = email;
            Wachtwoord = wachtwoord;
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            this.UserID = userID;
        }
    }
    
    
}
