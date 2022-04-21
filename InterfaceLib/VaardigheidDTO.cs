using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib
{
    public class VaardigheidDTO
    {
        public string Naam { get; }
        public int Id { get; }
        //public List<Medewerker> Medewerkers { get; } = new List<Medewerker>();

        public VaardigheidDTO(string naam, int id)
        {
            this.Naam = naam;
            this.Id = id;
        }

        public VaardigheidDTO(string naam)
        {
            this.Naam = naam;
        }
    }
}
