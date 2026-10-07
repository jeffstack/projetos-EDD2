namespace ProjetoBiblioteca;

public class Livros
{
    private List<Livro> acervo;

    public Livros()
    {
        acervo = new List<Livro>();
    }

    public List<Livro> Acervo
    {
        get { return acervo; }
    }

    public void adicionar(Livro livro)
    {
        acervo.Add(livro);
    }

    public Livro? pesquisar(Livro livro)
    {
        return acervo.FirstOrDefault(l => l.Isbn == livro.Isbn);
    }
}
