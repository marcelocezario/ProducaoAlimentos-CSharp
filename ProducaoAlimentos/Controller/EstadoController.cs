using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class EstadoController
    {
        // Métodos para Criação, Edição e Exclusão de Estado 
        public bool SalvarEstado(Estado estado)
        {
            ContextoSingleton.Instancia.Estados.Add(estado);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarEstado(int idEstado, Estado estadoEditado)
        {
            Estado estadoEditar = BuscarEstadoPorId(idEstado);

            if (estadoEditar != null)
            {
                estadoEditado.EstadoID = estadoEditar.EstadoID;
                estadoEditar = estadoEditado;

                ContextoSingleton.Instancia.Entry(estadoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirEstado(Endereco endereco)
        {
            ContextoSingleton.Instancia.Entry(endereco).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos de busca
        public Estado BuscarEstadoPorId(int idEstado)
        {
            return ContextoSingleton.Instancia.Estados.Find(idEstado);
        }
        public Estado BuscarEstadoPorNome(string nomeEstado)
        {
            var e = from x in ContextoSingleton.Instancia.Estados
                    where x.Nome.ToLower().Contains(nomeEstado.Trim().ToLower())
                    select x;

            if (e != null)
                return e.FirstOrDefault();
            else
                return null;
        }
        public Estado BuscarEstadoPorSigla(string siglaEstado)
        {
            var e = from x in ContextoSingleton.Instancia.Estados
                    where x.Sigla.ToLower().Contains(siglaEstado.Trim().ToLower())
                    select x;
            if (e != null)
                return e.FirstOrDefault();
            else
                return null;
        }
        public List<Estado> BuscarEstadosPorNome(string nomeEstado)
        {
            var e = (from x in ContextoSingleton.Instancia.Estados
                    where x.Nome.ToLower().Contains(nomeEstado.Trim().ToLower())
                    select x).ToList();

            if (e != null)
                return e;
            else
                return null;
        }
    }
}
