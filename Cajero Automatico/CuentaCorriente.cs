using System;

namespace SistemaBancario
{
    public class CuentaCorriente : CuentaBancaria
    {
        public float saldo;
        public float negativo;
        public float maximoExt = saldo + negativo

        
        public CuentaCorriente(float negativo) 
        {
            this.negativo = negativo
        }

        public void Extraer(float monto)
        {
            if(monto <= 0)
            {
                Console.WriteLine("Ingrese un monto valido")
                return
            }

            
            if(maximoExt < monto)
            {
                Console.WriteLine("No tienes suficiente dinero")
            } 
            else 
            {
                saldo -= monto 
            }
        }
    }
}