using System;
using ProjetoCursos.Models;

namespace ProjetoCursos.Views
{
    public class ConsoleView
    {
        public void ExibirMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== PROJETO CURSOS =====");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar curso");
            Console.WriteLine("2. Pesquisar curso");
            Console.WriteLine("3. Remover curso");
            Console.WriteLine("4. Adicionar disciplina no curso");
            Console.WriteLine("5. Pesquisar disciplina");
            Console.WriteLine("6. Remover disciplina do curso");
            Console.WriteLine("7. Matricular aluno na disciplina");
            Console.WriteLine("8. Remover aluno da disciplina");
            Console.WriteLine("9. Pesquisar aluno");
            Console.WriteLine();
        }

        public int LerInteiro(string mensagem)
        {
            int valor;
            bool entradaValida;

            do
            {
                Console.Write(mensagem);
                entradaValida = int.TryParse(Console.ReadLine(), out valor);

                if (!entradaValida)
                {
                    Console.WriteLine("Digite um número inteiro válido.");
                }
            }
            while (!entradaValida);

            return valor;
        }

        public string LerTexto(string mensagem)
        {
            string texto;

            do
            {
                Console.Write(mensagem);
                texto = Console.ReadLine();

                if (texto == null)
                {
                    texto = string.Empty;
                }

                texto = texto.Trim();

                if (texto.Length == 0)
                {
                    Console.WriteLine("O texto não pode ficar vazio.");
                }
            }
            while (texto.Length == 0);

            return texto;
        }

        public void ExibirCurso(Curso curso)
        {
            Console.WriteLine();
            Console.WriteLine("Curso encontrado:");
            Console.WriteLine("Código: " + curso.Id);
            Console.WriteLine("Descrição: " + curso.Descricao);
            Console.WriteLine("Disciplinas:");

            Disciplina[] disciplinas = curso.ObterDisciplinas();

            if (disciplinas.Length == 0)
            {
                Console.WriteLine("Nenhuma disciplina associada.");
                return;
            }

            for (int i = 0; i < disciplinas.Length; i++)
            {
                Console.WriteLine("- " + disciplinas[i].Id + " - " + disciplinas[i].Descricao);
            }
        }

        public void ExibirDisciplina(Disciplina disciplina)
        {
            Console.WriteLine();
            Console.WriteLine("Disciplina encontrada:");
            Console.WriteLine("Código: " + disciplina.Id);
            Console.WriteLine("Descrição: " + disciplina.Descricao);
            Console.WriteLine("Curso: " + disciplina.Curso.Descricao);
            Console.WriteLine("Alunos matriculados:");

            Aluno[] alunos = disciplina.ObterAlunos();

            if (alunos.Length == 0)
            {
                Console.WriteLine("Nenhum aluno matriculado.");
                return;
            }

            for (int i = 0; i < alunos.Length; i++)
            {
                Console.WriteLine("- " + alunos[i].Id + " - " + alunos[i].Nome);
            }
        }

        public void ExibirAluno(Aluno aluno)
        {
            Console.WriteLine();
            Console.WriteLine("Aluno encontrado:");
            Console.WriteLine("Código: " + aluno.Id);
            Console.WriteLine("Nome: " + aluno.Nome);
            Console.WriteLine("Curso: " + aluno.Curso.Descricao);
            Console.WriteLine("Disciplinas matriculadas:");

            Disciplina[] disciplinas = aluno.ObterDisciplinas();

            for (int i = 0; i < disciplinas.Length; i++)
            {
                Console.WriteLine("- " + disciplinas[i].Id + " - " + disciplinas[i].Descricao);
            }
        }

        public void ExibirMensagem(string mensagem)
        {
            Console.WriteLine();
            Console.WriteLine(mensagem);
        }

        public void Aguardar()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar.");
            Console.ReadLine();
        }
    }
}

