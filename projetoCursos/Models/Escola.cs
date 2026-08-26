namespace ProjetoCursos.Models
{
    public class Escola
    {
        private readonly Curso[] cursos = new Curso[5];

        public bool AdicionarCurso(Curso curso)
        {
            if (curso == null || QuantidadeCursos >= cursos.Length)
            {
                return false;
            }

            if (PesquisarCurso(curso) != null)
            {
                return false;
            }

            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] == null)
                {
                    cursos[i] = curso;
                    return true;
                }
            }

            return false;
        }

        public Curso PesquisarCurso(Curso curso)
        {
            if (curso == null)
            {
                return null;
            }

            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null && cursos[i].Id == curso.Id)
                {
                    return cursos[i];
                }
            }

            return null;
        }

        public bool RemoverCurso(Curso curso)
        {
            if (curso == null)
            {
                return false;
            }

            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null && cursos[i].Id == curso.Id)
                {
                    if (cursos[i].QuantidadeDisciplinas > 0)
                    {
                        return false;
                    }

                    cursos[i] = null;
                    return true;
                }
            }

            return false;
        }

        public int QuantidadeCursos
        {
            get
            {
                int quantidade = 0;

                for (int i = 0; i < cursos.Length; i++)
                {
                    if (cursos[i] != null)
                    {
                        quantidade++;
                    }
                }

                return quantidade;
            }
        }

        public Curso[] ObterCursos()
        {
            Curso[] resultado = new Curso[QuantidadeCursos];
            int posicao = 0;

            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null)
                {
                    resultado[posicao] = cursos[i];
                    posicao++;
                }
            }

            return resultado;
        }

        public Disciplina PesquisarDisciplina(int idDisciplina)
        {
            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null)
                {
                    Disciplina[] disciplinas = cursos[i].ObterDisciplinas();

                    for (int j = 0; j < disciplinas.Length; j++)
                    {
                        if (disciplinas[j].Id == idDisciplina)
                        {
                            return disciplinas[j];
                        }
                    }
                }
            }

            return null;
        }

        public Aluno PesquisarAluno(int idAluno)
        {
            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null)
                {
                    Disciplina[] disciplinas = cursos[i].ObterDisciplinas();

                    for (int j = 0; j < disciplinas.Length; j++)
                    {
                        Aluno[] alunos = disciplinas[j].ObterAlunos();

                        for (int k = 0; k < alunos.Length; k++)
                        {
                            if (alunos[k].Id == idAluno)
                            {
                                return alunos[k];
                            }
                        }
                    }
                }
            }

            return null;
        }

        public Aluno PesquisarAluno(string nome)
        {
            if (nome == null)
            {
                return null;
            }

            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null)
                {
                    Disciplina[] disciplinas = cursos[i].ObterDisciplinas();

                    for (int j = 0; j < disciplinas.Length; j++)
                    {
                        Aluno[] alunos = disciplinas[j].ObterAlunos();

                        for (int k = 0; k < alunos.Length; k++)
                        {
                            if (alunos[k].Nome.Equals(nome, System.StringComparison.OrdinalIgnoreCase))
                            {
                                return alunos[k];
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}

