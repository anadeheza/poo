namespace GestorTurnos
{
    public class TurnoNormal : ITipoTurno
    {
        public string Nombre => "Normal";

        public decimal ObtenerPrecio() => 5000m;
    }
}
