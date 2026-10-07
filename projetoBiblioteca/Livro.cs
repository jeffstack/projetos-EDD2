namespace ProjetoBiblioteca;

public class Livro
{
    private int isbn;
    private string titulo;
    private string autor;
    private string editora;
    private List<Exemplar> exemplares;

    public Livro(int isbn, string titulo = "", string autor = "", string editora = "")
    {
        this.isbn = isbn;
        this.titulo = titulo;
        this.autor = autor;
        this.editora = editora;
        exemplares = new List<Exemplar>();
    }

    public int Isbn { get { return isbn; } }
    public string Titulo { get { return titulo; } }
    public string Autor { get { return autor; } }
    public string Editora { get { return editora; } }
    public List<Exemplar> Exemplares { get { return exemplares; } }

    public void adicionarExemplar(Exemplar exemplar)
    {
        exemplares.Add(exemplar);
    }

    public int qtdeExemplares()
    {
        return exemplares.Count;
    }

    public int qtdeDisponiveis()
    {
        return exemplares.Count(e => e.disponivel());
    }

    public int qtdeEmprestimos()
    {
        return exemplares.Sum(e => e.qtdeEmprestimos());
    }

    public double percDisponibilidade()
    {
        if (qtdeExemplares() == 0)
        {
            return 0;
        }

        return qtdeDisponiveis() * 100.0 / qtdeExemplares();
    }
}
