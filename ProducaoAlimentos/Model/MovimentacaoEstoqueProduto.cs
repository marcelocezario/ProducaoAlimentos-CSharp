using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class MovimentacaoEstoqueProduto
    {
        public int MovimentacaoEstoqueProdutoID { get; set; }

        public DateTime DataMovimentacao { get; set; }
        public double Qtde { get; set; }

        [ForeignKey("_LoteInsumo")]
        public int LoteProdutoID { get; set; }
        public virtual LoteProduto _LoteProduto { get; set; }
    }
}
