using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQL
{
    public class VaardigheidDAL : IVaardigheidContainer
    {
        ConnectionDb db = new ConnectionDb();
        public void Create(VaardigheidDTO vaardigheid)
        {
            db.OpenConnection();
            string query = @"INSERT INTO Vaardigheid VALUES(@naam)";
            SqlCommand command = new SqlCommand(@query, db.connection);
            command.Parameters.AddWithValue("@naam", vaardigheid.Naam);
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }

        public void Delete(VaardigheidDTO vaardigheid)
        {
            db.OpenConnection();
            string query = @"DELETE FROM Vaardigheid WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@id", vaardigheid.Id);
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }

        public List<RatingDTO> FindByMedewerker(int id)
        {
            List<RatingDTO> ratings = new List<RatingDTO>();
            db.OpenConnection();
            string query = @"Select v.Id , v.Naam , Beschrijving , Score, LaatsteDatum
                    From MedewerkerVaardigheid mv
                    INNER JOIN Vaardigheid v on mv.VaardigheidId = v.Id 
                    WHERE mv.MedewerkerId  = @medId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@medId", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ratings.Add(new RatingDTO(
                        Convert.ToInt32(reader["Score"]),
                        reader["Beschrijving"].ToString(),
                        Convert.ToDateTime(reader["LaatsteDatum"]),
                        new VaardigheidDTO(
                            reader["Naam"].ToString(),
                            Convert.ToInt32(reader["Id"])
                            )));
                }
            }
            db.CloseConnetion();
            return ratings;
        }

        public List<VaardigheidDTO> GetAll()
        {
            List<VaardigheidDTO> vaardigheden = new List<VaardigheidDTO>();
            db.OpenConnection();
            SqlCommand command = new SqlCommand(@"SELECT * FROM Vaardigheid", db.connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    vaardigheden.Add(new VaardigheidDTO(
                    reader["Naam"].ToString(),
                    Convert.ToInt32(reader["Id"])));
                }
            }
            db.CloseConnetion();
            return vaardigheden;
        }

        public VaardigheidDTO? BestaandeVaardigeheid(string naam)
        {
            VaardigheidDTO dto = null;
            int index = GetAll().FindIndex(x => x.Naam == naam.ToLower());
            if (index >= 0)
            {
                dto = new VaardigheidDTO(GetAll()[index].Naam, GetAll()[index].Id);
            }
            return dto;
        }

        public void Update(VaardigheidDTO vaardigheid)
        {
            db.OpenConnection();
            string query = @"UPDATE Vaardigheid SET Naam = @naam WHERE Id = @vaarId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@vaarId", vaardigheid.Id);
            command.Parameters.AddWithValue("@naam", vaardigheid.Naam);
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }

        public void VerwijderVaarigheidVanMedewerker(MedewerkerDTO medewerker, VaardigheidDTO vaardigheid)
        {
            db.OpenConnection();
            string query = @"DELETE FROM MedewerkerVaardigheid WHERE VaardigheidId = @vaarId AND MedewerkerId = @medID";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@vaarId", vaardigheid.Id);
            command.Parameters.AddWithValue("@medID", medewerker.Id);
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }

        public void VoegVaardigheidToeAanMedewerker(MedewerkerDTO medewerker, RatingDTO rating)
        {
            if (BestaandeVaardigeheid(rating.vaardigheidDTO.Naam) != null)
            {
                db.OpenConnection();
                string query = @"INSERT INTO MedewerkerVaardigheid VALUES(@medID,@vaardID,@beschrijving @score ,@laatsteDatum)";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@medID", medewerker.Id);
                command.Parameters.AddWithValue("@vaardID", BestaandeVaardigeheid(rating.vaardigheidDTO.Naam).Id);
                command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
                command.Parameters.AddWithValue("@score", rating.Score);
                command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
                command.ExecuteNonQuery();
                db.CloseConnetion();
            }
        }

        public void UpdateRating(RatingDTO rating, VaardigheidDTO vaardigheid)
        {
            db.OpenConnection();
            string query = "UPDATE MedewerkerVaardigheid SET Beschrijving = @beschrijving, Score = @score, LaatsteDatum = @laatsteDatum WHERE VaardigheidId = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
            command.Parameters.AddWithValue("@score", rating.Score);
            command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
            command.Parameters.AddWithValue("@id", vaardigheid.Id);
            db.OpenConnection();
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }
    }
}
