namespace ProjetoGerenciadorProjetos;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Prioridade { get; set; }
    public string Status { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public DateTime? DataConclusao { get; private set; }

    public Tarefa(int id, string titulo, string descricao, int prioridade)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Prioridade = prioridade;
        Status = "Aberta";
        DataCriacao = DateTime.Now;
        DataConclusao = null;
    }

    public void Concluir()
    {
        Status = "Fechada";
        DataConclusao = DateTime.Now;
    }

    public void Cancelar()
    {
        Status = "Cancelada";
        DataConclusao = null;
    }

    public void Reabrir()
    {
        Status = "Aberta";
        DataConclusao = null;
    }
}
