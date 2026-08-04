using System;
using System.Collections.Generic;
using Xunit;

namespace GestorTurnos.Tests
{
    public class GestorTurnosTests
    {
        private static (GestorTurnos gestor, TurnoRepositoryFake repo, NotificadorFake notificador, ComprobanteFake comprobante)
            CrearGestor()
        {
            var validador = new PacienteValidator(new IReglaValidacionPaciente[]
            {
                new ReglaNombreObligatorio(),
                new ReglaDniValido(),
                new ReglaEmailValido(),
            });

            var factory = new TipoTurnoFactory(new Dictionary<string, Func<ITipoTurno>>
            {
                ["Normal"] = () => new TurnoNormal(),
                ["Urgente"] = () => new TurnoUrgente(),
                ["Seguimiento"] = () => new TurnoSeguimiento(),
            });

            var repo = new TurnoRepositoryFake();
            var notificador = new NotificadorFake();
            var comprobante = new ComprobanteFake();

            var gestor = new GestorTurnos(validador, factory, repo, notificador, comprobante);

            return (gestor, repo, notificador, comprobante);
        }

        [Fact]
        public void ProcesarTurno_ConDatosValidos_GuardaNotificaYMuestraComprobante()
        {
            var (gestor, repo, notificador, comprobante) = CrearGestor();

            gestor.ProcesarTurno("Juan Pérez", "30111222", "Normal", "juan.perez@mail.com");

            Assert.NotNull(repo.UltimoTurnoGuardado);
            Assert.Equal(5000m, repo.UltimoTurnoGuardado!.Precio);
            Assert.True(notificador.SeNotifico);
            Assert.True(comprobante.SeMostro);
        }

        [Fact]
        public void ProcesarTurno_ConNombreVacio_NoGuardaNiNotifica()
        {
            var (gestor, repo, notificador, comprobante) = CrearGestor();

            gestor.ProcesarTurno("", "123", "Normal", "email-invalido");

            Assert.Null(repo.UltimoTurnoGuardado);
            Assert.False(notificador.SeNotifico);
            Assert.False(comprobante.SeMostro);
        }

        [Fact]
        public void ProcesarTurno_ConTipoDeTurnoDesconocido_NoGuardaNiNotifica()
        {
            var (gestor, repo, notificador, comprobante) = CrearGestor();

            gestor.ProcesarTurno("Ana López", "35777888", "Telemedicina", "ana.lopez@mail.com");

            Assert.Null(repo.UltimoTurnoGuardado);
            Assert.False(notificador.SeNotifico);
            Assert.False(comprobante.SeMostro);
        }
    }
}
