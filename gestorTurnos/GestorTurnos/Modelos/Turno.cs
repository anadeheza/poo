namespace GestorTurnos
{
    // SRP: Turno ahora solo representa datos de un turno.
    // Antes también sabía persistir, notificar, mostrar comprobante Y validar
    // al paciente: 4 responsabilidades distintas, 4 razones para cambiar.
    public class Turno
    {
        public Persona Paciente { get; }
        public ITipoTurno Tipo { get; }
        public decimal Precio => Tipo.ObtenerPrecio();

        public Turno(Persona paciente, ITipoTurno tipo)
        {
            Paciente = paciente;
            Tipo = tipo;
        }
    }
}
