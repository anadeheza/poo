using System;

namespace SistemaBancario
{
    public class CajaDeAhorro : CuentaBancaria
    {
        public float saldo;
        
        public void Extraer(float monto)
        {
            if(monto <= 0)
            {
                Console.WriteLine("Ingrese un monto valido")
                return
            }

            if(saldo < monto)
            {
                Console.WriteLine("No tienes suficiente dinero")
                return
            } 
            else 
            {
                saldo -= monto 
            }
        }
    }
}