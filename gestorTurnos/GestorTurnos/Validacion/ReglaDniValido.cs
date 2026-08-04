namespace GestorTurnos
{
    public class ReglaDniValido : IReglaValidacionPaciente
    {
        public bool EsValida(Persona paciente, out string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(paciente.Dni) || paciente.Dni.Length < 7)
            {
                mensajeError = "El DNI ingresado no es válido.";
                return false;
            }

            mensajeError = string.Empty;
            return true;
        }
    }
}
