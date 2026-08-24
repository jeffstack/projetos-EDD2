using System;

namespace ProjetoVendedores
{
    public class Vendedor
    {
        private int id;
        private string nome;
        private double percComissao;
        private Venda[] asVendas;

        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public double PercComissao { get { return percComissao; } set { percComissao = value; } }
        public Venda[] AsVendas { get { return asVendas; } }

        public Vendedor(int id, string nome, double percComissao)
        {
            this.id = id;
            this.nome = nome;
            this.percComissao = percComissao;
            this.asVendas = new Venda[31];
        }

        public Vendedor(int id)
        {
            this.id = id;
            this.asVendas = new Venda[31];
        }

        public void RegistrarVenda(int dia, Venda venda)
        {
            if (dia >= 1 && dia <= 31)
            {
                asVendas[dia - 1] = venda;
            }
            else
            {
                Console.WriteLine("Dia inválido! Deve ser entre 1 e 31.");
            }
        }

        public double ValorVendas()
        {
            double total = 0;
            for (int i = 0; i < asVendas.Length; i++)
            {
                if (asVendas[i] != null)
                {
                    total += asVendas[i].Valor;
                }
            }
            return total;
        }

        public double ValorComissao()
        {
            return ValorVendas() * (percComissao / 100.0);
        }
    }
}
