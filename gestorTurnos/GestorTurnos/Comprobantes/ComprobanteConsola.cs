using System;

namespace GestorTurnos
{
    public class ComprobanteConsola : IComprobanteService
    {
        public void Mostrar(Turno turno)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("           COMPROBANTE DE TURNO - CLÍNICA           ");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"Paciente:   {turno.Paciente.Nombre}");
            Console.WriteLine($"DNI:        {turno.Paciente.Dni}");
            Console.WriteLine($"Email:      {turno.Paciente.Email}");
            Console.WriteLine($"Tipo turno: {turno.Tipo.Nombre}");
            Console.WriteLine($"Precio:     ${turno.Precio}");
            Console.WriteLine("----------------------------------------------------");
        }
    }
}
