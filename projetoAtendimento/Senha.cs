namespace ProjetoAtendimento;

public class Senha
{
    private int id;
    private DateTime dataGerac;
    private DateTime horaGerac;
    private DateTime dataAtend;
    private DateTime horaAtend;

    public Senha(int id)
    {
        this.id = id;
        dataGerac = DateTime.Now.Date;
        horaGerac = DateTime.Now;
    }

    public void RegistrarAtendimento()
    {
        dataAtend = DateTime.Now.Date;
        horaAtend = DateTime.Now;
    }

    public string DadosParciais()
    {
        return id + " - " + dataGerac.ToShortDateString() + " - " + horaGerac.ToLongTimeString();
    }

    public string DadosCompletos()
    {
        return id + " - " + dataGerac.ToShortDateString() + " - " + horaGerac.ToLongTimeString()
            + " - " + dataAtend.ToShortDateString() + " - " + horaAtend.ToLongTimeString();
    }

    public int Id => id;
}
