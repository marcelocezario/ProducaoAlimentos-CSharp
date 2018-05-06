using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<Contexto>()
                );
        }

        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ItemComposicaoProduto> ItensComposicaoProduto { get; set; }
        public DbSet<UnidadeDeMedida> UnidadesDeMedida { get; set; }
    }
}
