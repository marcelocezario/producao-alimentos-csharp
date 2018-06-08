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
                new Insumo(){ Nome = "Farinha de Trigo", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Batata", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Ovo", UnidadeDeMedidaID = 4},
                new Insumo(){ Nome = "Óleo", UnidadeDeMedidaID = 2},
                new Insumo(){ Nome = "Leite Condensado", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Creme de Leite", UnidadeDeMedidaID = 3},
                new Insumo(){ Nome = "Leite", UnidadeDeMedidaID = 2}
            };
            context.Insumos.AddRange(insumos);
            base.Seed(context);
            context.SaveChanges();

            List<Produto> produtos = new List<Produto>()
            {
                new Produto(){ Nome = "Nhoque", UnidadeDeMedidaID = 3, ComposicaoProduto = new List<ItemComposicaoProduto>()
                {
                    new ItemComposicaoProduto(){ InsumoID = 1, QuantidadeInsumo = 0.3},
                    new ItemComposicaoProduto(){ InsumoID = 2, QuantidadeInsumo = 0.6},
                    new ItemComposicaoProduto(){ InsumoID = 3, QuantidadeInsumo = 1},
                    new ItemComposicaoProduto(){ InsumoID = 4, QuantidadeInsumo = 0.01}
                }
            }
        };
            context.Produtos.AddRange(produtos);
            base.Seed(context);
            context.SaveChanges();
        }
    }
}
