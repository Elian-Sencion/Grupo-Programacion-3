using ProyectoBiblioteca.Logica;
using ProyectoBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProyectoBiblioteca.Tests
{
    public class ConexionTests
    {
        [Fact]
        public void CN_DeberiaTenerCadenaDeConexionCorrecta()
        {
            // Arrange
            string expectedConnectionString = "Data Source=DESKTOP-4JMMD2F;Initial Catalog=DB_BIBLIOTECA;User ID=sa;Password=Escuela10";

            // Act
            string actualConnectionString = Conexion.CN;

            // Assert
            Assert.Equal(expectedConnectionString, actualConnectionString);
        }
    }
}
