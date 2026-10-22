namespace ProjetoMedicamentos;

public class Medicamento
{
    private int id;
    private string nome = "";
    private string laboratorio = "";
    private Queue<Lote> lotes = new Queue<Lote>();

    public Medicamento()
    {
    }

    public Medicamento(int id, string nome, string laboratorio)
    {
        this.id = id;
        this.nome = nome;
        this.laboratorio = laboratorio;
    }

    public int getId()
    {
        return id;
    }

    public int qtdeDisponivel()
    {
        int total = 0;

        foreach (Lote lote in lotes)
        {
            total += lote.getQtde();
        }

        return total;
    }

    public void comprar(Lote lote)
    {
        lotes.Enqueue(lote);
    }

    public bool vender(int qtde)
    {
        if (qtde <= 0 || qtdeDisponivel() < qtde)
        {
            return false;
        }

        int restante = qtde;

        while (restante > 0)
        {
            Lote lote = lotes.Peek();
            int retirada = Math.Min(restante, lote.getQtde());
            lote.retirar(retirada);
            restante -= retirada;

            if (lote.getQtde() == 0)
            {
                lotes.Dequeue();
            }
        }

        return true;
    }

    public string dadosAnaliticos()
    {
        string texto = toString() + Environment.NewLine;
        texto += "Lotes:" + Environment.NewLine;

        foreach (Lote lote in lotes)
        {
            texto += lote.toString() + Environment.NewLine;
        }

        return texto;
    }

    public override string ToString()
    {
        return id + "-" + nome + "-" + laboratorio + "-" + qtdeDisponivel();
    }

    public string toString()
    {
        return ToString();
    }

    public override bool Equals(object? obj)
    {
        if (obj is Medicamento medicamento)
        {
            return id == medicamento.id;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }
}
