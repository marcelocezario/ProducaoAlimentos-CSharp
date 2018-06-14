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
        // Métodos para Criação, Edição e Exclusão de Produtos
        public bool SalvarProduto(Produto produto)
        {
            ContextoSingleton.Instancia.Produtos.Add(produto);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarProduto(int idProduto, Produto produtoEditado)
        {
            Produto produtoEditar = BuscarProdutoPorID(idProduto);

            if (produtoEditar != null)
            {
                produtoEditado.ProdutoID = produtoEditar.ProdutoID;
                produtoEditar = produtoEditado;

                ContextoSingleton.Instancia.Entry(produtoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirProduto(Produto produto)
        {
            ContextoSingleton.Instancia.Entry(produto).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos para Criação, Edição e Exclusão de Produtos
        public bool SalvarItemProduto(ItemProduto itemProduto)
        {
            ContextoSingleton.Instancia.Produtos.Add(itemProduto);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarItemProduto(int idItemProduto, Produto itemProdutoEditado)
        {
            Produto produtoEditar = BuscarProdutoPorID(idItemProduto);

            if (produtoEditar != null)
            {
                itemProdutoEditado.ProdutoID = produtoEditar.ProdutoID;
                produtoEditar = itemProdutoEditado;

                ContextoSingleton.Instancia.Entry(itemProdutoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirProduto(Produto produto)
        {
            ContextoSingleton.Instancia.Entry(produto).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        public Produto BuscarProdutoPorID(int produtoID)
        {
            return ContextoSingleton.Instancia.Produtos.Find(produtoID);
        }


        public Produto BuscarProdutoPorNome(string nomeProduto)
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
