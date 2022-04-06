using System.Data.SqlClient;
using System.Data;

namespace Operations
{
    public class Commands
    {
        static string  _ConnectionString = @"Server = (localdb)\MSSQLLocalDB; Database = Opiskelijaryhma; Trusted_Connection = True;";
        static string _tableName = "Opiskelija";
        static string _Column1 = "Etunimi";
        static string _Column2 = "Sukunimi";
        /// <summary>
        /// Returns a DataTable from a connected Database.
        /// </summary>
        /// <returns></returns>
        public static DataTable ReadDatabase()
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            try
            {
                _connection.Open();
    
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM [dbo].[{_tableName}] ORDER BY Sukunimi, Etunimi", _connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                _connection.Close();
                return dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _connection.Close();
                return null;
            }
        }

        /// <summary>
        /// Sends given command to the database.
        /// </summary>
        /// <param name="cmd"></param>
        public static void ExecuteCommand(string cmd)
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            _connection.Open();
            SqlCommand command = new SqlCommand(cmd, _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        public void SaveChanges(DataTable formDataTable)
        {
            var x = formDataTable.Rows;
            foreach (var item in x)
            {

            }
        }

        /// <summary>
        /// Creates a new row to a database and assigns specified names/cell values to it.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public static void AddRow(string firstName, string lastName)
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            _connection.Open();
            SqlCommand command = new SqlCommand($"INSERT INTO {_tableName} ({_Column1}, {_Column2})" +
                                                $"VALUES ('{firstName}','{lastName}')", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        /// <summary>
        /// Creates an message that can be shown to user. Message contains ID and the new name(s).
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string CreateMSGFromRow(DataGridViewRow row)
        {
            string msg = $"Muutettu käyttäjää ID:{row.Cells[0].Value.ToString()}, {row.Cells[1].Value.ToString()}" + $" {row.Cells[2].Value.ToString()}";
            return msg;
        }

       
    }
}
