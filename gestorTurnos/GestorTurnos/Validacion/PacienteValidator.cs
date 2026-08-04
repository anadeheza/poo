using System.Collections.Generic;

namespace GestorTurnos
{
    // OCP + SRP: esta clase no sabe nada de nombres, DNIs ni emails; solo sabe
    // recorrer una lista de reglas. Agregar una validación nueva (por ejemplo,
    // "el paciente debe tener obra social") es agregar una clase que implemente
    // IReglaValidacionPaciente, sin modificar PacienteValidator.
    public class PacienteValidator : IPacienteValidator
    {
        private readonly IEnumerable<IReglaValidacionPaciente> reglas;

        public PacienteValidator(IEnumerable<IReglaValidacionPaciente> reglas)
        {
            this.reglas = reglas;
        }

        public bool Validar(Persona paciente, out IReadOnlyList<string> errores)
        {
            var listaErrores = new List<string>();

            foreach (var regla in reglas)
            {
                if (!regla.EsValida(paciente, out var mensajeError))
                {
                    listaErrores.Add(mensajeError);
                }
            }

            errores = listaErrores;
            return listaErrores.Count == 0;
        }
    }
}
