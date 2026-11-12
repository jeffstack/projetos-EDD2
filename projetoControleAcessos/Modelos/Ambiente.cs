namespace ProjetoControleAcessos.Modelos;

public class Ambiente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public Queue<Log> Logs { get; set; } = new();

    public Ambiente()
    {
    }

    public Ambiente(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public void RegistrarLog(Log log)
    {
        if (Logs.Count >= 100)
        {
            Logs.Dequeue();
        }

        Logs.Enqueue(log);
    }
}
