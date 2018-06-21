using System.Data.Entity;

namespace Model.DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {
            Database.SetInitializer(new SeedDB());
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<EstoqueInsumo> EstoqueInsumos { get; set; }
        public DbSet<EstoqueProduto> EstoqueProduto { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<InsumoComposicaoProduto> InsumosComposicaoProduto { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }
        public DbSet<LoteInsumo> LotesInsumos { get; set; }
        public DbSet<LoteInsumoProducao> LotesInsumosProducao { get; set; }
        public DbSet<LoteProduto> LotesProdutos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<MovimentacaoEstoqueInsumo> MovimentacaoEstoqueInsumos { get; set; }
        public DbSet<MovimentacaoEstoqueProduto> MovimentacaoEstoqueProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<UnidadeDeMedida> UnidadesDeMedida { get; set; }
        public DbSet<Venda> Vendas { get; set; }
    }
}
