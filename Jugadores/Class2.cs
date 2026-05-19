using System;

namespace Jugadores
{
    public class Jugador:IJugador
    {
        public interface IJugador
        {
            public int tiempo
            {
                get;
                set;
            }

            public bool Cansado();
            public void Correr(int minutos);
            public void Descansar(int minutos);
        }
    }
}