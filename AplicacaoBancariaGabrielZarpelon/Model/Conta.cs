using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoBancariaGabrielZarpelon.Model
{
    class Conta
    {
        public string nome { get; set; }
        public string numeroConta { get; set; }
        public double saldo { get; set; }
        public DateTime data { get; set; }
        public List<Movimentacao> Movimentacao { get; set; }

        public Conta()
        {
            Movimentacao = new List<Movimentacao>();
        }
        public override string ToString()
        {
            return "Número de conta: " + numeroConta + "\nCliente: " + nome + "\nSaldo: " + saldo + "\nData de abertura: " + data;
        }


    }
}
