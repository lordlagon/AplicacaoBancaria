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

        public static Conta BuscarContaNConta(Conta conta)
        {
            foreach (Conta contaCadas in contas)
            {
                if (conta.nConta.Equals(contaCadas.nConta))
                {
                    return contaCadas;
                }
            }
            return null;
        }
        public static bool AddConta (Conta conta)
        {
            if (BuscarContaNConta(conta) != null)
            {
                return false;
            }
            contas.Add(conta);
            return true;
        }
        public static List<Conta> Lista()
        {
            return contas;
        }
    }
}
