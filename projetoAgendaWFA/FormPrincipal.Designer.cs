#nullable disable

namespace ProjetoAgendaWFA;

partial class FormPrincipal
{
    private System.ComponentModel.IContainer components = null;
    private Label titulo;
    private Label lblPesquisa;
    private TextBox txtPesquisa;
    private Button btnPesquisar;
    private ListBox listaContatos;
    private Button btnAdicionar;
    private Button btnAlterar;
    private Button btnRemover;
    private Button btnListar;
    private Button btnSair;
    private Label lblStatus;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        titulo = new Label();
        lblPesquisa = new Label();
        txtPesquisa = new TextBox();
        btnPesquisar = new Button();
        listaContatos = new ListBox();
        btnAdicionar = new Button();
        btnAlterar = new Button();
        btnRemover = new Button();
        btnListar = new Button();
        btnSair = new Button();
        lblStatus = new Label();
        SuspendLayout();

        titulo.AutoSize = true;
        titulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        titulo.Location = new Point(20, 18);
        titulo.Name = "titulo";
        titulo.Size = new Size(181, 30);
        titulo.Text = "Agenda de Contatos";

        lblPesquisa.AutoSize = true;
        lblPesquisa.Location = new Point(20, 67);
        lblPesquisa.Name = "lblPesquisa";
        lblPesquisa.Size = new Size(97, 15);
        lblPesquisa.Text = "Nome ou e-mail:";

        txtPesquisa.Location = new Point(125, 63);
        txtPesquisa.Name = "txtPesquisa";
        txtPesquisa.Size = new Size(250, 23);

        btnPesquisar.Location = new Point(385, 61);
        btnPesquisar.Name = "btnPesquisar";
        btnPesquisar.Size = new Size(85, 30);
        btnPesquisar.Text = "Pesquisar";
        btnPesquisar.UseVisualStyleBackColor = true;
        btnPesquisar.Click += Pesquisar;

        listaContatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        listaContatos.HorizontalScrollbar = true;
        listaContatos.Location = new Point(20, 105);
        listaContatos.Name = "listaContatos";
        listaContatos.Size = new Size(740, 229);

        btnAdicionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnAdicionar.Location = new Point(20, 365);
        btnAdicionar.Name = "btnAdicionar";
        btnAdicionar.Size = new Size(85, 30);
        btnAdicionar.Text = "Adicionar";
        btnAdicionar.UseVisualStyleBackColor = true;
        btnAdicionar.Click += Adicionar;

        btnAlterar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnAlterar.Location = new Point(120, 365);
        btnAlterar.Name = "btnAlterar";
        btnAlterar.Size = new Size(85, 30);
        btnAlterar.Text = "Alterar";
        btnAlterar.UseVisualStyleBackColor = true;
        btnAlterar.Click += Alterar;

        btnRemover.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnRemover.Location = new Point(220, 365);
        btnRemover.Name = "btnRemover";
        btnRemover.Size = new Size(85, 30);
        btnRemover.Text = "Remover";
        btnRemover.UseVisualStyleBackColor = true;
        btnRemover.Click += Remover;

        btnListar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnListar.Location = new Point(320, 365);
        btnListar.Name = "btnListar";
        btnListar.Size = new Size(85, 30);
        btnListar.Text = "Listar";
        btnListar.UseVisualStyleBackColor = true;
        btnListar.Click += Listar;

        btnSair.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnSair.Location = new Point(660, 365);
        btnSair.Name = "btnSair";
        btnSair.Size = new Size(85, 30);
        btnSair.Text = "Sair";
        btnSair.UseVisualStyleBackColor = true;
        btnSair.Click += Sair;

        lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(20, 405);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(118, 15);
        lblStatus.Text = "Total de contatos: 0";

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(780, 430);
        Controls.Add(lblStatus);
        Controls.Add(btnSair);
        Controls.Add(btnListar);
        Controls.Add(btnRemover);
        Controls.Add(btnAlterar);
        Controls.Add(btnAdicionar);
        Controls.Add(listaContatos);
        Controls.Add(btnPesquisar);
        Controls.Add(txtPesquisa);
        Controls.Add(lblPesquisa);
        Controls.Add(titulo);
        MinimumSize = new Size(650, 360);
        Name = "FormPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Agenda de Contatos";
        ResumeLayout(false);
        PerformLayout();
    }
}
