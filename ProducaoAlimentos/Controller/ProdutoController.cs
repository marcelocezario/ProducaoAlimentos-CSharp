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
            ContextoSingleton.Instancia.LotesProdutos.Add(loteProduto);
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

        // Métodos para Criação de MovimentacaoEstoqueProduto
        public bool SalvarMovimentacaoEstoqueProduto(MovimentacaoEstoqueProduto movimentacaoEstoque)
        {
            ContextoSingleton.Instancia.MovimentacaoEstoqueProdutos.Add(movimentacaoEstoque);
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
            var ep = from x in ListarEstoqueProdutos()
                    where x._Produto.Nome.ToLower().Contains(nomeProduto.Trim().ToLower())
                    select x;
            if (ep != null)
                return ep.FirstOrDefault();
            else
                return null;
        }
        public EstoqueProduto BuscarEstoqueProdutoPorProduto(Produto produto)
        {
            var ep = from x in ListarEstoqueProdutos()
                    where x._Produto.Equals(produto)
                    select x;
            if (ep != null)
                return ep.FirstOrDefault();
            else
                return null;
        }
        public LoteProduto BuscarLoteProdutoPorId(int idLoteProduto)
        {
            return ContextoSingleton.Instancia.LotesProdutos.Find(idLoteProduto);
        }
        public List<LoteProduto> BuscarLotesProdutosPorNome(string nomeProduto)
        {
            var lp = (from x in ListarLotesProdutos()
                    where x._Produto.Nome.ToLower().Contains(nomeProduto.Trim().ToLower())
                    select x).ToList();
            if (lp != null)
                return lp;
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
        public List<LoteProduto> ListarLotesProdutos() => ContextoSingleton.Instancia.LotesProdutos.ToList();

        // Métodos para controle de entrada e saída de estoque (MovimentãcaoEstoque, EstoqueProduto e LoteProduto)
        public bool RegistrarProducao(LoteProduto loteProduto)
        {
            EstoqueProduto estoqueProduto = BuscarEstoqueProdutoPorProduto(loteProduto._Produto);
            MovimentacaoEstoqueProduto movimentacaoEstoque = new MovimentacaoEstoqueProduto();
            if (estoqueProduto != null)
            {
                estoqueProduto.QtdeTotalEstoque += loteProduto.QtdeInicial;
                estoqueProduto.CustoTotalEstoque += loteProduto.CustoTotalInicial;

                EditarEstoqueProduto(estoqueProduto.EstoqueProdutoID, estoqueProduto);
            }
            else
            {
                estoqueProduto = new EstoqueProduto();
                estoqueProduto._Produto = loteProduto._Produto;
                estoqueProduto.QtdeTotalEstoque = loteProduto.QtdeInicial;
                estoqueProduto.CustoTotalEstoque = loteProduto.CustoTotalInicial;

                SalvarEstoqueProduto(estoqueProduto);
            }
            movimentacaoEstoque.DataMovimentacao = loteProduto.DataProducao;
            movimentacaoEstoque.Qtde = loteProduto.QtdeInicial;
            movimentacaoEstoque._LoteProduto = loteProduto;

            InsumoController ic = new InsumoController();
            foreach (LoteInsumoProducao i in loteProduto._ItemInsumoProducao)
            {
                ic.RegistrarSaidaEstoqueInsumo(i.LoteInsumoID, i.QtdeInsumo, loteProduto.DataProducao);
            }

            SalvarMovimentacaoEstoqueProduto(movimentacaoEstoque);
            SalvarLoteProduto(loteProduto);
            return true;
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
