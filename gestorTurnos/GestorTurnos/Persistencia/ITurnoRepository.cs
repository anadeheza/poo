namespace GestorTurnos
{
    // ISP: quien necesita guardar un turno depende solo de esto, no de
    // notificar ni de mostrar comprobantes.
    public interface ITurnoRepository
    {
        void Guardar(Turno turno);
    }
}
