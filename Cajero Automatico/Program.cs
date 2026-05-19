using System

namespace SistemaBancario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PRUEBA DE CAJA DE AHORRO ===\n");
            CajaDeAhorro ahorro = new CajaDeAhorro();
            ahorro.depositar(1000);
            ahorro.extraer(400);
            ahorro.extraer(800);
            ahorro.mostrarSaldo();
            
            Console.WriteLine("\n=== PRUEBA DE CUENTA CORRIENTE ===\n");
            CuentaCorriente corriente = new CuentaCorriente(500);
            corriente.depositar(200);
            corriente.extraer(600); 
            corriente.extraer(200); 
            corriente.mostrarSaldo(); 
            
            Console.WriteLine("\n=== PRUEBA DE BANCO ===\n");
            Banco banco = new Banco();
            CajaDeAhorro ahorro2 = new CajaDeAhorro();
            CuentaCorriente corriente2 = new CuentaCorriente(500);
            
            banco.agregarCuenta(ahorro2);
            banco.agregarCuenta(corriente2);
            
            ahorro2.depositar(1000);
            banco.transferir(ahorro2, corriente2, 300); 
            banco.transferir(ahorro2, corriente2, 900);
            
            Console.WriteLine("\nSaldo final de cuentas:");
            ahorro2.mostrarSaldo();
            corriente2.mostrarSaldo();
        }
    }
}