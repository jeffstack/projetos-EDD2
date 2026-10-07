namespace ProjetoAgendaWFA.Models;

public class Contato
{
    public string email { get; set; } = string.Empty;
    public string nome { get; set; } = string.Empty;
    public Data dtNasc { get; set; } = new();
    public List<Telefone> telefones { get; } = new();

    public Contato()
    {
    }

    public Contato(string email, string nome, Data dtNasc)
    {
        this.email = email;
        this.nome = nome;
        this.dtNasc = dtNasc;
    }

    public int getIdade()
    {
        DateTime nascimento = dtNasc.ParaDateTime();
        DateTime hoje = DateTime.Today;
        int idade = hoje.Year - nascimento.Year;
        if (nascimento.Date > hoje.AddYears(-idade))
            idade--;
        return idade;
    }

    public void adicionarTelefone(Telefone t)
    {
        if (t.principal)
        {
            foreach (Telefone telefone in telefones)
                telefone.principal = false;
        }
        telefones.Add(t);
    }

    public string getTelefonePrincipal()
    {
        return telefones.FirstOrDefault(t => t.principal)?.numero
            ?? telefones.FirstOrDefault()?.numero
            ?? string.Empty;
    }

    public override string ToString()
    {
        return $"Nome: {nome} | E-mail: {email} | Nascimento: {dtNasc} | Idade: {getIdade()} | Telefone principal: {getTelefonePrincipal()}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Contato outro)
            return false;
        return string.Equals(email.Trim(), outro.email.Trim(), StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return email.Trim().ToLowerInvariant().GetHashCode();
    }
}
