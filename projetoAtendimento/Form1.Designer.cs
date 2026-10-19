namespace ProjetoAtendimento;

partial class Form1
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Button btnGerar = null!;
    private Label lblQuantidade = null!;
    private NumericUpDown nudQuantidade = null!;
    private Button btnAdicionar = null!;
    private Label lblGuiche = null!;
    private NumericUpDown nudGuiche = null!;
    private Button btnChamar = null!;
    private Label lblSenhas = null!;
    private ListBox lstSenhas = null!;
    private Label lblAtendimentos = null!;
    private ListBox lstAtendimentos = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        btnGerar = new Button();
        lblQuantidade = new Label();
        nudQuantidade = new NumericUpDown();
        btnAdicionar = new Button();
        lblGuiche = new Label();
        nudGuiche = new NumericUpDown();
        btnChamar = new Button();
        lblSenhas = new Label();
        lstSenhas = new ListBox();
        lblAtendimentos = new Label();
        lstAtendimentos = new ListBox();
        ((System.ComponentModel.ISupportInitialize)nudQuantidade).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudGuiche).BeginInit();
        SuspendLayout();
        // lblTitulo
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.Location = new Point(24, 20);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(222, 30);
        lblTitulo.Text = "Projeto Atendimento";
        // btnGerar
        btnGerar.Location = new Point(24, 75);
        btnGerar.Name = "btnGerar";
        btnGerar.Size = new Size(120, 35);
        btnGerar.Text = "Gerar senha";
        btnGerar.UseVisualStyleBackColor = true;
        btnGerar.Click += btnGerar_Click;
        // lblQuantidade
        lblQuantidade.AutoSize = true;
        lblQuantidade.Location = new Point(170, 58);
        lblQuantidade.Name = "lblQuantidade";
        lblQuantidade.Text = "Quantidade de guichês:";
        // nudQuantidade
        nudQuantidade.Location = new Point(170, 80);
        nudQuantidade.Minimum = 1;
        nudQuantidade.Maximum = 50;
        nudQuantidade.Value = 1;
        nudQuantidade.Name = "nudQuantidade";
        nudQuantidade.Size = new Size(70, 23);
        // btnAdicionar
        btnAdicionar.Location = new Point(250, 80);
        btnAdicionar.Name = "btnAdicionar";
        btnAdicionar.Size = new Size(145, 35);
        btnAdicionar.Text = "Adicionar guichê";
        btnAdicionar.UseVisualStyleBackColor = true;
        btnAdicionar.Click += btnAdicionar_Click;
        // lblGuiche
        lblGuiche.AutoSize = true;
        lblGuiche.Location = new Point(425, 58);
        lblGuiche.Name = "lblGuiche";
        lblGuiche.Text = "Guichê:";
        // nudGuiche
        nudGuiche.Location = new Point(425, 80);
        nudGuiche.Minimum = 1;
        nudGuiche.Maximum = 1;
        nudGuiche.Value = 1;
        nudGuiche.Name = "nudGuiche";
        nudGuiche.Size = new Size(70, 23);
        // btnChamar
        btnChamar.Location = new Point(515, 80);
        btnChamar.Name = "btnChamar";
        btnChamar.Size = new Size(120, 35);
        btnChamar.Text = "Chamar";
        btnChamar.UseVisualStyleBackColor = true;
        btnChamar.Click += btnChamar_Click;
        // lblSenhas
        lblSenhas.AutoSize = true;
        lblSenhas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblSenhas.Location = new Point(24, 140);
        lblSenhas.Text = "Senhas aguardando atendimento";
        // lstSenhas
        lstSenhas.FormattingEnabled = true;
        lstSenhas.ItemHeight = 15;
        lstSenhas.Location = new Point(24, 170);
        lstSenhas.Name = "lstSenhas";
        lstSenhas.Size = new Size(390, 244);
        // lblAtendimentos
        lblAtendimentos.AutoSize = true;
        lblAtendimentos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblAtendimentos.Location = new Point(440, 140);
        lblAtendimentos.Text = "Atendimentos realizados";
        // lstAtendimentos
        lstAtendimentos.FormattingEnabled = true;
        lstAtendimentos.HorizontalScrollbar = true;
        lstAtendimentos.ItemHeight = 15;
        lstAtendimentos.Location = new Point(440, 170);
        lstAtendimentos.Name = "lstAtendimentos";
        lstAtendimentos.Size = new Size(390, 244);
        // Form1
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(854, 445);
        Controls.Add(lstAtendimentos);
        Controls.Add(lblAtendimentos);
        Controls.Add(lstSenhas);
        Controls.Add(lblSenhas);
        Controls.Add(btnChamar);
        Controls.Add(nudGuiche);
        Controls.Add(lblGuiche);
        Controls.Add(btnAdicionar);
        Controls.Add(nudQuantidade);
        Controls.Add(lblQuantidade);
        Controls.Add(btnGerar);
        Controls.Add(lblTitulo);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Projeto Atendimento";
        ((System.ComponentModel.ISupportInitialize)nudQuantidade).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudGuiche).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
