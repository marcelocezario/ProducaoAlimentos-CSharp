using Model;

namespace Controller
{
    public class MarcaController
    {
        public bool SalvarMarca(Marca marca)
        {
            ContextoSingleton.Instancia.Marcas.Add(marca);
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }
        public bool EditarMarca(int idMarca, Marca marcaEditada)
        {
            Marca marcaEditar = BuscarMarcaPorId(idMarca);

            if (marcaEditar != null)
            {
                marcaEditada.MarcaID = marcaEditar.MarcaID;
                marcaEditar = marcaEditada;

                ContextoSingleton.Instancia.Entry(marcaEditar).State = System.Data.Entity.EntityState.Modified;
                ContextoSingleton.Instancia.SaveChanges();

                return true;
            }
            else
                return false;
        }
        public bool ExcluirMarca(Marca marca)
        {
            ContextoSingleton.Instancia.Entry(marca).State = System.Data.Entity.EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();

            return true;
        }

        public Marca BuscarMarcaPorId(int idMarca)
        {
            return ContextoSingleton.Instancia.Marcas.Find(idMarca);
        }
    }
}
