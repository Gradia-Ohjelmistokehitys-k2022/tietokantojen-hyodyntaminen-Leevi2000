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

        /// <summary>
        /// Gets all car brands.
        /// </summary>
        /// <returns></returns>
        public List<AutonMerkki> getAllAutoMakers() {

            return dbModel.getAllAutoMakersFromDatabase();
        }

        /// <summary>
        /// Gets all car models, brand id must be given.
        /// </summary>
        /// <param name="makerId"></param>
        /// <returns></returns>
        public List<AutonMalli> getAutoModels(int makerId) {

            return dbModel.getAutoModelsByMakerId(makerId);
        }

        /// <summary>
        /// Gets all fuel/consumption types.
        /// </summary>
        /// <returns></returns>
        public List<Polttoaine> GetFuelType()
        {
            return dbModel.MGetFuelType();
        }

        /// <summary>
        /// Gets all color variations.
        /// </summary>
        /// <returns></returns>
        public List<Varit> GetColors()
        {
            return dbModel.MGetColors();
        }

        /// <summary>
        /// Saves the car into database.
        /// </summary>
        /// <param name="newCar"></param>
        /// <returns></returns>
        public bool SaveCar(model.Auto newCar)
        {
            bool success = dbModel.SaveCarIntoDB(newCar);
            return success;    
        }

        /// <summary>
        /// Gets the next car, the id of the current car must be given.
        /// </summary>
        /// <param name="currentId"></param>
        /// <param name="getPrevious"></param>
        /// <returns></returns>
        public Auto GetNextCar(int currentId, bool getPrevious = false)
        {
            return dbModel.MGetNextCar(currentId, getPrevious);
        }

        /// <summary>
        /// Gets a car by the given id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Auto GetCarByID(int Id)
        {
            return dbModel.MGetCarByID(Id);
        }
        
        /// <summary>
        /// Search query.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the next or previous set of results from search query.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="previous"></param>
        /// <returns></returns>
        public DataTable UserSeachNext(Haku search, bool previous = false)
        {
            return dbModel.MUserSeachNext(search, previous);
        }

        public bool ToFloatChecker(string s)
        {
            return float.TryParse(s, out float f);
        }

        /// <summary>
        /// Deletes currently selected car.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteCarFromDB(int Id)
        { 
            return dbModel.MDeleteCarFromDB(Id);
        }

        /// <summary>
        /// Gets information about the latest car added.
        /// </summary>
        /// <returns></returns>
        public Auto GetNewestCar()
        {
            return dbModel.MGetNewestCar();
        }
    }
}
