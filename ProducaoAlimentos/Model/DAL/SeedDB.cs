using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    //public class SeedDB : DropCreateDatabaseIfModelChanges<Contexto>
    public class SeedDB : DropCreateDatabaseAlways<Contexto>
    {
        protected override void Seed(Contexto context)
        {
            List<UnidadeDeMedida> unidadesDeMedida = new List<UnidadeDeMedida>()
            {
                new UnidadeDeMedida(){ Nome = "Centimetro", Sigla = "cm", Fracionavel = true},
                new UnidadeDeMedida(){ Nome = "Litro", Sigla = "l", Fracionavel = true},
                new UnidadeDeMedida(){ Nome = "Quilo", Sigla = "kg", Fracionavel = true},
                new UnidadeDeMedida(){ Nome = "Unidade", Sigla = "un", Fracionavel = false}
            };

            context.UnidadesDeMedida.AddRange(unidadesDeMedida);
            base.Seed(context);
            context.SaveChanges();

            List<Insumo> insumos = new List<Insumo>()
            {
                new Insumo(){ Nome = "Arroz", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Batata", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Creme de Leite", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Farinha de Trigo", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Feijão", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Leite", UnidadeDeMedidaID = 2},
                new Insumo(){ Nome = "Leite Condensado", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Óleo", UnidadeDeMedidaID = 2},
                new Insumo(){ Nome = "Ovo", UnidadeDeMedidaID = 4},
            };
            context.Insumos.AddRange(insumos);
            base.Seed(context);
            context.SaveChanges();

            List<Produto> produtos = new List<Produto>()
            {
                new Produto(){ Nome = "Nhoque", UnidadeDeMedidaID = 3, ComposicaoProduto = new List<ItemComposicaoProduto>()
                {
                    new ItemComposicaoProduto(){ InsumoID = 2, QuantidadeInsumo = 0.6},
                    new ItemComposicaoProduto(){ InsumoID = 4, QuantidadeInsumo = 0.3},
                    new ItemComposicaoProduto(){ InsumoID = 9, QuantidadeInsumo = 1},
                    new ItemComposicaoProduto(){ InsumoID = 8, QuantidadeInsumo = 0.01}
                }
            }
        };
            context.Produtos.AddRange(produtos);
            base.Seed(context);
            context.SaveChanges();


            List<ItemInsumo> itensInsumo = new List<ItemInsumo>()
            {
                new ItemInsumo(){ InsumoID = 3, QtdeTotalEstoque = 0, CustoTotalEstoque = 0 }
            };
            context.ItensInsumo.AddRange(itensInsumo);
            base.Seed(context);
            context.SaveChanges();


            List<Estado> estados = new List<Estado>()
            {
                new Estado(){ Nome = "Acre", Uf = "AC" },
                new Estado(){ Nome = "Alagoas", Uf = "AL" },
                new Estado(){ Nome = "Amapá", Uf = "AP" },
                new Estado(){ Nome = "Amazonas", Uf = "AM" },
                new Estado(){ Nome = "Bahia", Uf = "BA" },
                new Estado(){ Nome = "Ceará", Uf = "CE" },
                new Estado(){ Nome = "Distrito Federal", Uf = "DF" },
                new Estado(){ Nome = "Espirito Santo", Uf = "ES" },
                new Estado(){ Nome = "Goiás", Uf = "GO" },
                new Estado(){ Nome = "Maranhão", Uf = "MA" },
                new Estado(){ Nome = "Mato Grosso", Uf = "MT" },
                new Estado(){ Nome = "Mato Grosso do Sul", Uf = "MS" },
                new Estado(){ Nome = "Minas Gerais", Uf = "MG" },
                new Estado(){ Nome = "Pará", Uf = "PA" },
                new Estado(){ Nome = "Paraíba", Uf = "PB" },
                new Estado(){ Nome = "Paraná", Uf = "PR" },
                new Estado(){ Nome = "Pernambuco", Uf = "PE" },
                new Estado(){ Nome = "Piauí", Uf = "PI" },
                new Estado(){ Nome = "Rio de Janeiro", Uf = "RJ" },
                new Estado(){ Nome = "Rio Grande do Norte", Uf = "RN" },
                new Estado(){ Nome = "Rio Grande do Sul", Uf = "RS" },
                new Estado(){ Nome = "Rondônia", Uf = "RO" },
                new Estado(){ Nome = "Roraima", Uf = "RR" },
                new Estado(){ Nome = "Santa Catarina", Uf = "SC" },
                new Estado(){ Nome = "São Paulo", Uf = "SP" },
                new Estado(){ Nome = "Sergipe", Uf = "SE" },
                new Estado(){ Nome = "Tocantins", Uf = "TO" },
            };
            context.Estados.AddRange(estados);
            base.Seed(context);
            context.SaveChanges();



        }
    }
}
