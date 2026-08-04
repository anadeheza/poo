namespace GestorTurnos
{
    public class ReglaEmailValido : IReglaValidacionPaciente
    {
        public bool EsValida(Persona paciente, out string mensajeError)
        {
            if (string.IsNullOrWhiteSpace(paciente.Email) || !paciente.Email.Contains("@"))
            {
                mensajeError = "El email ingresado no es válido.";
                return false;
            }

            mensajeError = string.Empty;
            return true;
        }
    }
}
