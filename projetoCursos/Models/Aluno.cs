namespace ProjetoCursos.Models
{
    public class Aluno
    {
        private readonly Disciplina[] disciplinas = new Disciplina[6];

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Curso Curso { get; private set; }

        public Aluno(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public bool PodeMatricular(Curso curso)
        {
            if (curso == null)
            {
                return false;
            }

            if (Curso != null && Curso.Id != curso.Id)
            {
                return false;
            }

            return QuantidadeDisciplinas < disciplinas.Length;
        }

        public bool AdicionarDisciplina(Disciplina disciplina)
        {
            if (disciplina == null || QuantidadeDisciplinas >= disciplinas.Length)
            {
                return false;
            }

            if (EstaInscrito(disciplina))
            {
                return false;
            }

            if (disciplina.Curso == null || !PodeMatricular(disciplina.Curso))
            {
                return false;
            }

            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] == null)
                {
                    disciplinas[i] = disciplina;
                    Curso = disciplina.Curso;
                    return true;
                }
            }

            return false;
        }

        public bool RemoverDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null && disciplinas[i].Id == disciplina.Id)
                {
                    disciplinas[i] = null;

                    if (QuantidadeDisciplinas == 0)
                    {
                        Curso = null;
                    }

                    return true;
                }
            }

            return false;
        }

        public bool EstaInscrito(Disciplina disciplina)
        {
            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null && disciplinas[i].Id == disciplina.Id)
                {
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

