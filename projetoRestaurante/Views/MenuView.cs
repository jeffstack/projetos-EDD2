namespace ProjetoRestaurante.Views;

public class MenuView
{
    public void ExibirMenu()
    {
        Console.WriteLine("\n===== PROJETO RESTAURANTE =====");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Criar novo pedido");
        Console.WriteLine("2. Adicionar item ao pedido");
        Console.WriteLine("3. Remover item do pedido");
        Console.WriteLine("4. Consultar pedido");
        Console.WriteLine("5. Cancelar pedido");
        Console.WriteLine("6. Listar todos os pedidos");
        Console.Write("Escolha uma opção: ");
    }

    public void MostrarMensagem(string mensagem)
    {
        Console.WriteLine($"\n{mensagem}");
    }
}
