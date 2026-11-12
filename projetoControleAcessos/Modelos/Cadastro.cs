using System.Text.Json;

namespace ProjetoControleAcessos.Modelos;

public class Cadastro
{
    private const string NomeArquivo = "dados.json";

    public List<Usuario> Usuarios { get; set; } = new();
    public List<Ambiente> Ambientes { get; set; } = new();

    public void AdicionarUsuario(Usuario usuario)
    {
        Usuarios.Add(usuario);
    }

    public bool RemoverUsuario(Usuario usuario)
    {
        if (usuario.Ambientes.Count > 0)
        {
            return false;
        }

        return Usuarios.Remove(usuario);
    }

    public Usuario? PesquisarUsuario(Usuario usuario)
    {
        return Usuarios.FirstOrDefault(item => item.Id == usuario.Id);
    }

    public void AdicionarAmbiente(Ambiente ambiente)
    {
        Ambientes.Add(ambiente);
    }

    public bool RemoverAmbiente(Ambiente ambiente)
    {
        Ambiente? ambienteEncontrado = PesquisarAmbiente(ambiente);

        if (ambienteEncontrado is null)
        {
            return false;
        }

        foreach (Usuario usuario in Usuarios)
        {
            usuario.RevogarPermissao(ambienteEncontrado);
        }

        return Ambientes.Remove(ambienteEncontrado);
    }

    public Ambiente? PesquisarAmbiente(Ambiente ambiente)
    {
        return Ambientes.FirstOrDefault(item => item.Id == ambiente.Id);
    }

    public void Upload()
    {
        DadosPersistencia dados = new()
        {
            Usuarios = Usuarios.Select(usuario => new UsuarioPersistido
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Ambientes = usuario.Ambientes.Select(ambiente => ambiente.Id).ToList()
            }).ToList(),
            Ambientes = Ambientes.Select(ambiente => new AmbientePersistido
            {
                Id = ambiente.Id,
                Nome = ambiente.Nome,
                Logs = ambiente.Logs.Select(log => new LogPersistido
                {
                    DtAcesso = log.DtAcesso,
                    UsuarioId = log.Usuario.Id,
                    TipoAcesso = log.TipoAcesso
                }).ToList()
            }).ToList()
        };

        string json = JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(NomeArquivo, json);
    }

    public void Download()
    {
        if (!File.Exists(NomeArquivo))
        {
            return;
        }

        string json = File.ReadAllText(NomeArquivo);
        DadosPersistencia? dados = JsonSerializer.Deserialize<DadosPersistencia>(json);

        if (dados is null)
        {
            return;
        }

        Usuarios.Clear();
        Ambientes.Clear();

        foreach (AmbientePersistido ambientePersistido in dados.Ambientes)
        {
            Ambientes.Add(new Ambiente(ambientePersistido.Id, ambientePersistido.Nome));
        }

        foreach (UsuarioPersistido usuarioPersistido in dados.Usuarios)
        {
            Usuario usuario = new(usuarioPersistido.Id, usuarioPersistido.Nome);

            foreach (int ambienteId in usuarioPersistido.Ambientes)
            {
                Ambiente? ambiente = Ambientes.FirstOrDefault(item => item.Id == ambienteId);
                if (ambiente is not null)
                {
                    usuario.ConcederPermissao(ambiente);
                }
            }

            Usuarios.Add(usuario);
        }

        foreach (AmbientePersistido ambientePersistido in dados.Ambientes)
        {
            Ambiente? ambiente = Ambientes.FirstOrDefault(item => item.Id == ambientePersistido.Id);
            if (ambiente is null)
            {
                continue;
            }

            foreach (LogPersistido logPersistido in ambientePersistido.Logs)
            {
                Usuario? usuario = Usuarios.FirstOrDefault(item => item.Id == logPersistido.UsuarioId);
                if (usuario is not null)
                {
                    ambiente.RegistrarLog(new Log
                    {
                        DtAcesso = logPersistido.DtAcesso,
                        Usuario = usuario,
                        TipoAcesso = logPersistido.TipoAcesso
                    });
                }
            }
        }
    }

    private class DadosPersistencia
    {
        public List<UsuarioPersistido> Usuarios { get; set; } = new();
        public List<AmbientePersistido> Ambientes { get; set; } = new();
    }

    private class UsuarioPersistido
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<int> Ambientes { get; set; } = new();
    }

    private class AmbientePersistido
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<LogPersistido> Logs { get; set; } = new();
    }

    private class LogPersistido
    {
        public DateTime DtAcesso { get; set; }
        public int UsuarioId { get; set; }
        public bool TipoAcesso { get; set; }
    }
}
