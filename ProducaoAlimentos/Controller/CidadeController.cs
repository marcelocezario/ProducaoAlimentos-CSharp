using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class CidadeController
    {
        // Métodos para Criação, Edição e Exclusão de Cidade 
        public bool SalvarCidade(Cidade cidade)
        {
            ContextoSingleton.Instancia.Cidades.Add(cidade);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarCidade(int idCidade, Cidade cidadeEditado)
        {
            Cidade cidadeEditar = BuscarCidadePorId(idCidade);

            if (cidadeEditar != null)
            {
                cidadeEditado.EstadoID = cidadeEditar.EstadoID;
                cidadeEditar = cidadeEditado;

                ContextoSingleton.Instancia.Entry(cidadeEditar).State = System.Data.Entity.EntityState.Modified;
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
        public Cidade BuscarCidadePorId(int idCidade)
        {
            return ContextoSingleton.Instancia.Cidades.Find(idCidade);
        }
        public Cidade BuscarCidadePorNome(string nomeCidade)
        {
            var e = from x in ContextoSingleton.Instancia.Cidades
                    where x.Nome.ToLower().Contains(nomeCidade.Trim().ToLower())
                    select x;

            if (e != null)
                return e.FirstOrDefault();
            else
                return null;
        }

        public List<Cidade> BuscarCidadesPorNome(string nomeCidade)
        {
            var e = (from x in ContextoSingleton.Instancia.Cidades
                     where x.Nome.ToLower().Contains(nomeCidade.Trim().ToLower())
                     select x).ToList();

            if (e != null)
                return e;
            else
                return null;
        }
    }
}
