using ProjetoAgendaWFA.Models;

namespace ProjetoAgendaWFA;

public partial class FormContato : Form
{
    public Contato? Contato { get; private set; }

    public FormContato(Contato? contato = null)
    {
        InitializeComponent();
        Text = contato is null ? "Adicionar contato" : "Alterar contato";
        if (contato is not null)
        {
            PreencherCampos(contato);
            txtEmail.ReadOnly = true;
        }
    }

    private void PreencherCampos(Contato contato)
    {
        txtNome.Text = contato.nome;
        txtEmail.Text = contato.email;
        dtNascimento.Value = contato.dtNasc.ParaDateTime();
        Telefone? telefone = contato.telefones.FirstOrDefault();
        if (telefone is not null)
        {
            cbTipoTelefone.SelectedItem = telefone.tipo;
            txtNumeroTelefone.Text = telefone.numero;
            chkPrincipal.Checked = telefone.principal;
        }
    }

    private void Salvar(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtEmail.Text)
            || string.IsNullOrWhiteSpace(txtNumeroTelefone.Text))
        {
            MessageBox.Show("Preencha nome, e-mail e número de telefone.", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Data data = new(dtNascimento.Value.Day, dtNascimento.Value.Month, dtNascimento.Value.Year);
        Contato = new Contato(txtEmail.Text.Trim(), txtNome.Text.Trim(), data);
        Contato.adicionarTelefone(new Telefone(cbTipoTelefone.Text, txtNumeroTelefone.Text.Trim(), chkPrincipal.Checked));
        DialogResult = DialogResult.OK;
        Close();
    }
}
