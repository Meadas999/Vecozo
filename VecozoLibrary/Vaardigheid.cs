using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public class Vaardigheid
    {
        public string Naam { get; }
        public int Id { get; }

        public Vaardigheid(string naam, int id)
        {
            this.Naam = naam;
            this.Id = id;
        }

        public Vaardigheid(string naam)
        {
            this.Naam = naam;
        }

        public Vaardigheid(VaardigheidDTO dto)
        {
            this.Naam = dto.Naam;
            this.Id = dto.Id;   
        }
        public VaardigheidDTO GetDTO()
        {
            VaardigheidDTO dto = new VaardigheidDTO(Naam, Id);
            return dto;
        }

        public override string ToString()
        {
            return $"Naam: {this.Naam}\n";
        }
    }
}
