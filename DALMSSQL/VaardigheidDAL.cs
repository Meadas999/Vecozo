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
    public class VaardigheidDAL : IVaardigheidContainer
    {
        ConnectionDb db = new ConnectionDb();
        public VaardigheidDTO Create(VaardigheidDTO vaardigheid)
        {
            try
            {
                VaardigheidDTO dto = null;
                db.OpenConnection();
                string query = @"INSERT INTO Vaardigheid VALUES(@naam)
                            SELECT * FROM Vaardigheid WHERE naam = @naam";
                SqlCommand command = new SqlCommand(@query, db.connection);
                command.Parameters.AddWithValue("@naam", vaardigheid.Naam);
                command.ExecuteNonQuery();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dto = new VaardigheidDTO(
                             dr["Naam"].ToString(),
                             Convert.ToInt32(dr["Id"]));
                    }
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

        public void Delete(VaardigheidDTO vaardigheid)
        {
            try
            {
                db.OpenConnection();
                string query = @"DELETE FROM Vaardigheid WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@id", vaardigheid.Id);
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

        public List<RatingDTO> FindByMedewerker(int id)
        {
            try
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
            catch (SqlException sqlex)
            {
                throw new TemporaryException("Kan geen verbinding maken met de server");
            }
            catch (Exception ex)
            {
                throw new PermanentException("Er is een fout opgetreden");
            }
        }

        public List<VaardigheidDTO> GetAll()
        {
            try
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
            catch (SqlException sqlex)
            {
                throw new TemporaryException("Kan geen verbinding maken met de server");
            }
            catch (Exception ex)
            {
                throw new PermanentException("Er is een fout opgetreden");
            }
        }

        public VaardigheidDTO? BestaandeVaardigeheid(string naam)
        {
            try
            {
                VaardigheidDTO dto = null;
                int index = GetAll().FindIndex(x => x.Naam == naam);
                if (index >= 0)
                {
                    dto = new VaardigheidDTO(GetAll()[index].Naam, GetAll()[index].Id);
                }
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

        public void Update(VaardigheidDTO vaardigheid)
        {
            try
            {
                db.OpenConnection();
                string query = @"UPDATE Vaardigheid SET Naam = @naam WHERE Id = @vaarId";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@vaarId", vaardigheid.Id);
                command.Parameters.AddWithValue("@naam", vaardigheid.Naam);
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

        public void VerwijderVaarigheidVanMedewerker(MedewerkerDTO medewerker, int vaardigheidId)
        {
            try
            {
                db.OpenConnection();
                string query = @"DELETE FROM MedewerkerVaardigheid WHERE VaardigheidId = @vaarId AND MedewerkerId = @medID";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@vaarId", vaardigheid.Id);
                command.Parameters.AddWithValue("@medID", medewerker.Id);
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
        //TODO: Test
        public void VoegVaardigheidToeAanMedewerker(MedewerkerDTO medewerker, RatingDTO rating)
        {
            try
            {
                if (BestaandeVaardigeheid(rating.vaardigheidDTO.Naam) != null)
                {
                    db.OpenConnection();
                    string query = @"INSERT INTO MedewerkerVaardigheid VALUES(@medID,@vaardID,@beschrijving,@score,@laatsteDatum)";
                    SqlCommand command = new SqlCommand(query, db.connection);
                    command.Parameters.AddWithValue("@medID", medewerker.Id);
                    command.Parameters.AddWithValue("@vaardID", BestaandeVaardigeheid(rating.vaardigheidDTO.Naam).Id);
                    command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
                    command.Parameters.AddWithValue("@score", rating.Score);
                    command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
                    command.ExecuteNonQuery();
                    db.CloseConnetion();
                }
                else
                {
                    VaardigheidDTO var = Create(rating.vaardigheidDTO);
                    db.OpenConnection();
                    string query = @"INSERT INTO MedewerkerVaardigheid VALUES(@medID,@vaardID,@beschrijving,@score ,@laatsteDatum)";
                    SqlCommand command = new SqlCommand(query, db.connection);
                    command.Parameters.AddWithValue("@medID", medewerker.Id);
                    command.Parameters.AddWithValue("@vaardID", var.Id);
                    command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
                    command.Parameters.AddWithValue("@score", rating.Score);
                    command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
                    command.ExecuteNonQuery();
                    db.CloseConnetion();
                }
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

        public void UpdateRating(RatingDTO rating)
        {
            try
            {
                db.OpenConnection();
                string query = "UPDATE MedewerkerVaardigheid SET Beschrijving = @beschrijving, Score = @score, LaatsteDatum = @laatsteDatum WHERE VaardigheidId = @id";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
                command.Parameters.AddWithValue("@score", rating.Score);
                command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
                command.Parameters.AddWithValue("@id", rating.vaardigheidDTO.Id);
                db.OpenConnection();
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

        public void UpdateRating(MedewerkerDTO med, RatingDTO rating)
        {
            VaardigheidDTO? vaar = BestaandeVaardigeheid(rating.vaardigheidDTO.Naam);
            if (vaar != null)
            {
                db.OpenConnection();
                string query = "UPDATE MedewerkerVaardigheid SET VaardigheidId = @vaarID, Beschrijving = @beschrijving, Score = @score, LaatsteDatum = @laatsteDatum WHERE VaardigheidId = @id AND MedewerkerId = @medID";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@vaarID", vaar.Id);
                command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
                command.Parameters.AddWithValue("@score", rating.Score);
                command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
                command.Parameters.AddWithValue("@id", rating.vaardigheidDTO.Id);
                command.Parameters.AddWithValue("@medID", med.Id);
                command.ExecuteNonQuery();
                db.CloseConnetion();
            }
            else
            {
                VaardigheidDTO v = Create(rating.vaardigheidDTO);
                db.OpenConnection();
                string query = "UPDATE MedewerkerVaardigheid SET VaardigheidId = @vaarID, Beschrijving = @beschrijving, Score = @score, LaatsteDatum = @laatsteDatum WHERE VaardigheidId = @id AND MedewerkerId = @medID";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@vaarID", v.Id);
                command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
                command.Parameters.AddWithValue("@score", rating.Score);
                command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
                command.Parameters.AddWithValue("@id", rating.vaardigheidDTO.Id);
                command.Parameters.AddWithValue("@medID", med.Id);
                command.ExecuteNonQuery();
                db.CloseConnetion();
            }
 
        }
        public VaardigheidDTO FindVaardigheid(int id)
        {
            db.OpenConnection();
            string query = @"SELECT * FROM Vaardigheid WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();
            VaardigheidDTO dto = null;
            {
                while (reader.Read())
                {
                    dto = new VaardigheidDTO(
                        reader["Naam"].ToString(),
                        Convert.ToInt32(reader["Id"]));
                }
            }
            db.CloseConnetion();
            return dto;
        }
        public RatingDTO FindRating(int MedewerkerId, int VaardigheidId)
        {
            db.OpenConnection();
            string query = @"SELECT * FROM MedewerkerVaardigheid WHERE MedewerkerId = @medId AND VaardigheidId = @vaarId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@medId", MedewerkerId);
            command.Parameters.AddWithValue("@vaarId", VaardigheidId);
            SqlDataReader reader = command.ExecuteReader();
            RatingDTO rating = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    rating = new RatingDTO(
                        Convert.ToInt32(reader["Score"]),
                        reader["Beschrijving"].ToString(),
                        Convert.ToDateTime(reader["LaatsteDatum"]));
                }
            }
            db.CloseConnetion();
            return rating;
        }
    }
}
