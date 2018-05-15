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


        List <UnidadeDeMedida> unidadesDeMedida = new List<UnidadeDeMedida>()
        {
            new UnidadeDeMedida(){ Nome = "Centimetro", Sigla = "cm", Fracionavel = true},
            new UnidadeDeMedida(){ Nome = "Litro", Sigla = "l", Fracionavel = true},
            new UnidadeDeMedida(){ Nome = "Quilo", Sigla = "kg", Fracionavel = true},
            new UnidadeDeMedida(){ Nome = "Unidade", Sigla = "un", Fracionavel = false}
        };
    }
}
