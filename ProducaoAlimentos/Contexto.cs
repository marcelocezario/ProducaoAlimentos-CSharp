using System;
using Model;

namespace ProducaoAlimentos.DAL
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
        public DbSet<ItemComposicaoProduto> ItensComposicaoProduto { get; set; }
        public DbSet<ItemEstoque> ItensEstoque { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<UnidadeDeMedida> UnidadesDeMedida { get; set; }
    }
}
