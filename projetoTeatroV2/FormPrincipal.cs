using System.Globalization;

namespace ProjetoTeatro;

public class FormPrincipal : Form
{
    private const int QuantidadeFileiras = 15;
    private const int QuantidadePoltronas = 40;

    private readonly EstadoPoltrona[,] mapa = new EstadoPoltrona[QuantidadeFileiras, QuantidadePoltronas];
    private readonly Button[,] botoesPoltronas = new Button[QuantidadeFileiras, QuantidadePoltronas];
    private Label labelFaturamento = null!;

    public FormPrincipal()
    {
        Text = "Controle de Teatro";
        StartPosition = FormStartPosition.CenterScreen;
        Width = 1400;
        Height = 750;
        MinimumSize = new Size(1100, 600);

        CriarInterface();
    }

    private void CriarInterface()
    {
        Label labelTitulo = new Label();
        labelTitulo.Text = "Mapa de poltronas";
        labelTitulo.Dock = DockStyle.Top;
        labelTitulo.Height = 40;
        labelTitulo.TextAlign = ContentAlignment.MiddleCenter;
        labelTitulo.Font = new Font("Arial", 14, FontStyle.Bold);

        Panel painelMapa = new Panel();
        painelMapa.Dock = DockStyle.Fill;
        painelMapa.AutoScroll = true;
        painelMapa.Padding = new Padding(10);

        TableLayoutPanel tabela = new TableLayoutPanel();
        tabela.RowCount = QuantidadeFileiras;
        tabela.ColumnCount = QuantidadePoltronas;
        tabela.AutoSize = true;
        tabela.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        tabela.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
        tabela.Dock = DockStyle.Top;

        for (int coluna = 0; coluna < QuantidadePoltronas; coluna++)
        {
            tabela.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32));
        }

        for (int fileira = 0; fileira < QuantidadeFileiras; fileira++)
        {
            tabela.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
        }

        CriarBotoesPoltronas(tabela);
        painelMapa.Controls.Add(tabela);

        Panel painelInferior = new Panel();
        painelInferior.Dock = DockStyle.Bottom;
        painelInferior.Height = 75;
        painelInferior.Padding = new Padding(10);

        Button botaoFaturamento = new Button();
        botaoFaturamento.Text = "Faturamento";
        botaoFaturamento.Width = 130;
        botaoFaturamento.Height = 35;
        botaoFaturamento.Location = new Point(10, 18);
        botaoFaturamento.Click += BotaoFaturamento_Click;

        labelFaturamento = new Label();
        labelFaturamento.Text = "Qtde de lugares ocupados: 0\nValor da bilheteria: R$ 0,00";
        labelFaturamento.AutoSize = true;
        labelFaturamento.Location = new Point(160, 14);
        labelFaturamento.Font = new Font("Arial", 10, FontStyle.Bold);

        painelInferior.Controls.Add(botaoFaturamento);
        painelInferior.Controls.Add(labelFaturamento);

        Controls.Add(painelMapa);
        Controls.Add(painelInferior);
        Controls.Add(labelTitulo);
    }

    private void CriarBotoesPoltronas(TableLayoutPanel tabela)
    {
        for (int fileira = 0; fileira < QuantidadeFileiras; fileira++)
        {
            for (int poltrona = 0; poltrona < QuantidadePoltronas; poltrona++)
            {
                mapa[fileira, poltrona] = EstadoPoltrona.Vaga;

                Button botao = new Button();
                botao.Text = (poltrona + 1).ToString();
                botao.Width = 30;
                botao.Height = 28;
                botao.Margin = new Padding(1);
                botao.Padding = new Padding(0);
                botao.BackColor = Color.LightGreen;
                botao.Tag = new int[] { fileira, poltrona };
                botao.Click += BotaoPoltrona_Click;

                botoesPoltronas[fileira, poltrona] = botao;
                tabela.Controls.Add(botao, poltrona, fileira);
            }
        }
    }

    private void BotaoPoltrona_Click(object? sender, EventArgs e)
    {
        if (sender is not Button botao || botao.Tag is not int[] coordenadas)
        {
            return;
        }

        int fileira = coordenadas[0];
        int poltrona = coordenadas[1];

        if (!CoordenadaValida(fileira, poltrona))
        {
            MessageBox.Show("A fileira ou a poltrona informada é inválida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (mapa[fileira, poltrona] != EstadoPoltrona.Vaga)
        {
            string estado = mapa[fileira, poltrona] == EstadoPoltrona.Inteira ? "inteira" : "meia entrada";
            MessageBox.Show(
                $"A poltrona {poltrona + 1} da fileira {fileira + 1} já está ocupada ({estado}).",
                "Poltrona ocupada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        DialogResult escolha = MessageBox.Show(
            $"A poltrona {poltrona + 1} da fileira {fileira + 1} está vaga.\n\n" +
            "Clique em Sim para reservar inteira.\n" +
            "Clique em Não para reservar meia entrada.",
            "Tipo de reserva",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);

        if (escolha == DialogResult.Yes)
        {
            mapa[fileira, poltrona] = EstadoPoltrona.Inteira;
            AtualizarBotao(fileira, poltrona);
        }
        else if (escolha == DialogResult.No)
        {
            mapa[fileira, poltrona] = EstadoPoltrona.Meia;
            AtualizarBotao(fileira, poltrona);
        }
    }

    private void AtualizarBotao(int fileira, int poltrona)
    {
        Button botao = botoesPoltronas[fileira, poltrona];

        if (mapa[fileira, poltrona] == EstadoPoltrona.Inteira)
        {
            botao.BackColor = Color.IndianRed;
            botao.ForeColor = Color.White;
        }
        else if (mapa[fileira, poltrona] == EstadoPoltrona.Meia)
        {
            botao.BackColor = Color.Gold;
            botao.ForeColor = Color.Black;
        }
    }

    private void BotaoFaturamento_Click(object? sender, EventArgs e)
    {
        int quantidadeOcupada = 0;
        decimal valorTotal = 0;

        for (int fileira = 0; fileira < QuantidadeFileiras; fileira++)
        {
            for (int poltrona = 0; poltrona < QuantidadePoltronas; poltrona++)
            {
                if (mapa[fileira, poltrona] == EstadoPoltrona.Inteira)
                {
                    quantidadeOcupada++;
                    valorTotal += ObterValorInteira(fileira);
                }
                else if (mapa[fileira, poltrona] == EstadoPoltrona.Meia)
                {
                    quantidadeOcupada++;
                    valorTotal += ObterValorInteira(fileira) / 2;
                }
            }
        }

        string valorFormatado = valorTotal.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
        labelFaturamento.Text =
            $"Qtde de lugares ocupados: {quantidadeOcupada}\n" +
            $"Valor da bilheteria: {valorFormatado}";
    }

    private decimal ObterValorInteira(int fileira)
    {
        if (fileira >= 0 && fileira <= 4)
        {
            return 50;
        }

        if (fileira >= 5 && fileira <= 9)
        {
            return 30;
        }

        if (fileira >= 10 && fileira <= 14)
        {
            return 15;
        }

        return 0;
    }

    private bool CoordenadaValida(int fileira, int poltrona)
    {
        return fileira >= 0 && fileira < QuantidadeFileiras &&
               poltrona >= 0 && poltrona < QuantidadePoltronas;
    }
}

public enum EstadoPoltrona
{
    Vaga,
    Inteira,
    Meia
}
