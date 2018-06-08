using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoteInsumo
    {
        public int LoteInsumoID { get; set; }
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }
        public double Qtde { get; set; }
        public double ValorCustoMedio { get; set; }
        public DateTime Validade { get; set; }
        public DateTime DataCompra { get; set; }



        //VERIFICAR PARA COLOCAR OPÇÃO DE MARCA DO INSUMO
    }
}
