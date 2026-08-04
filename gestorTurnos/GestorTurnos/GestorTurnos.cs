using System;

namespace GestorTurnos
{
    // DIP: antes, esta clase (y Turno) creaban sus propias dependencias con
    // "new" (acceso a "base de datos", "SMTP", validación) — un módulo de
    // alto nivel dependiendo de detalles concretos de bajo nivel. Ahora recibe
    // interfaces por constructor. GestorTurnos ya no sabe si el turno se
    // guarda en SQL Server, en un archivo o en memoria: solo conoce el
    // contrato ITurnoRepository. Eso también es lo que permite testearla con
    // fakes, sin tocar la consola real (ver GestorTurnos.Tests).
    public class GestorTurnos
    {
        private readonly IPacienteValidator validador;
        private readonly ITipoTurnoFactory tipoTurnoFactory;
        private readonly ITurnoRepository repositorio;
        private readonly INotificador notificador;
        private readonly IComprobanteService comprobante;

        public GestorTurnos(
            IPacienteValidator validador,
            ITipoTurnoFactory tipoTurnoFactory,
            ITurnoRepository repositorio,
            INotificador notificador,
            IComprobanteService comprobante)
        {
            this.validador = validador;
            this.tipoTurnoFactory = tipoTurnoFactory;
            this.repositorio = repositorio;
            this.notificador = notificador;
            this.comprobante = comprobante;
        }

        public void ProcesarTurno(string nombrePaciente, string dni, string tipoTurno, string email)
        {
            var paciente = new Persona(nombrePaciente, dni, email);

            if (!validador.Validar(paciente, out var errores))
            {
                foreach (var error in errores)
                {
                    Console.WriteLine($"Error: {error}");
                }

                Console.WriteLine("No se puede procesar el turno.");
                return;
            }

            ITipoTurno tipo;
            try
            {
                tipo = tipoTurnoFactory.Crear(tipoTurno);
            }
            catch (TipoTurnoNoValidoException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return;
            }

            var turno = new Turno(paciente, tipo);

            repositorio.Guardar(turno);
            notificador.Notificar(turno);
            comprobante.Mostrar(turno);
        }
    }
}
