using System;

namespace Carreras
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto fiat = new Auto(45);
            Bicicleta bici = new Bicicleta();
            Camion camion = new Camion();

            bici.Mover(20);
            Console.WriteLine($"Posición de la bici luego de 20s: {bici.Posicion()}"); // Debería dar 200
            
            bici.Mover(10);
            Console.WriteLine($"Posición de la bici luego de 30s: {bici.Posicion()}"); // Debería dar 300

            Carrera granPremio = new Carrera();            

            granPremio.IniciarCompetencia(fiat, camion, 10);
            granPremio.IniciarCompetencia(bici, camion, 5);
            
            Console.ReadLine();
        }
    }
}