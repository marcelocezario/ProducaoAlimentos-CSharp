using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemComposicaoProduto
    {
        public int ItemComposicaoProdutoID { get; set; }
        public int ProdutoID { get; set; }
        public int InsumoID { get; set; }
        public virtual int _Insumo { get; set; }
        public double QuantidadeInsumo { get; set; }
    }
}
