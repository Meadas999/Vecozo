using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public class MedewerkerContainer
    {
        private readonly IMedewerkerContainer medewerkerContainer;

        public MedewerkerContainer(IMedewerkerContainer medewerkerContainer)
        {
            this.medewerkerContainer = medewerkerContainer;
        }
        
        public Medewerker Inloggen(string email, string wachtwoord)
        {
            MedewerkerDTO dto = medewerkerContainer.Inloggen(email, wachtwoord);
            if (dto != null)
            {
                Medewerker medewerker = new Medewerker(dto);
                return medewerker;
            }
            else
            {
                return null;
            }
            
        }
        public List<Medewerker> ZoekMedewerkerOpVaardigheid(string naam)
        {
            List<MedewerkerDTO> dtos = medewerkerContainer.ZoekMedewerkerOpVaardigheid(naam);
            List<Medewerker> medewerkers = new List<Medewerker>();
            foreach (MedewerkerDTO dto in dtos)
            {
                Medewerker medewerker = new Medewerker(dto);
                medewerkers.Add(medewerker);
            }
            return medewerkers;
        }
        public List<Medewerker> HaalAlleMedewerkersOp()
        {
            List<MedewerkerDTO> dtos = medewerkerContainer.HaalAlleMedewerkersOp();
            List<Medewerker> medewerkers = new List<Medewerker>();
            foreach (MedewerkerDTO dto in dtos)
            {
                Medewerker medewerker = new Medewerker(dto);
                medewerkers.Add(medewerker);
            }
            return medewerkers;
        }
        public Medewerker FindById(int id)
        {
            MedewerkerDTO dto = medewerkerContainer.FindById(id);
            Medewerker medewerker = new Medewerker(dto);
            return medewerker;
        }

        public Team GetTeamById(int userid)
        {
            Team team = new(medewerkerContainer.GetTeamById(userid));
            return team;
        }
    }
}