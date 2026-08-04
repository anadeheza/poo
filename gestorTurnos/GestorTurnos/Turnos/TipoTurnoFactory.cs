using System;
using System.Collections.Generic;

namespace GestorTurnos
{
    // OCP: el mapeo "nombre -> tipo de turno" se recibe de afuera (se registra
    // en Program.cs). Para sumar un tipo de turno nuevo no hay que tocar esta
    // clase: se crea la clase ITipoTurno nueva y se agrega una línea en el
    // registro del composition root.
    public class TipoTurnoFactory : ITipoTurnoFactory
    {
        private readonly IReadOnlyDictionary<string, Func<ITipoTurno>> constructores;

        public TipoTurnoFactory(IReadOnlyDictionary<string, Func<ITipoTurno>> constructores)
        {
            this.constructores = constructores;
        }

        public ITipoTurno Crear(string nombreTipo)
        {
            if (!constructores.TryGetValue(nombreTipo, out var constructor))
            {
                throw new TipoTurnoNoValidoException(nombreTipo);
            }

            return constructor();
        }
    }
}
