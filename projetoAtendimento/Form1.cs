namespace ProjetoAtendimento;

public partial class Form1 : Form
{
    private Senhas senhas;
    private Guiches guiches;

    public Form1()
    {
        InitializeComponent();
        senhas = new Senhas();
        guiches = new Guiches();
    }

    private void btnGerar_Click(object? sender, EventArgs e)
    {
        senhas.Gerar();
        AtualizarListaSenhas();
    }

    private void btnAdicionar_Click(object? sender, EventArgs e)
    {
        int quantidade = (int)nudQuantidade.Value;
        int primeiroId = guiches.ListaGuiches.Count + 1;

        for (int i = 0; i < quantidade; i++)
        {
            guiches.Adicionar(new Guiche(primeiroId + i));
        }

        AtualizarCampoGuiche();
        MessageBox.Show("Guichê(s) adicionado(s) com sucesso.", "Projeto Atendimento");
    }

    private void btnChamar_Click(object? sender, EventArgs e)
    {
        if (guiches.ListaGuiches.Count == 0)
        {
            MessageBox.Show("Adicione pelo menos um guichê.", "Projeto Atendimento");
            return;
        }

        int numeroGuiche = (int)nudGuiche.Value;

        if (numeroGuiche < 1 || numeroGuiche > guiches.ListaGuiches.Count)
        {
            MessageBox.Show("Informe um guichê cadastrado.", "Projeto Atendimento");
            return;
        }

        Guiche guiche = guiches.ListaGuiches[numeroGuiche - 1];

        if (!guiche.Chamar(senhas.FilaSenhas))
        {
            MessageBox.Show("Não há senhas aguardando atendimento.", "Projeto Atendimento");
            return;
        }

        AtualizarListaSenhas();
        AtualizarListaAtendimentos();
    }

    private void AtualizarCampoGuiche()
    {
        nudGuiche.Maximum = Math.Max(1, guiches.ListaGuiches.Count);
        if (nudGuiche.Value > nudGuiche.Maximum)
        {
            nudGuiche.Value = nudGuiche.Maximum;
        }
    }

    private void AtualizarListaSenhas()
    {
        lstSenhas.Items.Clear();

        foreach (Senha senha in senhas.FilaSenhas)
        {
            lstSenhas.Items.Add(senha.DadosParciais());
        }
    }

    private void AtualizarListaAtendimentos()
    {
        lstAtendimentos.Items.Clear();

        foreach (Guiche guiche in guiches.ListaGuiches)
        {
            foreach (Senha senha in guiche.Atendimentos)
            {
                lstAtendimentos.Items.Add("Guichê " + guiche.Id + " - " + senha.DadosCompletos());
            }
        }
    }
}
