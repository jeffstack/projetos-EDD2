namespace ProjetoAtendimento;

public class Senhas
{
    private int proximoAtendimento;
    private Queue<Senha> filaSenhas;

    public Senhas()
    {
        filaSenhas = new Queue<Senha>();
        proximoAtendimento = 1;
    }

    public void Gerar()
    {
        filaSenhas.Enqueue(new Senha(proximoAtendimento));
        proximoAtendimento++;
    }

    public Queue<Senha> FilaSenhas => filaSenhas;
}
