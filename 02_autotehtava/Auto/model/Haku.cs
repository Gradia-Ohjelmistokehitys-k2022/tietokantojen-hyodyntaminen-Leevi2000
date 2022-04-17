using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Autokauppa.model
{
    public class Haku
    {
        private string _hakuKategoria;
        private string _hakuSana;
        private DataTable _dataTable;

        public Haku(string Kategoria, string Hakusana)
        {
            _hakuSana = Hakusana;
            _hakuKategoria = Kategoria;
        }
        public string HakuKategoria { get => _hakuKategoria; set => _hakuKategoria = value; }
        public string HakuSana { get => _hakuSana; set => _hakuSana = value; }
        public DataTable DataTable { get => _dataTable; set => _dataTable = value; }
    }
}
