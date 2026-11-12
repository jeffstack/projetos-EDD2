using ProjetoControleAcessos.Modelos;

Cadastro cadastro = new();
cadastro.Download();

int opcao;
do
{
    ExibirMenu();
    opcao = LerInteiro("Escolha uma opção: ");
    Console.WriteLine();

    switch (opcao)
    {
        case 1:
            CadastrarAmbiente();
            break;
        case 2:
            ConsultarAmbiente();
            break;
        case 3:
            ExcluirAmbiente();
            break;
        case 4:
            CadastrarUsuario();
            break;
        case 5:
            ConsultarUsuario();
            break;
        case 6:
            ExcluirUsuario();
            break;
        case 7:
            ConcederPermissao();
            break;
        case 8:
            RevogarPermissao();
            break;
        case 9:
            RegistrarAcesso();
            break;
        case 10:
            ConsultarLogs();
            break;
        case 0:
            cadastro.Upload();
            Console.WriteLine("Dados salvos. Programa encerrado.");
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    if (opcao != 0)
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }
}
while (opcao != 0);

void ExibirMenu()
{
    Console.Clear();
    Console.WriteLine("=== PROJETO CONTROLE DE ACESSOS ===");
    Console.WriteLine("0. Sair");
    Console.WriteLine("1. Cadastrar ambiente");
    Console.WriteLine("2. Consultar ambiente");
    Console.WriteLine("3. Excluir ambiente");
    Console.WriteLine("4. Cadastrar usuário");
    Console.WriteLine("5. Consultar usuário");
    Console.WriteLine("6. Excluir usuário");
    Console.WriteLine("7. Conceder permissão de acesso ao usuário");
    Console.WriteLine("8. Revogar permissão de acesso do usuário");
    Console.WriteLine("9. Registrar acesso");
    Console.WriteLine("10. Consultar logs de acesso");
    Console.WriteLine();
}

void CadastrarAmbiente()
{
    int id = LerInteiro("ID do ambiente: ");
    if (cadastro.PesquisarAmbiente(new Ambiente(id, string.Empty)) is not null)
    {
        Console.WriteLine("Já existe um ambiente com este ID.");
        return;
    }

    string nome = LerTexto("Nome do ambiente: ");
    cadastro.AdicionarAmbiente(new Ambiente(id, nome));
    Console.WriteLine("Ambiente cadastrado com sucesso.");
}

void ConsultarAmbiente()
{
    Ambiente? ambiente = EncontrarAmbiente();
    if (ambiente is null) return;

    Console.WriteLine($"ID: {ambiente.Id}");
    Console.WriteLine($"Nome: {ambiente.Nome}");
    Console.WriteLine($"Quantidade de logs: {ambiente.Logs.Count}");
}

void ExcluirAmbiente()
{
    Ambiente? ambiente = EncontrarAmbiente();
    if (ambiente is null) return;

    Console.WriteLine(cadastro.RemoverAmbiente(ambiente)
        ? "Ambiente removido com sucesso."
        : "Não foi possível remover o ambiente.");
}

void CadastrarUsuario()
{
    int id = LerInteiro("ID do usuário: ");
    if (cadastro.PesquisarUsuario(new Usuario(id, string.Empty)) is not null)
    {
        Console.WriteLine("Já existe um usuário com este ID.");
        return;
    }

    string nome = LerTexto("Nome do usuário: ");
    cadastro.AdicionarUsuario(new Usuario(id, nome));
    Console.WriteLine("Usuário cadastrado com sucesso.");
}

void ConsultarUsuario()
{
    Usuario? usuario = EncontrarUsuario();
    if (usuario is null) return;

    Console.WriteLine($"ID: {usuario.Id}");
    Console.WriteLine($"Nome: {usuario.Nome}");
    Console.WriteLine("Ambientes com permissão:");

    if (usuario.Ambientes.Count == 0)
    {
        Console.WriteLine("Nenhum.");
        return;
    }

    foreach (Ambiente ambiente in usuario.Ambientes)
    {
        Console.WriteLine($"- {ambiente.Id} - {ambiente.Nome}");
    }
}

void ExcluirUsuario()
{
    Usuario? usuario = EncontrarUsuario();
    if (usuario is null) return;

    Console.WriteLine(cadastro.RemoverUsuario(usuario)
        ? "Usuário removido com sucesso."
        : "Não foi possível remover. O usuário ainda possui permissões.");
}

void ConcederPermissao()
{
    Usuario? usuario = EncontrarUsuario();
    Ambiente? ambiente = EncontrarAmbiente();
    if (usuario is null || ambiente is null) return;

    Console.WriteLine(usuario.ConcederPermissao(ambiente)
        ? "Permissão concedida com sucesso."
        : "O usuário já possui permissão neste ambiente.");
}

void RevogarPermissao()
{
    Usuario? usuario = EncontrarUsuario();
    Ambiente? ambiente = EncontrarAmbiente();
    if (usuario is null || ambiente is null) return;

    Console.WriteLine(usuario.RevogarPermissao(ambiente)
        ? "Permissão revogada com sucesso."
        : "O usuário não possui permissão neste ambiente.");
}

void RegistrarAcesso()
{
    Ambiente? ambiente = EncontrarAmbiente();
    Usuario? usuario = EncontrarUsuario();
    if (ambiente is null || usuario is null) return;

    bool autorizado = usuario.Ambientes.Any(item => item.Id == ambiente.Id);
    ambiente.RegistrarLog(new Log(usuario, autorizado));
    Console.WriteLine(autorizado ? "Acesso autorizado e registrado." : "Acesso negado e registrado.");
}

void ConsultarLogs()
{
    Ambiente? ambiente = EncontrarAmbiente();
    if (ambiente is null) return;

    Console.WriteLine("1. Autorizados");
    Console.WriteLine("2. Negados");
    Console.WriteLine("3. Todos");
    int filtro = LerInteiro("Filtro: ");

    IEnumerable<Log> logs = ambiente.Logs;
    if (filtro == 1) logs = logs.Where(log => log.TipoAcesso);
    if (filtro == 2) logs = logs.Where(log => !log.TipoAcesso);

    foreach (Log log in logs)
    {
        Console.WriteLine($"{log.DtAcesso:dd/MM/yyyy HH:mm:ss} | Usuário: {log.Usuario.Nome} | {(log.TipoAcesso ? "Autorizado" : "Negado")}");
    }
}

Ambiente? EncontrarAmbiente()
{
    int id = LerInteiro("ID do ambiente: ");
    Ambiente? ambiente = cadastro.PesquisarAmbiente(new Ambiente(id, string.Empty));
    if (ambiente is null) Console.WriteLine("Ambiente não encontrado.");
    return ambiente;
}

Usuario? EncontrarUsuario()
{
    int id = LerInteiro("ID do usuário: ");
    Usuario? usuario = cadastro.PesquisarUsuario(new Usuario(id, string.Empty));
    if (usuario is null) Console.WriteLine("Usuário não encontrado.");
    return usuario;
}

int LerInteiro(string mensagem)
{
    Console.Write(mensagem);
    int valor;
    while (!int.TryParse(Console.ReadLine(), out valor))
    {
        Console.Write("Digite um número válido: ");
    }

    return valor;
}

string LerTexto(string mensagem)
{
    Console.Write(mensagem);
    string? texto = Console.ReadLine();
    return string.IsNullOrWhiteSpace(texto) ? "Sem nome" : texto.Trim();
}
