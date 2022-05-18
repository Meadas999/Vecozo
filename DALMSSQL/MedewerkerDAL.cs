﻿using InterfaceLib;
using System.Data.SqlClient;

namespace DALMSSQL
{
    public class MedewerkerDAL : IMedewerkerContainer
    {
        ConnectionDb db = new ConnectionDb();

        public void Create(MedewerkerDTO medewerker, string newWachtwoord)
        {
            string wachtwoordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(newWachtwoord, 13);
            db.OpenConnection();
            string query = "INSERT INTO Medewerker (Voornaam, Tussenvoegsel, Achternaam, Email, Wachtwoord, TeamId) VALUES (@Voornaam, @Tussenvoegsel, @Achternaam, @Email, @Wachtwoord, @TeamId)";
            SqlCommand cmd = new SqlCommand(query, db.connection);
            cmd.Parameters.AddWithValue("@Voornaam", medewerker.Voornaam);
            cmd.Parameters.AddWithValue("@Tussenvoegsel", medewerker.Tussenvoegsel);
            cmd.Parameters.AddWithValue("@Achternaam", medewerker.Achternaam);
            cmd.Parameters.AddWithValue("@Email", medewerker.Email);
            cmd.Parameters.AddWithValue("@Wachtwoord", newWachtwoord);
            cmd.Parameters.AddWithValue("@TeamId", medewerker.MijnTeam.Id);
            cmd.ExecuteNonQuery();
            db.CloseConnetion();
        }
        public MedewerkerDTO? Inloggen(string email, string wachtwoord)
        {
            bool isValid = false;
            db.OpenConnection();
            MedewerkerDTO med = null;
            string query = @"SELECT Wachtwoord, Id FROM Leidinggevenden WHERE Email = @email";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    med = new MedewerkerDTO(
                    reader["Wachtwoord"].ToString(),
                    Convert.ToInt32(reader["Id"]));
                    isValid = BCrypt.Net.BCrypt.EnhancedVerify(wachtwoord, med.WachtwoordHash);
                }
                db.CloseConnetion();
            }
           
            if (isValid)
            { 
                return FindById(med.Id);
            }
            return null;
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
            string query = @"SELECT * FROM Medewerker 
                 INNER JOIN MedewerkerVaardigheid on Medewerker.Id = MedewerkerVaardigheid.MedewerkerId
                 INNER JOIN Vaardigheid on Vaardigheid.Id = MedewerkerVaardigheid.VaardigheidId
                 WHERE Vaardigheid.Naam LIKE '%' + @naam + '%'";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@naam", naam);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    medewerkers.Add(new MedewerkerDTO(
                        reader["Email"].ToString(),
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
                        reader["Voornaam"].ToString(),
                        reader["Achternaam"].ToString(),
                        reader["Tussenvoegsel"].ToString(),
                        Convert.ToInt32(reader["Id"])));
                }
            }
            db.CloseConnetion();
            return medewerkers;
        }
        public MedewerkerDTO FindById(int id)
        {
            MedewerkerDTO medewerker = null;
            db.OpenConnection();
            string query = @"SELECT * FROM Medewerker WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    medewerker = new MedewerkerDTO(
                        reader["Email"].ToString(),
                        reader["Voornaam"].ToString(),
                        reader["Achternaam"].ToString(),
                        reader["Tussenvoegsel"].ToString(),
                        Convert.ToInt32(reader["Id"]));
                }
            }
            db.CloseConnetion();
            return medewerker;
        }
    }
}
