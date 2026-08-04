namespace GestorTurnos
{
    public class ReglaNombreObligatorio : IReglaValidacionPaciente
    {
        public bool EsValida(Persona paciente, out string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(paciente.Nombre))
            {
                mensajeError = "El nombre del paciente es obligatorio.";
                return false;
            }

            mensajeError = string.Empty;
            return true;
        }
    }
}
