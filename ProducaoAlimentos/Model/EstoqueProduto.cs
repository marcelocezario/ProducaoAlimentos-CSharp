using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class EstoqueProduto
    {
        public int EstoqueProdutoID { get; set; }

        [ForeignKey("_Produto")]
        public int ProdutoID { get; set; }
        public virtual Produto _Produto { get; set; }

        public double QtdeTotalEstoque { get; set; }
        public double CustoTotalEstoque { get; set; }
    }
}
