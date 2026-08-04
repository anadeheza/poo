using System;
using System.Collections.Generic;
using Xunit;

namespace GestorTurnos.Tests
{
    public class TiposDeTurnoTests
    {
        // LSP: cualquier ITipoTurno se comporta de forma consistente:
        // un Nombre no vacío y un precio válido (>= 0). No hay casos
        // especiales ocultos entre las implementaciones.
        [Theory]
        [MemberData(nameof(TiposDeTurno))]
        public void ObtenerPrecio_DevuelveUnPrecioMayorOIgualACero(ITipoTurno tipo)
        {
            Assert.True(tipo.ObtenerPrecio() >= 0);
            Assert.False(string.IsNullOrWhiteSpace(tipo.Nombre));
        }

        public static IEnumerable<object[]> TiposDeTurno()
        {
            yield return new object[] { new TurnoNormal() };
            yield return new object[] { new TurnoUrgente() };
            yield return new object[] { new TurnoSeguimiento() };
        }

        [Fact]
        public void TurnoNormal_CobraElPrecioEsperado()
        {
            Assert.Equal(5000m, new TurnoNormal().ObtenerPrecio());
        }

        [Fact]
        public void TurnoUrgente_CobraElPrecioEsperado()
        {
            Assert.Equal(7500m, new TurnoUrgente().ObtenerPrecio());
        }

        [Fact]
        public void TurnoSeguimiento_CobraElPrecioEsperado()
        {
            Assert.Equal(3000m, new TurnoSeguimiento().ObtenerPrecio());
        }
    }

    public class TipoTurnoFactoryTests
    {
        private static TipoTurnoFactory CrearFactoryPorDefecto()
        {
            return new TipoTurnoFactory(new Dictionary<string, Func<ITipoTurno>>
            {
                ["Normal"] = () => new TurnoNormal(),
                ["Urgente"] = () => new TurnoUrgente(),
                ["Seguimiento"] = () => new TurnoSeguimiento(),
            });
        }

        [Fact]
        public void Crear_ConTipoRegistrado_DevuelveLaImplementacionCorrecta()
        {
            var factory = CrearFactoryPorDefecto();

            var tipo = factory.Crear("Urgente");

            Assert.IsType<TurnoUrgente>(tipo);
        }

        [Fact]
        public void Crear_ConTipoNoRegistrado_LanzaExcepcion()
        {
            var factory = CrearFactoryPorDefecto();

            Assert.Throws<TipoTurnoNoValidoException>(() => factory.Crear("Telemedicina"));
        }
    }
}
