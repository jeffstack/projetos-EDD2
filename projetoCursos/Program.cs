using System;
using ProjetoCursos.Controllers;
using ProjetoCursos.Models;
using ProjetoCursos.Views;

namespace ProjetoCursos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Escola escola = new Escola();
            CursoController cursoController = new CursoController(escola);
            DisciplinaController disciplinaController = new DisciplinaController(escola);
            AlunoController alunoController = new AlunoController(escola);
            ConsoleView view = new ConsoleView();

            int opcao;

            do
            {
                view.ExibirMenu();
                opcao = view.LerInteiro("Escolha uma opção: ");

                switch (opcao)
                {
                    case 0:
                        view.ExibirMensagem("Programa encerrado.");
                        break;
                    case 1:
                        AdicionarCurso(cursoController, view);
                        break;
                    case 2:
                        PesquisarCurso(cursoController, view);
                        break;
                    case 3:
                        RemoverCurso(cursoController, view);
                        break;
                    case 4:
                        AdicionarDisciplina(disciplinaController, view);
                        break;
                    case 5:
                        PesquisarDisciplina(disciplinaController, view);
                        break;
                    case 6:
                        RemoverDisciplina(disciplinaController, view);
                        break;
                    case 7:
                        MatricularAluno(disciplinaController, alunoController, view);
                        break;
                    case 8:
                        RemoverAluno(disciplinaController, view);
                        break;
                    case 9:
                        PesquisarAluno(alunoController, view);
                        break;
                    default:
                        view.ExibirMensagem("Opção inválida.");
                        break;
                }

                if (opcao != 0)
                {
                    view.Aguardar();
                }
            }
            while (opcao != 0);
        }

        private static void AdicionarCurso(CursoController controller, ConsoleView view)
        {
            int id = view.LerInteiro("Digite o código do curso: ");
            string descricao = view.LerTexto("Digite a descrição do curso: ");

            if (controller.AdicionarCurso(id, descricao))
            {
                view.ExibirMensagem("Curso adicionado com sucesso.");
            }
            else
            {
                view.ExibirMensagem("Não foi possível adicionar o curso. Verifique se o código já existe ou se o limite de 5 cursos foi atingido.");
            }
        }

        private static void PesquisarCurso(CursoController controller, ConsoleView view)
        {
            int id = view.LerInteiro("Digite o código do curso: ");
            Curso curso = controller.PesquisarCurso(id);

            if (curso == null)
            {
                view.ExibirMensagem("Curso não encontrado.");
            }
            else
            {
                view.ExibirCurso(curso);
            }
        }

        private static void RemoverCurso(CursoController controller, ConsoleView view)
        {
            int id = view.LerInteiro("Digite o código do curso: ");

            if (controller.RemoverCurso(id))
            {
                view.ExibirMensagem("Curso removido com sucesso.");
            }
            else
            {
                view.ExibirMensagem("Não foi possível remover o curso. Ele pode não existir ou ainda possuir disciplinas associadas.");
            }
        }

        private static void AdicionarDisciplina(DisciplinaController controller, ConsoleView view)
        {
            int idCurso = view.LerInteiro("Digite o código do curso: ");
            int idDisciplina = view.LerInteiro("Digite o código da disciplina: ");
            string descricao = view.LerTexto("Digite a descrição da disciplina: ");

            if (controller.AdicionarDisciplina(idCurso, idDisciplina, descricao))
            {
                view.ExibirMensagem("Disciplina adicionada com sucesso.");
            }
            else
            {
                view.ExibirMensagem("Não foi possível adicionar a disciplina. Verifique o curso, o código ou o limite de 12 disciplinas.");
            }
        }

        private static void PesquisarDisciplina(DisciplinaController controller, ConsoleView view)
        {
            int id = view.LerInteiro("Digite o código da disciplina: ");
            Disciplina disciplina = controller.PesquisarDisciplina(id);

            if (disciplina == null)
            {
                view.ExibirMensagem("Disciplina não encontrada.");
            }
            else
            {
                view.ExibirDisciplina(disciplina);
            }
        }

        private static void RemoverDisciplina(DisciplinaController controller, ConsoleView view)
        {
            int idCurso = view.LerInteiro("Digite o código do curso: ");
            int idDisciplina = view.LerInteiro("Digite o código da disciplina: ");

            if (controller.RemoverDisciplina(idCurso, idDisciplina))
            {
                view.ExibirMensagem("Disciplina removida com sucesso.");
            }
            else
            {
                view.ExibirMensagem("Não foi possível remover a disciplina. Ela pode não existir ou possuir alunos matriculados.");
            }
        }

        private static void MatricularAluno(DisciplinaController controller, AlunoController alunoController, ConsoleView view)
        {
            int idDisciplina = view.LerInteiro("Digite o código da disciplina: ");
            int idAluno = view.LerInteiro("Digite o código do aluno: ");
            Aluno aluno = alunoController.PesquisarAluno(idAluno);
            string nomeAluno;

            if (aluno == null)
            {
                nomeAluno = view.LerTexto("Digite o nome do aluno: ");
            }
            else
            {
                nomeAluno = aluno.Nome;
            }

            if (controller.MatricularAluno(idDisciplina, idAluno, nomeAluno))
            {
                view.ExibirMensagem("Aluno matriculado com sucesso.");
            }
            else
            {
                view.ExibirMensagem("Não foi possível matricular o aluno. Verifique os limites, a disciplina e o curso do aluno.");
            }
        }

        private static void RemoverAluno(DisciplinaController controller, ConsoleView view)
        {
            int idDisciplina = view.LerInteiro("Digite o código da disciplina: ");
            int idAluno = view.LerInteiro("Digite o código do aluno: ");

            if (controller.RemoverAluno(idDisciplina, idAluno))
            {
                view.ExibirMensagem("Aluno removido da disciplina com sucesso.");
            }
            else
            {
                view.ExibirMensagem("Não foi possível remover o aluno. Verifique os códigos informados.");
            }
        }

        private static void PesquisarAluno(AlunoController controller, ConsoleView view)
        {
            string nome = view.LerTexto("Digite o nome do aluno: ");
            Aluno aluno = controller.PesquisarAluno(nome);

            if (aluno == null)
            {
                view.ExibirMensagem("Aluno não encontrado.");
            }
            else
            {
                view.ExibirAluno(aluno);
            }
        }
    }
}

