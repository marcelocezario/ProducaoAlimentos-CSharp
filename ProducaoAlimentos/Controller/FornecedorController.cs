using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class FornecedorController
    {
        // Métodos para Criação, Edição e Exclusão de Fornecedors 
        public bool SalvarFornecedor(Fornecedor fornecedor)
        {
            ContextoSingleton.Instancia.Fornecedores.Add(fornecedor);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarFornecedor(int idFornecedor, Fornecedor fornecedorEditado)
        {
            Fornecedor fornecedorEditar = BuscarFornecedorPorId(idFornecedor);

            if (fornecedorEditar != null)
            {
                fornecedorEditado.FornecedorID = fornecedorEditar.FornecedorID;
                fornecedorEditar = fornecedorEditado;

                ContextoSingleton.Instancia.Entry(fornecedorEditar).State = System.Data.Entity.EntityState.Modified;
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
        public Fornecedor BuscarFornecedorPorId(int idFornecedor)
        {
            return ContextoSingleton.Instancia.Fornecedores.Find(idFornecedor);
        }
        public Fornecedor BuscarFornecedorPorNome(string nomeFornecedor)
        {
            var i = from x in ContextoSingleton.Instancia.Fornecedores
                    where x.Nome.ToLower().Contains(nomeFornecedor.Trim().ToLower())
                    select x;

            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }

        // Métodos para listagem de dados
        public List<Fornecedor> ListarFornecedors() => ContextoSingleton.Instancia.Fornecedores.ToList();
    }
}
