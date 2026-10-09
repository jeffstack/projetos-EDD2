namespace ProjetoGerenciadorProjetos;

public class Projetos
{
    private readonly List<Projeto> itens = new();

    public bool Adicionar(Projeto projeto)
    {
        if (itens.Any(p => p.Id == projeto.Id))
        {
            return false;
        }

        itens.Add(projeto);
        return true;
    }

    public bool Remover(Projeto projeto)
    {
        if (projeto.Tarefas.Count > 0)
        {
            return false;
        }

        return itens.Remove(projeto);
    }

    public Projeto? Buscar(int id)
    {
        return itens.FirstOrDefault(p => p.Id == id);
    }

    public List<Projeto> Listar()
    {
        return itens.ToList();
    }
}
