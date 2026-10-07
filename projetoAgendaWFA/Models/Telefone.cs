namespace ProjetoAgendaWFA.Models;

public class Telefone
{
    public string tipo { get; set; } = string.Empty;
    public string numero { get; set; } = string.Empty;
    public bool principal { get; set; }

    public Telefone()
    {
    }

    public Telefone(string tipo, string numero, bool principal)
    {
        this.tipo = tipo;
        this.numero = numero;
        this.principal = principal;
    }
}
