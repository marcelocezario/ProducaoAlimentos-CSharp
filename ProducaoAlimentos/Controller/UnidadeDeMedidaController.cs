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
        // Métodos para Criação, Edição e Exclusão de Unidades de Medida
        public bool SalvarUnidadeDeMedida(UnidadeDeMedida unidadeDeMedida)
        {
            ContextoSingleton.Instancia.UnidadesDeMedida.Add(unidadeDeMedida);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarUnidadeDeMedida(int idUnidadeDeMedida, UnidadeDeMedida unidadeDeMedidaEditado)
        {
            UnidadeDeMedida unidadeDeMedidaEditar = BuscarUnidadeDeMedidaPorID(idUnidadeDeMedida);

            if (unidadeDeMedidaEditar != null)
            {
                unidadeDeMedidaEditado.UnidadeDeMedidaID = unidadeDeMedidaEditar.UnidadeDeMedidaID;
                unidadeDeMedidaEditar = unidadeDeMedidaEditado;

                ContextoSingleton.Instancia.Entry(unidadeDeMedidaEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirUnidadeDeMedida(UnidadeDeMedida unidadeDeMedida)
        {
            ContextoSingleton.Instancia.Entry(unidadeDeMedida).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos de busca
        public UnidadeDeMedida BuscarUnidadeDeMedidaPorID(int unidadeDeMedidaID)
        {
            return ContextoSingleton.Instancia.UnidadesDeMedida.Find(unidadeDeMedidaID);
        }
        public UnidadeDeMedida BuscarUnidadeDeMedidaPorNome(string nomeUnidadeDeMedida)
        {
            var um = from x in ContextoSingleton.Instancia.UnidadesDeMedida
                    where x.Nome.ToLower().Contains(nomeUnidadeDeMedida.Trim().ToLower())
                    select x;

            if (um != null)
                return um.FirstOrDefault();
            else
                return null;
        }

        // Métodos para listagem de dados
        public List<UnidadeDeMedida> ListarUnidadesDeMedida() => ContextoSingleton.Instancia.UnidadesDeMedida.ToList();
    }
}
