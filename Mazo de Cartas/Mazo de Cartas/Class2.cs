using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazo_de_Cartas
{
    internal class Mano
    {
        public List<Carta> cartasActuales = new List<Carta>();
        public void RecibirCarta(Carta carta)
        {
            cartasActuales.Add(carta);
        }

        public void MostrarMano()
        {
            Console.WriteLine("cartas en mano: ");

            foreach (Carta carta in cartasActuales)
            {
                    Console.WriteLine(carta);
            }
            Console.WriteLine();
        }

        public int CantidadDeCartas()
        {
            int cantidad = cartasActuales.Count;
            return cantidad;
        }
    }
}
