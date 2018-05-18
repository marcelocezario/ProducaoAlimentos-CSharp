using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Insumo
    {
        public int InsumoID { get; set; }
        public string Nome { get; set; }
        public string UnidadeDeMedida { get; set; }
        public double ValorTotalEstoque { get; set; }
        public double QuantidadeTotalEstoque { get; set; }

        public double ApenasTeste { get; set; }
    }
}
