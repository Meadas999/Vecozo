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

        public void Create(LeidingGevendeDTO dto, string newWachtwoord)
        {
            string wachtwoordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(newWachtwoord, 13);
            db.OpenConnection();
            string query = @"INSERT INTO Leidinggevende (Voornaam, Tussenvoegsel, Achternaam, Email, Wachtwoord)
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

        public LeidingGevendeDTO? Inloggen(string email, string wachtwoord)
        {
            db.OpenConnection();
            LeidingGevendeDTO dto = null;
            string query = @"SELECT * FROM Leidinggevende WHERE Email = @email";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@email", email);
            SqlDataReader reader = command.ExecuteReader();
            if(reader.HasRows)
            {
                bool correct = BCrypt.Net.BCrypt.EnhancedVerify(wachtwoord,reader["Wachtwoord"].ToString());
                if(correct)
                {
                    while(reader.Read())
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
            }
            db.CloseConnetion();
            return dto;
        }

        public void UpdateMedewerker(MedewerkerDTO dto)
        {
            db.OpenConnection();
            string query = @"UPDATE Medewerker SET Email = @email, 
            Voornaam = @voornaam, Tussenvoegsel = @tussenvoegsel, Achternaam = @achternaam 
            WHERE Id = @id";
            SqlCommand command = new SqlCommand(query,db.connection);
            command.Parameters.AddWithValue("@voornaam", dto.Voornaam);
            command.Parameters.AddWithValue("@tussenvoegsel", dto.Tussenvoegsel);
            command.Parameters.AddWithValue("@achternaam", dto.Achternaam);
            command.Parameters.AddWithValue("@email", dto.Email);
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }
    }
}
