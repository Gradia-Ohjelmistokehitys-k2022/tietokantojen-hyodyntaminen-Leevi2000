using System.Data.SqlClient;
using System.Data;
using System.IO;
using System;

namespace Operations
{
    public class Commands
    {
        static string  _ConnectionString = @"Server = (localdb)\MSSQLLocalDB; ;Database=Opiskelijaryhma;Trusted_Connection = True";
        static string _StudentTableName = "Opiskelija";
        static string _GroupTableName = "OpiskelijaRyhmaTaulu";
        static string _Column1 = "Etunimi";
        static string _Column2 = "Sukunimi";
        static string _Column3 = "RyhmaId";

        /// <summary>
        /// Returns a DataTable of students from connected Database.
        /// </summary>
        /// <returns></returns>
        public static DataTable ReadStudentDataBase()
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            try
            {
                _connection.Open();
    
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM [dbo].[{_StudentTableName}] ORDER BY Sukunimi, Etunimi", _connection);
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
        /// Returns a DataTable of groups from connected Database.
        /// </summary>
        /// <returns></returns>
        public static DataTable ReadGroupDataBase()
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            try
            {
                _connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM [dbo].[{_StudentTableName}] LEFT JOIN [dbo].[{_GroupTableName}] ON {_StudentTableName}.RyhmaId={_GroupTableName}.Id", _connection);
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
        /// Takes in custom command. Most preferably select command, since this method returns datatable.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static DataTable ReadGivenCommand(string cmd)
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(cmd, _connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
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

        public static DataTable GetGroups()
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter($"SELECT * FROM [dbo].[{_GroupTableName}]", _connection);
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

        /// <summary>
        /// Creates a new row to a database and assigns specified names/cell values to it.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public static void AddRow(string firstName, string lastName, string groupId)
        {
            SqlConnection _connection = new SqlConnection(_ConnectionString);
            _connection.Open();
            SqlCommand command = new SqlCommand($"INSERT INTO {_StudentTableName} ({_Column1}, {_Column2}, {_Column3})" +
                                                $"VALUES ('{firstName}','{lastName}','{groupId}')", _connection);
            command.ExecuteNonQuery();
            _connection.Close();
        }

        /// <summary>
        /// Creates an message that can be shown to user. Message contains ID and the new name(s).
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string CreateMSGFromRow(DataGridViewRow row, bool userBeingDeleted = false)
        {
            string msg;
            if(userBeingDeleted) { msg = $"Poistettu käyttäjä ID:{row.Cells[0].Value.ToString()}, {row.Cells[1].Value.ToString()}" + $" {row.Cells[2].Value.ToString()}"; }
            else { msg = $"Muutettu käyttäjää ID:{row.Cells[0].Value.ToString()}, {row.Cells[1].Value.ToString()}" + $" {row.Cells[2].Value.ToString()}"; }
            
            return msg;
        }

       
    }
}
