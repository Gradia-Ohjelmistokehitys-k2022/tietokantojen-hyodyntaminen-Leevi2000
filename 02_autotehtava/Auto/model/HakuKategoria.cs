using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Autokauppa.model
{
    public class HakuKategoria
    {
        private string _Id;
        private string _Name;

        public HakuKategoria(string Id, string Name)
        {
            _Id = Id;
            _Name = Name;
        }


        public string Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
    }
}
