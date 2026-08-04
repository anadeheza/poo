using System;

namespace GestorTurnos
{
    // LSP: el código original, ante un tipo desconocido, imprimía un error y
    // devolvía -1 como "precio". Eso rompe el contrato implícito de
    // ObtenerPrecio() (siempre debería devolver un precio válido >= 0), y
    // cualquier código que confiara en ese contrato podía fallar en silencio
    // si alguna implementación futura decidía "sustituir" ese comportamiento.
    // Con esta excepción, todas las implementaciones de ITipoTurno son
    // 100% sustituibles entre sí: o devuelven un precio válido, o el proceso
    // de creación falla explícitamente. Nunca hay un valor "trampa".
    public class TipoTurnoNoValidoException : Exception
    {
        public TipoTurnoNoValidoException(string tipo)
            : base($"Tipo de turno desconocido: '{tipo}'.")
        {
        }
    }
}
