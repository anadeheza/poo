using Jugadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jugador_cansado
{
    public class Pro : IJugador
    {
        public int tiempo { get; set; } = 0;
        public const int maxMins = 40;

        public bool Cansado()
        {
            return tiempo >= maxMins;
        }

        public bool Correr(int minutos)
        {
            if(Cansado())
            {
                return false;
            }
            
            if(tiempo + minutos > maxMins)
            {
                tiempo = maxMins;
                return false;
            }
            else
            {
                tiempo += minutos;
                return true;
            }
        }

        public void Descansar(int minutos)
        {
            tiempo -= minutos;
            if(tiempo < 0)
            {
                tiempo = 0;
            }
        }
    }
}
