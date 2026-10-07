namespace ProjetoAgendaWFA.Models;

public class Contatos
{
    private readonly List<Contato> agenda = new();

    public IReadOnlyList<Contato> Agenda => agenda.AsReadOnly();

    public bool adicionar(Contato c)
    {
        if (agenda.Contains(c))
            return false;
        agenda.Add(c);
        return true;
    }

    public Contato? pesquisar(Contato c)
    {
        return agenda.FirstOrDefault(contato =>
            string.Equals(contato.email, c.email, StringComparison.OrdinalIgnoreCase)
            || string.Equals(contato.nome, c.nome, StringComparison.OrdinalIgnoreCase));
    }

    public bool alterar(Contato c)
    {
        Contato? contato = agenda.FirstOrDefault(item =>
            string.Equals(item.email, c.email, StringComparison.OrdinalIgnoreCase));
        if (contato is null)
            return false;

        int indice = agenda.IndexOf(contato);
        agenda[indice] = c;
        return true;
    }

    public bool remover(Contato c)
    {
        Contato? contato = pesquisar(c);
        return contato is not null && agenda.Remove(contato);
    }
}
