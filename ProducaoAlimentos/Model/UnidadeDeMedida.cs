using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UnidadeDeMedida
    {
        public int UnidadeDeMedidaID { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public bool Fracionavel { get; set; }
    }
}
