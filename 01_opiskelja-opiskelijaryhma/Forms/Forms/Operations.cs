using System.Data.SqlClient;
using System.Data;

namespace Operations
{
    public class Commands
    {
        static string  _ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = Opiskelijaryhma; Trusted_Connection = True;";
        static string _tableName = "Opiskelija";
        
        public static DataTable ConnectAndReadDatabase()
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            try
            {
                _connection.Open();
    
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM [dbo].[{_tableName}]", _connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                return dataTable;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }


        }
        public static void ChangeValue(string TableColumn)
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            SqlCommand command = new SqlCommand($"INSERT INTO {_tableName} {TableColumn} " +
                                                "Values ('string', 1)", _connection);
            command.ExecuteNonQuery();
        }





    }
}
