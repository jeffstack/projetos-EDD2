namespace ProjetoCursos.Models
{
    public class Curso
    {
        private readonly Disciplina[] disciplinas = new Disciplina[12];

        public int Id { get; private set; }
        public string Descricao { get; private set; }

        public Curso(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            if (disciplina == null || QuantidadeDisciplinas >= disciplinas.Length)
            {
                return false;
            }

            if (PesquisarDisciplina(disciplina) != null || disciplina.Curso != null)
            {
                return false;
            }

            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] == null)
                {
                    disciplinas[i] = disciplina;
                    disciplina.DefinirCurso(this);
                    return true;
                }
            }

            return false;
        }

        public Disciplina PesquisarDisciplina(Disciplina disciplina)
        {
            if (disciplina == null)
            {
                return null;
            }

            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null && disciplinas[i].Id == disciplina.Id)
                {
                    return disciplinas[i];
                }
            }

            return null;
        }

        public bool RemoverDisciplina(Disciplina disciplina)
        {
            if (disciplina == null)
            {
                return false;
            }

            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null && disciplinas[i].Id == disciplina.Id)
                {
                    if (disciplinas[i].QuantidadeAlunos > 0)
                    {
                        return false;
                    }

                    disciplinas[i].DefinirCurso(null);
                    disciplinas[i] = null;
                    return true;
                }
            }

            return false;
        }

        public int QuantidadeDisciplinas
        {
            get
            {
                int quantidade = 0;

                for (int i = 0; i < disciplinas.Length; i++)
                {
                    if (disciplinas[i] != null)
                    {
                        quantidade++;
                    }
                }

                return quantidade;
            }
        }

        public Disciplina[] ObterDisciplinas()
        {
            Disciplina[] resultado = new Disciplina[QuantidadeDisciplinas];
            int posicao = 0;

            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null)
                {
                    resultado[posicao] = disciplinas[i];
                    posicao++;
                }
            }

            return resultado;
        }
    }
}

