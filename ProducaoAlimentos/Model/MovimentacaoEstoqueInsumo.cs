using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class MovimentacaoEstoqueInsumo
    {
        public int MovimentacaoEstoqueInsumoID { get; set; }

        public DateTime DataMovimentacao { get; set; }
        public double Qtde { get; set; }

        [ForeignKey("_LoteInsumo")]
        public int LoteInsumoID { get; set; }
        public virtual LoteInsumo _LoteInsumo { get; set; }
    }
}
