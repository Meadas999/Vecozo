using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface ILeidinggevendeContainer
    {
        public void Create(LeidingGevendeDTO medewerker, string newWachtwoord);
        public void UpdateMedewerker(MedewerkerDTO dto);
        public LeidingGevendeDTO? Inloggen(string email, string wachtwoord);
        public LeidingGevendeDTO? FindById(int id);
    }
}
