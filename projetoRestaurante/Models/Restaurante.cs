namespace ProjetoRestaurante.Models;

public class Restaurante
{
    private int proxPedido = 1;
    private readonly Pedido?[] pedidos = new Pedido?[50];

    public bool NovoPedido(Pedido pedido)
    {
        if (proxPedido > 50)
        {
            return false;
        }

        for (int i = 0; i < pedidos.Length; i++)
        {
            if (pedidos[i] is null)
            {
                pedido.Id = proxPedido;
                proxPedido++;
                pedidos[i] = pedido;
                return true;
            }
        }

        return false;
    }

    public Pedido? BuscarPedido(Pedido pedido)
    {
        foreach (Pedido? pedidoSalvo in pedidos)
        {
            if (pedidoSalvo is not null && pedidoSalvo.Id == pedido.Id)
            {
                return pedidoSalvo;
            }
        }

        return null;
    }

    public bool CancelarPedido(Pedido pedido)
    {
        for (int i = 0; i < pedidos.Length; i++)
        {
            if (pedidos[i] is not null && pedidos[i]!.Id == pedido.Id)
            {
                pedidos[i] = null;
                return true;
            }
        }

        return false;
    }

    public List<Pedido> ListarPedidos()
    {
        List<Pedido> pedidosAtivos = new();

        foreach (Pedido? pedido in pedidos)
        {
            if (pedido is not null)
            {
                pedidosAtivos.Add(pedido);
            }
        }

        return pedidosAtivos;
    }
}
