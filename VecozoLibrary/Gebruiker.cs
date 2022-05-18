using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public abstract class Gebruiker
    {
        public string Email { get; private set; }
        public string Voornaam { get; private set; }
        public string? Tussenvoegsel { get; private set; }
        public string Achternaam { get; private set; }
        public int UserID { get; private set; }

        public Gebruiker(string email, string voornaam,string achternaam,int userID = 0, string tussenvoegsel = "")
        {
            this.Email = email;
            this.Voornaam = voornaam;
            this.Tussenvoegsel = tussenvoegsel;
            this.Achternaam = achternaam;
            this.UserID = userID;
        }
        public Gebruiker(string email, string voornaam, string achternaam,string tussenvoegsel = "")
        {
            this.Email = email;
            this.Voornaam = voornaam;
            this.Tussenvoegsel = tussenvoegsel;
            this.Achternaam = achternaam;
        }
        public override string ToString()
        {
            return $"{this.Voornaam} {this.Tussenvoegsel} {this.Achternaam}";
        }
    }
}
