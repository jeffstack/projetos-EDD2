namespace ProjetoAgenda;

public class Contato
{
    public string Email { get; set; }
    public string Nome { get; set; }
    public Data DtNasc { get; set; }
    public List<Telefone> Telefones { get; set; }

    public Contato(string email, string nome, Data dtNasc)
    {
        Email = email;
        Nome = nome;
        DtNasc = dtNasc;
        Telefones = new List<Telefone>();
    }

    public int getIdade()
    {
        DateTime hoje = DateTime.Today;
        int idade = hoje.Year - DtNasc.Ano;

        if (DtNasc.Mes > hoje.Month ||
            (DtNasc.Mes == hoje.Month && DtNasc.Dia > hoje.Day))
        {
            idade--;
        }

        return idade;
    }

    public void adicionarTelefone(Telefone t)
    {
        Telefones.Add(t);
    }

    public string getTelefonePrincipal()
    {
        Telefone? telefone = Telefones.FirstOrDefault(t => t.Principal);
        return telefone == null ? "Não informado" : telefone.Numero;
    }

    public override string ToString()
    {
        return $"Nome: {Nome} | E-mail: {Email} | Nascimento: {DtNasc} | " +
               $"Idade: {getIdade()} | Telefone principal: {getTelefonePrincipal()}";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Contato outro)
        {
            return false;
        }

        return string.Equals(Email.Trim(), outro.Email.Trim(),
            StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return Email.Trim().ToLowerInvariant().GetHashCode();
    }
}
