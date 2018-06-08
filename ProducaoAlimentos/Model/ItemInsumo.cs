using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemInsumo
    {
        public int ItemInsumoID { get; set; }
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }
        public double QtdeTotalEstoque { get; set; }
        public double CustoTotalEstoque { get; set; }
    }
}
