namespace ProjetoGerenciadorProjetos;

public class Projeto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Tarefa> Tarefas { get; private set; }

    public Projeto(int id, string nome)
    {
        Id = id;
        Nome = nome;
        Tarefas = new List<Tarefa>();
    }

    public void AdicionarTarefa(Tarefa tarefa)
    {
        Tarefas.Add(tarefa);
    }

    public bool RemoverTarefa(Tarefa tarefa)
    {
        return Tarefas.Remove(tarefa);
    }

    public Tarefa? BuscarTarefa(int id)
    {
        return Tarefas.FirstOrDefault(t => t.Id == id);
    }

    public List<Tarefa> TarefasPorStatus(string status)
    {
        return Tarefas
            .Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<Tarefa> TarefasPorPrioridade(int prioridade)
    {
        return Tarefas.Where(t => t.Prioridade == prioridade).ToList();
    }

    public int TotalAbertas()
    {
        return TarefasPorStatus("Aberta").Count;
    }

    public int TotalFechadas()
    {
        return TarefasPorStatus("Fechada").Count;
    }
}
