using System;
using System.Collections.Generic;

namespace GestorTurnos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Composition root: el único lugar del programa que conoce las
            // implementaciones concretas y las conecta entre sí.
            var tipoTurnoFactory = new TipoTurnoFactory(new Dictionary<string, Func<ITipoTurno>>
            {
                ["Normal"] = () => new TurnoNormal(),
                ["Urgente"] = () => new TurnoUrgente(),
                ["Seguimiento"] = () => new TurnoSeguimiento(),
                // Para sumar "Telemedicina": crear TurnoTelemedicina.cs y
                // agregar una línea acá. Nada más cambia (OCP).
            });

            var validador = new PacienteValidator(new IReglaValidacionPaciente[]
            {
                new ReglaNombreObligatorio(),
                new ReglaDniValido(),
                new ReglaEmailValido(),
            });

            var gestor = new GestorTurnos(
                validador,
                tipoTurnoFactory,
                new TurnoRepositoryConsola(),
                new NotificadorEmailConsola(),
                new ComprobanteConsola());

            // Ejemplos de prueba: turno Normal, Urgente y Seguimiento
            gestor.ProcesarTurno("Juan Pérez", "30111222", "Normal", "juan.perez@mail.com");
            gestor.ProcesarTurno("María Gómez", "27888999", "Urgente", "maria.gomez@mail.com");
            gestor.ProcesarTurno("Carlos Ruiz", "40555666", "Seguimiento", "carlos.ruiz@mail.com");

            // Ejemplo con datos inválidos, para ver que la validación corta el proceso
            gestor.ProcesarTurno("", "123", "Normal", "email-invalido");

            // Ejemplo con tipo de turno desconocido
            gestor.ProcesarTurno("Ana López", "35777888", "Telemedicina", "ana.lopez@mail.com");
        }
    }
}
