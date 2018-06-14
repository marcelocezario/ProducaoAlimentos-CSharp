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
            CadastrarMarca = 4,

            RegistrarEntradaInsumos = 10,

            ListarInsumos = 20,
            ListarProdutos = 21,
            ListarUnidadesDeMedida = 22,

            Sair = 99,
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
            Console.WriteLine("|                4 - Cadastrar Marca                    | ");
            Console.WriteLine("|                                                       | ");
            Console.WriteLine("|                10 - Registrar Entrada de Insumos      | ");
            Console.WriteLine("|                                                       | ");
            Console.WriteLine("|                20 - Listar Insumos                    | ");
            Console.WriteLine("|                21 - Listar Produtos                   | ");
            Console.WriteLine("|                22 - Listar Unidades de Medida         | ");
            Console.WriteLine("|                                                       | ");
            Console.WriteLine("|                99 - Sair                              | ");
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
                    case OpcoesMenuPrincipal.CadastrarMarca:
                        CadastrarMarca();
                        break;



                    case OpcoesMenuPrincipal.RegistrarEntradaInsumos:
                        RegistrarEntradaInsumo();
                        break;


                    case OpcoesMenuPrincipal.ListarInsumos:
                        ListarInsumos();
                        break;
                    case OpcoesMenuPrincipal.ListarProdutos:
                        ListarProdutos();
                        break;
                    case OpcoesMenuPrincipal.ListarUnidadesDeMedida:
                        ListarUnidadesDeMedida();
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
            UnidadeDeMedidaController umc = new UnidadeDeMedidaController();
            Insumo insumo = new Insumo();

            Console.Write("Digite o nome do Insumo: ");
            insumo.Nome = Console.ReadLine();

            UnidadeDeMedida unidadeDeMedida;
            String opcao = "n";
            do
            {
                Console.Write("Digite o nome de uma unidade de medida do insumo: ");
                
                unidadeDeMedida = umc.BuscarUnidadeDeMedidaPorNome(Console.ReadLine());
                try
                {
                    ExibirUnidadeDeMedida(unidadeDeMedida);
                    Console.WriteLine("");
                    Console.Write("Cofirma Unidade De Medida (s/n)? ");
                    opcao = Console.ReadLine();
                } catch(NullReferenceException e)
                {
                    Console.WriteLine("Unidade de medida não encontrada!");
                    Console.WriteLine("");
                }
            } while (!opcao.Trim().ToLower().Equals("s"));

            insumo._UnidadeDeMedida = unidadeDeMedida;

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
            UnidadeDeMedidaController umc = new UnidadeDeMedidaController();
            Produto produto = new Produto();
            List<ItemComposicaoProduto> itens = new List<ItemComposicaoProduto>();
            InsumoController ic = new InsumoController();

            Console.Write("Digite o nome do Produto: ");
            produto.Nome = Console.ReadLine();


            UnidadeDeMedida unidadeDeMedida;
            String opcao = "n";
            do
            {
                Console.Write("Digite o nome de uma unidade de medida do insumo: ");

                unidadeDeMedida = umc.BuscarUnidadeDeMedidaPorNome(Console.ReadLine());
                try
                {
                    ExibirUnidadeDeMedida(unidadeDeMedida);
                    Console.WriteLine("");
                    Console.Write("Cofirma Unidade De Medida (s/n)? ");
                    opcao = Console.ReadLine();
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Unidade de medida não encontrada!");
                    Console.WriteLine("");
                }
            } while (!opcao.Trim().ToLower().Equals("s"));

            produto._UnidadeDeMedida = unidadeDeMedida;

            Console.WriteLine("");
            do
            {
                opcao = "n";
                ItemComposicaoProduto item = new ItemComposicaoProduto();
                Console.Write("Digite o nome do insumo que deseja utilizar na receita: ");
                item._Insumo = ic.BuscarInsumoPorNome(Console.ReadLine());

                try
                {
                    Console.Write("Digite a quantidade (em " + item._Insumo._UnidadeDeMedida.Sigla + ") de " + item._Insumo.Nome + " necessária para produzir 1 " + produto._UnidadeDeMedida.Sigla + " de " + produto.Nome + ": ");
                    item.QuantidadeInsumo = double.Parse(Console.ReadLine());

                    itens.Add(item);

                    Console.WriteLine("");
                    Console.Write("Deseja adicionar mais algum insumo a receita (s/n)? ");

                    opcao = Console.ReadLine();
                } catch (NullReferenceException e)
                {
                    Console.WriteLine("Insumo não encontrado!");
                    Console.WriteLine("");
                }
            } while (!opcao.Trim().ToLower().Equals("n"));

            produto.ComposicaoProduto = itens;

            pc.SalvarProduto(produto);

            Console.WriteLine("Produto adicionado com sucesso!");
            Console.WriteLine("");
        }

        private static void CadastrarUnidadeDeMedida()
        {
            Console.WriteLine(" _______________________________________________________ ");
            Console.WriteLine("|------------- CADASTRAR UNIDADE DE MEDIDA -------------|");
            Console.WriteLine("|_______________________________________________________|");
            Console.WriteLine("");

            UnidadeDeMedidaController umc = new UnidadeDeMedidaController();
            UnidadeDeMedida unidadeDeMedida = new UnidadeDeMedida();

            Console.Write("Digite o nome da Unidade de Medida: ");
            unidadeDeMedida.Nome = Console.ReadLine();

            Console.Write("Digite a sigla da Unidade de Medida: ");
            unidadeDeMedida.Sigla = Console.ReadLine();

            Console.Write("A unidade de medida é fracionável (s/n)?");
            if (Console.ReadLine().Trim().ToLower().Equals("s"))
                unidadeDeMedida.Fracionavel = true;
            else
                unidadeDeMedida.Fracionavel = false;

            umc.SalvarUnidadeDeMedida(unidadeDeMedida);

            Console.WriteLine("Unidade de Medida adicionada com sucesso!");
            Console.WriteLine("");
        }

        private static void CadastrarMarca()
        {
            Console.WriteLine(" _______________________________________________________ ");
            Console.WriteLine("|------------------- CADASTRAR MARCA -------------------|");
            Console.WriteLine("|_______________________________________________________|");
            Console.WriteLine("");

            Console.Write("Digite o nome da marca: ");
            
        }

        private static void RegistrarEntradaInsumo()
        {
            Console.WriteLine(" _______________________________________________________ ");
            Console.WriteLine("|------------ REGISTRAR ENTRADA DE INSUMOS -------------|");
            Console.WriteLine("|_______________________________________________________|");
            Console.WriteLine("");


            InsumoController ic = new InsumoController();
            Insumo insumo;

            string opcao = "n";
            do
            {
                Console.Write("Digite o nome do insumo que deseja adicionar em estoque: ");
                insumo = ic.BuscarInsumoPorNome(Console.ReadLine());

                try
                {
                    ExibirInsumo(insumo);
                    Console.Write("Confirma o insumo (s/n)? ");
                    opcao = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Insumo não encontrado!");
                    Console.WriteLine("");
                }
            } while (!opcao.Trim().ToLower().Equals("s"));

        }

        private static void ListarInsumos()
        {
            Console.WriteLine(" _______________________________________________________ ");
            Console.WriteLine("|------------------- LISTAR INSUMOS --------------------|");
            Console.WriteLine("|_______________________________________________________|");
            Console.WriteLine("");

            InsumoController ic = new InsumoController();

            foreach (Insumo i in ic.ListarInsumos())
                ExibirInsumo(i);
        }

        private static void ListarProdutos()
        {
            Console.WriteLine(" _______________________________________________________ ");
            Console.WriteLine("|------------------- LISTAR PRODUTOS -------------------|");
            Console.WriteLine("|_______________________________________________________|");
            Console.WriteLine("");

            ProdutoController pc = new ProdutoController();

            foreach (Produto p in pc.ListarProdutos())
                ExibirProduto(p);

        }

        private static void ListarUnidadesDeMedida()
        {
            Console.WriteLine(" _______________________________________________________ ");
            Console.WriteLine("|-------------- LISTAR UNIDADES DE MEDIDA --------------|");
            Console.WriteLine("|_______________________________________________________|");
            Console.WriteLine("");

            UnidadeDeMedidaController uc = new UnidadeDeMedidaController();

            foreach (UnidadeDeMedida u in uc.ListarUnidadesDeMedida())
                ExibirUnidadeDeMedida(u);
        }

        private static void ExibirInsumo(Insumo i)
        {
            Console.WriteLine("");
            Console.WriteLine("Id..................: " + i.InsumoID);
            Console.WriteLine("Nome................: " + i.Nome);
            Console.WriteLine("Unidade de Medida...: " + i._UnidadeDeMedida.Nome);
            Console.WriteLine("-----------------------------------------------------");
        }

        private static void ExibirProduto(Produto p)
        {
            Console.WriteLine("");
            Console.WriteLine("Id..................: " + p.ProdutoID);
            Console.WriteLine("Nome................: " + p.Nome);
            Console.WriteLine("Unidade de Medida...: " + p._UnidadeDeMedida.Nome);
            Console.WriteLine("....Composição....");
            foreach (ItemComposicaoProduto i in p.ComposicaoProduto)
            {
                Console.WriteLine(i.QuantidadeInsumo + " " + i._Insumo._UnidadeDeMedida.Sigla + " de " + i._Insumo.Nome);
            }
            Console.WriteLine("-----------------------------------------------------");
        }

        private static void ExibirUnidadeDeMedida(UnidadeDeMedida u)
        {
            Console.WriteLine("");
            Console.WriteLine("Id..................: " + u.UnidadeDeMedidaID);
            Console.WriteLine("Nome................: " + u.Nome);
            Console.WriteLine("Sigla...............: " + u.Sigla);
            Console.WriteLine("Fracionável.........: " + u.Fracionavel);
            Console.WriteLine("-----------------------------------------------------");
        }

        private static void LimparTela() => Console.Clear();
    }
}
