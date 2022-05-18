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
        public string WachtwoordHash { get; }
        public string Voornaam { get; }
        public string? Tussenvoegsel { get; }
        public string Achternaam { get; }
        public int Id { get; }
        public List<LeidingGevendeDTO> LeidingGevenden { get; set; } = new List<LeidingGevendeDTO>();
        public List<VaardigheidDTO> Vaardigheden { get; set; } = new List<VaardigheidDTO>();
        public TeamDTO? MijnTeam { get; set; }
       
        public MedewerkerDTO(string email, string voornaam, string? tussenvoegsel, string achternaam, int userID)
        {
            Email = email;
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            this.Id = userID;
        }

        public MedewerkerDTO(string wachtwoordHash, int id)
        {
            WachtwoordHash = wachtwoordHash;
            Id = id;
        }
        public MedewerkerDTO()
        {

        }
    }
}
