namespace Carreras
{
    public interface IVehiculo
    {
        void Mover(int segundos);
        int Posicion();
        void ReiniciarPosicion();
    }
}