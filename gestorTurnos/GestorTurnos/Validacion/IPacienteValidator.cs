using System.Collections.Generic;

namespace GestorTurnos
{
    public interface IPacienteValidator
    {
        bool Validar(Persona paciente, out IReadOnlyList<string> errores);
    }
}
