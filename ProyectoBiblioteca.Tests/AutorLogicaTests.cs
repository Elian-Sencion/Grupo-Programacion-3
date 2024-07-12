using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoBiblioteca.Logica;
using ProyectoBiblioteca.Models;
using Moq;
using Xunit;



namespace ProyectoBiblioteca.Tests
{
    public class AutorLogicaTests
    {
        private AutorLogica _autorLogica;
                private static Random random = new Random();
        private static List<int> usedNumbers = new List<int>();
        private int GetUniqueRandomNumber()
        {
            int number;
            do
            {
                number = random.Next(1, 201); // Generar un número aleatorio entre 1 y 200
            } while (usedNumbers.Contains(number)); // Repetir si el número ya ha sido utilizado

            usedNumbers.Add(number); // Agregar el número a la lista de números usados
            return number;
        }


        public AutorLogicaTests()
        {
            _autorLogica = AutorLogica.Instancia;
        }

        [Fact]
        public void Registrar_AutorValido_RetornaVerdadero()
        {
            // Arrange
            int uniqueNumber = GetUniqueRandomNumber();
            var autor = new Autor { Descripcion = $"Autor de prueba  {uniqueNumber}" };

            // Act
            var resultado = _autorLogica.Registrar(autor);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void Modificar_AutorValido_RetornaVerdadero()
        {
            // Arrange
            var autor = new Autor { IdAutor = 1, Descripcion = "Autor modificado", Estado = true };

            // Act
            var resultado = _autorLogica.Modificar(autor);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void Listar_CuandoSeInvoca_RetornaListaDeAutores()
        {
            // Act
            var lista = _autorLogica.Listar();

            // Assert
            Assert.NotNull(lista);
            Assert.IsType<List<Autor>>(lista);
        }

        [Fact]
        public void Eliminar_DeberiaEliminarAutorExistente()
        {
            // Arrange
            int idAutorAEliminar = 7;
            bool resultadoEsperado = true;

            // Act
            var resultado = _autorLogica.Eliminar(idAutorAEliminar);

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}