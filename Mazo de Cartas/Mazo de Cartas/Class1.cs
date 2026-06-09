using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mazo_de_Cartas
{
    internal class Mazo
    {

        public List<Carta> cartas = new List<Carta>();

        public Mazo()
        {
            string[] palos = { "Espada", "Basto", "Oro", "Copa" };

            foreach (string palo in palos)
            {
                for(int i = 1; i <= 12; i++)
                {
                    if (i == 8 || i == 9) continue;
                    cartas.Add(new Carta(palo, i));
                }
            }
        }
        public void Barajar()
        {
            int cantCartas = cartas.Count;
            Random barajado = new Random();


            for ( int i = 0; i < cantCartas; i++)
            {
                int j = barajado.Next(cantCartas);
                Carta aux = cartas[i];
                cartas[i] = cartas[j];
                cartas[j] = aux;
            }
        }

        public Carta RobarCarta()
        {
            int cantCartas = cartas.Count;

            if (cantCartas != 0)
            {
                Carta carta = cartas[0];
                cartas.RemoveAt(0);
                return carta;
            } else
            {
                Console.WriteLine("no hay cartas en el mazo");
                Console.WriteLine();
                return null;
            }


        }

        public int CuantasCartasQuedan()
        {
            int cantCartas = cartas.Count;

            return cantCartas;
        }
    }
}
