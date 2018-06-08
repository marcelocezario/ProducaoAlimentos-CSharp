using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemEstoque
    {
        public int ItemEstoqueID { get; set; }
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }
        public double QtdeEstoque { get; set; }
        public double ValorEstoque { get; set; }
    }
}
