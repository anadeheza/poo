using System

namespace Carreras
{
    class Carrera
    {
        public void Iniciar(IVehiculo v1, IVehiculo v2, int secs) 
        {
            v1.ReiniciarPosicion()
            v2.ReiniciarPosicion()

            v1.Mover(secs)
            v2.Mover(secs)

            int pos1 = v1.Posicion()
            int pos2 = v2.Posicion()

            if(pos1 > pos2) 
            {
                Console.WriteLine("{v1} llego mas lejos que {v2}")
            }
            else if (pos2 > pos1)
            {
                Console.WriteLine("{v2} llego mas lejos que {v1}")
            }
            else 
            {
                Console.WriteLine("{v1} y {v2} empataron")
            }
        }
    }
}