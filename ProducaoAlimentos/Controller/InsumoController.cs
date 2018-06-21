using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class InsumoController
    {
        // Métodos para Criação, Edição e Exclusão de Insumos 
        public bool SalvarInsumo(Insumo insumo)
        {
            ContextoSingleton.Instancia.Insumos.Add(insumo);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarInsumo(int idInsumo, Insumo insumoEditado)
        {
            Insumo insumoEditar = BuscarInsumoPorId(idInsumo);

            if (insumoEditar != null)
            {
                insumoEditado.InsumoID = insumoEditar.InsumoID;
                insumoEditar = insumoEditado;

                ContextoSingleton.Instancia.Entry(insumoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirInsumo(Insumo insumo)
        {
            ContextoSingleton.Instancia.Entry(insumo).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos para Criação, Edição e Exclusão de EstoqueInsumo
        public bool SalvarEstoqueInsumo(EstoqueInsumo estoqueInsumo)
        {
            ContextoSingleton.Instancia.EstoqueInsumos.Add(estoqueInsumo);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarEstoqueInsumo(int idEstoqueInsumo, EstoqueInsumo estoqueInsumoEditado)
        {
            EstoqueInsumo estoqueInsumoEditar = BuscarEstoqueInsumoPorId(idEstoqueInsumo);

            if (estoqueInsumoEditar != null)
            {
                estoqueInsumoEditado.EstoqueInsumoID = estoqueInsumoEditar.EstoqueInsumoID;
                estoqueInsumoEditar = estoqueInsumoEditado;

                ContextoSingleton.Instancia.Entry(estoqueInsumoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirEstoqueInsumo(EstoqueInsumo estoqueInsumo)
        {
            ContextoSingleton.Instancia.Entry(estoqueInsumo).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        //Métodos para Criação, Edição e Exclusão de LotesInsumo
        public bool SalvarLoteInsumo(LoteInsumo loteInsumo)
        {
            ContextoSingleton.Instancia.LotesInsumos.Add(loteInsumo);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarLoteInsumo(int idLoteInsumo, LoteInsumo loteInsumoEditado)
        {

            LoteInsumo loteInsumoEditar = BuscarLoteInsumoPorId(idLoteInsumo);

            if (loteInsumoEditar != null)
            {
                loteInsumoEditado.LoteInsumoID = loteInsumoEditar.LoteInsumoID;
                loteInsumoEditar = loteInsumoEditado;

                ContextoSingleton.Instancia.Entry(loteInsumoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirLoteInsumo(LoteInsumo loteInsumo)
        {
            ContextoSingleton.Instancia.Entry(loteInsumo).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos de busca
        public Insumo BuscarInsumoPorId(int idInsumo)
        {
            return ContextoSingleton.Instancia.Insumos.Find(idInsumo);
        }
        public Insumo BuscarInsumoPorNome(string nomeInsumo)
        {
            var i = from x in ContextoSingleton.Instancia.Insumos
                    where x.Nome.ToLower().Contains(nomeInsumo.Trim().ToLower())
                    select x;

            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }
        public EstoqueInsumo BuscarEstoqueInsumoPorId(int idEstoqueInsumo)
        {
            return ContextoSingleton.Instancia.EstoqueInsumos.Find(idEstoqueInsumo);
        }
        public EstoqueInsumo BuscarEstoqueInsumoPorNome(string nomeInsumo)
        {
            var i = from x in ListarEstoqueInsumo()
                    where x._Insumo.Nome.ToLower().Contains(nomeInsumo.Trim().ToLower())
                    select x;
            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }
        public EstoqueInsumo BuscarEstoqueInsumoPorNomeExato(string nomeInsumo)
        {
            var i = from x in ListarEstoqueInsumo()
                    where x._Insumo.Nome.ToLower().Equals(nomeInsumo.Trim().ToLower())
                    select x;
            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }
        public LoteInsumo BuscarLoteInsumoPorId(int idLoteInsumo)
        {
            return ContextoSingleton.Instancia.LotesInsumos.Find(idLoteInsumo);
        }
        public List<LoteInsumo> BuscarLotesInsumosPorNome(string nomeInsumo)
        {
            var e = (from x in ListarLotesInsumos()
                     where x._Insumo.Nome.ToLower().Contains(nomeInsumo.Trim().ToLower())
                     select x).ToList();
            if (e != null)
                return e;
            else
                return null;
        }

        // Métodos para listagem de dados
        public List<Insumo> ListarInsumos() => ContextoSingleton.Instancia.Insumos.ToList();
        public List<Insumo> ListarInsumosOrdemAlfabetica()
        {
            var i = from x in ListarInsumos()
                    orderby x.Nome
                    select x;

            return i.ToList();
        }
        public List<EstoqueInsumo> ListarEstoqueInsumo() => ContextoSingleton.Instancia.EstoqueInsumos.ToList();
        public List<LoteInsumo> ListarLotesInsumos() => ContextoSingleton.Instancia.LotesInsumos.ToList();

        // Métodos para controle de entrada e saída de estoque (EstoqueInsumo e LoteInsumo)
        public void RegistrarEntradaEstoqueInsumo(LoteInsumo loteInsumo)
        {
            //Verificando se existe estoqueInsumo e adicionando quantidade e valor em estoque
            EstoqueInsumo estoqueInsumo = BuscarEstoqueInsumoPorNomeExato(loteInsumo._Insumo.Nome);
            if (estoqueInsumo != null)
            {
                estoqueInsumo.QtdeTotalEstoque += loteInsumo.QtdeInicial;
                estoqueInsumo.CustoTotalEstoque += loteInsumo.CustoMedio * loteInsumo.QtdeInicial;

                EditarEstoqueInsumo(estoqueInsumo.EstoqueInsumoID, estoqueInsumo);
            }
            else
            {
                estoqueInsumo = new EstoqueInsumo();
                estoqueInsumo._Insumo = loteInsumo._Insumo;
                estoqueInsumo.QtdeTotalEstoque = loteInsumo.QtdeInicial;
                estoqueInsumo.CustoTotalEstoque = loteInsumo.CustoMedio * loteInsumo.QtdeInicial;

                SalvarEstoqueInsumo(estoqueInsumo);
            }
            SalvarLoteInsumo(loteInsumo);
        }
        public void RegistrarSaidaEstoqueInsumo(int idLoteInsumo, double qtdeSaida)
        {
            LoteInsumo loteInsumo = BuscarLoteInsumoPorId(idLoteInsumo);

            if (loteInsumo != null)
            {
                double custoSaida = loteInsumo.CustoMedio * qtdeSaida;
                loteInsumo.QtdeDisponivel -= qtdeSaida;

                EstoqueInsumo estoqueInsumo = BuscarEstoqueInsumoPorNomeExato(loteInsumo._Insumo.Nome);
                estoqueInsumo.QtdeTotalEstoque -= qtdeSaida;
                estoqueInsumo.CustoTotalEstoque -= custoSaida;

                EditarEstoqueInsumo(estoqueInsumo.EstoqueInsumoID, estoqueInsumo);
                EditarLoteInsumo(loteInsumo.LoteInsumoID, loteInsumo);
            }
        }


    }
}
