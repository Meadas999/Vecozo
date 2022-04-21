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
            Medewerker medewerker = new Medewerker(dto);
            return medewerker;
        }
    }
}