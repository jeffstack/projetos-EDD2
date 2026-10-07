namespace ProjetoAgendaWFA.Models;

public class Data
{
    private int dia;
    private int mes;
    private int ano;

    public Data()
    {
    }

    public Data(int dia, int mes, int ano)
    {
        setData(dia, mes, ano);
    }

    public void setData(int dia, int mes, int ano)
    {
        DateTime data = new(ano, mes, dia);
        this.dia = data.Day;
        this.mes = data.Month;
        this.ano = data.Year;
    }

    public DateTime ParaDateTime()
    {
        return new DateTime(ano, mes, dia);
    }

    public override string ToString()
    {
        return $"{dia:00}/{mes:00}/{ano:0000}";
    }
}
