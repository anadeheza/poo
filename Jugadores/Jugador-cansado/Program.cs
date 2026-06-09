using Jugador_cansado;
using System;

namespace Jugadores
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IJugador amateur = new Amateur();
            IJugador pro = new Pro();

            Console.WriteLine("--- Intento de correr 30 minutos ---");

            Console.WriteLine($"¿Amateur pudo correr? {amateur.Correr(30)}");
            Console.WriteLine($"¿Profesional pudo correr? {pro.Correr(30)}");

            Console.WriteLine($"\n¿Amateur está cansado? {amateur.Cansado()}");

            amateur.Descansar(20);
            Console.WriteLine($"Amateur descansa. ¿Está cansado ahora? {amateur.Cansado()}");
        }
    }
}
