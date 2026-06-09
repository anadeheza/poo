using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazo_de_Cartas
{
    internal class Carta
    {
        public string Palo { get; }
        public int Valor { get; }

        public Carta(string palo, int valor)
        {
            Palo = palo;
            Valor = valor;
        }

        public override string ToString()
        {
            return Valor + " de " + Palo;
        }
    }
}
