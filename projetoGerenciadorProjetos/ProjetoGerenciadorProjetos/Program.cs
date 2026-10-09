namespace ProjetoGerenciadorProjetos;

public class Program
{
    private static readonly Projetos projetos = new();
    private static int proximoProjetoId = 1;
    private static int proximaTarefaId = 1;

    public static void Main(string[] args)
    {
        int opcao;

        do
        {
            ExibirMenu();
            opcao = LerInteiro("Escolha uma opção: ");
            Console.WriteLine();

            switch (opcao)
            {
                case 1: AdicionarProjeto(); break;
                case 2: PesquisarProjeto(); break;
                case 3: RemoverProjeto(); break;
                case 4: AdicionarTarefa(); break;
                case 5: AlterarStatusTarefa("concluir"); break;
                case 6: AlterarStatusTarefa("cancelar"); break;
                case 7: AlterarStatusTarefa("reabrir"); break;
                case 8: ListarTarefasProjeto(); break;
                case 9: FiltrarTarefasProjeto(); break;
                case 10: FiltrarTarefasTodosProjetos(); break;
                case 11: ExibirResumoGeral(); break;
                case 0: Console.WriteLine("Programa encerrado."); break;
                default: Console.WriteLine("Opção inválida."); break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        } while (opcao != 0);
    }

    private static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("       GERENCIADOR DE PROJETOS");
        Console.WriteLine("========================================");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Adicionar projeto");
        Console.WriteLine("2. Pesquisar projeto");
        Console.WriteLine("3. Remover projeto");
        Console.WriteLine("4. Adicionar tarefa em projeto");
        Console.WriteLine("5. Concluir tarefa");
        Console.WriteLine("6. Cancelar tarefa");
        Console.WriteLine("7. Reabrir tarefa");
        Console.WriteLine("8. Listar tarefas de um projeto");
        Console.WriteLine("9. Filtrar tarefas em um projeto");
        Console.WriteLine("10. Filtrar tarefas em todos os projetos");
        Console.WriteLine("11. Resumo geral");
        Console.WriteLine("========================================");
    }

    private static void AdicionarProjeto()
    {
        string nome = LerTexto("Nome do projeto: ");
        Projeto projeto = new(proximoProjetoId++, nome);
        projetos.Adicionar(projeto);
        Console.WriteLine($"Projeto cadastrado com o código {projeto.Id}.");
    }

    private static void PesquisarProjeto()
    {
        Projeto? projeto = SelecionarProjeto();
        if (projeto == null) return;

        Console.WriteLine($"\nProjeto: {projeto.Nome}");
        Console.WriteLine($"Tarefas abertas: {projeto.TotalAbertas()}");
        Console.WriteLine($"Tarefas fechadas: {projeto.TotalFechadas()}");
        Console.WriteLine($"Tarefas canceladas: {projeto.TarefasPorStatus("Cancelada").Count}");
        ExibirTarefasPorStatus(projeto);
    }

    private static void RemoverProjeto()
    {
        Projeto? projeto = SelecionarProjeto();
        if (projeto == null) return;

        if (projeto.Tarefas.Count > 0)
        {
            Console.WriteLine("O projeto não pode ser removido porque possui tarefas.");
            return;
        }

        projetos.Remover(projeto);
        Console.WriteLine("Projeto removido.");
    }

    private static void AdicionarTarefa()
    {
        Projeto? projeto = SelecionarProjeto();
        if (projeto == null) return;

        string titulo = LerTexto("Título da tarefa: ");
        string descricao = LerTexto("Descrição da tarefa: ");
        int prioridade = LerPrioridade();
        Tarefa tarefa = new(proximaTarefaId++, titulo, descricao, prioridade);
        projeto.AdicionarTarefa(tarefa);
        Console.WriteLine($"Tarefa cadastrada com o código {tarefa.Id}.");
    }

    private static void AlterarStatusTarefa(string acao)
    {
        Projeto? projeto = SelecionarProjeto();
        if (projeto == null) return;

        Tarefa? tarefa = SelecionarTarefa(projeto);
        if (tarefa == null) return;

        if (acao == "concluir") tarefa.Concluir();
        if (acao == "cancelar") tarefa.Cancelar();
        if (acao == "reabrir") tarefa.Reabrir();
        string mensagem = acao switch
        {
            "concluir" => "Tarefa concluída com sucesso.",
            "cancelar" => "Tarefa cancelada com sucesso.",
            _ => "Tarefa reaberta com sucesso."
        };
        Console.WriteLine(mensagem);
    }

    private static void ListarTarefasProjeto()
    {
        Projeto? projeto = SelecionarProjeto();
        if (projeto == null) return;
        ExibirTarefas(projeto.Tarefas);
    }

    private static void FiltrarTarefasProjeto()
    {
        Projeto? projeto = SelecionarProjeto();
        if (projeto == null) return;

        List<Tarefa> resultado = FiltrarTarefas(projeto.Tarefas);
        ExibirTarefas(resultado);
    }

    private static void FiltrarTarefasTodosProjetos()
    {
        List<Tarefa> todas = projetos.Listar().SelectMany(p => p.Tarefas).ToList();
        List<Tarefa> resultado = FiltrarTarefas(todas);
        ExibirTarefas(resultado);
    }

    private static List<Tarefa> FiltrarTarefas(List<Tarefa> tarefas)
    {
        Console.WriteLine("1. Filtrar por status");
        Console.WriteLine("2. Filtrar por prioridade");
        int tipo = LerInteiro("Escolha o tipo de filtro: ");

        if (tipo == 1)
        {
            string status = LerStatus();
            return tarefas.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (tipo == 2)
        {
            int prioridade = LerPrioridade();
            return tarefas.Where(t => t.Prioridade == prioridade).ToList();
        }

        Console.WriteLine("Tipo de filtro inválido.");
        return new List<Tarefa>();
    }

    private static void ExibirResumoGeral()
    {
        List<Projeto> lista = projetos.Listar();
        List<Tarefa> tarefas = lista.SelectMany(p => p.Tarefas).ToList();
        int abertas = tarefas.Count(t => t.Status == "Aberta");
        int fechadas = tarefas.Count(t => t.Status == "Fechada");
        int canceladas = tarefas.Count(t => t.Status == "Cancelada");
        int totalConsiderado = abertas + fechadas;
        double percentual = totalConsiderado == 0 ? 0 : (double)fechadas / totalConsiderado * 100;

        Console.WriteLine($"Quantidade de projetos: {lista.Count}");
        Console.WriteLine($"Tarefas abertas: {abertas}");
        Console.WriteLine($"Tarefas fechadas: {fechadas}");
        Console.WriteLine($"Tarefas canceladas: {canceladas}");
        Console.WriteLine($"Percentual concluído (fechadas em relação a abertas + fechadas): {percentual:F2}%");
    }

    private static Projeto? SelecionarProjeto()
    {
        List<Projeto> lista = projetos.Listar();
        if (lista.Count == 0)
        {
            Console.WriteLine("Nenhum projeto cadastrado.");
            return null;
        }

        Console.WriteLine("Projetos cadastrados:");
        foreach (Projeto projeto in lista)
        {
            Console.WriteLine($"{projeto.Id} - {projeto.Nome}");
        }

        int id = LerInteiro("Código do projeto: ");
        Projeto? selecionado = projetos.Buscar(id);
        if (selecionado == null) Console.WriteLine("Projeto não encontrado.");
        return selecionado;
    }

    private static Tarefa? SelecionarTarefa(Projeto projeto)
    {
        if (projeto.Tarefas.Count == 0)
        {
            Console.WriteLine("O projeto não possui tarefas.");
            return null;
        }

        ExibirTarefas(projeto.Tarefas);
        int id = LerInteiro("Código da tarefa: ");
        Tarefa? tarefa = projeto.BuscarTarefa(id);
        if (tarefa == null) Console.WriteLine("Tarefa não encontrada.");
        return tarefa;
    }

    private static void ExibirTarefasPorStatus(Projeto projeto)
    {
        ExibirTarefas(projeto.TarefasPorStatus("Aberta"));
        ExibirTarefas(projeto.TarefasPorStatus("Fechada"));
        ExibirTarefas(projeto.TarefasPorStatus("Cancelada"));
    }

    private static void ExibirTarefas(List<Tarefa> tarefas)
    {
        if (tarefas.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa encontrada.");
            return;
        }

        foreach (Tarefa tarefa in tarefas)
        {
            string dataConclusao = tarefa.DataConclusao?.ToString("dd/MM/yyyy HH:mm") ?? "-";
            Console.WriteLine($"Código: {tarefa.Id} | {tarefa.Titulo} | Prioridade: {NomePrioridade(tarefa.Prioridade)} | Status: {tarefa.Status}");
            Console.WriteLine($"Descrição: {tarefa.Descricao} | Criação: {tarefa.DataCriacao:dd/MM/yyyy HH:mm} | Conclusão: {dataConclusao}");
        }
    }

    private static string LerStatus()
    {
        Console.WriteLine("1. Aberta");
        Console.WriteLine("2. Fechada");
        Console.WriteLine("3. Cancelada");
        int opcao = LerInteiro("Escolha o status: ");
        return opcao switch
        {
            1 => "Aberta",
            2 => "Fechada",
            3 => "Cancelada",
            _ => "Status inválido"
        };
    }

    private static int LerPrioridade()
    {
        int prioridade;
        do
        {
            prioridade = LerInteiro("Prioridade (1-alta, 2-média, 3-baixa): ");
            if (prioridade is < 1 or > 3) Console.WriteLine("Prioridade inválida.");
        } while (prioridade is < 1 or > 3);
        return prioridade;
    }

    private static string NomePrioridade(int prioridade)
    {
        return prioridade switch
        {
            1 => "Alta",
            2 => "Média",
            3 => "Baixa",
            _ => "Inválida"
        };
    }

    private static int LerInteiro(string mensagem)
    {
        int valor;
        while (true)
        {
            Console.Write(mensagem);
            if (int.TryParse(Console.ReadLine(), out valor)) return valor;
            Console.WriteLine("Digite um número válido.");
        }
    }

    private static string LerTexto(string mensagem)
    {
        string? texto;
        do
        {
            Console.Write(mensagem);
            texto = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(texto));
        return texto.Trim();
    }
}
