using ProjetoMedicamentos;

Medicamentos medicamentos = new Medicamentos();
int opcao;

do
{
    Console.Clear();
    Console.WriteLine("PROJETO MEDICAMENTOS");
    Console.WriteLine("--------------------");
    Console.WriteLine("0. Finalizar processo");
    Console.WriteLine("1. Cadastrar medicamento");
    Console.WriteLine("2. Consultar medicamento (sintético)");
    Console.WriteLine("3. Consultar medicamento (analítico)");
    Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
    Console.WriteLine("5. Vender medicamento");
    Console.WriteLine("6. Listar medicamentos");
    Console.Write("Escolha uma opção: ");
    opcao = LerInteiro();
    Console.WriteLine();

    switch (opcao)
    {
        case 1:
            CadastrarMedicamento(medicamentos);
            break;
        case 2:
            ConsultarMedicamento(medicamentos, false);
            break;
        case 3:
            ConsultarMedicamento(medicamentos, true);
            break;
        case 4:
            ComprarMedicamento(medicamentos);
            break;
        case 5:
            VenderMedicamento(medicamentos);
            break;
        case 6:
            ListarMedicamentos(medicamentos);
            break;
        case 0:
            Console.WriteLine("Processo finalizado.");
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    if (opcao != 0)
    {
        Console.WriteLine();
        Console.WriteLine("Pressione ENTER para continuar.");
        Console.ReadLine();
    }
} while (opcao != 0);

static void CadastrarMedicamento(Medicamentos medicamentos)
{
    Console.WriteLine("CADASTRO DE MEDICAMENTO");
    Console.Write("Id: ");
    int id = LerInteiro();
    Console.Write("Nome: ");
    string nome = Console.ReadLine() ?? "";
    Console.Write("Laboratório: ");
    string laboratorio = Console.ReadLine() ?? "";

    medicamentos.adicionar(new Medicamento(id, nome, laboratorio));
    Console.WriteLine("Medicamento cadastrado.");
}

static void ConsultarMedicamento(Medicamentos medicamentos, bool analitico)
{
    Console.Write("Informe o id do medicamento: ");
    int id = LerInteiro();
    Medicamento medicamento = medicamentos.pesquisar(new Medicamento(id, "", ""));

    if (medicamento.getId() == 0)
    {
        Console.WriteLine("Medicamento não encontrado.");
        return;
    }

    Console.WriteLine(analitico ? medicamento.dadosAnaliticos() : medicamento.toString());
}

static void ComprarMedicamento(Medicamentos medicamentos)
{
    Console.Write("Informe o id do medicamento: ");
    int id = LerInteiro();
    Medicamento medicamento = medicamentos.pesquisar(new Medicamento(id, "", ""));

    if (medicamento.getId() == 0)
    {
        Console.WriteLine("Medicamento não encontrado.");
        return;
    }

    Console.Write("Id do lote: ");
    int idLote = LerInteiro();
    Console.Write("Quantidade: ");
    int quantidade = LerInteiro();
    Console.Write("Data de vencimento (dd/MM/yyyy): ");
    DateTime vencimento = LerData();

    medicamento.comprar(new Lote(idLote, quantidade, vencimento));
    Console.WriteLine("Lote cadastrado.");
}

static void VenderMedicamento(Medicamentos medicamentos)
{
    Console.Write("Informe o id do medicamento: ");
    int id = LerInteiro();
    Medicamento medicamento = medicamentos.pesquisar(new Medicamento(id, "", ""));

    if (medicamento.getId() == 0)
    {
        Console.WriteLine("Medicamento não encontrado.");
        return;
    }

    Console.Write("Quantidade para venda: ");
    int quantidade = LerInteiro();

    if (medicamento.vender(quantidade))
    {
        Console.WriteLine("Venda realizada.");
    }
    else
    {
        Console.WriteLine("Quantidade indisponível para venda.");
    }
}

static void ListarMedicamentos(Medicamentos medicamentos)
{
    Console.WriteLine("MEDICAMENTOS CADASTRADOS");

    foreach (Medicamento medicamento in medicamentos.getListaMedicamentos())
    {
        Console.WriteLine(medicamento.toString());
    }
}

static int LerInteiro()
{
    int valor;

    while (!int.TryParse(Console.ReadLine(), out valor))
    {
        Console.Write("Digite um número válido: ");
    }

    return valor;
}

static DateTime LerData()
{
    DateTime data;

    while (!DateTime.TryParse(Console.ReadLine(), out data))
    {
        Console.Write("Digite uma data válida (dd/MM/yyyy): ");
    }

    return data;
}
