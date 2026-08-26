namespace ProjetoCursos.Models
{
    public class Disciplina
    {
        private readonly Aluno[] alunos = new Aluno[15];

        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public Curso Curso { get; private set; }

        public Disciplina(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public bool MatricularAluno(Aluno aluno)
        {
            if (aluno == null || QuantidadeAlunos >= alunos.Length)
            {
                return false;
            }

            if (PesquisarAluno(aluno) != null)
            {
                return false;
            }

            if (!aluno.PodeMatricular(Curso))
            {
                return false;
            }

            if (!aluno.AdicionarDisciplina(this))
            {
                return false;
            }

            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] == null)
                {
                    alunos[i] = aluno;
                    return true;
                }
            }

            aluno.RemoverDisciplina(this);
            return false;
        }

        public bool DesmatricularAluno(Aluno aluno)
        {
            if (aluno == null)
            {
                return false;
            }

            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null && alunos[i].Id == aluno.Id)
                {
                    alunos[i] = null;
                    aluno.RemoverDisciplina(this);
                    return true;
                }
            }

            return false;
        }

        public Aluno PesquisarAluno(Aluno aluno)
        {
            if (aluno == null)
            {
                return null;
            }

            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null && alunos[i].Id == aluno.Id)
                {
                    return alunos[i];
                }
            }

            return null;
        }

        public int QuantidadeAlunos
        {
            get
            {
                int quantidade = 0;

                for (int i = 0; i < alunos.Length; i++)
                {
                    if (alunos[i] != null)
                    {
                        quantidade++;
                    }
                }

                return quantidade;
            }
        }

        public Aluno[] ObterAlunos()
        {
            Aluno[] resultado = new Aluno[QuantidadeAlunos];
            int posicao = 0;

            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] != null)
                {
                    resultado[posicao] = alunos[i];
                    posicao++;
                }
            }

            return resultado;
        }

        internal void DefinirCurso(Curso curso)
        {
            Curso = curso;
        }
    }
}

