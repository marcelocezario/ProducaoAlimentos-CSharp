using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class InsumoComposicaoProduto
    {
        public int InsumoComposicaoProdutoID { get; set; }

        [ForeignKey("_Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }

        public double QtdeInsumo { get; set; }
    }
}
