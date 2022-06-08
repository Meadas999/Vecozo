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

        public void Create(Medewerker medewerker,string wachtwoord)
        {
            medewerkerContainer.Create(medewerker.GetDTOMetTeam(),wachtwoord);
        }
        
        public Medewerker? Inloggen(string email, string wachtwoord)
        {
            MedewerkerDTO? dto = medewerkerContainer.Inloggen(email, wachtwoord);
            if (dto != null)
            {
                Medewerker medewerker = new Medewerker(dto);
                return medewerker;
            }
            return null;
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
                //dto.MijnTeam = medewerkerContainer.GetTeamVanMedewerker(dto);
                Medewerker medewerker = new Medewerker(dto);
                medewerkers.Add(medewerker);
            }
            return medewerkers;
        }

        public void KoppelTeamsAanMedewerkers()
        {
            List<Medewerker> med = HaalAlleMedewerkersOp();
            foreach(var m in med)
            {
                m.MijnTeam = new Team(medewerkerContainer.GetTeamVanMedewerker(m.GetDTO()));
            }
        }
        public Medewerker FindById(int id)
        {
            MedewerkerDTO dto = medewerkerContainer.FindById(id);
            //dto.MijnTeam = medewerkerContainer.GetTeamVanMedewerker(dto);
            Medewerker medewerker = new Medewerker(dto);
            return medewerker;
        }
        public Team GetTeamVanMedewerker(Medewerker med)
        {
            TeamDTO dto = medewerkerContainer.GetTeamVanMedewerker(med.GetDTO());
            Team team = new Team(dto);
            return team;
        }
        public void KoppelMedewerkerAanLeidinggevenden(Medewerker med, LeidingGevende leid)
        {
            medewerkerContainer.KoppelMedewerkerAanLeidinggevenden(med.GetDTO(), leid.GetDTO());
        }

    }
}