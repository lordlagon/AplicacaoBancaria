using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacaoBancariaGabrielZarpelon.Model;

namespace AplicacaoBancariaGabrielZarpelon.Controller
{
    class DepositoSaque
    {
        Movimentacao movimentacao = new Movimentacao();
        public static double Deposito(Conta conta, Movimentacao movimentacao)
        {
            conta.saldo += movimentacao.valor;
            return conta.saldo;
            
        }
        public static double Saque(Conta conta, Movimentacao movimentacao)
        {
            conta.saldo -= movimentacao.valor;
            return conta.saldo;

        }
        
    }
}
