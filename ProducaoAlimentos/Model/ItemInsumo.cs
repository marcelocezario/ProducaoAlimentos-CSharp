using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ItemInsumo
    {
        public int ItemInsumoID { get; set; }

        [ForeignKey("_Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }

        public double QtdeTotalEstoque { get; set; }
        public double CustoTotalEstoque { get; set; }
    }
}
