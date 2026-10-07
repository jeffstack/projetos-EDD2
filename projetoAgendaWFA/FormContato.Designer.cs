#nullable disable

namespace ProjetoAgendaWFA;

partial class FormContato
{
    private System.ComponentModel.IContainer components = null;
    private Label lblNome;
    private TextBox txtNome;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblNascimento;
    private DateTimePicker dtNascimento;
    private Label lblTipo;
    private ComboBox cbTipoTelefone;
    private Label lblNumero;
    private TextBox txtNumeroTelefone;
    private CheckBox chkPrincipal;
    private Button btnSalvar;
    private Button btnCancelar;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        lblNome = new Label();
        txtNome = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblNascimento = new Label();
        dtNascimento = new DateTimePicker();
        lblTipo = new Label();
        cbTipoTelefone = new ComboBox();
        lblNumero = new Label();
        txtNumeroTelefone = new TextBox();
        chkPrincipal = new CheckBox();
        btnSalvar = new Button();
        btnCancelar = new Button();
        SuspendLayout();

        lblNome.AutoSize = true;
        lblNome.Location = new Point(20, 23);
        lblNome.Name = "lblNome";
        lblNome.Size = new Size(39, 15);
        lblNome.Text = "Nome:";

        txtNome.Location = new Point(130, 17);
        txtNome.Name = "txtNome";
        txtNome.Size = new Size(250, 23);

        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(20, 61);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(43, 15);
        lblEmail.Text = "E-mail:";

        txtEmail.Location = new Point(130, 55);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(250, 23);

        lblNascimento.AutoSize = true;
        lblNascimento.Location = new Point(20, 99);
        lblNascimento.Name = "lblNascimento";
        lblNascimento.Size = new Size(73, 15);
        lblNascimento.Text = "Nascimento:";

        dtNascimento.Format = DateTimePickerFormat.Short;
        dtNascimento.Location = new Point(130, 93);
        dtNascimento.MaxDate = DateTime.Today;
        dtNascimento.Name = "dtNascimento";
        dtNascimento.Size = new Size(150, 23);
        dtNascimento.Value = new DateTime(2000, 1, 1);

        lblTipo.AutoSize = true;
        lblTipo.Location = new Point(20, 137);
        lblTipo.Name = "lblTipo";
        lblTipo.Size = new Size(88, 15);
        lblTipo.Text = "Tipo telefone:";

        cbTipoTelefone.DropDownStyle = ComboBoxStyle.DropDownList;
        cbTipoTelefone.FormattingEnabled = true;
        cbTipoTelefone.Items.AddRange(new object[] { "Celular", "Residencial", "Comercial" });
        cbTipoTelefone.Location = new Point(130, 131);
        cbTipoTelefone.Name = "cbTipoTelefone";
        cbTipoTelefone.Size = new Size(120, 23);
        cbTipoTelefone.SelectedIndex = 0;

        lblNumero.AutoSize = true;
        lblNumero.Location = new Point(20, 175);
        lblNumero.Name = "lblNumero";
        lblNumero.Size = new Size(51, 15);
        lblNumero.Text = "Número:";

        txtNumeroTelefone.Location = new Point(130, 169);
        txtNumeroTelefone.Name = "txtNumeroTelefone";
        txtNumeroTelefone.Size = new Size(250, 23);

        chkPrincipal.AutoSize = true;
        chkPrincipal.Location = new Point(130, 205);
        chkPrincipal.Name = "chkPrincipal";
        chkPrincipal.Size = new Size(130, 19);
        chkPrincipal.Text = "Telefone principal";
        chkPrincipal.UseVisualStyleBackColor = true;

        btnSalvar.Location = new Point(220, 245);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(75, 30);
        btnSalvar.Text = "Salvar";
        btnSalvar.UseVisualStyleBackColor = true;
        btnSalvar.Click += Salvar;

        btnCancelar.DialogResult = DialogResult.Cancel;
        btnCancelar.Location = new Point(305, 245);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(75, 30);
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;

        AcceptButton = btnSalvar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancelar;
        ClientSize = new Size(420, 300);
        Controls.Add(btnCancelar);
        Controls.Add(btnSalvar);
        Controls.Add(chkPrincipal);
        Controls.Add(txtNumeroTelefone);
        Controls.Add(lblNumero);
        Controls.Add(cbTipoTelefone);
        Controls.Add(lblTipo);
        Controls.Add(dtNascimento);
        Controls.Add(lblNascimento);
        Controls.Add(txtEmail);
        Controls.Add(lblEmail);
        Controls.Add(txtNome);
        Controls.Add(lblNome);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FormContato";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Contato";
        ResumeLayout(false);
        PerformLayout();
    }
}
