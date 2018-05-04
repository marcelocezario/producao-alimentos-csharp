﻿using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleView
{
    class Program
    {
        enum OpcoesMenuPrincipal
        {
            CadastrarInsumos = 1,
            CadastrarProdutos = 2,

            ListarInsumos = 5,
            ListarProdutos = 6,

            Sair = 9,
        }

        private static OpcoesMenuPrincipal Menu()
        {
            Console.WriteLine("1 - CadastrarInsumos");
            Console.WriteLine("2 - CadastrarProdutos");
            Console.WriteLine("");
            Console.WriteLine("5 - ListarInsumos");
            Console.WriteLine("6 - ListarProdutos");
            Console.WriteLine("");
            Console.WriteLine("9 - Sair");
            Console.WriteLine("");

            Console.Write("Escolha a sua opção e tecle enter: ");
            string opcao = Console.ReadLine();
            Console.WriteLine("");
            return (OpcoesMenuPrincipal)int.Parse(opcao);
        }


        static void Main(string[] args)
        {
            OpcoesMenuPrincipal opcaoDigitada = OpcoesMenuPrincipal.Sair;
            do
            {
                opcaoDigitada = Menu();

                switch (opcaoDigitada)
                {
                    case OpcoesMenuPrincipal.CadastrarInsumos:
                        CadastrarInsumo();
                        break;
                    case OpcoesMenuPrincipal.CadastrarProdutos:
                        CadastrarProduto();
                        break;


                    case OpcoesMenuPrincipal.ListarInsumos:
                        ListarInsumos();
                        break;
                    case OpcoesMenuPrincipal.ListarProdutos:
                        ListarProdutos();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("");
            } while (opcaoDigitada != OpcoesMenuPrincipal.Sair);
        }

        private static void CadastrarInsumo()
        {
            InsumoController ic = new InsumoController();
            Insumo insumo = new Insumo();

            Console.Write("Digite o nome do Insumo: ");
            insumo.Nome = Console.ReadLine();
            Console.Write("Digite a unidade de medida do insumo: ");
            insumo.UnidadeDeMedida = Console.ReadLine();

            ic.SalvarInsumo(insumo);

            Console.WriteLine("Insumo adicionado com sucesso!");
            Console.WriteLine("");
        }

        private static void CadastrarProduto()
        {
            ProdutoController pc = new ProdutoController();
            Produto produto = new Produto();
            List<ItemComposicaoProduto> itens = new List<ItemComposicaoProduto>();
            InsumoController ic = new InsumoController();

            Console.Write("Digite o nome do Produto: ");
            produto.Nome = Console.ReadLine();
            Console.Write("Digite a unidade de medida do Produto: ");
            produto.UnidadeDeMedida = Console.ReadLine();

            Console.WriteLine("");
            string opcao;
            do
            {
                ItemComposicaoProduto item = new ItemComposicaoProduto();
                Console.Write("Digite o nome do insumo que deseja utilizar na receita: ");
                item._Insumo = ic.PesquisarInsumoPorNome(Console.ReadLine());
                item.InsumoID = item._Insumo.InsumoID;

                Console.Write("Digite a quantidade (em " + item._Insumo.UnidadeDeMedida
                    + ") de " + item._Insumo.Nome + " necessária para produzir 1 " + produto.UnidadeDeMedida + " de " + produto.Nome + ": ");
                item.QuantidadeInsumo = double.Parse(Console.ReadLine());

                itens.Add(item);

                Console.WriteLine("");
                Console.Write("Deseja adicionar mais algum insumo a receita (s/n)? ");

                opcao = Console.ReadLine();

            } while (opcao.Equals("s") || opcao.Equals("S"));

            produto.ComposicaoProduto = itens;

            pc.SalvarProduto(produto);

            Console.WriteLine("Produto adicionado com sucesso!");
            Console.WriteLine("");
        }

        private static void ListarInsumos()
        {
            InsumoController ic = new InsumoController();

            Console.WriteLine("Listagem de insumos");
            foreach (Insumo i in ic.ListarInsumosOrdemAlfabetica())
            {
                Console.WriteLine("");
                Console.WriteLine("Id..................: " + i.InsumoID);
                Console.WriteLine("Nome................: " + i.Nome);
                Console.WriteLine("Unidade de Medida...: " + i.UnidadeDeMedida);
                Console.WriteLine("-----------------------------------------------------");
            }
        }

        private static void ListarProdutos()
        {
            ProdutoController pc = new ProdutoController();

            Console.WriteLine("Listagem de produtos");
            foreach (Produto p in pc.ListarProdutosOrdemAlfabetica())
            {
                Console.WriteLine("");
                Console.WriteLine("Id..................: " + p.ProdutoID);
                Console.WriteLine("Nome................: " + p.Nome);
                Console.WriteLine("Unidade de Medida...: " + p.UnidadeDeMedida);
                Console.WriteLine("....Composição....");
                foreach (ItemComposicaoProduto i in p.ComposicaoProduto)
                {
                    Console.WriteLine(i.QuantidadeInsumo + " " + i._Insumo.UnidadeDeMedida + " de " + i._Insumo.Nome);
                }
                Console.WriteLine("-----------------------------------------------------");
            }
        }

        private void LimparTela()
        {

        }
    }
}
