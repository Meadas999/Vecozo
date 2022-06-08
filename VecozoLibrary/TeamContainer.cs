using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public class TeamContainer
    {
        private readonly ITeamContainer container;

        public TeamContainer(ITeamContainer container)
        {
            this.container = container;
        }

        public List<Team> GetAll()
        {
            return container.GetAll().Select(x => new Team(x)).ToList();
        }

        public Team FindById(int id)
        {
            TeamDTO dto = container.FindByUserId(id);
            return new Team(dto);
        }

        public List<Medewerker> GetMedewerkersFromTeam(int teamid)
        {
            List<MedewerkerDTO> dtos = container.GetMedewerkersFromTeam(teamid);
            List<Medewerker> medewerkers = new List<Medewerker>();
            if (dtos == null)
            {
                return null;
            }
            else
            {
                foreach (MedewerkerDTO m in dtos)
                {
                    medewerkers.Add(new Medewerker(m));
                }
            }
            return medewerkers;
        }

        public void UpdateTeamMedewerker(Medewerker medewerker)
        {
            container.UpdateTeamMedewerker(medewerker.GetDTO());
        }

        public void Update(Team team)
        {
            container.Update(team.GetDTO());
        }
    }
}
