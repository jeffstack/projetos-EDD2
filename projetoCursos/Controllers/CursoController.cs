using ProjetoCursos.Models;

namespace ProjetoCursos.Controllers
{
    public class CursoController
    {
        private readonly Escola escola;

        public CursoController(Escola escola)
        {
            this.escola = escola;
        }

        public bool AdicionarCurso(int id, string descricao)
        {
            Curso curso = new Curso(id, descricao);
            return escola.AdicionarCurso(curso);
        }

        public Curso PesquisarCurso(int id)
        {
            return escola.PesquisarCurso(new Curso(id, string.Empty));
        }

        public bool RemoverCurso(int id)
        {
            Curso curso = PesquisarCurso(id);
            return escola.RemoverCurso(curso);
        }
    }
}

