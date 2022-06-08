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
        public string? Tussenvoegsel { get; set; }
        public string Achternaam { get; }
        public int Id { get; }
        public List<LeidingGevendeDTO> LeidingGevenden { get; set; } = new List<LeidingGevendeDTO>();
        public List<RatingDTO> Ratings { get; set; } = new List<RatingDTO>();
        public TeamDTO? MijnTeam { get; set; }
       
        public MedewerkerDTO(string email, string voornaam, string? tussenvoegsel, string achternaam, int userID)
        {
            Email = email;
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            this.Id = userID;
            
        }

        public MedewerkerDTO(string email, string voornaam, string? tussenvoegsel, string achternaam, int userID, TeamDTO mijnTeam)
        {
            Email = email;
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            this.Id = userID;
            MijnTeam = mijnTeam;
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
