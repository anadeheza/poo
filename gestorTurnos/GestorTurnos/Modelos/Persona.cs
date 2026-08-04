namespace GestorTurnos
{
    public class Persona
    {
        public string Nombre { get; }
        public string Dni { get; }
        public string Email { get; }

        public Persona(string nombre, string dni, string email)
        {
            Nombre = nombre;
            Dni = dni;
            Email = email;
        }
    }
}
