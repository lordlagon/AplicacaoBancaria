using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoBancariaGabrielZarpelon.Model;

namespace AplicacaoBancariaGabrielZarpelon.DAL
{
    class ContaDAO
    {
        private static List<Conta> contas = new List<Conta>();

        public static Conta BuscarContaNumeroConta(Conta conta)
        {
            foreach (Conta contaCadastrada in contas)
            {
                if (conta.numeroConta.Equals(contaCadastrada.numeroConta))
                {
                    return contaCadastrada;
                }
            }
            return null;
        }
        public static bool AddConta (Conta conta)
        {
            if (BuscarContaNumeroConta(conta) != null)
            {
                return false;
            }
            contas.Add(conta);
            return true;
        }
        public static List<Conta> RetornarLista()
        {
            return contas;
        }
    }
}
