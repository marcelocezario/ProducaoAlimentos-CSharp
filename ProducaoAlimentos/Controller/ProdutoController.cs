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

        // Métodos para Criação, Edição e Exclusão de ItensProdutos
        public bool SalvarItemProduto(ItemProduto itemProduto)
        {
            ContextoSingleton.Instancia.ItensProduto.Add(itemProduto);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarItemProduto(int idItemProduto, ItemProduto itemProdutoEditado)
        {
            ItemProduto itemProdutoEditar = BuscarItemProdutoPorId(idItemProduto);

            if (itemProdutoEditar != null)
            {
                itemProdutoEditado.ProdutoID = itemProdutoEditar.ProdutoID;
                itemProdutoEditar = itemProdutoEditado;

                ContextoSingleton.Instancia.Entry(itemProdutoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirItemProduto(ItemProduto itemProduto)
        {
            ContextoSingleton.Instancia.Entry(itemProduto).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos para Criação, Edição e Exclusão de LotesProdutos
        public bool SalvarLoteProduto(LoteProduto loteProduto)
        {
            ContextoSingleton.Instancia.LotesProduto.Add(loteProduto);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarLoteProduto(int idLoteProduto, LoteProduto loteProdutoEditado)
        {

            LoteProduto loteProdutoEditar = BuscarLoteProdutoPorId(idLoteProduto);

            if (loteProdutoEditar != null)
            {
                loteProdutoEditado.LoteProdutoID = loteProdutoEditar.LoteProdutoID;
                loteProdutoEditar = loteProdutoEditado;

                ContextoSingleton.Instancia.Entry(loteProdutoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirLoteProduto(LoteProduto loteProduto)
        {
            ContextoSingleton.Instancia.Entry(loteProduto).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos de busca
        public Produto BuscarProdutoPorID(int idProduto)
        {
            return ContextoSingleton.Instancia.Produtos.Find(idProduto);
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
        public ItemProduto BuscarItemProdutoPorId(int idItemProduto)
        {
            return ContextoSingleton.Instancia.ItensProduto.Find(idItemProduto);
        }
        public LoteProduto BuscarLoteProdutoPorId(int idLoteProduto)
        {
            return ContextoSingleton.Instancia.LotesProduto.Find(idLoteProduto);
        }

        // Métodos para listagem de dados
        public List<Produto> ListarProdutos() => ContextoSingleton.Instancia.Produtos.ToList();
        public List<Produto> ListarProdutosOrdemAlfabetica()
        {
            var p = from x in ListarProdutos()
                    orderby x.Nome
                    select x;

            return p.ToList();
        }
        public List<ItemProduto> ListarItensProduto() => ContextoSingleton.Instancia.ItensProduto.ToList();
        public List<LoteProduto> ListarLotesProduto() => ContextoSingleton.Instancia.LotesProduto.ToList();

        // Métodos para controle de entrada e saída de estoque
        public void RegistrarEntradaEstoqueProduto(LoteProduto loteProduto)
        {

        }
        public void RegistrarSaidaEstoqueProduto(int idLoteProduto, double qtdeSaida)
        {

        }
    }
}
