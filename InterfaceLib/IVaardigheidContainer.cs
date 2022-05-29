using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public interface IVaardigheidContainer
    {
        public VaardigheidDTO Create(VaardigheidDTO vaardigheid);
        public void Delete(VaardigheidDTO vaardigheid);
        public void VerwijderVaarigheidVanMedewerker(MedewerkerDTO medewerker, int vaardigheidId);
        public void Update(VaardigheidDTO vaardigheid);
        public List<RatingDTO> FindByMedewerker(int id);
        public List<VaardigheidDTO> GetAll();
        public void VoegVaardigheidToeAanMedewerker(MedewerkerDTO medewerker, RatingDTO rating);
        public VaardigheidDTO? BestaandeVaardigeheid(string naam);
        public void UpdateRating(MedewerkerDTO med, RatingDTO rating);
        public RatingDTO FindRating(int MedewerkerId, int VaardigheidId);
        public VaardigheidDTO FindVaardigheid(int id);

    }
}
