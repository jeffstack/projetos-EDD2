using System.Globalization;
using ProjetoRestaurante.Models;
using ProjetoRestaurante.Views;

namespace ProjetoRestaurante.Controllers;

public class RestauranteController
{
    private readonly Restaurante restaurante = new();
    private readonly MenuView view = new();
    private readonly CultureInfo cultura = new("pt-BR");

    public void Executar()
    {
        int opcao;

        do
        {
            view.ExibirMenu();
            opcao = LerInteiro();

            switch (opcao)
            {
                case 1:
                    CriarPedido();
                    break;
                case 2:
                    AdicionarItem();
                    break;
                case 3:
                    RemoverItem();
                    break;
                case 4:
                    ConsultarPedido();
                    break;
                case 5:
                    CancelarPedido();
                    break;
                case 6:
                    ListarPedidos();
                    break;
                case 0:
                    view.MostrarMensagem("Programa encerrado.");
                    break;
                default:
                    view.MostrarMensagem("Opção inválida.");
                    break;
            }
        } while (opcao != 0);
    }

    private void CriarPedido()
    {
        Console.Write("Nome do cliente: ");
        string cliente = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(cliente))
        {
            view.MostrarMensagem("O nome do cliente deve ser informado.");
            return;
        }

        Pedido pedido = new(0, cliente);

        if (restaurante.NovoPedido(pedido))
        {
            view.MostrarMensagem($"Pedido criado com o número {pedido.Id}.");
        }
        else
        {
            view.MostrarMensagem("Não foi possível criar o pedido. Limite diário atingido.");
        }
    }

    private void AdicionarItem()
    {
        Pedido? pedido = EncontrarPedido();
        if (pedido is null)
        {
            return;
        }

        Console.Write("Id do item: ");
        int id = LerInteiro();
        Console.Write("Descrição do item: ");
        string descricao = Console.ReadLine() ?? string.Empty;
        Console.Write("Preço do item: ");
        double preco = LerDouble();

        if (string.IsNullOrWhiteSpace(descricao) || preco < 0)
        {
            view.MostrarMensagem("Descrição e preço válido devem ser informados.");
            return;
        }

        if (pedido.AdicionarItem(new Item(id, descricao, preco)))
        {
            view.MostrarMensagem("Item adicionado ao pedido.");
        }
        else
        {
            view.MostrarMensagem("Não foi possível adicionar o item. Limite de 10 itens atingido.");
        }
    }

    private void RemoverItem()
    {
        Pedido? pedido = EncontrarPedido();
        if (pedido is null)
        {
            return;
        }

        Console.Write("Id do item que será removido: ");
        int id = LerInteiro();

        if (pedido.RemoverItem(new Item(id, string.Empty, 0)))
        {
            view.MostrarMensagem("Item removido do pedido.");
        }
        else
        {
            view.MostrarMensagem("Item não encontrado no pedido.");
        }
    }

    private void ConsultarPedido()
    {
        Pedido? pedido = EncontrarPedido();
        if (pedido is not null)
        {
            Console.WriteLine();
            Console.WriteLine(pedido.DadosDoPedido());
        }
    }

    private void CancelarPedido()
    {
        Pedido? pedido = EncontrarPedido();
        if (pedido is null)
        {
            return;
        }

        if (restaurante.CancelarPedido(pedido))
        {
            view.MostrarMensagem("Pedido cancelado.");
        }
        else
        {
            view.MostrarMensagem("Não foi possível cancelar o pedido.");
        }
    }

    private void ListarPedidos()
    {
        List<Pedido> pedidos = restaurante.ListarPedidos();
        double somaGeral = 0;

        Console.WriteLine("\n===== PEDIDOS DO DIA =====");
        if (pedidos.Count == 0)
        {
            Console.WriteLine("Nenhum pedido cadastrado.");
        }
        else
        {
            foreach (Pedido pedido in pedidos)
            {
                double total = pedido.CalcularTotal();
                Console.WriteLine($"Pedido {pedido.Id} - R$ {total:F2}");
                somaGeral += total;
            }
        }

        Console.WriteLine($"Soma geral do dia: R$ {somaGeral:F2}");
    }

    private Pedido? EncontrarPedido()
    {
        Console.Write("Número do pedido: ");
        int id = LerInteiro();
        Pedido? pedido = restaurante.BuscarPedido(new Pedido(id, string.Empty));

        if (pedido is null)
        {
            view.MostrarMensagem("Pedido não encontrado.");
        }

        return pedido;
    }

    private int LerInteiro()
    {
        string valor = Console.ReadLine() ?? string.Empty;
        return int.TryParse(valor, out int resultado) ? resultado : -1;
    }

    private double LerDouble()
    {
        string valor = Console.ReadLine() ?? string.Empty;
        return double.TryParse(valor, NumberStyles.Number, cultura, out double resultado) ? resultado : -1;
    }
}
