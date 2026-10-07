namespace ProjetoBiblioteca;

public class Exemplar
{
    private int tombo;
    private List<Emprestimo> emprestimos;

    public Exemplar(int tombo)
    {
        this.tombo = tombo;
        emprestimos = new List<Emprestimo>();
    }

    public int Tombo
    {
        get { return tombo; }
    }

    public List<Emprestimo> Emprestimos
    {
        get { return emprestimos; }
    }

    public bool emprestar()
    {
        if (!disponivel())
        {
            return false;
        }

        emprestimos.Add(new Emprestimo());
        return true;
    }

    public bool devolver()
    {
        if (disponivel())
        {
            return false;
        }

        emprestimos[emprestimos.Count - 1].RegistrarDevolucao();
        return true;
    }

    public bool disponivel()
    {
        return emprestimos.Count == 0 || emprestimos[emprestimos.Count - 1].DtDevolucao != DateTime.MinValue;
    }

    public int qtdeEmprestimos()
    {
        return emprestimos.Count;
    }
}
