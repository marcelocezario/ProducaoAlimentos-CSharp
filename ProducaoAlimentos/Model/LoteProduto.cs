using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class LoteProduto
    {
        public int LoteProdutoID { get; set; }

        [ForeignKey("_Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }

        public virtual List<LoteInsumoProducao> _ItemInsumoProducao { get; set; }

        public double QtdeInicial { get; set; }
        public double QtdeDisponivel { get; set; }
        public double CustoMedio { get; set; }
        public double CustoTotalInicial { get; set; }
        public double ValorVendaUnitario { get; set; }
        public DateTime Validade { get; set; }
        public DateTime DataProducao { get; set; }
    }
}
