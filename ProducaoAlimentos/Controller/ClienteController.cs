using Model;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class ClienteController
    {
        // Métodos para Criação, Edição e Exclusão de Clientes 
        public bool SalvarCliente(Cliente cliente)
        {
            ContextoSingleton.Instancia.Clientes.Add(cliente);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarCliente(int idCliente, Cliente clienteEditado)
        {
            Cliente clienteEditar = BuscarClientePorId(idCliente);

            if (clienteEditar != null)
            {
                clienteEditado.ID = clienteEditar.ID;
                clienteEditar = clienteEditado;

                ContextoSingleton.Instancia.Entry(clienteEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirFornecedor(Fornecedor fornecedor)
        {
            ContextoSingleton.Instancia.Entry(fornecedor).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos de busca
        public Cliente BuscarClientePorId(int idCliente)
        {
            return ContextoSingleton.Instancia.Clientes.Find(idCliente);
        }
        public Cliente BuscarClientePorNome(string nomeCliente)
        {
            var f = from x in ContextoSingleton.Instancia.Clientes
                    where x.Nome.ToLower().Contains(nomeCliente.Trim().ToLower())
                    select x;

            if (f != null)
                return f.FirstOrDefault();
            else
                return null;
        }
        public List<Cliente> BuscarClientesPorNome(string nomeCliente)
        {
            var f = (from x in ContextoSingleton.Instancia.Clientes
                     where x.Nome.ToLower().Contains(nomeCliente.Trim().ToLower())
                     select x).ToList();

            if (f != null)
                return f;
            else
                return null;
        }

        // Métodos para listagem de dados
        public List<Cliente> ListarClientes() => ContextoSingleton.Instancia.Clientes.ToList();

    }
}
