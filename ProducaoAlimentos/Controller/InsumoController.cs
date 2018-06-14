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
        public bool SalvarInsumo(Insumo insumo)
        {
            ContextoSingleton.Instancia.Insumos.Add(insumo);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        public bool EditarInsumo (int idInsumo, Insumo insumoEditado)
        {
            Insumo insumoEditar = PesquisarInsumoPorID(idInsumo);

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
            ContextoSingleton.Instancia.Entry(insumo).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        public Insumo PesquisarInsumoPorID(int insumoID)
        {
            return ContextoSingleton.Instancia.Insumos.Find(insumoID);
        }
        
        public Insumo PesquisarInsumoPorNome(string nomeInsumo)
        {
            var i = from x in ContextoSingleton.Instancia.Insumos
                    where x.Nome.ToLower().Contains(nomeInsumo.Trim().ToLower())
                    select x;

            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }

        public ItemInsumo PesquisarItemInsumoPorInsumo (Insumo insumo)
        {
            var i = from x in ContextoSingleton.Instancia.ItensInsumo
                    where x.Equals(insumo)
                    select x;
            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }

        public List<Insumo> ListarInsumos() => ContextoSingleton.Instancia.Insumos.ToList();

        public List<Insumo> ListarInsumosOrdemAlfabetica()
        {
            var i = from x in ListarInsumos()
                    orderby x.Nome
                    select x;

            return i.ToList();
        }

        //Controle de entrada e saída de estoque
        public List<ItemInsumo> ListarItensInsumo() => ContextoSingleton.Instancia.ItensInsumo.ToList();

        public ItemInsumo BuscarItemInsumo(Insumo insumo)
        {
            var i = from x in ListarItensInsumo()
                    where x._Insumo.Nome.ToLower().Equals(insumo.Nome.Trim().ToLower())
                    select x;
            if (i != null)
                return i.FirstOrDefault();
            else
                return null;
        }

        public void EntradaEstoqueInsumo (LoteInsumo loteInsumo)
        {
            //Verificando se existe itemInsumo e adicionando quantidade e valor em estoque
            ItemInsumo itemInsumo = PesquisarItemInsumoPorInsumo(loteInsumo._Insumo);
            if (itemInsumo != null)
            {
                itemInsumo.QtdeTotalEstoque += loteInsumo.Qtde;
                itemInsumo.CustoTotalEstoque += loteInsumo.ValorCustoTotal;

                ContextoSingleton.Instancia.Entry(itemInsumo).State = System.Data.Entity.EntityState.Modified;
            } else
            {
                itemInsumo.InsumoID = loteInsumo.InsumoID;
                itemInsumo.QtdeTotalEstoque = loteInsumo.Qtde;
                itemInsumo.CustoTotalEstoque = loteInsumo.ValorCustoTotal;

                ContextoSingleton.Instancia.ItensInsumo.Add(itemInsumo);
            }

            ContextoSingleton.Instancia.LotesInsumo.Add(loteInsumo);
            ContextoSingleton.Instancia.SaveChanges();
        }

    }
}
