using ProjetoBiblioteca;

Livros livros = new Livros();
int opcao;

do
{
    ExibirMenu();
    opcao = LerInteiro("Escolha uma opção: ");
    Console.WriteLine();

    switch (opcao)
    {
        case 1:
            AdicionarLivro();
            break;
        case 2:
            PesquisarLivro(false);
            break;
        case 3:
            PesquisarLivro(true);
            break;
        case 4:
            AdicionarExemplar();
            break;
        case 5:
            RegistrarEmprestimo();
            break;
        case 6:
            RegistrarDevolucao();
            break;
        case 0:
            Console.WriteLine("Programa encerrado.");
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    if (opcao != 0)
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
        Console.Clear();
    }
} while (opcao != 0);

void ExibirMenu()
{
    Console.WriteLine("========================================");
    Console.WriteLine("          PROJETO BIBLIOTECA");
    Console.WriteLine("========================================");
    Console.WriteLine("0. Sair");
    Console.WriteLine("1. Adicionar livro");
    Console.WriteLine("2. Pesquisar livro (sintético)");
    Console.WriteLine("3. Pesquisar livro (analítico)");
    Console.WriteLine("4. Adicionar exemplar");
    Console.WriteLine("5. Registrar empréstimo");
    Console.WriteLine("6. Registrar devolução");
    Console.WriteLine("========================================");
}

void AdicionarLivro()
{
    Console.WriteLine("ADICIONAR LIVRO");
    int isbn = LerInteiro("ISBN: ");

    if (livros.pesquisar(new Livro(isbn)) != null)
    {
        Console.WriteLine("Já existe um livro com este ISBN.");
        return;
    }

    string titulo = LerTexto("Título: ");
    string autor = LerTexto("Autor: ");
    string editora = LerTexto("Editora: ");

    livros.adicionar(new Livro(isbn, titulo, autor, editora));
    Console.WriteLine("Livro adicionado com sucesso.");
}

void PesquisarLivro(bool analitico)
{
    Console.WriteLine(analitico ? "PESQUISAR LIVRO (ANALÍTICO)" : "PESQUISAR LIVRO (SINTÉTICO)");
    int isbn = LerInteiro("ISBN: ");
    Livro? livro = livros.pesquisar(new Livro(isbn));

    if (livro == null)
    {
        Console.WriteLine("Livro não encontrado.");
        return;
    }

    ExibirResumo(livro);

    if (analitico)
    {
        Console.WriteLine("\nDetalhes dos exemplares:");
        if (livro.Exemplares.Count == 0)
        {
            Console.WriteLine("Nenhum exemplar cadastrado.");
        }

        foreach (Exemplar exemplar in livro.Exemplares)
        {
            Console.WriteLine($"- Tombo: {exemplar.Tombo} | Disponível: {(exemplar.disponivel() ? "Sim" : "Não")} | Empréstimos: {exemplar.qtdeEmprestimos()}");
            foreach (Emprestimo emprestimo in exemplar.Emprestimos)
            {
                string devolucao = emprestimo.DtDevolucao == DateTime.MinValue
                    ? "Em aberto"
                    : emprestimo.DtDevolucao.ToString("dd/MM/yyyy HH:mm");
                Console.WriteLine($"  Empréstimo: {emprestimo.DtEmprestimo:dd/MM/yyyy HH:mm} | Devolução: {devolucao}");
            }
        }
    }
}

void ExibirResumo(Livro livro)
{
    Console.WriteLine($"\nISBN: {livro.Isbn}");
    Console.WriteLine($"Título: {livro.Titulo}");
    Console.WriteLine($"Autor: {livro.Autor}");
    Console.WriteLine($"Editora: {livro.Editora}");
    Console.WriteLine($"Total de exemplares: {livro.qtdeExemplares()}");
    Console.WriteLine($"Exemplares disponíveis: {livro.qtdeDisponiveis()}");
    Console.WriteLine($"Quantidade de empréstimos: {livro.qtdeEmprestimos()}");
    Console.WriteLine($"Percentual de disponibilidade: {livro.percDisponibilidade():F2}%");
}

void AdicionarExemplar()
{
    Console.WriteLine("ADICIONAR EXEMPLAR");
    int isbn = LerInteiro("ISBN do livro: ");
    Livro? livro = livros.pesquisar(new Livro(isbn));

    if (livro == null)
    {
        Console.WriteLine("Livro não encontrado.");
        return;
    }

    int tombo = LerInteiro("Número do tombo: ");
    bool tomboExiste = livros.Acervo.Any(l => l.Exemplares.Any(e => e.Tombo == tombo));

    if (tomboExiste)
    {
        Console.WriteLine("Já existe um exemplar com este tombo.");
        return;
    }

    livro.adicionarExemplar(new Exemplar(tombo));
    Console.WriteLine("Exemplar adicionado com sucesso.");
}

void RegistrarEmprestimo()
{
    Console.WriteLine("REGISTRAR EMPRÉSTIMO");
    Exemplar? exemplar = LocalizarExemplar();

    if (exemplar == null)
    {
        return;
    }

    if (exemplar.emprestar())
    {
        Console.WriteLine("Empréstimo registrado com sucesso.");
    }
    else
    {
        Console.WriteLine("O exemplar já está emprestado.");
    }
}

void RegistrarDevolucao()
{
    Console.WriteLine("REGISTRAR DEVOLUÇÃO");
    Exemplar? exemplar = LocalizarExemplar();

    if (exemplar == null)
    {
        return;
    }

    if (exemplar.devolver())
    {
        Console.WriteLine("Devolução registrada com sucesso.");
    }
    else
    {
        Console.WriteLine("O exemplar não está emprestado.");
    }
}

Exemplar? LocalizarExemplar()
{
    int isbn = LerInteiro("ISBN do livro: ");
    Livro? livro = livros.pesquisar(new Livro(isbn));

    if (livro == null)
    {
        Console.WriteLine("Livro não encontrado.");
        return null;
    }

    int tombo = LerInteiro("Número do tombo: ");
    Exemplar? exemplar = livro.Exemplares.FirstOrDefault(e => e.Tombo == tombo);

    if (exemplar == null)
    {
        Console.WriteLine("Exemplar não encontrado.");
    }

    return exemplar;
}

int LerInteiro(string mensagem)
{
    int valor;
    Console.Write(mensagem);

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

    while (string.IsNullOrWhiteSpace(texto))
    {
        Console.Write("O campo é obrigatório. Digite novamente: ");
        texto = Console.ReadLine();
    }

    return texto.Trim();
}
