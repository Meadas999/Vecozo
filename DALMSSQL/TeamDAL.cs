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

        public TeamDTO? FindById(int id)
        {
            TeamDTO? dto = null;
            db.OpenConnection();
            string query = @"SELECT * FROM Team WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@id", id);
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

        public List<TeamDTO> GetAll()
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
    }
}
