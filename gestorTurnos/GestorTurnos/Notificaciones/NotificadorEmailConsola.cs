using System;

namespace GestorTurnos
{
    public class NotificadorEmailConsola : INotificador
    {
        public void Notificar(Turno turno)
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("[EMAIL] Conectando al servidor SMTP...");
            Console.WriteLine($"[EMAIL] Enviando confirmación de turno a {turno.Paciente.Email}...");
            Console.WriteLine("[EMAIL] Email enviado correctamente.");
            Console.WriteLine("----------------------------------------------------");
        }
    }
}
