using ContribuyentesAPI.Models;
using System.Data.SqlClient;

namespace ContribuyentesAPI.Data
{
    public class ContribuyentesData
    {
        

        public List<ContribuyenteModel> GetContribuyentes()
        {
            List<ContribuyenteModel> contribuyentes = new List<ContribuyenteModel>();

            var cn = new Connection();

            using (var connection = new SqlConnection(cn.getConnectionString()))
            {
                connection.Open();
                string query = "SELECT * FROM Contribuyentes";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ContribuyenteModel contribuyente = new ContribuyenteModel();
                            contribuyente.RncCedula = reader["RncCedula"].ToString();
                            contribuyente.Nombre = reader["Nombre"].ToString();
                            contribuyente.Tipo = reader["Tipo"].ToString();
                            contribuyente.Estatus = reader["Estatus"].ToString();
                            contribuyentes.Add(contribuyente);
                        }
                    }
                }
            }
            return contribuyentes;
        }

        public ContribuyenteModel GetContribuyente(string rncCedula)
        {
            ContribuyenteModel contribuyente = null; // Initialize to null

            var cn = new Connection();
            using (SqlConnection connection = new SqlConnection(cn.getConnectionString()))
            {
                connection.Open();
                string query = "SELECT * FROM Contribuyentes WHERE RncCedula = @RncCedula";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RncCedula", rncCedula);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if data is found
                        {
                            contribuyente = new ContribuyenteModel(); // Initialize the model
                            contribuyente.RncCedula = reader["RncCedula"].ToString();
                            contribuyente.Nombre = reader["Nombre"].ToString();
                            contribuyente.Tipo = reader["Tipo"].ToString();
                            contribuyente.Estatus = reader["Estatus"].ToString();
                        }
                    }
                }
            }
            return contribuyente;
        }

    }
}
