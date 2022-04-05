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
        public static void ChangeValue(DataTable formDataTable)
        {
            var savedTable = ReadDatabase();
            var x = savedTable.Rows;

            SqlConnection _connection = new SqlConnection(_ConnectionString);
            _connection.Open();

            DataSet ds = new DataSet();
            ds.Tables.Add(savedTable);

            //SqlCommand command = new SqlCommand($"INSERT INTO {_tableName} {formDataTable} " +
            //                                    "Values ('string', 1)", _connection);
            //string sql = "INSERT INTO T (A, B, C) VALUES (@A, @B, @C)";
            //SqlCommand command = _connection.CreateCommand();
            //command.CommandText = sql;
            //command.Parameters()

            //command.ExecuteNonQuery();

            _connection.Close();
        }

        public static void AddRow(string firstName, string lastName)
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            _connection.Open();
            SqlCommand command = new SqlCommand($"INSERT INTO {_tableName} ({_Column1}, {_Column2})" +
                                                $"VALUES ('{firstName}','{lastName}')", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }




    }
}
