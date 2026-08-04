namespace GestorTurnos
{
    public interface ITipoTurnoFactory
    {
        ITipoTurno Crear(string nombreTipo);
    }
}
