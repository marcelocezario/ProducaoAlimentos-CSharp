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

        // Métodos para Criação, Edição e Exclusão de ItensInsumo
        public bool SalvarItemInsumo(ItemInsumo itemInsumo)
        {
            ContextoSingleton.Instancia.ItensInsumo.Add(itemInsumo);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarItemInsumo(int idItemInsumo, ItemInsumo itemInsumoEditado)
        {
            ItemInsumo itemInsumoEditar = BuscarItemInsumoPorId(idItemInsumo);

            if (itemInsumoEditar != null)
            {
                itemInsumoEditado.ItemInsumoID = itemInsumoEditar.ItemInsumoID;
                itemInsumoEditar = itemInsumoEditado;

                ContextoSingleton.Instancia.Entry(itemInsumoEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirIteminsumo(ItemInsumo itemInsumo)
        {
            ContextoSingleton.Instancia.Entry(itemInsumo).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        //Métodos para Criação, Edição e Exclusão de LotesInsumo
        public bool SalvarLoteInsumo(LoteInsumo loteInsumo)
        {
            ContextoSingleton.Instancia.LotesInsumo.Add(loteInsumo);
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
        public ItemInsumo BuscarItemInsumoPorId(int idItemInsumo)
        {
            return ContextoSingleton.Instancia.ItensInsumo.Find(idItemInsumo);
        }
        public ItemInsumo BuscarItemInsumoPorNome(string nomeInsumo)
        {
            var i = from x in ListarItensInsumo()
                    where x._Insumo.Nome.ToLower().Contains(nomeInsumo.Trim().ToLower())
                    select x;
            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }
        public ItemInsumo BuscarItemInsumoPorNomeExato(string nomeInsumo)
        {
            var i = from x in ListarItensInsumo()
                    where x._Insumo.Nome.ToLower().Equals(nomeInsumo.Trim().ToLower())
                    select x;
            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }
        public LoteInsumo BuscarLoteInsumoPorId(int idLoteInsumo)
        {
            return ContextoSingleton.Instancia.LotesInsumo.Find(idLoteInsumo);
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
        public List<ItemInsumo> ListarItensInsumo() => ContextoSingleton.Instancia.ItensInsumo.ToList();
        public List<LoteInsumo> ListarLotesInsumo() => ContextoSingleton.Instancia.LotesInsumo.ToList();

        // Métodos para controle de entrada e saída de estoque
        public void RegistrarEntradaEstoqueInsumo(LoteInsumo loteInsumo)
        {
            //Verificando se existe itemInsumo e adicionando quantidade e valor em estoque
            ItemInsumo itemInsumo = BuscarItemInsumoPorNomeExato(loteInsumo._Insumo.Nome);
            if (itemInsumo != null)
            {
                itemInsumo.QtdeTotalEstoque += loteInsumo.Qtde;
                itemInsumo.CustoTotalEstoque += loteInsumo.ValorCustoTotal;

                EditarItemInsumo(itemInsumo.ItemInsumoID, itemInsumo);
            }
            else
            {
                itemInsumo = new ItemInsumo();
                itemInsumo._Insumo = loteInsumo._Insumo;
                itemInsumo.QtdeTotalEstoque = loteInsumo.Qtde;
                itemInsumo.CustoTotalEstoque = loteInsumo.ValorCustoTotal;

                SalvarItemInsumo(itemInsumo);
            }
            SalvarLoteInsumo(loteInsumo);
        }
        public void RegistrarSaidaEstoqueInsumo(int idLoteInsumo, double qtdeSaida)
        {
            LoteInsumo loteInsumo = BuscarLoteInsumoPorId(idLoteInsumo);

            if (loteInsumo != null)
            {
                double custoSaida = (loteInsumo.ValorCustoTotal / loteInsumo.Qtde) * qtdeSaida;
                loteInsumo.Qtde -= qtdeSaida;
                loteInsumo.ValorCustoTotal -= custoSaida;

                ItemInsumo itemInsumo = BuscarItemInsumoPorNomeExato(loteInsumo._Insumo.Nome);
                itemInsumo.QtdeTotalEstoque -= qtdeSaida;
                itemInsumo.CustoTotalEstoque -= custoSaida;

                EditarItemInsumo(itemInsumo.ItemInsumoID, itemInsumo);
                EditarLoteInsumo(loteInsumo.LoteInsumoID, loteInsumo);
            }
        }


    }
}
