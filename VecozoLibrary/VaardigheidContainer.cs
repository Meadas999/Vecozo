using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;

namespace BusnLogicVecozo
{
    public class VaardigheidContainer
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
        public void VerwijderVaarigheidVanMedewerker(Medewerker medewerker, Vaardigheid vaardigheid)
        {
            MedewerkerDTO dto = medewerker.GetDTO();
            VaardigheidDTO dto2 = vaardigheid.GetDTO();
            container.VerwijderVaarigheidVanMedewerker(dto, dto2);
        }
        public void Update(Vaardigheid vaardigheid)
        {
            VaardigheidDTO dto = vaardigheid.GetDTO();
            container.Update(dto);
        }
        public List<Vaardigheid> FindByMedewerker(Medewerker medewerker)
        {
            MedewerkerDTO dto = medewerker.GetDTO();
            List<VaardigheidDTO> dtos = container.FindByMedewerker(dto);
            return dtos.Select(v => new Vaardigheid(v)).ToList();

        }
        public List<Vaardigheid> GetAll()
        {
            List<VaardigheidDTO> dtos = container.GetAll();
            return dtos.Select(v => new Vaardigheid(v)).ToList();
        }
        public void VoegVaardigheidToeAanMedewerker(Medewerker medewerker, Vaardigheid vaardigheid, Rating rating)
        {
            MedewerkerDTO dto = medewerker.GetDTO();
            VaardigheidDTO dto2 = vaardigheid.GetDTO();
            RatingDTO dto3 = rating.GetDTO();
            container.VoegVaardigheidToeAanMedewerker(dto, dto2, dto3);
        }
        public Vaardigheid? BestaandeVaardigeheid(string naam)
        {
            VaardigheidDTO dto = container.BestaandeVaardigeheid(naam);
            if (dto == null)
            {
                return null;
            }
            return new Vaardigheid(dto);
        }
        public void UpdateRating(Rating rating, Vaardigheid vaardigheid)
        {
            VaardigheidDTO dto = vaardigheid.GetDTO();
            RatingDTO dto2 = rating.GetDTO();
            container.UpdateRating(dto2, dto);
        }
    }
}
