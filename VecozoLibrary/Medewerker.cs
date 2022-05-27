using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public class Medewerker : Gebruiker
    {
        public List<LeidingGevende> LeidingGevenden { get; } = new List<LeidingGevende>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
        public Team? MijnTeam { get; set; }


        public Medewerker(string email, string voornaam, string achternaam, int userID, string tussenvoegsel, List<Rating> ratings) : base(email,  voornaam, achternaam, userID, tussenvoegsel)
        {
            Ratings = ratings;
        }

        public Medewerker(string email, string voornaam, string achternaam, string tussenvoegsel = "") : base(email, voornaam, achternaam, tussenvoegsel)
        {
        }
        public Medewerker(MedewerkerDTO dto) : base(dto.Email, dto.Voornaam, dto.Achternaam, dto.Id, dto.Tussenvoegsel)
        {
            //Vaardigheden = dto.Vaardigheden.Select(x => new Vaardigheid(x)).ToList();
            //LeidingGevenden = dto.LeidingGevenden.Select(x => new LeidingGevende(x)).ToList();
            MijnTeam = new(dto.MijnTeam);
        }
        
        public MedewerkerDTO GetDTO()
        {
            return new MedewerkerDTO(this.Email, this.Voornaam, this.Tussenvoegsel, this.Achternaam, this.UserID, this.MijnTeam.GetDTO());
        }
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
