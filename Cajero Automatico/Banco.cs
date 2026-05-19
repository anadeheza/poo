using System;

namespace SistemaBancario
{
    public class Banco
    {

        private List<CuentaBancaria> cuentas = new List<CuentaBancaria>()

        public void AgregarCuenta(CuentaBancaria cuenta) 
        {
            cuentas.Add(cuenta)
            Console.WriteLine("cuenta agregada")
        }

        public void cuentaRegistrada(CuentaBancaria cuenta)
        {
            return cuentas.Contains(cuenta)
        }

        public void transferir(CuentaBancaria origen, CuentaBancaria destino, float monto)
        {

            if(monto <= 0)
            {
                Console.WriteLine("Ingrese un monto valido")
            }
            else if(!cuentaRegistrada(origen) || !cuentaRegistrada(destino))
            {
                Console.WriteLine("Verifique que ambas cuentas existen")
            }
        
            float saldoOrigen = origen.saldo

            try
            {
                if(origen is CajaDeAhorro && monto > origen.saldo)
                {
                    Console.WriteLine($"Saldo insuficiente")
                    return
                }

                if(origen is CuentaCorriente && monto > origen.maximoExt)
                {
                    Console.WriteLine($"Saldo insufisciente")
                    return
                }
            }

            if(RealizarExtraccion(origen, monto))
            {
                destino.Depositar(monto)
                Console.WriteLine($"Transferencia de {monto} exitosa")
            }
            else 
            {
                Console.WriteLine($"Transferencia de {monto} rechazada")
            }
        }
        catch (Exception err)
        {
            Console.WriteLine($"Error {err.Message}")
        }
    }

    public bool RealizarExtraccion(CuentaBancaria cuenta, float monto)
    {
        if(cuenta is CajaDeAhorro)
        {
            if(monto > cuenta.saldo)
                return false

            cuenta.saldo -= monto
            Console.WriteLine($"Extracción exitosa de {monto:C} de Caja de Ahorro. Nuevo saldo: {cuenta.saldo:C}");
            return true 
        }
        else if (cuenta is CuentaCorriente)
        {
            if(monto > cuenta.maximoExt)
                return false
           
            cuenta.saldo -= monto
            Console.WriteLine($"Extracción exitosa de {monto:C} de Caja de Ahorro. Nuevo saldo: {cuenta.saldo:C}");
            return true 
        }

        return false 
    }
}