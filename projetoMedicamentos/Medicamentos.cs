namespace ProjetoMedicamentos;

public class Medicamentos
{
    private List<Medicamento> listaMedicamentos;

    public Medicamentos()
    {
        listaMedicamentos = new List<Medicamento>();
    }

    public void adicionar(Medicamento medicamento)
    {
        listaMedicamentos.Add(medicamento);
    }

    public bool deletar(Medicamento medicamento)
    {
        Medicamento medicamentoEncontrado = pesquisar(medicamento);

        if (medicamentoEncontrado.getId() == 0 && medicamento.getId() != 0)
        {
            return false;
        }

        if (medicamentoEncontrado.qtdeDisponivel() == 0)
        {
            return listaMedicamentos.Remove(medicamentoEncontrado);
        }

        return false;
    }

    public Medicamento pesquisar(Medicamento medicamento)
    {
        foreach (Medicamento item in listaMedicamentos)
        {
            if (item.Equals(medicamento))
            {
                return item;
            }
        }

        return new Medicamento();
    }

    public List<Medicamento> getListaMedicamentos()
    {
        return listaMedicamentos;
    }
}
