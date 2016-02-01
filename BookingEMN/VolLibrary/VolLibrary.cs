using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace VolLibrary
{
    [Transaction (TransactionOption.Required), ObjectPooling (5, 10), EventTrackingEnabled]
    public class LibVol : ServicedComponent
    {
        public LibVol()
        {
          
        }

        [AutoComplete]
        public int EnregistrerVol(int id, string nom, string prenom, string telephone, string mail)
        {
            // Connexion à la BDD
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=GOURBI-PC\\SQLEXPRESS;Initial Catalog=CMDVOL;Persist Security Info=True;User ID=ext;Password=commodor64";
            connection.Open();

            // Exécution de la requête
            SqlCommand command = new SqlCommand("sp_enregistrerCommandeVol", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idVol", id);
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
