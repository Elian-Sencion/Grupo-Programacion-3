using ProyectoBiblioteca.Logica;
using ProyectoBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xunit;

namespace ProyectoBiblioteca.Tests
{
    public class TipoPersonaLogicaTests
    {
        [Fact]
        public void Listar_DeberiaRetornarListaDeTiposPersona()
        {
            // Arrange
            var logica = TipoPersonaLogica.Instancia;

            // Act
            List<TipoPersona> tiposPersona = logica.Listar();

            // Assert
            Assert.NotNull(tiposPersona);
            Assert.NotEmpty(tiposPersona);
        }
    }
}
