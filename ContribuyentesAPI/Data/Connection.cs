using System.Data.SqlClient;
namespace ContribuyentesAPI.Data
{
    public class Connection
    {
        private string connectionString = string.Empty;

        public Connection()
        {
           var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = builder.GetSection("ConnectionStrings:SQLString").Value;
        }

        public string getConnectionString()
        {
            return connectionString;
        }
    }
}
