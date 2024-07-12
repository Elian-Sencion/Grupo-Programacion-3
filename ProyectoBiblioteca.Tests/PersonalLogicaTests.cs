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
    public class PersonaLogicaTests
    {
        private static Random random = new Random();
        private static List<int> usedNumbers = new List<int>();
        private int GetUniqueRandomNumber()
        {
            int number;
            do
            {
                number = random.Next(1, 201);
            } while (usedNumbers.Contains(number));

            usedNumbers.Add(number);
            return number;
        }

        [Fact]
        public void Registrar_DeberiaRetornarTrueAlRegistrarPersona()
        {
            // Arrange
            PersonaLogica logica = PersonaLogica.Instancia;
            int uniqueNumber = GetUniqueRandomNumber();
            Persona persona = new Persona
            {
                Nombre = "Juan",
                Apellido = "Perez",
                Correo = $"juan.perez{uniqueNumber}@example.com",
                Clave = "clave123",
                oTipoPersona = new TipoPersona { IdTipoPersona = 1 }, // Asignar el IdTipoPersona correspondiente
            };

            // Act
            bool resultado = logica.Registrar(persona);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void Modificar_DeberiaRetornarTrueAlModificarPersona()
        {
            // Arrange
            PersonaLogica logica = PersonaLogica.Instancia;
            Persona persona = new Persona
            {
                IdPersona = 1, // Reemplazar con el Id de la persona existente en tu base de datos
                Nombre = "Juan Modificado",
                Apellido = "Perez Modificado",
                Correo = "juan.perez.modificado@example.com",
                Clave = "nuevaclave123",
                oTipoPersona = new TipoPersona { IdTipoPersona = 1 }, // Reemplazar con el IdTipoPersona correspondiente
                Estado = true
            };

            // Act
            bool resultado = logica.Modificar(persona);

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void Listar_DeberiaRetornarListaDePersonas()
        {
            // Arrange
            PersonaLogica logica = PersonaLogica.Instancia;

            // Act
            var listaPersonas = logica.Listar();

            // Assert
            Assert.NotNull(listaPersonas);
            Assert.NotEmpty(listaPersonas);
        }

        [Fact]
        public void Eliminar_DeberiaEliminarPersona()
        {
            // Arrange
            PersonaLogica logica = PersonaLogica.Instancia;
            int idPersonaAEliminar = 1; // Reemplazar con el Id de la persona a eliminar

            // Act
            bool resultado = logica.Eliminar(idPersonaAEliminar);

            // Assert
            Assert.True(resultado);
        }
    }
}
