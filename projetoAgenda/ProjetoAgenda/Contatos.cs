namespace ProjetoAgenda;

public class Contatos
{
    private readonly List<Contato> agenda = new();

    public IReadOnlyList<Contato> Agenda => agenda.AsReadOnly();

    public bool adicionar(Contato c)
    {
        if (agenda.Any(contato => contato.Equals(c)))
        {
            return false;
        }

        agenda.Add(c);
        return true;
    }

    public Contato? pesquisar(Contato c)
    {
        return agenda.FirstOrDefault(contato => contato.Equals(c));
    }

    public bool alterar(Contato c)
    {
        int indice = agenda.FindIndex(contato => ReferenceEquals(contato, c));

        if (indice == -1)
        {
            indice = agenda.FindIndex(contato => contato.Equals(c));
        }

        if (indice == -1)
        {
            return false;
        }

        agenda[indice] = c;
        return true;
    }

    public bool remover(Contato c)
    {
        return agenda.Remove(c);
    }
}
