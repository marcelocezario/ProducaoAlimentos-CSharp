﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class LoteInsumo
    {
        public int LoteInsumoID { get; set; }

        [ForeignKey("_Insumo")]
        public int InsumoID { get; set; }
        public virtual Insumo _Insumo { get; set; }

        [ForeignKey("_Marca")]
        public int MarcaId { get; set; }
        public virtual Marca _Marca { get; set; }

        public double QtdeInicial { get; set; }
        public double QtdeDisponivel { get; set; }
        public double CustoMedio { get; set; }
        public double CustoTotalInicial { get; set; }
        public DateTime DataCompra { get; set; }
        public DateTime Validade { get; set; }
    }
}
