using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ItemComposicaoProduto
    {
        public int ItemComposicaoProdutoID { get; set; }

        [ForeignKey("_Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }

        public double QtdeInsumo { get; set; }
    }
}
