using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;

namespace BusnLogicVecozo
{
    internal class VaardigheidContainer
    {
        private readonly IVaardigheidContainer container;
        public VaardigheidContainer(IVaardigheidContainer container)
        {
            this.container = container;
        }
        public void Create(Vaardigheid vaardigheid)
        {
            VaardigheidDTO dto = vaardigheid.GetDTO();
            container.Create(dto);
        }
        public void Delete(Vaardigheid vaardigheid)
        {
            VaardigheidDTO dto = vaardigheid.GetDTO();
            container.Delete(dto);
        }
    }
}
