﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Insumo
    {
        public int InsumoID { get; set; }
        public string Nome { get; set; }

        [ForeignKey("_UnidadeDeMedida")]
        public int UnidadeDeMedidaID { get; set; }
        public virtual UnidadeDeMedida _UnidadeDeMedida { get; set; }
    }
}
