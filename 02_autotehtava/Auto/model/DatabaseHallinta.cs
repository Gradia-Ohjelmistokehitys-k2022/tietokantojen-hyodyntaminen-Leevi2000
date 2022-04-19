﻿using System;
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

            // Creating a car from DataRow
            foreach (DataRow r in carDataTable.Rows)
            {
                newCar.Id = int.Parse(r["ID"].ToString());
                newCar.Price = float.Parse(r["Hinta"].ToString());
                newCar.RegistryDate = DateTime.Parse(r["Rekisteri_paivamaara"].ToString());
                newCar.EngineVolume = float.Parse(r["Moottorin_tilavuus"].ToString());
                newCar.Meter = int.Parse(r["Mittarilukema"].ToString());
                newCar.CarBrandId = int.Parse(r["AutonMerkkiID"].ToString());
                newCar.CarModelId = int.Parse(r["AutonMalliID"].ToString());
                newCar.ColorId = int.Parse(r["VaritID"].ToString());
                newCar.FuelTypeId = int.Parse(r["PolttoaineID"].ToString());
            }
         
            return newCar;
        }

        private int GetCarIDFromRow(DataRowCollection row)
        {
            return int.Parse(row[0]["ID"].ToString());
        }

        public DataTable MUserSearch(Haku search)
        {
            DataTable dt = new DataTable();
            string cmd;

            if (search.HakuSana != null && search.HakuKategoria != null)
            {
                // SQLCommand with Category and word
                cmd = $"SELECT a.ID, a.Hinta, a.Rekisteri_paivamaara AS Rekisteröintipäivä, a.Moottorin_tilavuus AS 'Moottorin Tilavuus', a.Mittarilukema, b.Merkki, c.Auton_mallin_nimi AS Malli, d.Polttoaineen_nimi AS Polttoainetyyppi, e.Varin_nimi AS Väri FROM [dbo].[auto] a " +
                    $"LEFT JOIN [dbo].[AutonMerkki] b ON a.AutonMerkkiID = b.ID AND " +
                    $"LEFT JOIN [dbo].[AutonMallit] c ON a.AutonMalliID = c.ID " +
                    $"LEFT JOIN [dbo].[Polttoaine] d ON a.PolttoaineID = d.ID " +
                    $"LEFT JOIN [dbo].[Varit] e ON a.VaritID = e.ID " +
                    $"WHERE {search.HakuKategoria} LIKE {search.HakuSana}";
                dt = GetDataTable(cmd);
            }
            else if (search.HakuKategoria != null)
            {
                // SQLCommand with Category
            }
            else if (search.HakuSana != null)
            {
                // SQLCommand with word
            }

            return dt;
        }

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
    }
}
