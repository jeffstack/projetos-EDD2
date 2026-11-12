namespace ProjetoControleAcessos.Modelos;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public List<Ambiente> Ambientes { get; set; } = new();

    public Usuario()
    {
    }

    public Usuario(int id, string nome)
    {
        Id = id;
        Nome = nome;
    }

    public bool ConcederPermissao(Ambiente ambiente)
    {
        if (Ambientes.Any(item => item.Id == ambiente.Id))
        {
            return false;
        }

        Ambientes.Add(ambiente);
        return true;
    }

    public bool RevogarPermissao(Ambiente ambiente)
    {
        Ambiente? ambienteEncontrado = Ambientes.FirstOrDefault(item => item.Id == ambiente.Id);

        if (ambienteEncontrado is null)
        {
            return false;
        }

        Ambientes.Remove(ambienteEncontrado);
        return true;
    }
}
