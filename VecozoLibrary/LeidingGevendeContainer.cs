using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public class LeidingGevendeContainer
    {
        private readonly ILeidinggevendeContainer leidinggevendeContainer;

        public LeidingGevendeContainer(ILeidinggevendeContainer leidinggevendeContainer)
        {
            this.leidinggevendeContainer = leidinggevendeContainer;
        }
        public void Create(LeidingGevende leid, string newWachtwoord)
        {
            LeidingGevendeDTO dto = leid.GetDTO();
            leidinggevendeContainer.Create(dto, newWachtwoord);
        }
        public void UpdateMedewerker(Medewerker med)
        {
            MedewerkerDTO dto = med.GetDTO();
            leidinggevendeContainer.UpdateMedewerker(dto);
        }
        public LeidingGevende? Inloggen(string email, string wachtwoord)
        {
            LeidingGevendeDTO dto = leidinggevendeContainer.Inloggen(email, wachtwoord);
            LeidingGevende leid = new LeidingGevende(dto);
            return leid;
        }
    }
}
