namespace GestorTurnos
{
    // ISP: interfaz mínima, de un solo método. Cada regla implementa
    // exactamente lo que necesita, sin cargar con métodos que no usa.
    public interface IReglaValidacionPaciente
    {
        bool EsValida(Persona paciente, out string mensajeError);
    }
}
