using ProjetoAgendaWFA.Models;

namespace ProjetoAgendaWFA;

public partial class FormPrincipal : Form
{
    private readonly Contatos contatos = new();

    public FormPrincipal()
    {
        InitializeComponent();
        AtualizarLista();
    }

    private void AtualizarLista(IEnumerable<Contato>? itens = null)
    {
        listaContatos.Items.Clear();
        foreach (Contato contato in itens ?? contatos.Agenda)
            listaContatos.Items.Add(contato);
        lblStatus.Text = $"Total de contatos: {listaContatos.Items.Count}";
    }

    private void Adicionar(object? sender, EventArgs e)
    {
        using FormContato formulario = new();
        if (formulario.ShowDialog(this) == DialogResult.OK && formulario.Contato is not null)
        {
            if (!contatos.adicionar(formulario.Contato))
                MessageBox.Show("Já existe um contato com este e-mail.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            AtualizarLista();
        }
    }

    private Contato? ContatoSelecionado()
    {
        return listaContatos.SelectedItem as Contato;
    }

    private void Pesquisar(object? sender, EventArgs e)
    {
        string texto = txtPesquisa.Text.Trim();
        if (texto.Length == 0)
        {
            AtualizarLista();
            return;
        }

        List<Contato> encontrados = contatos.Agenda
            .Where(c => c.nome.Contains(texto, StringComparison.OrdinalIgnoreCase)
                     || c.email.Contains(texto, StringComparison.OrdinalIgnoreCase))
            .ToList();
        AtualizarLista(encontrados);
    }

    private void Alterar(object? sender, EventArgs e)
    {
        Contato? selecionado = ContatoSelecionado();
        if (selecionado is null)
        {
            MessageBox.Show("Selecione um contato para alterar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using FormContato formulario = new(selecionado);
        if (formulario.ShowDialog(this) == DialogResult.OK && formulario.Contato is not null)
        {
            if (!contatos.alterar(formulario.Contato))
                MessageBox.Show("Não foi possível alterar o contato.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            AtualizarLista();
        }
    }

    private void Remover(object? sender, EventArgs e)
    {
        Contato? selecionado = ContatoSelecionado();
        if (selecionado is null)
        {
            MessageBox.Show("Selecione um contato para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (contatos.remover(selecionado))
            AtualizarLista();
    }

    private void Listar(object? sender, EventArgs e)
    {
        txtPesquisa.Clear();
        AtualizarLista();
    }

    private void Sair(object? sender, EventArgs e)
    {
        Close();
    }
}
