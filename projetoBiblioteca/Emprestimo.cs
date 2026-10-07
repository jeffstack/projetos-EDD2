namespace ProjetoBiblioteca;

public class Emprestimo
{
    private DateTime dtEmprestimo;
    private DateTime dtDevolucao;

    public Emprestimo()
    {
        dtEmprestimo = DateTime.Now;
        dtDevolucao = DateTime.MinValue;
    }

    public DateTime DtEmprestimo
    {
        get { return dtEmprestimo; }
    }

    public DateTime DtDevolucao
    {
        get { return dtDevolucao; }
    }

    public void RegistrarDevolucao()
    {
        dtDevolucao = DateTime.Now;
    }
}
