using System;

namespace ProjetoVendedores
{
    public class Venda
    {
        private int qtde;
        private double valor;

        public int Qtde 
        { 
            get { return qtde; } 
            set { qtde = value; } 
        }
        
        public double Valor 
        { 
            get { return valor; } 
            set { valor = value; } 
        }

        public Venda(int qtde, double valor)
        {
            this.qtde = qtde;
            this.valor = valor;
        }

        public double ValorMedio()
        {
            if (qtde == 0) return 0;
            return valor / qtde;
        }
    }
}
