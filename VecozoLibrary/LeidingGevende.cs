using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public class LeidingGevende : Gebruiker
    {
        public List<Medewerker> Medewerkers { get; set; } = new List<Medewerker>();

        public LeidingGevende(string email, string wachtwoord, string voornaam, string achternaam, int userID = 0, string tussenvoegsel = "") : base(email, wachtwoord, voornaam, achternaam, userID, tussenvoegsel)
        {
        }


        public LeidingGevende(LeidingGevendeDTO dto) : base(dto.Email, dto.Wachtwoord, dto.Voornaam, dto.Achternaam, dto.UserID, dto.Tussenvoegsel)
        {
            Medewerkers = dto.Medewerkers.Select(m => new Medewerker(m)).ToList();
        }
        

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
