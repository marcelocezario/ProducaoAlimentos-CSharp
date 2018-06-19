using Model;
using System.Linq;

namespace Controller
{
    public class EstadoController
    {
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
                    where x.Uf
        }
    }
}
