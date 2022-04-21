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
            db.OpenConnection();
            string query = "INSERT INTO Rating VALUES @beschrijving, @laatsteDatum)";
            SqlCommand command = new SqlCommand(query, db.connection);
            command.Parameters.AddWithValue("@beschrijving", rating.Beschrijving);
            command.Parameters.AddWithValue("@laatsteDatum", rating.LaatsteDatum);
            db.OpenConnection();
            command.ExecuteNonQuery();
            db.CloseConnetion();
        }

    }

}

