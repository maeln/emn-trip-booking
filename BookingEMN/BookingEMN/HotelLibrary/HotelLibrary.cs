using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HotelLibrary
{
    [Transaction(TransactionOption.Required), ObjectPooling(5, 10), EventTrackingEnabled]
    public class LibHotel : ServicedComponent
    {
        public LibHotel()
        {

        }

        [AutoComplete]
        public int EnregistrerHotel(int id, string dateDebut, string dateFin, string nom, string prenom, string telephone, string mail)
        {
            // Connexion à la BDD
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=GOURBI-PC\\SQLEXPRESS;Initial Catalog=CMDHOTEL;Persist Security Info=True;User ID=ext;Password=commodor64";
            connection.Open();

            // Exécution de la requête
            SqlCommand command = new SqlCommand("sp_enregistrerCommandeHotel", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idHotel", id);
            command.Parameters.AddWithValue("@dateDebut", dateDebut);
            command.Parameters.AddWithValue("@dateFin", dateFin);
            command.Parameters.AddWithValue("@nom", nom);
            command.Parameters.AddWithValue("@prenom", prenom);
            command.Parameters.AddWithValue("@telephone", telephone);
            command.Parameters.AddWithValue("@mail", mail);
            int resultat = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();

            // Fermeture de la connexion
            connection.Close();

            return resultat;
        }
    }
}
