using Model;

namespace Controller
{
    public class VendaController
    {
        // Métodos para Criação, Edição e Exclusão de Venda 
        public bool SalvarVenda(Venda venda)
        {
            ContextoSingleton.Instancia.Vendas.Add(venda);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarVenda(int idVenda, Venda vendaEditado)
        {
            Venda vendaEditar = BuscarVendaPorId(idVenda);

            if (vendaEditar != null)
            {
                vendaEditado.VendaID = vendaEditar.VendaID;
                vendaEditar = vendaEditado;

                ContextoSingleton.Instancia.Entry(vendaEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirVenda(Venda venda)
        {
            ContextoSingleton.Instancia.Entry(venda).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        // Métodos de busca
        public Venda BuscarVendaPorId(int idVenda)
        {
            return ContextoSingleton.Instancia.Vendas.Find(idVenda);
        }
    }
}
