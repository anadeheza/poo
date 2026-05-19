using System;

namespace Carreras
{
    public class Auto : IVehiculo
    {
        public int _posicion = 0;
        public int velMax;

        public Auto() 
        {
            velMax = 40;
        }

        public Auto(int velPers)
        {
            velMax = velPers;
        }

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