namespace ProjetoAtendimento;

public class Guiche
{
    private int id;
    private Queue<Senha> atendimentos;

    public Guiche()
    {
        atendimentos = new Queue<Senha>();
        id = 0;
    }

    public Guiche(int id)
    {
        atendimentos = new Queue<Senha>();
        this.id = id;
    }

    public bool Chamar(Queue<Senha> filaSenhas)
    {
        if (filaSenhas.Count == 0)
        {
            return false;
        }

        Senha senha = filaSenhas.Dequeue();
        senha.RegistrarAtendimento();
        atendimentos.Enqueue(senha);
        return true;
    }

    public int Id => id;
    public Queue<Senha> Atendimentos => atendimentos;
}
