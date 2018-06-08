using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }

        [ForeignKey("_UnidadeDeMedida")]
        public int UnidadeDeMedidaID { get; set; }
        public virtual UnidadeDeMedida _UnidadeDeMedida { get; set; }

        public virtual List<ItemComposicaoProduto> ComposicaoProduto { get; set; }
    }
}
