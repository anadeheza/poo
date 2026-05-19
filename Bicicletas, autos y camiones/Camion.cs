using System;

namespace Carreras
{
    public class Camion : IVehiculo
    {
        public int _posicion = 0;
        public const int velMax = 30;

        public void Mover(int segundos)
        {
            pos += velMax * segundos;
        }

        public int Posicion()
        {
            return pos;
        }

        public void ReiniciarPosicion()
        {
            pos = 0;
        }
    }
}