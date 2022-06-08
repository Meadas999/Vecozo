using DALMSSQL.Exceptions;
using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQL
{
    public class TeamDAL : ITeamContainer
    {
        ConnectionDb db = new();

        public TeamDTO? FindByUserId(int userid)
        {
            try
            {
                int teamid = GetTeamIdByUserid(userid);
                TeamDTO? dto = null;
                db.OpenConnection();
                string query = @"SELECT * FROM Team WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@id", userid);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    dto = new TeamDTO(
                        Convert.ToInt32(reader["Id"]),
                        reader["TeamKleur"].ToString(),
                        reader["Taak"].ToString(),
                        (float)Convert.ToDouble(reader["Gem_Rating"]));
                }
                db.CloseConnetion();
                return dto;
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

        public List<TeamDTO> GetAll()
        {
            try
            {
                List<TeamDTO> dtos = new();
                db.OpenConnection();
                string query = @"SELECT * FROM Team";
                SqlCommand command = new SqlCommand(query, db.connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dtos.Add(new TeamDTO(
                        Convert.ToInt32(reader["Id"]),
                        reader["TeamKleur"].ToString(),
                        reader["Taak"].ToString(),
                        (float)Convert.ToDouble(reader["Gem_Rating"])));
                }
                db.CloseConnetion();

                return dtos;
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
        private int GetTeamIdByUserid(int userid)
        {
            try
            {
                db.OpenConnection();
                string query = @"SELECT TeamId FROM Medewerker WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@id", userid);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int teamid = Convert.ToInt32(reader["TeamId"]);
                        return teamid;
                    }
                }
                db.CloseConnetion();
                return -1;
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

        public List<MedewerkerDTO> GetMedewerkersFromTeam(int teamid)
        {
            List<MedewerkerDTO> medewerkers = new List<MedewerkerDTO>();
            db.OpenConnection();
            string query = @"SELECT * FROM Medewerker AS M INNER JOIN Team AS T ON T.Id = M.TeamID WHERE M.TeamId = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@id", teamid);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    medewerkers.Add(new MedewerkerDTO(reader["Email"].ToString(),
                    reader["Voornaam"].ToString(), reader["Achternaam"].ToString(),
                    reader["Tussenvoegsel"].ToString(), Convert.ToInt32(reader["Id"]),
                    new TeamDTO(Convert.ToInt32(reader["TeamId"]), reader["TeamKleur"].ToString(),
                    reader["Taak"].ToString(), (float)Convert.ToDouble(reader["Gem_Rating"]))));
                }
            }
            db.CloseConnetion();
            return medewerkers;
        }

        public void UpdateTeamMedewerker(MedewerkerDTO medewerker)
        {
            db.OpenConnection();
            string query = @"UPDATE Medewerker SET TeamId = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("id", medewerker.Id);
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }

        public void Update(TeamDTO team)
        {
            db.OpenConnection();
            string query = @"UPDATE Team SET TeamKleur = @kleur, Taak = @taak, Gem_Rating = @rating WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("id", team.Id);
            command.Parameters.AddWithValue("kleur", team.Kleur);
            command.Parameters.AddWithValue("rating", team.GemRating);
            command.Parameters.AddWithValue("taak", team.Taak);
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }
    }
}
