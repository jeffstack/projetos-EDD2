namespace ProjetoAgenda;

public class Program
{
    private static readonly Contatos contatos = new();

    public static void Main()
    {
        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("===== PROJETO AGENDA =====");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar contato");
            Console.WriteLine("2. Pesquisar contato");
            Console.WriteLine("3. Alterar contato");
            Console.WriteLine("4. Remover contato");
            Console.WriteLine("5. Listar contatos");
            Console.Write("Escolha uma opção: ");
            opcao = LerInteiro();
            Console.WriteLine();

            switch (opcao)
            {
                case 1:
                    AdicionarContato();
                    break;
                case 2:
                    PesquisarContato();
                    break;
                case 3:
                    AlterarContato();
                    break;
                case 4:
                    RemoverContato();
                    break;
                case 5:
                    ListarContatos();
                    break;
                case 0:
                    Console.WriteLine("Programa encerrado.");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    Pausar();
                    break;
            }
        } while (opcao != 0);
    }

    private static void AdicionarContato()
    {
        Console.WriteLine("--- Adicionar contato ---");
        Contato contato = LerDadosContato();

        if (contatos.adicionar(contato))
        {
            Console.WriteLine("Contato adicionado com sucesso.");
        }
        else
        {
            Console.WriteLine("Já existe um contato com este e-mail.");
        }

        Pausar();
    }

    private static void PesquisarContato()
    {
        Console.WriteLine("--- Pesquisar contato ---");
        string email = LerTexto("E-mail: ");
        Contato? contato = contatos.pesquisar(new Contato(email, "", new Data()));

        Console.WriteLine(contato == null ? "Contato não encontrado." : contato);
        Pausar();
    }

    private static void AlterarContato()
    {
        Console.WriteLine("--- Alterar contato ---");
        string email = LerTexto("E-mail do contato: ");
        Contato? contato = contatos.pesquisar(new Contato(email, "", new Data()));

        if (contato == null)
        {
            Console.WriteLine("Contato não encontrado.");
            Pausar();
            return;
        }

        Contato novosDados = LerDadosContato();
        contato.Email = novosDados.Email;
        contato.Nome = novosDados.Nome;
        contato.DtNasc = novosDados.DtNasc;
        contato.Telefones = novosDados.Telefones;
        contatos.alterar(contato);
        Console.WriteLine("Contato alterado com sucesso.");
        Pausar();
    }

    private static void RemoverContato()
    {
        Console.WriteLine("--- Remover contato ---");
        string email = LerTexto("E-mail do contato: ");
        Contato? contato = contatos.pesquisar(new Contato(email, "", new Data()));

        if (contato != null && contatos.remover(contato))
        {
            Console.WriteLine("Contato removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }

        Pausar();
    }

    private static void ListarContatos()
    {
        Console.WriteLine("--- Lista de contatos ---");

        if (contatos.Agenda.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
        }
        else
        {
            foreach (Contato contato in contatos.Agenda)
            {
                Console.WriteLine(contato);
            }
        }

        Pausar();
    }

    private static Contato LerDadosContato()
    {
        string nome = LerTexto("Nome: ");
        string email = LerTexto("E-mail: ");
        Data nascimento = LerData();
        Contato contato = new(email, nome, nascimento);

        string adicionar;
        do
        {
            adicionar = LerTexto("Adicionar telefone? (s/n): ").ToLower();
            if (adicionar == "s")
            {
                string tipo = LerTexto("Tipo do telefone: ");
                string numero = LerTexto("Número: ");
                bool principal = contato.Telefones.Count == 0 ||
                    LerTexto("É o telefone principal? (s/n): ").ToLower() == "s";
                contato.adicionarTelefone(new Telefone(tipo, numero, principal));
            }
        } while (adicionar != "n");

        return contato;
    }

    private static Data LerData()
    {
        while (true)
        {
            Console.Write("Data de nascimento (dd/mm/aaaa): ");
            string entrada = Console.ReadLine() ?? "";

            if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime data))
            {
                return new Data(data.Day, data.Month, data.Year);
            }

            Console.WriteLine("Data inválida.");
        }
    }

    private static string LerTexto(string mensagem)
    {
        Console.Write(mensagem);
        return (Console.ReadLine() ?? "").Trim();
    }

    private static int LerInteiro()
    {
        return int.TryParse(Console.ReadLine(), out int valor) ? valor : -1;
    }

    private static void Pausar()
    {
        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para continuar...");
        Console.ReadLine();
    }
}
