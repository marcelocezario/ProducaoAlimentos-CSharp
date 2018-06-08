using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ItemProduto
    {
        public int ItemProdutoID { get; set; }
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }
        public double QtdeTotalEstoque { get; set; }
        public double CustoTotalEstoque { get; set; }
    }
}
