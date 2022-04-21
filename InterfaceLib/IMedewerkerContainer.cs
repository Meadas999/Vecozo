using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IMedewerkerContainer
    {
        public MedewerkerDTO? Inloggen(string email, string wachtwoord);
        public List<MedewerkerDTO> ZoekOpNaam(string naam);
        public List<MedewerkerDTO> ZoekMedewerkerOpVaardigheid(string naam);
        public List<MedewerkerDTO> HaalAlleMedewerkersOp();
    }
}
