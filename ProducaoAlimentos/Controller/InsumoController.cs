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
            Insumo insumoEditar = BuscarInsumoPorID(idInsumo);

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
            ItemInsumo itemInsumoEditar = BuscarItemInsumoPorID(idItemInsumo);

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

            LoteInsumo loteInsumoEditar = BuscarLoteInsumoPorID(idLoteInsumo);

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
        public Insumo BuscarInsumoPorID(int insumoID)
        {
            return ContextoSingleton.Instancia.Insumos.Find(insumoID);
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
        public ItemInsumo BuscarItemInsumoPorID(int itemInsumoID)
        {
            return ContextoSingleton.Instancia.ItensInsumo.Find(itemInsumoID);
        }
        public ItemInsumo BuscarItemInsumoPorInsumo(Insumo insumo)
        {
            var i = from x in ContextoSingleton.Instancia.ItensInsumo
                    where x.Equals(insumo)
                    select x;
            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }
        public ItemInsumo BuscarItemInsumoPorNome(Insumo insumo)
        {
            var i = from x in ListarItensInsumo()
                    where x._Insumo.Nome.ToLower().Equals(insumo.Nome.Trim().ToLower())
                    select x;
            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }
        public LoteInsumo BuscarLoteInsumoPorID(int loteInsumoID)
        {
            return ContextoSingleton.Instancia.LotesInsumo.Find(loteInsumoID);
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

        // Métodos para controle de entrada e saída de estoque
        public void EntradaEstoqueInsumo(LoteInsumo loteInsumo)
        {   
            //Verificando se existe itemInsumo e adicionando quantidade e valor em estoque
            ItemInsumo itemInsumo = BuscarItemInsumoPorInsumo(loteInsumo._Insumo);
            if (itemInsumo != null)
            {
                itemInsumo.QtdeTotalEstoque += loteInsumo.Qtde;
                itemInsumo.CustoTotalEstoque += loteInsumo.ValorCustoTotal;

                EditarItemInsumo(itemInsumo.ItemInsumoID, itemInsumo);
            }
            else
            {
                itemInsumo.InsumoID = loteInsumo.InsumoID;
                itemInsumo.QtdeTotalEstoque = loteInsumo.Qtde;
                itemInsumo.CustoTotalEstoque = loteInsumo.ValorCustoTotal;

                SalvarItemInsumo(itemInsumo);
            }
            SalvarLoteInsumo(loteInsumo);
        }
        public void SaidaEstoqueInsumo(LoteInsumo loteInsumo, double qtde)
        {

        }


    }
}
