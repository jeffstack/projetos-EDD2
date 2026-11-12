namespace ProjetoControleAcessos.Modelos;

public class Log
{
    public DateTime DtAcesso { get; set; }
    public Usuario Usuario { get; set; } = new();
    public bool TipoAcesso { get; set; }

    public Log()
    {
    }

    public Log(Usuario usuario, bool tipoAcesso)
    {
        DtAcesso = DateTime.Now;
        Usuario = usuario;
        TipoAcesso = tipoAcesso;
    }
}
