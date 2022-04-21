using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQL
{
    public class RatingDAL
    {
        ConnectionDb db = new ConnectionDb();
        
        public void Create(RatingDTO rating, MedewerkerDTO medewerker, VaardigheidDTO vaardigheid)
        {
            string query = "INSERT INTO Rating VALUES(@naam, @beschrijving, @laatsteDatum, @vaardigHeidId, medewerkerId)";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@naam", rating.Naam);
            command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
            command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
            command.Parameters.AddWithValue("@vaardigheidId", vaardigheid.Id);
            command.Parameters.AddWithValue("@medewerkerId", medewerker.userID);
            db.OpenConnection();
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }
        public RatingDTO FindByVaardigheidEnMedewerker(int vaardigheidId, int medewerkerId)
        {
            RatingDTO rating = new  RatingDTO();
            db.OpenConnection();
            string query = @"SELECT * FROM Rating 
                 WHERE MederwerkerId = @medewerkerId AND VaardigheidID = @vaardigheidId";
            using (SqlCommand command = new(query, db.connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@medewerkerId", vaardigheidId);
                command.Parameters.AddWithValue("@medewerkerId", medewerkerId);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        rating = new RatingDTO(
                            Convert.ToInt32(dr["Id"]),
                            dr["Naam"].ToString(),
                            dr["Beschrijving"].ToString(),
                            Convert.ToDateTime(dr["Deadline"]));
                    }
                }
                db.CloseConnetion();
                return rating;
            }
        }
        public void Delete(int id)
        {
            db.OpenConnection();
            string query = "DELETE FROM Rating WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@id", id);
            db.OpenConnection();
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }
        public void Update(RatingDTO rating)
        {
            db.OpenConnection();
            string query = "UPDATE Rating SET Naam = @naam, Beschrijving = @beschrijving, LaatsteDatum = @laatsteDatum WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@naam", rating.Naam);
            command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
            command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
            command.Parameters.AddWithValue("@id", rating.Id);
            db.OpenConnection();
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }

    }
}
