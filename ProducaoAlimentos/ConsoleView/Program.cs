using Controller;
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
            Console.WriteLine("1 - " + OpcoesMenuPrincipal.CadastrarInsumos);
            Console.WriteLine("2 - " + OpcoesMenuPrincipal.CadastrarProdutos);
            Console.WriteLine("");
            Console.WriteLine("5 - " + OpcoesMenuPrincipal.ListarInsumos);
            Console.WriteLine("6 - " + OpcoesMenuPrincipal.ListarProdutos);
            Console.WriteLine("");
            Console.WriteLine("9 - " + OpcoesMenuPrincipal.Sair);
            Console.WriteLine("");

            Console.WriteLine("Escolha a sua opção e tecle enter: ");
            string opcao = Console.ReadLine();
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

            insumo.Nome = "Farinha de Trigo";
            insumo.UnidadeDeMedida = "Kg";

            ic.SalvarInsumo(insumo);
        }

        private static void CadastrarProduto()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
