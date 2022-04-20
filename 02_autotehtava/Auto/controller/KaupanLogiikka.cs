using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autokauppa.model;
using System.Data;

namespace Autokauppa.controller
{

    
    public class KaupanLogiikka
    {
        DatabaseHallinta dbModel = new DatabaseHallinta();

        public bool TestDatabaseConnection()
        {
            bool doesItWork = dbModel.connectDatabase();
            return doesItWork;
        }

        //public bool saveAuto(model.Auto newAuto) 
        //{
        //    bool didItGoIntoDatabase = dbModel.saveAutoIntoDatabase(newAuto);
        //    return didItGoIntoDatabase;
        //}

        public List<AutonMerkki> getAllAutoMakers() {

            return dbModel.getAllAutoMakersFromDatabase();
        }

        public List<AutonMalli> getAutoModels(int makerId) {

            return dbModel.getAutoModelsByMakerId(makerId);
        }

        public List<Polttoaine> GetFuelType()
        {
            return dbModel.MGetFuelType();
        }

        public List<Varit> GetColors()
        {
            return dbModel.MGetColors();
        }

        public bool SaveCar(model.Auto newCar)
        {
            bool success = dbModel.SaveCarIntoDB(newCar);
            return success;    
        }

        public Auto GetNextCar(int currentId, bool getPrevious = false)
        {
            return dbModel.MGetNextCar(currentId, getPrevious);
        }

        public Auto GetCarByID(int Id)
        {
            return dbModel.MGetCarByID(Id);
        }

        public DataTable UserSearch(Haku search)
        {
            return dbModel.MUserSearch(search);
        }

        /// <summary>
        /// Gets a list of auto (car) table's columns and also gives them a cleaner looking name for user.
        /// </summary>
        /// <returns></returns>
        public List<HakuKategoria> GetCarDBColumns()
        {
            return (dbModel.MGetCarDBColumns());
        }
    }
}
