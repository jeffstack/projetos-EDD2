using System;

namespace ProjetoVendedores
{
    class Program
    {
        static void Main(string[] args)
        {
            Vendedores equipe = new Vendedores(10);
            int opcao = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("===== PROJETO VENDEDORES =====");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Cadastrar vendedor");
                Console.WriteLine("2. Consultar vendedor");
                Console.WriteLine("3. Excluir vendedor");
                Console.WriteLine("4. Registrar venda");
                Console.WriteLine("5. Listar vendedores");
                Console.Write("Escolha uma opção: ");
                
                try
                {
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 0:
                            Console.WriteLine("\nEncerrando o programa...");
                            break;

                        case 1:
                            CadastrarVendedor(equipe);
                            break;

                        case 2:
                            ConsultarVendedor(equipe);
                            break;

                        case 3:
                            ExcluirVendedor(equipe);
                            break;

                        case 4:
                            RegistrarVenda(equipe);
                            break;

                        case 5:
                            ListarVendedores(equipe);
                            break;

                        default:
                            Console.WriteLine("\nOpção inválida!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nErro: Digite apenas números inteiros no menu.");
                }

                if (opcao != 0)
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }

            } while (opcao != 0);
        }

        static void CadastrarVendedor(Vendedores equipe)
        {
            Console.WriteLine("\n--- CADASTRAR VENDEDOR ---");
            if (equipe.Qtde >= equipe.Max)
            {
                Console.WriteLine("Capacidade máxima de vendedores (10) já atingida.");
                return;
            }

            Console.Write("Digite o ID do Vendedor: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Vendedor: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o Percentual de Comissão (%): ");
            double comissao = double.Parse(Console.ReadLine());

            Vendedor novoVendedor = new Vendedor(id, nome, comissao);

            if (equipe.AddVendedor(novoVendedor))
            {
                Console.WriteLine("Vendedor cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro ao cadastrar. O ID informado já pode existir no sistema.");
            }
        }

        static void ConsultarVendedor(Vendedores equipe)
        {
            Console.WriteLine("\n--- CONSULTAR VENDEDOR ---");
            Console.Write("Digite o ID do Vendedor a ser consultado: ");
            int id = int.Parse(Console.ReadLine());

            Vendedor busca = new Vendedor(id);
            Vendedor encontrado = equipe.SearchVendedor(busca);

            if (encontrado != null)
            {
                Console.WriteLine($"\nID: {encontrado.Id}");
                Console.WriteLine($"Nome: {encontrado.Nome}");
                Console.WriteLine($"Total de Vendas no Mês: R$ {encontrado.ValorVendas():F2}");
                Console.WriteLine($"Comissão Devida: R$ {encontrado.ValorComissao():F2}");
                Console.WriteLine("\n--- Detalhamento Diário ---");
                
                bool temRegistro = false;
                for (int i = 0; i < encontrado.AsVendas.Length; i++)
                {
                    if (encontrado.AsVendas[i] != null)
                    {
                        temRegistro = true;
                        Console.WriteLine($"Dia {i + 1}: Valor Médio da Venda: R$ {encontrado.AsVendas[i].ValorMedio():F2}");
                    }
                }

                if (!temRegistro)
                {
                    Console.WriteLine("Nenhum registro de venda no mês para este vendedor.");
                }
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado!");
            }
        }

        static void ExcluirVendedor(Vendedores equipe)
        {
            Console.WriteLine("\n--- EXCLUIR VENDEDOR ---");
            Console.Write("Digite o ID do Vendedor que deseja excluir: ");
            int id = int.Parse(Console.ReadLine());

            Vendedor busca = new Vendedor(id);
            Vendedor encontrado = equipe.SearchVendedor(busca);

            if (encontrado != null)
            {
                if (equipe.DelVendedor(busca))
                {
                    Console.WriteLine("Vendedor excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não foi possível excluir. O vendedor possui vendas associadas a ele.");
                }
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado!");
            }
        }

        static void RegistrarVenda(Vendedores equipe)
        {
            Console.WriteLine("\n--- REGISTRAR VENDA ---");
            Console.Write("Digite o ID do Vendedor: ");
            int id = int.Parse(Console.ReadLine());

            Vendedor busca = new Vendedor(id);
            Vendedor encontrado = equipe.SearchVendedor(busca);

            if (encontrado != null)
            {
                Console.Write("Digite o Dia da Venda (1 a 31): ");
                int dia = int.Parse(Console.ReadLine());

                if (dia >= 1 && dia <= 31)
                {
                    Console.Write("Quantidade de Itens Vendidos no dia: ");
                    int qtde = int.Parse(Console.ReadLine());

                    Console.Write("Valor Total das Vendas no dia (R$): ");
                    double valor = double.Parse(Console.ReadLine());

                    Venda novaVenda = new Venda(qtde, valor);
                    encontrado.RegistrarVenda(dia, novaVenda);

                    Console.WriteLine("Venda registrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Dia inválido! Venda não registrada.");
                }
            }
            else
            {
                Console.WriteLine("Vendedor não encontrado!");
            }
        }

        static void ListarVendedores(Vendedores equipe)
        {
            Console.WriteLine("\n--- LISTA DE VENDEDORES ---");
            
            if (equipe.Qtde == 0)
            {
                Console.WriteLine("Nenhum vendedor cadastrado no sistema.");
                return;
            }

            for (int i = 0; i < equipe.Qtde; i++)
            {
                Vendedor v = equipe.OsVendedores[i];
                Console.WriteLine($"ID: {v.Id} | Nome: {v.Nome} | Total Vendas: R$ {v.ValorVendas():F2} | Comissão: R$ {v.ValorComissao():F2}");
            }

            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"TOTAL DE VENDAS DA EQUIPE: R$ {equipe.ValorVendas():F2}");
            Console.WriteLine($"TOTAL DE COMISSÕES DEVIDAS: R$ {equipe.ValorComissao():F2}");
        }
    }
}
