using System;

namespace ProjetoVendedores
{
    public class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public Vendedor[] OsVendedores { get { return osVendedores; } }
        public int Max { get { return max; } }
        public int Qtde { get { return qtde; } }

        public Vendedores(int max = 10)
        {
            this.max = max;
            this.qtde = 0;
            this.osVendedores = new Vendedor[max];
        }

        public bool AddVendedor(Vendedor v)
        {
            if (qtde < max)
            {
                if (SearchVendedor(v) != null)
                {
                    return false; 
                }

                osVendedores[qtde] = v;
                qtde++;
                return true;
            }
            return false;
        }

        public bool DelVendedor(Vendedor v)
        {
            Vendedor vendedorEncontrado = SearchVendedor(v);
            
            if (vendedorEncontrado != null)
            {
                bool temVendas = false;
                for (int i = 0; i < vendedorEncontrado.AsVendas.Length; i++)
                {
                    if (vendedorEncontrado.AsVendas[i] != null)
                    {
                        temVendas = true;
                        break;
                    }
                }

                if (temVendas)
                {
                    return false;
                }

                int index = -1;
                for (int i = 0; i < qtde; i++)
                {
                    if (osVendedores[i].Id == vendedorEncontrado.Id)
                    {
                        index = i;
                        break;
                    }
                }

                for (int i = index; i < qtde - 1; i++)
                {
                    osVendedores[i] = osVendedores[i + 1];
                }
                
                osVendedores[qtde - 1] = null;
                qtde--;
                return true;
            }
            return false;
        }

        public Vendedor SearchVendedor(Vendedor v)
        {
            for (int i = 0; i < qtde; i++)
            {
                if (osVendedores[i].Id == v.Id)
                {
                    return osVendedores[i];
                }
            }
            return null;
        }

        public double ValorVendas()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].ValorVendas();
            }
            return total;
        }

        public double ValorComissao()
        {
            double total = 0;
            for (int i = 0; i < qtde; i++)
            {
                total += osVendedores[i].ValorComissao();
            }
            return total;
        }
    }
}
