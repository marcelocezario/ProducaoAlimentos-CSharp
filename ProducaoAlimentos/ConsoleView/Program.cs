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
            CadastrarUnidadeDeMedida = 3,

            ListarInsumos = 5,
            ListarProdutos = 6,

            Sair = 9,
        }

        private static OpcoesMenuPrincipal Menu()
        {
            LimparTela();
            Console.WriteLine(" _______________________________________________________  ");
            Console.WriteLine("|------------------ PRODUÇÃO ALIMENTOS -----------------| ");
            Console.WriteLine("|                                                       | ");
            Console.WriteLine("|                1 - Cadastrar Insumos                  | ");
            Console.WriteLine("|                2 - Cadastrar Produtos                 | ");
            Console.WriteLine("|                3 - Cadastrar Unidade de Medida        | ");
            Console.WriteLine("|                                                       | ");
            Console.WriteLine("|                5 - Listar Insumos                     | ");
            Console.WriteLine("|                6 - Listar Produtos                    | ");
            Console.WriteLine("|                                                       | ");
            Console.WriteLine("|                9 - Sair                               | ");
            Console.WriteLine("|_______________________________________________________| ");

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

                LimparTela();

                switch (opcaoDigitada)
                {
                    case OpcoesMenuPrincipal.CadastrarInsumos:
                        CadastrarInsumo();
                        break;
                    case OpcoesMenuPrincipal.CadastrarProdutos:
                        CadastrarProduto();
                        break;
                    case OpcoesMenuPrincipal.CadastrarUnidadeDeMedida:
                        CadastrarUnidadeDeMedida();
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
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();

            } while (opcaoDigitada != OpcoesMenuPrincipal.Sair);
        }

        private static void CadastrarInsumo()
        {
            Console.WriteLine(" _______________________________________________________ ");
            Console.WriteLine("|------------------ CADASTRAR INSUMO -------------------|");
            Console.WriteLine("|_______________________________________________________|");
            Console.WriteLine("");

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
            Console.WriteLine(" _______________________________________________________ ");
            Console.WriteLine("|------------------ CADASTRAR PRODUTO ------------------|");
            Console.WriteLine("|_______________________________________________________|");
            Console.WriteLine("");

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
            Console.WriteLine(" _______________________________________________________ ");
            Console.WriteLine("|------------------- LISTAR INSUMOS --------------------|");
            Console.WriteLine("|_______________________________________________________|");
            Console.WriteLine("");

            InsumoController ic = new InsumoController();

            foreach (Insumo i in ic.ListarInsumosOrdemAlfabetica())
                ExibirInsumo(i);
        }

        private static void ListarProdutos()
        {
            Console.WriteLine(" _______________________________________________________ ");
            Console.WriteLine("|------------------- LISTAR PRODUTOS -------------------|");
            Console.WriteLine("|_______________________________________________________|");
            Console.WriteLine("");

            ProdutoController pc = new ProdutoController();

            foreach (Produto p in pc.ListarProdutosOrdemAlfabetica())
                ExibirProduto(p);

        }

        private static void ExibirInsumo(Insumo i)
        {
            Console.WriteLine("");
            Console.WriteLine("Id..................: " + i.InsumoID);
            Console.WriteLine("Nome................: " + i.Nome);
            Console.WriteLine("Unidade de Medida...: " + i.UnidadeDeMedida);
            Console.WriteLine("-----------------------------------------------------");
        }

        private static void ExibirProduto(Produto p)
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

        private static void LimparTela() => Console.Clear();
    }
}
