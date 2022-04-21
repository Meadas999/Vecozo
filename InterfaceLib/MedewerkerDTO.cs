using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class MedewerkerDTO
    {

        public string Email { get; }
        public string Wachtwoord { get; }
        public string Voornaam { get; }
        public string? Tussenvoegsel { get; }
        public string Achternaam { get; }
        public int userID { get; }
        public List<LeidingGevendeDTO> LeidingGevenden { get; set; } = new List<LeidingGevendeDTO>();
        public List<VaardigheidDTO> Vaardigheden { get; set; } = new List<VaardigheidDTO>();
        public TeamDTO? MijnTeam { get; set; }
       
        public MedewerkerDTO(string email, string wachtwoord, string voornaam, string? tussenvoegsel, string achternaam, int userID)
        {
            Email = email;
            Wachtwoord = wachtwoord;
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            this.userID = userID;
        }
    }
}
