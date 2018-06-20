﻿using System;
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
                new Produto(){ Nome = "Nhoque", UnidadeDeMedidaID = 3, _ComposicaoProduto = new List<ItemComposicaoProduto>()
                {
                    new ItemComposicaoProduto(){ InsumoID = 2, QtdeInsumo = 0.6},
                    new ItemComposicaoProduto(){ InsumoID = 4, QtdeInsumo = 0.3},
                    new ItemComposicaoProduto(){ InsumoID = 9, QtdeInsumo = 1},
                    new ItemComposicaoProduto(){ InsumoID = 8, QtdeInsumo = 0.01}
                }
            }
        };
            context.Produtos.AddRange(produtos);
            base.Seed(context);
            context.SaveChanges();


            List<EstoqueInsumo> estoqueInsumo = new List<EstoqueInsumo>()
            {
                new EstoqueInsumo(){ InsumoID = 3, QtdeTotalEstoque = 0, CustoTotalEstoque = 0 }
            };
            context.EstoqueInsumos.AddRange(estoqueInsumo);
            base.Seed(context);
            context.SaveChanges();


            List<Estado> estados = new List<Estado>()
            {
                new Estado(){ Nome = "Acre", Sigla = "AC" },
                new Estado(){ Nome = "Alagoas", Sigla = "AL" },
                new Estado(){ Nome = "Amapá", Sigla = "AP" },
                new Estado(){ Nome = "Amazonas", Sigla = "AM" },
                new Estado(){ Nome = "Bahia", Sigla = "BA" },
                new Estado(){ Nome = "Ceará", Sigla = "CE" },
                new Estado(){ Nome = "Distrito Federal", Sigla = "DF" },
                new Estado(){ Nome = "Espirito Santo", Sigla = "ES" },
                new Estado(){ Nome = "Goiás", Sigla = "GO" },
                new Estado(){ Nome = "Maranhão", Sigla = "MA" },
                new Estado(){ Nome = "Mato Grosso", Sigla = "MT" },
                new Estado(){ Nome = "Mato Grosso do Sul", Sigla = "MS" },
                new Estado(){ Nome = "Minas Gerais", Sigla = "MG" },
                new Estado(){ Nome = "Pará", Sigla = "PA" },
                new Estado(){ Nome = "Paraíba", Sigla = "PB" },
                new Estado(){ Nome = "Paraná", Sigla = "PR" },
                new Estado(){ Nome = "Pernambuco", Sigla = "PE" },
                new Estado(){ Nome = "Piauí", Sigla = "PI" },
                new Estado(){ Nome = "Rio de Janeiro", Sigla = "RJ" },
                new Estado(){ Nome = "Rio Grande do Norte", Sigla = "RN" },
                new Estado(){ Nome = "Rio Grande do Sul", Sigla = "RS" },
                new Estado(){ Nome = "Rondônia", Sigla = "RO" },
                new Estado(){ Nome = "Roraima", Sigla = "RR" },
                new Estado(){ Nome = "Santa Catarina", Sigla = "SC" },
                new Estado(){ Nome = "São Paulo", Sigla = "SP" },
                new Estado(){ Nome = "Sergipe", Sigla = "SE" },
                new Estado(){ Nome = "Tocantins", Sigla = "TO" },
            };
            context.Estados.AddRange(estados);
            base.Seed(context);
            context.SaveChanges();

        }
    }
}
