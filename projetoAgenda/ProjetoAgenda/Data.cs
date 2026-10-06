namespace ProjetoAgenda;

public class Data
{
    private int dia;
    private int mes;
    private int ano;

    public Data()
    {
        setData(1, 1, 2000);
    }

    public Data(int dia, int mes, int ano)
    {
        setData(dia, mes, ano);
    }

    public int Dia => dia;
    public int Mes => mes;
    public int Ano => ano;

    public void setData(int dia, int mes, int ano)
    {
        _ = new DateTime(ano, mes, dia);
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
    }

    public override string ToString()
    {
        return $"{dia:00}/{mes:00}/{ano:0000}";
    }
}
