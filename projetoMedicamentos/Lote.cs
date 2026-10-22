namespace ProjetoMedicamentos;

public class Lote
{
    private int id;
    private int qtde;
    private DateTime venc;

    public Lote()
    {
    }

    public Lote(int id, int qtde, DateTime venc)
    {
        this.id = id;
        this.qtde = qtde;
        this.venc = venc;
    }

    public int getId()
    {
        return id;
    }

    public int getQtde()
    {
        return qtde;
    }

    public DateTime getVenc()
    {
        return venc;
    }

    public void retirar(int quantidade)
    {
        qtde -= quantidade;
    }

    public override string ToString()
    {
        return id + "-" + qtde + "-" + venc.ToString("dd/MM/yyyy");
    }

    public string toString()
    {
        return ToString();
    }
}
