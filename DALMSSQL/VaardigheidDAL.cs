﻿using InterfaceLib;
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
            if(BestaandeVaardigeheid(vaardigheid.Naam) == null)
            {
                db.OpenConnection();
                string query = @"INSERT INTO Vaardigheid VALUES(@naam)";
                SqlCommand command = new SqlCommand(@query, db.connection);
                command.Parameters.AddWithValue("@naam", vaardigheid.Naam);
                command.ExecuteNonQuery();
                db.CloseConnetion();
            }
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

        public List<VaardigheidDTO> FindByMedewerker(MedewerkerDTO medewerker)
        {
            List<VaardigheidDTO> vaardigheden = new List<VaardigheidDTO>();
            db.OpenConnection();
            string query = @"SELECT * FROM Vaardigheid 
            INNER JOIN MedewerkerVaardigheden on Vaardigheid.Vaardigheid_id
            WHERE MedewerkerVaardigheden.medewerker_id = @medId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@medId", medewerker.Id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    vaardigheden.Add(new VaardigheidDTO(
                        reader["Naam"].ToString(),
                        Convert.ToInt32(reader["Vaardigheid_id"])));
                }
            }
            db.CloseConnetion();
            return vaardigheden;
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
                    Convert.ToInt32(reader["Vaardigheid_id"])));
                }
            }
            db.CloseConnetion();
            return vaardigheden;
        }

        public VaardigheidDTO? BestaandeVaardigeheid(string naam)
        {
            VaardigheidDTO dto = null;
            int index = GetAll().FindIndex(x => x.Naam == naam.ToLower());
            if(index >= 0)
            {
                dto = new VaardigheidDTO(GetAll()[index].Naam, GetAll()[index].Id);
            }
            return dto;
        }
        
        public void Update(VaardigheidDTO vaardigheid)
        {
            db.OpenConnection();
            string query = @"UPDATE Vaardigheid SET Naam = @naam WHERE Vaardigheid_id = @vaarId";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@vaarId", vaardigheid.Id);
            command.Parameters.AddWithValue("@naam", vaardigheid.Naam);
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }

        public void VerwijderVaarigheidVanMedewerker(MedewerkerDTO medewerker, VaardigheidDTO vaardigheid)
        {
            db.OpenConnection();
            string query = @"DELETE FROM MedewerkerVaardigheden WHERE Vaardigheid_id = @vaarId AND Medewerker_id = @medID";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@vaarId", vaardigheid.Id);
            command.Parameters.AddWithValue("@medID", medewerker.Id);
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }

        public void VoegVaardigheidToeAanMedewerker(MedewerkerDTO medewerker, VaardigheidDTO vaardigheid, RatingDTO rating)
        {
            if(BestaandeVaardigeheid(vaardigheid.Naam) != null)
            {
                db.OpenConnection();
                string query = @"INSERT INTO MedewerkerVaardigheden VALUES(@medID,@vaardID,@beschrijving @score ,@laatsteDatum)";
                SqlCommand command = new SqlCommand(query, db.connection);
                command.Parameters.AddWithValue("@medID", medewerker.Id);
                command.Parameters.AddWithValue("@vaardID", BestaandeVaardigeheid(vaardigheid.Naam).Id);
                command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
                command.Parameters.AddWithValue("@score", rating.Score);
                command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
                command.ExecuteNonQuery();
                db.CloseConnetion();
            }
        }
        public void Update(RatingDTO rating)
        {
            db.OpenConnection();
            string query = "UPDATE Rating SET Beschrijving = @beschrijving, LaatsteDatum = @laatsteDatum WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
            command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
            command.Parameters.AddWithValue("@id", rating.Id);
            db.OpenConnection();
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }
    }
}
