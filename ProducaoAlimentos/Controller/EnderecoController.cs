using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class EnderecoController
    {
        // Métodos para Criação, Edição e Exclusão de Endereço 
        public bool SalvarEndereco(Endereco endereco)
        {
            ContextoSingleton.Instancia.Enderecos.Add(endereco);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarEnderedco(int idEndereco, Endereco enderecoEditado)
        {
            Endereco enderecoEditar = BuscarEnderecoPorId(idEndereco);

            if (enderecoEditar != null)
            {
                enderecoEditado.EnderecoID = enderecoEditar.EnderecoID;
                enderecoEditar = enderecoEditado;

                ContextoSingleton.Instancia.Entry(enderecoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirEndereco(Endereco endereco)
        {
            ContextoSingleton.Instancia.Entry(endereco).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos de busca
        public Endereco BuscarEnderecoPorId(int idEndereco)
        {
            return ContextoSingleton.Instancia.Enderecos.Find(idEndereco);
        }

        // Métodos para listagem de dados
        public List<Endereco> ListarEnderecos() => ContextoSingleton.Instancia.Enderecos.ToList();
    }
}
