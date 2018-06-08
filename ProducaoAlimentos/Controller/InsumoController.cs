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

        public Insumo PesquisarInsumoPorID(int insumoID)
        {
            return ContextoSingleton.Instancia.Insumos.Find(insumoID);
        }

        public bool ExcluirInsumo(Insumo insumo)
        {
            ContextoSingleton.Instancia.Entry(insumo).State =
                System.Data.Entity.EntityState.Deleted;

            ContextoSingleton.Instancia.SaveChanges();

            return true;
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

        public List<Insumo> ListarInsumos() => ContextoSingleton.Instancia.Insumos.ToList();

        public List<Insumo> ListarInsumosOrdemAlfabetica()
        {
            var i = from x in ListarInsumos()
                    orderby x.Nome
                    select x;

            return i.ToList();
        }


        //Controle de entrada e saída de estoque
        public ItemInsumo BuscarItemInsumo(Insumo insumo)
        {
            ItemInsumo itemInsumo;

            var i = from x in ContextoSingleton.Instancia.Item

            return null;
        }

        public void EntradaEstoque (Insumo insumo, double quantidadeTotal, double valorCusto)
        {

        }
    }
}
