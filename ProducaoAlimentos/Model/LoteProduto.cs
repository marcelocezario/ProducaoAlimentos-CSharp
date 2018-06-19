using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class LoteProduto
    {
        public int LoteProdutoID { get; set; }

        [ForeignKey("_Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }

        public int ItemInsumoProducaoID { get; set; }
        public virtual ItemInsumoProducao _ItemInsumoProducao { get; set; }

        public double Qtde { get; set; }
        public double ValorCustoMedio { get; set; }
        public double ValorVendaMedio { get; set; }
        public DateTime Validade { get; set; }
        public DateTime DataProducao { get; set; }
    }
}
