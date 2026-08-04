namespace GestorTurnos
{
    public class TurnoUrgente : ITipoTurno
    {
        public string Nombre => "Urgente";

        public decimal ObtenerPrecio() => 7500m;
    }
}
