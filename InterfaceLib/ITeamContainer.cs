using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface ITeamContainer
    {
        public List<TeamDTO> GetAll();
        public TeamDTO? FindByUserId(int userid);
    }
}
