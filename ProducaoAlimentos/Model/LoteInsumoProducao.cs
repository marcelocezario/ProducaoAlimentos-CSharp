using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class LoteInsumoProducao
    {
        public int LoteInsumoProducaoID { get; set; }

        public double QtdeInsumo { get; set; }
        public double CustoInsumo { get; set; }

        [ForeignKey("_LoteInsumo")]
        public int LoteInsumoID { get; set; }
        public virtual LoteInsumo _LoteInsumo { get; set; }
    }
}
