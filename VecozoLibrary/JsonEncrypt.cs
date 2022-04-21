using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogicVecozo
{
    public class JsonEncrypt
    {

        public class Rootobject
        {
            public Databaseconfig DatabaseConfig { get; set; }
            public Defaults Defaults { get; set; }
        }

        public class Databaseconfig
        {
            public string Servername { get; set; }
            public string ConnectionString { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Database { get; set; }
        }

        public class Defaults
        {
            public string Standaardkleur { get; set; }
        }

    }
}
