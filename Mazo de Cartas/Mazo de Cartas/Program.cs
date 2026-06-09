using System;

namespace Mazo_de_Cartas
{
    internal class Program
    {
        static void Main()
        {
            Mazo mazo = new Mazo();
            mazo.Barajar();
            Mano jugador1 = new Mano();
            Mano jugador2 = new Mano();

            // Repartir 3 cartas a cada jugador
            for (int i = 0; i < 3; i++)
            {
                jugador1.RecibirCarta(mazo.RobarCarta());
                jugador2.RecibirCarta(mazo.RobarCarta());
            }

            jugador1.MostrarMano();
            jugador2.MostrarMano();
            Console.WriteLine("Quedan: " + mazo.CuantasCartasQuedan() + " cartas");
        }
    }
}
