using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoteProduto
    {
        public int LoteProdutoID { get; set; }
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }
        public double Qtde { get; set; }
        public double ValorCustoMedio { get; set; }
        public double ValorVendaMedio { get; set; }
        public DateTime Validade { get; set; }
        public DateTime DataProducao { get; set; }
    }
}
