using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQL
{
    public class LeidinggevendenDAL
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
    }
}
