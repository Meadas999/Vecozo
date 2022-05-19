
﻿using BusnLogicVecozo;
using VecozoWeb.Models;

namespace VecozoWep.Models
{
    public class MedewerkerVM
    {
        public string Voornaam { get; private set; }
        public string? Tussenvoegsel { get; private set; }
        public string Achternaam { get; private set; }
        public int UserID { get; private set; }
        public Team? MijnTeam { get; set; }
        public List<RatingVM> Ratings { get; set; }

        public MedewerkerVM(string voornaam, string? tussenvoegsel, string achternaam, int userID, Team? mijnTeam, List<RatingVM> ratings)
        {
            Voornaam = voornaam;
            Tussenvoegsel = tussenvoegsel;
            Achternaam = achternaam;
            UserID = userID;
            MijnTeam = mijnTeam;
            Ratings = ratings;
        }
        public MedewerkerVM(Medewerker medewerker)
        {
            Voornaam = medewerker.Voornaam;
            Tussenvoegsel = medewerker.Tussenvoegsel;
            Achternaam = medewerker.Achternaam;
            UserID = medewerker.UserID;
            MijnTeam = medewerker.MijnTeam;
        }
        public MedewerkerVM()
        {

        }

        public string GetFullName()
        {
            return $"{Voornaam} {Tussenvoegsel} {Achternaam}";
        }
    }
}



