using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class LoteInsumo
    {
        public int LoteInsumoID { get; set; }

        [ForeignKey("_Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }

        public int MarcaId { get; set; }
        public virtual Marca _Marca { get; set; }

        public double Qtde { get; set; }
        public double ValorCustoMedio { get; set; }
        public DateTime Validade { get; set; }
        public DateTime DataCompra { get; set; }



        //VERIFICAR PARA COLOCAR OPÇÃO DE MARCA DO INSUMO
    }
}
