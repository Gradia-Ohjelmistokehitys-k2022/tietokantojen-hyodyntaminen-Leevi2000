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
            string cmd;

            if (c.Id == 0)
            {
                cmd = ($"INSERT INTO [dbo].[auto]" +
                $" ([Hinta], [Rekisteri_paivamaara], [Moottorin_tilavuus], [Mittarilukema]," +
                $" [AutonMerkkiID], [AutonMalliID], [VaritID], [PolttoaineID])" +
                $" VALUES (@Price, '{date}', @EngineVolume, {c.Meter}, {c.CarBrandId}," +
                $" {c.CarModelId}, {c.ColorId}, {c.FuelTypeId})");
            }
            else
            {
                cmd = ($"INSERT INTO [dbo].[auto]" +
                $" ([Hinta], [Rekisteri_paivamaara], [Moottorin_tilavuus], [Mittarilukema]," +
                $" [AutonMerkkiID], [AutonMalliID], [VaritID], [PolttoaineID])" +
                $" VALUES (@Price, '{date}', @EngineVolume, {c.Meter}, {c.CarBrandId}," +
                $" {c.CarModelId}, {c.ColorId}, {c.FuelTypeId})" +
                $" WHERE ID = {c.Id}");
            }

            SqlCommand sqlcmd = new SqlCommand(cmd, dbYhteys);
            sqlcmd.Parameters.AddWithValue("@EngineVolume", c.EngineVolume);
            sqlcmd.Parameters.AddWithValue("@Price", c.Price);
            sqlcmd.ExecuteNonQuery();
            bool success = true;
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd, dbYhteys);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
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

        /// <summary>
        /// Returns a list of possible color variations from database.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Gets previous or next car in database by ID from database and returns Car (Auto) object.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getPrevious"></param>
        /// <returns></returns>
        public Auto MGetNextCar(int id, bool getPrevious = false)
        {
            DataTable carDataTable = new DataTable();
            Auto newCar = new Auto();
            int currentId = id;

            if (currentId == 0) { carDataTable = GetDataTable($"SELECT TOP(1)* FROM [dbo].[auto] ORDER BY ID ASC"); }

            else if (getPrevious == true) 
            {
                var lowestId = GetCarIDFromRow(GetDataTable($"SELECT TOP(1)* FROM [dbo].[auto] ORDER BY ID ASC").Rows);

                if (currentId > lowestId) { carDataTable = GetDataTable($"SELECT TOP(1)* FROM [dbo].[auto] WHERE ID < {currentId} ORDER BY ID DESC "); } 
                else
                {
                    carDataTable = GetDataTable($"SELECT TOP(1)* FROM [dbo].[auto] WHERE ID > {currentId} ORDER BY ID DESC");
                }
            }
            else if (getPrevious == false) 
            {
                var highestId = GetCarIDFromRow(GetDataTable($"SELECT TOP(1)* FROM [dbo].[auto] ORDER BY ID DESC").Rows);

                if (currentId < highestId) { carDataTable = GetDataTable($"SELECT TOP(1)* FROM [dbo].[auto] WHERE ID > {currentId} ORDER BY ID ASC "); }
                else
                {
                    carDataTable = GetDataTable($"SELECT TOP(1)* FROM [dbo].[auto] WHERE ID < {currentId} ORDER BY ID ASC");
                }
            }
            newCar = CreateCarFromDataRowCollection(carDataTable.Rows);
         
            return newCar;
        }

        public Auto MGetCarByID(int Id)
        {
            var carDataTable = GetDataTable($"SELECT * FROM [dbo].[auto] WHERE ID = {Id}");
            Auto newCar = CreateCarFromDataRowCollection(carDataTable.Rows);
            return newCar;
        }

        /// <summary>
        /// Returns a car object of the last row in DataRowCollection. Usually used when collection has only one row. 
        /// </summary>
        /// <param name="RowCollection"></param>
        /// <returns></returns>
        private Auto CreateCarFromDataRowCollection(DataRowCollection RowCollection)
        {
            Auto c = new Auto();
            var rc = RowCollection;

            // Creating a car from DataRow
            foreach (DataRow r in rc)
            {
                c.Id = int.Parse(r["ID"].ToString());
                c.Price = float.Parse(r["Hinta"].ToString());
                c.RegistryDate = DateTime.Parse(r["Rekisteri_paivamaara"].ToString());
                c.EngineVolume = float.Parse(r["Moottorin_tilavuus"].ToString());
                c.Meter = int.Parse(r["Mittarilukema"].ToString());
                c.CarBrandId = int.Parse(r["AutonMerkkiID"].ToString());
                c.CarModelId = int.Parse(r["AutonMalliID"].ToString());
                c.ColorId = int.Parse(r["VaritID"].ToString());
                c.FuelTypeId = int.Parse(r["PolttoaineID"].ToString());
            }
            return c;
        }

        private int GetCarIDFromRow(DataRowCollection row)
        {
            return int.Parse(row[0]["ID"].ToString());
        }

        /// <summary>
        /// Returns a datatable of users search result.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public DataTable MUserSearch(Haku search)
        {
            DataTable dt = new DataTable();
            disconnectDatabase();
            connectDatabase();
            //ExecuteCommand($"DROP TABLE IF EXISTS #SearchTemp");
            ExecuteCommand($"IF OBJECT_ID('tempdb..#SearchTemp') IS NOT NULL BEGIN DROP TABLE #SearchTemp END");
            if (search.HakuSana != null && search.HakuKategoria != null)
            {
            
                if (search.HakuKategoria == "Hinta")
                {
                    ExecuteCommand($"SELECT TOP 250 * INTO #SearchTemp FROM [dbo].[auto] WHERE {search.HakuKategoria} BETWEEN ({search.HakuSana}-1000) AND ({search.HakuSana}+2000)");
                }
                else if (search.HakuKategoria == "Mittarilukema")
                {
                    ExecuteCommand($"SELECT TOP 250 * INTO #SearchTemp FROM [dbo].[auto] WHERE {search.HakuKategoria} BETWEEN ({search.HakuSana}-10000) AND ({search.HakuSana}+10000)");
                }
                else
                {
                    ExecuteCommand($"SELECT * INTO #SearchTemp FROM [dbo].[auto] WHERE {search.HakuKategoria} LIKE {search.HakuSana}");
                }
                // Temp db is used to reduce performance issues. 
                

                dt = GetDataTable("SELECT a.ID, a.Hinta, a.Rekisteri_paivamaara AS Rekisteröintipäivä, " +
                    "a.Moottorin_tilavuus AS 'Moottorin Tilavuus', a.Mittarilukema, b.Merkki, " +
                    "c.Auton_mallin_nimi AS Malli, d.Polttoaineen_nimi AS Polttoainetyyppi, " +
                    "e.Varin_nimi AS Väri FROM #SearchTemp a " +
                    $"LEFT JOIN [dbo].[AutonMerkki] b ON a.AutonMerkkiID = b.ID " +
                    $"LEFT JOIN [dbo].[AutonMallit] c ON a.AutonMalliID = c.ID " +
                    $"LEFT JOIN [dbo].[Polttoaine] d ON a.PolttoaineID = d.ID " +
                    $"LEFT JOIN [dbo].[Varit] e ON a.VaritID = e.ID");
            }
            ExecuteCommand($"DROP TABLE IF EXISTS #SearchTemp");
            return dt;
        }

        /// <summary>
        /// Gets a list of auto (car) table's columns and also gives them a cleaner looking name for user.
        /// </summary>
        /// <returns></returns>
        public List<HakuKategoria> MGetCarDBColumns()
        {
            var r = GetDataTable("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'auto' ORDER BY ORDINAL_POSITION").Rows;
            List<HakuKategoria> list = new List<HakuKategoria>();

            list.Add(new HakuKategoria(r[1]["COLUMN_NAME"].ToString(), "Hinta"));
            list.Add(new HakuKategoria(r[2]["COLUMN_NAME"].ToString(), "Rekisteröintipäivä"));
            list.Add(new HakuKategoria(r[3]["COLUMN_NAME"].ToString(), "Moottorin tilavuus"));
            list.Add(new HakuKategoria(r[4]["COLUMN_NAME"].ToString(), "Mittarilukema"));
            list.Add(new HakuKategoria(r[5]["COLUMN_NAME"].ToString(), "Auton Merkki"));
            list.Add(new HakuKategoria(r[6]["COLUMN_NAME"].ToString(), "Auton Malli"));
            list.Add(new HakuKategoria(r[7]["COLUMN_NAME"].ToString(), "Väri"));
            list.Add(new HakuKategoria(r[8]["COLUMN_NAME"].ToString(), "Polttoaine"));

            return list;
        }

        public void ExecuteCommand(string cmd)
        {
            SqlCommand command = new SqlCommand(cmd, dbYhteys);
            command.ExecuteNonQuery();
        }
    }
}
