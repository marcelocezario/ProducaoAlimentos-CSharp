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

        // Métodos para Criação, Edição e Exclusão de EstoqueProdutos
        public bool SalvarEstoqueProduto(EstoqueProduto estoqueProduto)
        {
            ContextoSingleton.Instancia.EstoqueProduto.Add(estoqueProduto);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarEstoqueProduto(int idEstoqueProduto, EstoqueProduto estoqueProdutoEditado)
        {
            EstoqueProduto estoqueProdutoEditar = BuscarEstoqueProdutoPorId(idEstoqueProduto);

            if (estoqueProdutoEditar != null)
            {
                estoqueProdutoEditado.ProdutoID = estoqueProdutoEditar.ProdutoID;
                estoqueProdutoEditar = estoqueProdutoEditado;

                ContextoSingleton.Instancia.Entry(estoqueProdutoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirEstoqueProduto(EstoqueProduto estoqueProduto)
        {
            ContextoSingleton.Instancia.Entry(estoqueProduto).State =
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
        public EstoqueProduto BuscarEstoqueProdutoPorId(int idItemProduto)
        {
            return ContextoSingleton.Instancia.EstoqueProduto.Find(idItemProduto);
        }
        public EstoqueProduto BuscarEstoqueProdutoPorNome(string nomeProduto)
        {
            var e = from x in ListarEstoqueProdutos()
                    where x._Produto.Nome.ToLower().Contains(nomeProduto.Trim().ToLower())
                    select x;
            if (e != null)
                return e.FirstOrDefault();
            else
                return null;
        }
        public EstoqueProduto BuscarEstoqueProdutoPorNomeExato(string nomeProduto)
        {
            var e = from x in ListarEstoqueProdutos()
                    where x._Produto.Nome.ToLower().Equals(nomeProduto.Trim().ToLower())
                    select x;
            if (e != null)
                return e.FirstOrDefault();
            else
                return null;
        }
        public LoteProduto BuscarLoteProdutoPorId(int idLoteProduto)
        {
            return ContextoSingleton.Instancia.LotesProduto.Find(idLoteProduto);
        }
        public List<LoteProduto> BuscarLotesProdutosPorNome(string nomeProduto)
        {
            var e = (from x in ListarLotesProdutos()
                    where x._Produto.Nome.ToLower().Contains(nomeProduto.Trim().ToLower())
                    select x).ToList();
            if (e != null)
                return e;
            else
                return null;
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
        public List<EstoqueProduto> ListarEstoqueProdutos() => ContextoSingleton.Instancia.EstoqueProduto.ToList();
        public List<LoteProduto> ListarLotesProdutos() => ContextoSingleton.Instancia.LotesProduto.ToList();

        // Métodos para controle de entrada e saída de estoque (EstoqueProduto e LoteProduto)
        public void RegistrarEntradaEstoqueProduto(LoteProduto loteProduto)
        {
            // Verificando se existe estoqueProduto e adicionando quantidade e valor em estoque
            EstoqueProduto estoqueProduto = BuscarEstoqueProdutoPorNomeExato(loteProduto._Produto.Nome);
            if (estoqueProduto != null)
            {
                estoqueProduto.QtdeTotalEstoque += loteProduto.QtdeInicial;
                estoqueProduto.CustoTotalEstoque += loteProduto.CustoMedio * loteProduto.QtdeInicial;

                EditarEstoqueProduto(estoqueProduto.EstoqueProdutoID, estoqueProduto);
            }
            else
            {
                estoqueProduto = new EstoqueProduto();
                estoqueProduto._Produto = loteProduto._Produto;
                estoqueProduto.QtdeTotalEstoque = loteProduto.QtdeInicial;
                estoqueProduto.CustoTotalEstoque = loteProduto.CustoMedio * loteProduto.QtdeInicial;

                SalvarEstoqueProduto(estoqueProduto);
            }
            SalvarLoteProduto(loteProduto);
        }
        public void RegistrarSaidaEstoqueProduto(int idLoteProduto, double qtdeSaida)
        {
            LoteProduto loteProduto = BuscarLoteProdutoPorId(idLoteProduto);

            if(loteProduto != null)
            {
                double custoSaida = loteProduto.CustoMedio * qtdeSaida;
                loteProduto.QtdeDisponivel -= qtdeSaida;

                EstoqueProduto estoqueProduto = BuscarEstoqueProdutoPorNomeExato(loteProduto._Produto.Nome);
                estoqueProduto.QtdeTotalEstoque -= qtdeSaida;
                estoqueProduto.CustoTotalEstoque -= custoSaida;

                EditarEstoqueProduto(estoqueProduto.EstoqueProdutoID, estoqueProduto);
                EditarLoteProduto(loteProduto.LoteProdutoID, loteProduto);
            }

        }
    }
}
