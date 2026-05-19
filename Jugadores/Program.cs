using System;

namespace SistemaDeportivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PROBANDO JUGADOR AMATEUR ===");
            IJugador amateur = new Amateur();
            
            amateur.Correr(15); 
            amateur.Correr(10); 
            amateur.Correr(5);  
            amateur.Descansar(20); 
            amateur.Correr(5);  

            Console.WriteLine("\n=== PROBANDO JUGADOR PROFESIONAL ===");
            IJugador profesional = new Profesional();
            
            profesional.Correr(30); 
            profesional.Correr(15); 
            profesional.Descansar(10); 
            profesional.Correr(5); 

            Console.ReadLine();
        }
    }
}