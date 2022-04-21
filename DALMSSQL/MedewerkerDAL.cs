using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQL
{
    public class MedewerkerDAL : IMedewerkerContainer
    {
        ConnectionDb db = new ConnectionDb();
        public MedewerkerDTO? Inloggen(string email, string wachtwoord)
        {
            db.OpenConnection();
            MedewerkerDTO med = null;
            string query = @"SELECT * FROM Medewerker WHERE Email = @email AND Wachtwoord = @wachtwoord";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@wachtwoord", wachtwoord);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    med = new MedewerkerDTO(
                        reader["Email"].ToString(),
                        reader["Wachtwoord"].ToString(),
                        reader["Voornaam"].ToString(),
                        reader["Achternaam"].ToString(),
                        reader["Tussenvoegsel"].ToString(),
                        Convert.ToInt32(reader["Id"]));
                }
            }
            db.CloseConnetion();
            return med;
        }
        public List<MedewerkerDTO> ZoekOpNaam(string naam)
        {
            List<MedewerkerDTO> medewerkers = new List<MedewerkerDTO>();
            db.OpenConnection();
            string query = @"SELECT * FROM Medewerker WHERE CONCAT_WS(' ', Voornaam, ISNULL(Tussenvoegsel, ' '), Achternaam) LIKE '%' + @naam + '%' ";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@naam", naam);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    medewerkers.Add(new MedewerkerDTO(reader["Email"].ToString(),
                        reader["Wachtwoord"].ToString(),
                        reader["Voornaam"].ToString(),
                        reader["Achternaam"].ToString(),
                        reader["Tussenvoegsel"].ToString(),
                        Convert.ToInt32(reader["Id"])));
                    
                }
                return medewerkers;

            }
            db.CloseConnetion();
            return medewerkers;
        }
        public List<MedewerkerDTO> ZoekMedewerkerOpVaardigheid(string naam)
        {
            List<MedewerkerDTO> medewerkers = new List<MedewerkerDTO>();
            db.OpenConnection();
            string query = @"SELECT * FROM Medewerker M INNER JOIN Vaardigheid V ON V.Medewerker_id = M.Id WHERE V.Naam = @naam";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@naam", naam);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    medewerkers.Add(new MedewerkerDTO(
                        reader["Email"].ToString(),
                        reader["Wachtwoord"].ToString(),
                        reader["Voornaam"].ToString(),
                        reader["Achternaam"].ToString(),
                        reader["Tussenvoegsel"].ToString(),
                        Convert.ToInt32(reader["Id"])));
                }
            }
            db.CloseConnetion();
            return medewerkers;
        }
        public List<MedewerkerDTO> HaalAlleMedewerkersOp()
        {
            List<MedewerkerDTO> medewerkers = new List<MedewerkerDTO>();
            db.OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Medewerker", db.connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    medewerkers.Add(new MedewerkerDTO(
                        reader["Email"].ToString(),
                        reader["Wachtwoord"].ToString(),
                        reader["Voornaam"].ToString(),
                        reader["Achternaam"].ToString(),
                        reader["Tussenvoegsel"].ToString(),
                        Convert.ToInt32(reader["Id"])));
                }
            }
            db.CloseConnetion();
            return medewerkers;
        }
    }
}
