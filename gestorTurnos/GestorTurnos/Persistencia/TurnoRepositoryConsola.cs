using System;

namespace GestorTurnos
{
    // Simula el acceso a base de datos con Console.WriteLine, igual que el
    // código original, pero ahora detrás de una interfaz (ver DIP en
    // GestorTurnos.cs). El día de mañana esta clase se reemplaza por una que
    // hable con SQL Server / EF Core sin tocar el resto del sistema.
    public class TurnoRepositoryConsola : ITurnoRepository
    {
        public void Guardar(Turno turno)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("[BASE DE DATOS] Conectando a la base de datos...");
            Console.WriteLine($"[BASE DE DATOS] Insertando turno: Paciente={turno.Paciente.Nombre}, DNI={turno.Paciente.Dni}, Tipo={turno.Tipo.Nombre}, Precio=${turno.Precio}");
            Console.WriteLine("[BASE DE DATOS] Turno guardado correctamente.");
            Console.WriteLine("----------------------------------------------------");
        }
    }
}
