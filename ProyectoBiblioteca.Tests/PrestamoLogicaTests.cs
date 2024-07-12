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
    public class PrestamoLogicaTests
    {
        [Fact]
        public void Registrar_DeberiaRegistrarPrestamo()
        {
            // Arrange
            var logica = PrestamoLogica.Instancia;
            var prestamo = new Prestamo
            {
                oEstadoPrestamo = new EstadoPrestamo { IdEstadoPrestamo = 2 }, // Reemplaza con un estado de préstamo válido en tu base de datos
                oPersona = new Persona { IdPersona = 3 }, // Reemplaza con un IdPersona existente en tu base de datos
                oLibro = new Libro { IdLibro = 1 }, // Reemplaza con un IdLibro existente en tu base de datos
                TextoFechaDevolucion = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy"), // Fecha de devolución dentro de una semana
                EstadoEntregado = "Entregado" // Ejemplo de EstadoEntregado
            };

            // Act
            bool resultado = logica.Registrar(prestamo);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void Existe_DeberiaVerificarExistenciaDePrestamo()
        {
            // Arrange
            var logica = PrestamoLogica.Instancia;
            var prestamo = new Prestamo
            {
                oPersona = new Persona { IdPersona = 3 }, // Reemplaza con un IdPersona existente en tu base de datos
                oLibro = new Libro { IdLibro = 1 } // Reemplaza con un IdLibro existente en tu base de datos
            };

            // Act
            bool existe = logica.Existe(prestamo);

            // Assert
            Assert.True(existe);
        }

        [Fact]
        public void ListarEstados_DeberiaRetornarListaDeEstados()
        {
            // Arrange
            var logica = PrestamoLogica.Instancia;

            // Act
            List<EstadoPrestamo> estados = logica.ListarEstados();

            // Assert
            Assert.NotNull(estados);
            Assert.NotEmpty(estados);
        }

        [Fact]
        public void Listar_DeberiaRetornarListaDePrestamos()
        {
            // Arrange
            var logica = PrestamoLogica.Instancia;
            int idEstadoPrestamo = 0; // Reemplaza con un IdEstadoPrestamo válido o deja 0 para todos los estados
            int idPersona = 0; // Reemplaza con un IdPersona válido o deja 0 para todos los usuarios

            // Act
            List<Prestamo> prestamos = logica.Listar(idEstadoPrestamo, idPersona);

            // Assert
            Assert.NotNull(prestamos);
            Assert.NotEmpty(prestamos);
        }

        [Fact]
        public void Devolver_DeberiaActualizarEstadoDePrestamo()
        {
            // Arrange
            var logica = PrestamoLogica.Instancia;
            int idPrestamo = 1; // Reemplaza con un IdPrestamo existente en tu base de datos
            string estadoRecibido = "Recibido"; // Ejemplo de EstadoRecibido

            // Act
            bool resultado = logica.Devolver(estadoRecibido, idPrestamo);

            // Assert
            Assert.True(resultado);
        }
    }
}
