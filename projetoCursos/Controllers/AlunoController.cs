using ProjetoCursos.Models;

namespace ProjetoCursos.Controllers
{
    public class AlunoController
    {
        private readonly Escola escola;

        public AlunoController(Escola escola)
        {
            this.escola = escola;
        }

        public Aluno PesquisarAluno(int idAluno)
        {
            return escola.PesquisarAluno(idAluno);
        }

        public Aluno PesquisarAluno(string nome)
        {
            return escola.PesquisarAluno(nome);
        }
    }
}

