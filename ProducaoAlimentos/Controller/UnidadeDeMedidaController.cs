using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class UnidadeDeMedidaController
    {
        public bool SalvarUnidadeDeMedida(UnidadeDeMedida unidadeDeMedida)
        {
            ContextoSingleton.Instancia.UnidadesDeMedida.Add(unidadeDeMedida);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        public List<UnidadeDeMedida> ListarUnidadesDeMedida() => ContextoSingleton.Instancia.UnidadesDeMedida.ToList();

    }
}
