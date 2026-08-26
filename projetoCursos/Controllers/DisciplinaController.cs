using ProjetoCursos.Models;

namespace ProjetoCursos.Controllers
{
    public class DisciplinaController
    {
        private readonly Escola escola;

        public DisciplinaController(Escola escola)
        {
            this.escola = escola;
        }

        public bool AdicionarDisciplina(int idCurso, int idDisciplina, string descricao)
        {
            Curso curso = escola.PesquisarCurso(new Curso(idCurso, string.Empty));

            if (curso == null || escola.PesquisarDisciplina(idDisciplina) != null)
            {
                return false;
            }

            Disciplina disciplina = new Disciplina(idDisciplina, descricao);
            return curso.AdicionarDisciplina(disciplina);
        }

        public Disciplina PesquisarDisciplina(int idDisciplina)
        {
            return escola.PesquisarDisciplina(idDisciplina);
        }

        public bool RemoverDisciplina(int idCurso, int idDisciplina)
        {
            Curso curso = escola.PesquisarCurso(new Curso(idCurso, string.Empty));

            if (curso == null)
            {
                return false;
            }

            Disciplina disciplina = curso.PesquisarDisciplina(new Disciplina(idDisciplina, string.Empty));
            return curso.RemoverDisciplina(disciplina);
        }

        public bool MatricularAluno(int idDisciplina, int idAluno, string nomeAluno)
        {
            Disciplina disciplina = escola.PesquisarDisciplina(idDisciplina);

            if (disciplina == null)
            {
                return false;
            }

            Aluno aluno = escola.PesquisarAluno(idAluno);

            if (aluno == null)
            {
                aluno = new Aluno(idAluno, nomeAluno);
            }

            return disciplina.MatricularAluno(aluno);
        }

        public bool RemoverAluno(int idDisciplina, int idAluno)
        {
            Disciplina disciplina = escola.PesquisarDisciplina(idDisciplina);

            if (disciplina == null)
            {
                return false;
            }

            Aluno aluno = disciplina.PesquisarAluno(new Aluno(idAluno, string.Empty));
            return disciplina.DesmatricularAluno(aluno);
        }
    }
}

