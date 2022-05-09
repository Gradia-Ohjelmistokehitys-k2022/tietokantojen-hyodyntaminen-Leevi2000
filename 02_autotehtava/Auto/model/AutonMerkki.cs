using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokauppa.model
{
    public class AutonMerkki
    {
        private string _Merkki;
        private int _Id;

       
        public int Id { get => _Id; set => _Id = value; }
        public string Merkki { get => _Merkki; set => _Merkki = value; }
    }
}
