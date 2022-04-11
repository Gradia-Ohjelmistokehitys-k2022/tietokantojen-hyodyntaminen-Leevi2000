using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokauppa.model
{
    public class AutonMalli
    {
        private int _Id;
        private string _Nimi;
        private int _MerkkiId;

        public int Id { get => _Id; set => _Id = value; }
        public string Nimi { get => _Nimi; set => _Nimi = value; }
        public int MerkkiId { get => _MerkkiId; set => _MerkkiId = value; }
    }
}
