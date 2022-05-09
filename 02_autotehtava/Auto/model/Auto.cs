using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokauppa.model
{
    public class Auto
    {
        private int _Id;
        private decimal _Price;
        private DateTime _RegistryDate;
        private decimal _EngineVolume;
        private int _Meter;
        private int _CarBrandId;
        private int _CarModelId;
        private int _ColorId;
        private int _FuelTypeId;
        public Auto(int Id, decimal Price, DateTime RegistryDate, decimal EngineVolume, int Meter, int CarBrandId, int CarModelId, int ColorId, int FuelTypeId)
        {
            _Id = Id;
            _Price = Price;
            _RegistryDate = RegistryDate;
            _EngineVolume = EngineVolume;
            _Meter = Meter;
            _CarBrandId = CarBrandId;
            _CarModelId = CarModelId;
            _ColorId = ColorId;
            _FuelTypeId = FuelTypeId;
        }
        public Auto()
        {

        }
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime RegistryDate { get; set; }
        public decimal EngineVolume { get; set; }
        public int Meter { get; set; }
        public int CarBrandId { get; set; }
        public int CarModelId { get; set; }
        public int ColorId { get; set; }
        public int FuelTypeId { get; set; }
    }
}
