namespace ProjetoAtendimento;

public class Guiches
{
    private List<Guiche> listaGuiches;

    public Guiches()
    {
        listaGuiches = new List<Guiche>();
    }

    public void Adicionar(Guiche guiche)
    {
        listaGuiches.Add(guiche);
    }

    public List<Guiche> ListaGuiches => listaGuiches;
}
