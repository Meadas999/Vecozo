using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public abstract class Gebruiker
    {
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string Voornaam { get; set; }
        public string? Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public int UserID { get; set; }

        public Gebruiker(string email, string wachtwoord,string voornaam,string achternaam,int userID = 0, string tussenvoegsel = "")
        {
            this.Email = email;
            this.Wachtwoord = wachtwoord;
            this.Voornaam = voornaam;
            this.Tussenvoegsel = tussenvoegsel;
            this.Achternaam = achternaam;
            this.UserID = userID;
        }
        public Gebruiker(string email, string wachtwoord, string voornaam, string achternaam,string tussenvoegsel = "")
        {
            this.Email = email;
            this.Wachtwoord = wachtwoord;
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
