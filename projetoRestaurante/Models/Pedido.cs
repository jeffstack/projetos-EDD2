using System.Text;

namespace ProjetoRestaurante.Models;

public class Pedido
{
    private readonly Item?[] itens = new Item?[10];

    public int Id { get; set; }
    public string Cliente { get; set; }

    public Pedido(int id, string cliente)
    {
        Id = id;
        Cliente = cliente;
    }

    public bool AdicionarItem(Item item)
    {
        for (int i = 0; i < itens.Length; i++)
        {
            if (itens[i] is null)
            {
                itens[i] = item;
                return true;
            }
        }

        return false;
    }

    public bool RemoverItem(Item item)
    {
        for (int i = 0; i < itens.Length; i++)
        {
            if (itens[i] is not null && itens[i]!.Id == item.Id)
            {
                itens[i] = null;
                return true;
            }
        }

        return false;
    }

    public string DadosDoPedido()
    {
        StringBuilder dados = new();
        dados.AppendLine($"Pedido: {Id}");
        dados.AppendLine($"Cliente: {Cliente}");
        dados.AppendLine("Itens:");

        bool possuiItens = false;
        foreach (Item? item in itens)
        {
            if (item is not null)
            {
                dados.AppendLine($"  {item}");
                possuiItens = true;
            }
        }

        if (!possuiItens)
        {
            dados.AppendLine("  Nenhum item.");
        }

        dados.AppendLine($"Valor total: R$ {CalcularTotal():F2}");
        return dados.ToString();
    }

    public double CalcularTotal()
    {
        double total = 0;

        foreach (Item? item in itens)
        {
            if (item is not null)
            {
                total += item.Preco;
            }
        }

        return total;
    }
}
