using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Forms
{
    internal class UnsavedChanges
    {
        List<SqlCommand> sqlCommandList = new List<SqlCommand>();

        void AddChange(int id, string firstName, string lastName)
        {
            SqlCommand command = new SqlCommand($"INSERT INTO Opiskelija (Etunimi, Sukunimi)" +
                                                $"VALUES ('{firstName}','{lastName}')");
            sqlCommandList.Add(command);
        }
    }
}
