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
            return new Team(container.FindById(id));
        }




    }
}
