namespace GestorTurnos.Tests
{
    // DIP: gracias a que GestorTurnos depende de interfaces, en los tests
    // podemos reemplazar la "base de datos", el "email" y el "comprobante"
    // por versiones en memoria. Nada de esto era posible con el código
    // original, que hacía "new" de todo puertas adentro.
    public class TurnoRepositoryFake : ITurnoRepository
    {
        public Turno? UltimoTurnoGuardado { get; private set; }

        public void Guardar(Turno turno)
        {
            UltimoTurnoGuardado = turno;
        }
    }

    public class NotificadorFake : INotificador
    {
        public bool SeNotifico { get; private set; }

        public void Notificar(Turno turno)
        {
            SeNotifico = true;
        }
    }

    public class ComprobanteFake : IComprobanteService
    {
        public bool SeMostro { get; private set; }

        public void Mostrar(Turno turno)
        {
            SeMostro = true;
        }
    }
}
