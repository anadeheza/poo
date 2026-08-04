using Xunit;

namespace GestorTurnos.Tests
{
    public class ReglaNombreObligatorioTests
    {
        [Fact]
        public void EsValida_ConNombreVacio_DevuelveFalse()
        {
            var regla = new ReglaNombreObligatorio();
            var paciente = new Persona("", "30111222", "juan@mail.com");

            var esValida = regla.EsValida(paciente, out var error);

            Assert.False(esValida);
            Assert.Equal("El nombre del paciente es obligatorio.", error);
        }

        [Fact]
        public void EsValida_ConNombreValido_DevuelveTrue()
        {
            var regla = new ReglaNombreObligatorio();
            var paciente = new Persona("Juan Pérez", "30111222", "juan@mail.com");

            var esValida = regla.EsValida(paciente, out var error);

            Assert.True(esValida);
            Assert.Equal(string.Empty, error);
        }
    }

    public class ReglaDniValidoTests
    {
        [Theory]
        [InlineData("123")]
        [InlineData("")]
        public void EsValida_ConDniCorto_DevuelveFalse(string dni)
        {
            var regla = new ReglaDniValido();
            var paciente = new Persona("Juan Pérez", dni, "juan@mail.com");

            var esValida = regla.EsValida(paciente, out _);

            Assert.False(esValida);
        }

        [Fact]
        public void EsValida_ConDniValido_DevuelveTrue()
        {
            var regla = new ReglaDniValido();
            var paciente = new Persona("Juan Pérez", "30111222", "juan@mail.com");

            var esValida = regla.EsValida(paciente, out _);

            Assert.True(esValida);
        }
    }

    public class ReglaEmailValidoTests
    {
        [Fact]
        public void EsValida_SinArroba_DevuelveFalse()
        {
            var regla = new ReglaEmailValido();
            var paciente = new Persona("Juan Pérez", "30111222", "email-invalido");

            var esValida = regla.EsValida(paciente, out _);

            Assert.False(esValida);
        }

        [Fact]
        public void EsValida_ConEmailValido_DevuelveTrue()
        {
            var regla = new ReglaEmailValido();
            var paciente = new Persona("Juan Pérez", "30111222", "juan@mail.com");

            var esValida = regla.EsValida(paciente, out _);

            Assert.True(esValida);
        }
    }

    public class PacienteValidatorTests
    {
        private static PacienteValidator CrearValidadorCompleto()
        {
            return new PacienteValidator(new IReglaValidacionPaciente[]
            {
                new ReglaNombreObligatorio(),
                new ReglaDniValido(),
                new ReglaEmailValido(),
            });
        }

        [Fact]
        public void Validar_ConPacienteValido_DevuelveTrueYSinErrores()
        {
            var validador = CrearValidadorCompleto();
            var paciente = new Persona("Juan Pérez", "30111222", "juan@mail.com");

            var esValido = validador.Validar(paciente, out var errores);

            Assert.True(esValido);
            Assert.Empty(errores);
        }

        [Fact]
        public void Validar_ConVariosDatosInvalidos_AcumulaTodosLosErrores()
        {
            var validador = CrearValidadorCompleto();
            var paciente = new Persona("", "123", "email-invalido");

            var esValido = validador.Validar(paciente, out var errores);

            Assert.False(esValido);
            Assert.Equal(3, errores.Count);
        }
    }
}
