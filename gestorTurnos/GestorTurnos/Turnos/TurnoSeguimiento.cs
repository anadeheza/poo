namespace GestorTurnos
{
    public class TurnoSeguimiento : ITipoTurno
    {
        public string Nombre => "Seguimiento";

        public decimal ObtenerPrecio() => 3000m;
    }
}
