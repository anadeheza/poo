using System;

namespace SistemaBancario
{
    public class CuentaBancaria
    {
        protected float saldo; //no private para que las subclases lo puedan usar

        public void Depositar(float monto) 
        {
            
            if(monto <= 0)
            {
                Console.WriteLine("Ingrese un monto positivo")
                return
            }
            saldo += monto;
        }

        public void Extraer(float monto);

        public void MostrarSaldo() 
        {
            Console.WriteLine($"Saldo: {saldo}")
        }
    }
}