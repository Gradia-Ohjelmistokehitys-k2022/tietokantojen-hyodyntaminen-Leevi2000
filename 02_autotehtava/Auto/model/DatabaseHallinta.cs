using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Autokauppa.model
{
    public class DatabaseHallinta
    {
        string yhteysTiedot;
        SqlConnection dbYhteys;

        public DatabaseHallinta()
        {
            dbYhteys = new SqlConnection();
            yhteysTiedot = @"Server = (localdb)\MSSQLLocalDB; Database = Autokauppa; Trusted_Connection = True;";
            dbYhteys.ConnectionString = yhteysTiedot;
        }

        public bool connectDatabase()
        {
            try
            { 
                dbYhteys.Open();
                dbYhteys.Close();
                return true;
            }
            catch(Exception e)
            { 
                Console.WriteLine("Virheilmoitukset:" + e);
                return false;
            }
            
        }

        public void disconnectDatabase()
        {
            dbYhteys.Close();
        }

        public bool saveAutoIntoDatabase(Auto newAuto)
        {
            bool palaute = false;
            return palaute;

            
        }

        public List<AutonMerkki> getAllAutoMakersFromDatabase()
        {
            List<AutonMerkki> palaute = new List<AutonMerkki>();

            var dataTable = GetDataTable("SELECT * FROM [dbo].[AutonMerkki]");

            foreach(DataRow row in dataTable.Rows)
            {
                AutonMerkki merkki = new AutonMerkki();
                foreach(DataColumn column in dataTable.Columns)
                {
                    if(column.ToString() == "ID")
                    {
                        merkki.Id = int.Parse(row[column].ToString());
                    }
                    else
                    {
                        merkki.Merkki = row[column].ToString();
                    }
                }
                palaute.Add(merkki);
            }
            disconnectDatabase();
            return palaute;
        }

        public List<AutonMalli> getAutoModelsByMakerId(int makerId)   
        {
            var dataTable = GetDataTable($"SELECT * FROM [dbo].[AutonMallit] WHERE AutonMerkkiID = {makerId}");
            List<AutonMalli> palaute = new List<AutonMalli>();
            foreach (DataRow row in dataTable.Rows)
            {
                AutonMalli malli = new AutonMalli();
                malli.Id = int.Parse(row["ID"].ToString());
                malli.Nimi = row["Auton_mallin_nimi"].ToString();
                malli.MerkkiId = int.Parse(row["AutonMerkkiID"].ToString());
                palaute.Add(malli);
            }
            return palaute;
        }

        private DataTable GetDataTable(string cmd)
        {
            connectDatabase();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd, dbYhteys);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            disconnectDatabase();
            return dataTable;
        }

    }
}
