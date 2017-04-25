using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoBancariaGabrielZarpelon.Model
{
    class Movimentacao
    {
        public string tipo { get; set; }
        public double valor { get; set; }
        public DateTime data { get; set; }
        public override string ToString()
        {
            return "\n  Tipo: " + tipo + " Valor: " + valor + " Data: " + data;
        }
    }
   
}
