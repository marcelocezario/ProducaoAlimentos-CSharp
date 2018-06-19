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
            Database.SetInitializer(new SeedDB());
        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<ItemComposicaoProduto> ItensComposicaoProduto { get; set; }
        public DbSet<ItemInsumo> ItensInsumo { get; set; }
        public DbSet<ItemProduto> ItensProduto { get; set; }
        public DbSet<LoteInsumo> LotesInsumo { get; set; }
        public DbSet<LoteProduto> LotesProduto { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<UnidadeDeMedida> UnidadesDeMedida { get; set; }
    }
}
