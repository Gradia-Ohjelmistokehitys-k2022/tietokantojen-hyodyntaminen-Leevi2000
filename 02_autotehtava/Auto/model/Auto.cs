using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokauppa.model
{
    public class Auto
    {
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
