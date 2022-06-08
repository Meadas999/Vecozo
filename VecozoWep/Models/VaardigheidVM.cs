using BusnLogicVecozo;
using VecozoWeb.Models;

namespace VecozoWep.Models
{
    public class VaardigheidVM
    {
        public string Naam { get; }
        public int Id { get; }

        public VaardigheidVM(string naam, int id)
        {
            Naam = naam;
            Id = id;
        }
        public VaardigheidVM(string naam)
        {
            Naam = naam;
        }

        public VaardigheidVM(Vaardigheid v)
        {
            Naam = v.Naam;
            Id = v.Id;
        }


        public Vaardigheid GetVaardigheid()
        {
            Vaardigheid vaardigheid = new(Naam, Id);
            return vaardigheid;
        }
        
        public VaardigheidVM()
        {

        }
    }
} 