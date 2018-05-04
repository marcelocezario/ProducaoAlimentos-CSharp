using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ProdutoController
    {
        public bool SalvarProduto(Produto produto)
        {
            ContextoSingleton.Instancia.Produtos.Add(produto);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        public Produto PesquisarProdutoPorID(int produtoID)
        {
            return ContextoSingleton.Instancia.Produtos.Find(produtoID);
        }

        public bool ExcluirProduto(Produto produto)
        {
            ContextoSingleton.Instancia.Entry(produto).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        public Produto PesquisarProdutoPorNome(string nomeProduto)
        {
            var p = from x in ContextoSingleton.Instancia.Produtos
                    where x.Nome.ToLower().Contains(nomeProduto.Trim().ToLower())
                    select x;

            if (p != null)
                return p.FirstOrDefault();
            else
                return null;
        }

        public List<Produto> ListarProdutos() => ContextoSingleton.Instancia.Produtos.ToList();

        public List<Produto> ListarProdutosOrdemAlfabetica()
        {
            var p = from x in ListarProdutos()
                    orderby x.Nome
                    select x;

            return p.ToList();
        }
    }
}
