using DALMSSQL.Exceptions;
using InterfaceLib;
using System.Data.SqlClient;

namespace DALMSSQL
{
    public class MedewerkerDAL : IMedewerkerContainer
    {
        ConnectionDb db = new ConnectionDb();
        VaardigheidDAL vaardigheidDAL = new VaardigheidDAL();

        public void Create(MedewerkerDTO medewerker, string newWachtwoord)
        {
            if (medewerker.Tussenvoegsel == null)
            {
                medewerker.Tussenvoegsel = "";
            }
            string wachtwoordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(newWachtwoord, 13);
            db.OpenConnection();
            string query = "INSERT INTO Medewerker (Voornaam, Tussenvoegsel, Achternaam, Email, Wachtwoord, TeamId) VALUES (@Voornaam, @Tussenvoegsel, @Achternaam, @Email, @Wachtwoord, @TeamId)";
            SqlCommand cmd = new SqlCommand(query, db.connection);
            cmd.Parameters.AddWithValue("@Voornaam", medewerker.Voornaam);
            cmd.Parameters.AddWithValue("@Tussenvoegsel", medewerker.Tussenvoegsel);
            cmd.Parameters.AddWithValue("@Achternaam", medewerker.Achternaam);
            cmd.Parameters.AddWithValue("@Email", medewerker.Email);
            cmd.Parameters.AddWithValue("@Wachtwoord", wachtwoordHash);
            cmd.Parameters.AddWithValue("@TeamId", medewerker.MijnTeam.Id);
            cmd.ExecuteNonQuery();
            db.CloseConnetion();
        }
        public MedewerkerDTO? Inloggen(string email, string wachtwoord)
        {
            try
            {
                bool isValid = false;
                db.OpenConnection();
                MedewerkerDTO med = null;
                string query = @"SELECT Wachtwoord, Id FROM Medewerker WHERE Email = @email";
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
                    MedewerkerDTO dto = FindById(med.Id);
                    dto.MijnTeam = GetTeamVanMedewerker(dto);
                    return dto;
                }
                return null;
            }
            if (isValid)
            { 
                MedewerkerDTO dto = FindById(med.Id);
                dto.MijnTeam = GetTeamVanMedewerker(dto);
                return dto;
            catch (SqlException sqlex)
            {
                throw new TemporaryException("Kan geen verbinding maken met de server");
            }
            catch (Exception ex)
            {
                throw new PermanentException("Er is een fout opgetreden");
            }
        }
        public List<MedewerkerDTO> ZoekOpNaam(string naam)
        {
            try
            {
                List<MedewerkerDTO> medewerkers = new List<MedewerkerDTO>();
                db.OpenConnection();
                string query = @"SELECT * FROM Medewerker WHERE CONCAT_WS(' ', Voornaam, ISNULL(Tussenvoegsel, ' '), Achternaam) LIKE '%' + @naam + '%' ";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@naam", naam);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    medewerkers.Add(new MedewerkerDTO(reader["Email"].ToString(),
                        reader["Voornaam"].ToString(),
                        reader["Achternaam"].ToString(),
                        reader["Tussenvoegsel"].ToString(),
                        Convert.ToInt32(reader["Id"])));
                        


                }
                db.CloseConnetion();
                return medewerkers;

            }
            catch (SqlException sqlex)
            {
                throw new TemporaryException("Kan geen verbinding maken met de server");
            }
            catch (Exception ex)
            {
                throw new PermanentException("Er is een fout opgetreden");
            }
        }
        public List<MedewerkerDTO> ZoekMedewerkerOpVaardigheid(string naam)
        {
            try
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
            catch (SqlException sqlex)
            {
                throw new TemporaryException("Kan geen verbinding maken met de server");
            }
            catch (Exception ex)
            {
                throw new PermanentException("Er is een fout opgetreden");
            }
        }
        public List<MedewerkerDTO> HaalAlleMedewerkersOp()
        {
            try
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
            catch (SqlException sqlex)
            {
                throw new TemporaryException("Kan geen verbinding maken met de server");
            }
            catch (Exception ex)
            {
                throw new PermanentException("Er is een fout opgetreden");
            }
        }
        public MedewerkerDTO? FindById(int id)
        {
            try
            {
                MedewerkerDTO? medewerker = null;
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
                            reader["Tussenvoegsel"].ToString(),
                            reader["Achternaam"].ToString(),
                            Convert.ToInt32(reader["Id"]));
                    }
                }
                db.CloseConnetion();
                return medewerker;
            }
            catch (SqlException sqlex)
            {
                throw new TemporaryException("Kan geen verbinding maken met de server");
            }
            catch (Exception ex)
            {
                throw new PermanentException("Er is een fout opgetreden");
            }
        }



        public void KoppelMedewerkerAanLeidinggevenden(MedewerkerDTO med, LeidingGevendeDTO leid)
        {
            try
            {
                db.OpenConnection();
                string query = @"INSERT INTO LeidinggevendeMedewerker VALUES (@leidId,@medId)";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@leidId", leid.UserID);
                command.Parameters.AddWithValue("@medId", med.Id);
                command.ExecuteNonQuery();
                db.CloseConnetion();
            }
            catch (SqlException sqlex)
            {
                throw new TemporaryException("Kan geen verbinding maken met de server");
            }
            catch (Exception ex)
            {
                throw new PermanentException("Er is een fout opgetreden");
            }
        }

        public TeamDTO? GetTeamVanMedewerker(MedewerkerDTO dto)
        {
            try
            {
                TeamDTO? team = null;
                db.OpenConnection();
                string query = @"SELECT * FROM Team T INNER JOIN Medewerker M ON M.TeamId = T.Id WHERE M.Id = @id";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@id", dto.Id);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        team = new TeamDTO(
                        Convert.ToInt32(reader["Id"]),
                        reader["TeamKleur"].ToString(),
                        reader["Taak"].ToString(),
                        (float)Convert.ToDouble(reader["Gem_Rating"]));
                    }
                }
                db.CloseConnetion();
                return team;
            }
            catch (SqlException sqlex)
            {
                throw new TemporaryException("Kan geen verbinding maken met de server");
            }
            catch (Exception ex)
            {
                throw new PermanentException("Er is een fout opgetreden");
            }
        }
    }
}
