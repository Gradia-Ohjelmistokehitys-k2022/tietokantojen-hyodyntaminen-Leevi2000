using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

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

                return true;
            }
            catch(Exception e)
            {
                dbYhteys.Close();
                Console.WriteLine("Virheilmoitukset:" + e);
                return false;
            }
            
        }

        public void disconnectDatabase()
        {
            dbYhteys.Close();
        }

        public bool SaveCarIntoDB(Auto c)
        {
            //  c.RegistryDate is in wrong format so this fixes it.
            string date = c.RegistryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            string cmd = ($"INSERT INTO [dbo].[auto]" +
                $" ([Hinta], [Rekisteri_paivamaara], [Moottorin_tilavuus], [Mittarilukema]," +
                $" [AutonMerkkiID], [AutonMalliID], [VaritID], [PolttoaineID])" +
                $" VALUES (@Price, '{date}', @EngineVolume, {c.Meter}, {c.CarBrandId}," +
                $" {c.CarModelId}, {c.ColorId}, {c.FuelTypeId})");

            connectDatabase();
            SqlCommand sqlcmd = new SqlCommand(cmd, dbYhteys);
            sqlcmd.Parameters.AddWithValue("@EngineVolume", c.EngineVolume);
            sqlcmd.Parameters.AddWithValue("@Price", c.Price);
            sqlcmd.ExecuteNonQuery();
            bool success = true;
            disconnectDatabase();
            return success;
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

        public List<Polttoaine> MGetFuelType()
        {
            var dataTable = GetDataTable($"SELECT * FROM [dbo].[Polttoaine]");
            List<Polttoaine> fuelTypes = new List<Polttoaine>();
            foreach(DataRow row in dataTable.Rows)
            {
                Polttoaine fuel = new Polttoaine();
                fuel.Id = int.Parse(row["ID"].ToString());
                fuel.Name = row["Polttoaineen_nimi"].ToString();
                fuelTypes.Add(fuel);
            }
            return fuelTypes;
        }

        public List<Varit> MGetColors()
        {
            var dataTable = GetDataTable($"SELECT * FROM [dbo].[Varit]");
            List<Varit> colors = new List<Varit>();
            foreach (DataRow row in dataTable.Rows)
            {
                Varit color = new Varit();
                color.Id = int.Parse(row["ID"].ToString());
                color.Name = row["Varin_nimi"].ToString();
                colors.Add(color);
            }
            return colors;
        }

    }
}
