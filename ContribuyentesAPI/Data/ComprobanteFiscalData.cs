using ContribuyentesAPI.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ContribuyentesAPI.Data
{
    public class ComprobantesFiscalesData
    {
        public List<ComprobanteFiscalModel> GetComprobantesFiscales()
        {
            List<ComprobanteFiscalModel> comprobantes = new List<ComprobanteFiscalModel>();

            var cn = new Connection();

            using (var connection = new SqlConnection(cn.getConnectionString()))
            {
                connection.Open();
                string query = "SELECT * FROM ComprobantesFiscales";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ComprobanteFiscalModel comprobante = new ComprobanteFiscalModel();
                            comprobante.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            comprobante.RncCedula = reader["RncCedula"].ToString();
                            comprobante.NCF = reader["NCF"].ToString();
                            comprobante.Monto = reader.GetDecimal(reader.GetOrdinal("Monto"));
                            comprobante.Itbis18 = reader.GetDecimal(reader.GetOrdinal("Itbis18"));
                            comprobantes.Add(comprobante);
                        }
                    }
                }
            }
            return comprobantes;
        }

        public List<ComprobanteFiscalModel> GetComprobantesFiscalesByRnc(string rncCedula)
        {
            List<ComprobanteFiscalModel> comprobantes = new List<ComprobanteFiscalModel>();

            var cn = new Connection();
            using (SqlConnection connection = new SqlConnection(cn.getConnectionString()))
            {
                connection.Open();
                string query = "SELECT * FROM ComprobantesFiscales WHERE RncCedula = @RncCedula";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RncCedula", rncCedula);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ComprobanteFiscalModel comprobante = new ComprobanteFiscalModel();
                            comprobante.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            comprobante.RncCedula = reader["RncCedula"].ToString();
                            comprobante.NCF = reader["NCF"].ToString();
                            comprobante.Monto = reader.GetDecimal(reader.GetOrdinal("Monto"));
                            comprobante.Itbis18 = reader.GetDecimal(reader.GetOrdinal("Itbis18"));
                            comprobantes.Add(comprobante);
                        }
                    }
                }
            }
            return comprobantes;
        }

        public decimal GetTotalMontoByRnc(string rncCedula)
        {
            decimal totalMonto = 0;

            var cn = new Connection();
            using (SqlConnection connection = new SqlConnection(cn.getConnectionString()))
            {
                connection.Open();
                string query = "SELECT SUM(Monto + Itbis18) AS TotalMonto FROM ComprobantesFiscales WHERE RncCedula = @RncCedula";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RncCedula", rncCedula);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalMonto = Convert.ToDecimal(result);
                    }
                }
            }
            return totalMonto;
        }
    }
}
