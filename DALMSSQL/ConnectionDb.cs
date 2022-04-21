using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.Json;
using static BusnLogicVecozo.JsonEncrypt;

namespace DALMSSQL
{
    public class ConnectionDb
    {
        public string data = File.ReadAllText(@"C:\Users\amier\OneDrive - Office 365 Fontys\S2\Proftaak\vecozo\Vecozo\VecozoLibrary\CredentialHiding.json");
        public SqlConnection? connection;
        public Rootobject root;

        public void OpenConnection()
        {

            try
            {
                root = JsonSerializer.Deserialize<Rootobject>(data);
                if (root != null)
                {
                    connection = new SqlConnection(root.DatabaseConfig.ConnectionString);
                    connection.Open();
                }
            }
            catch { }
        }

        public void CloseConnetion()
        {
            try
            {
                if (connection != null)
                    connection.Close();
            }
            catch { }
        }
    }
}
