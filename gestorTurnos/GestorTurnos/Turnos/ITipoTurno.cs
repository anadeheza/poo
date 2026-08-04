namespace GestorTurnos
{
    // OCP: en vez de un switch en TurnoTipo.ObtenerPrecio(), cada tipo de turno
    // implementa esta interfaz. Agregar un tipo nuevo = agregar una clase nueva,
    // sin tocar código existente.
    public interface ITipoTurno
    {
        string Nombre { get; }
        decimal ObtenerPrecio();
    }
}
