using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQL
{
    public class LeidinggevendenDAL : ILeidinggevendeContainer
    {
        ConnectionDb db = new ConnectionDb();
        MedewerkerDAL md = new();
        public void Create(LeidingGevendeDTO dto, string newWachtwoord)
        {
            string wachtwoordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(newWachtwoord, 13);
            db.OpenConnection();
            string query = @"INSERT INTO Leidinggevenden (Voornaam, Tussenvoegsel, Achternaam, Email, Wachtwoord)
            VALUES (@Voornaam, @Tussenvoegsel, @Achternaam, @Email, @Wachtwoord)";
            SqlCommand cmd = new SqlCommand(query, db.connection);
            cmd.Parameters.AddWithValue("@Voornaam", dto.Voornaam);
            cmd.Parameters.AddWithValue("@Tussenvoegsel", dto.Tussenvoegsel);
            cmd.Parameters.AddWithValue("@Achternaam", dto.Achternaam);
            cmd.Parameters.AddWithValue("@Email", dto.Email);
            cmd.Parameters.AddWithValue("@Wachtwoord", wachtwoordHash);
            cmd.ExecuteNonQuery();
            db.CloseConnetion();
        }

        public LeidingGevendeDTO? FindById(int id)
        {
            db.OpenConnection();
            LeidingGevendeDTO? dto = null;
            string query = @"SELECT * FROM Leidinggevenden WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                dto = new LeidingGevendeDTO(
                    reader["Email"].ToString(),
                    reader["Wachtwoord"].ToString(),
                    reader["Voornaam"].ToString(),
                    reader["Tussenvoegsel"].ToString(),
                    reader["Achternaam"].ToString(),
                    Convert.ToInt32(reader["Id"]));
            }
            db.CloseConnetion();
            return dto;
        }

        public List<LeidingGevendeDTO> HaalAlleLeidinggevenedeOp()
        {
            List<LeidingGevendeDTO> dtos = new();
            db.OpenConnection();
            string query = @"SELECT * FROM Leidinggevenden";
            SqlCommand cmd = new SqlCommand(query, db.connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dtos.Add(new LeidingGevendeDTO(
                reader["Email"].ToString(),
                reader["Voornaam"].ToString(),
                reader["Tussenvoegsel"].ToString(),
                reader["Achternaam"].ToString(),
                Convert.ToInt32(reader["Id"])));
            }
            db.CloseConnetion();
            return dtos;
        }

        public LeidingGevendeDTO? Inloggen(string email, string wachtwoord)
        {
            bool isValid = false;
            db.OpenConnection();
            LeidingGevendeDTO dto = null;
            string query = @"SELECT * FROM Leidinggevenden WHERE Email = @email";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    bool correct = BCrypt.Net.BCrypt.EnhancedVerify(wachtwoord, reader["Wachtwoord"].ToString());
                    if (correct)
                    {
                        dto = new LeidingGevendeDTO(
                        reader["Email"].ToString(),
                        reader["Wachtwoord"].ToString(),
                        reader["Voornaam"].ToString(),
                        reader["Tussenvoegsel"].ToString(),
                        reader["Achternaam"].ToString(),
                        Convert.ToInt32(reader["Id"]));
                    }
                }
                db.CloseConnetion();
                isValid = BCrypt.Net.BCrypt.EnhancedVerify(wachtwoord, med.Wachtwoord);
            }

            if (isValid)
            {
                return FindById(med.UserID);
            }
            return null;
        }

        public void UpdateMedewerker(MedewerkerDTO dto)
        {
            db.OpenConnection();
            string query = @"UPDATE Medewerker SET Email = @email, 
            Voornaam = @voornaam, Tussenvoegsel = @tussenvoegsel, Achternaam = @achternaam 
            WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@voornaam", dto.Voornaam);
            command.Parameters.AddWithValue("@tussenvoegsel", dto.Tussenvoegsel);
            command.Parameters.AddWithValue("@achternaam", dto.Achternaam);
            command.Parameters.AddWithValue("@email", dto.Email);
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }


    }
}
