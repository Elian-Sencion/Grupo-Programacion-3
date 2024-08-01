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
    public class EditorialLogicaTests
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
        public void Registrar_DeberiaRegistrarNuevaEditorial()
        {
            // Arrange
            EditorialLogica logica = EditorialLogica.Instancia;
            int uniqueNumber = GetUniqueRandomNumber();
            Editorial nuevaEditorial = new Editorial { Descripcion = $"Nueva Editorial  {uniqueNumber}", Estado = true };

            // Act
            bool registroExitoso = logica.Registrar(nuevaEditorial);

            // Assert
            Assert.True(registroExitoso);
        }

        [Fact]
        public void Modificar_DeberiaModificarEditorialExistente()
        {
            // Arrange
            EditorialLogica logica = EditorialLogica.Instancia;
            Editorial editorialExistente = new Editorial { IdEditorial = 1, Descripcion = "Editorial Matrix", Estado = true };

            // Act
            bool modificacionExitosa = logica.Modificar(editorialExistente);

            // Assert
            Assert.True(modificacionExitosa);
        }

        [Fact]
        public void Modificar_NoDeberiaModificarEditorialInexistente()
        {
            // Arrange
            EditorialLogica logica = EditorialLogica.Instancia;
            int idInexistente = 9999; // Un ID que sabemos que no existe
            Editorial editorialInexistente = new Editorial { IdEditorial = idInexistente, Descripcion = "Editorial Inexistente", Estado = true };

            // Act
            bool modificacionExitosa = logica.Modificar(editorialInexistente);

            // Assert
            Assert.False(modificacionExitosa);
        }

        [Fact]
        public void Listar_DeberiaRetornarListaDeEditoriales()
        {
            // Arrange
            EditorialLogica logica = EditorialLogica.Instancia;

            // Act
            List<Editorial> listaEditoriales = logica.Listar();

            // Assert
            Assert.NotNull(listaEditoriales);
            Assert.NotEmpty(listaEditoriales);
        }

        [Fact]
        public void Eliminar_DeberiaEliminarEditorialExistente()
        {
            // Arrange
            EditorialLogica logica = EditorialLogica.Instancia;
            int idEditorialExistente = 3;

            // Act
            bool eliminacionExitosa = logica.Eliminar(idEditorialExistente);

            // Assert
            Assert.True(eliminacionExitosa);
        }

        [Fact]
        public void Eliminar_NoDeberiaEliminarEditorialInexistente()
        {
            // Arrange
            EditorialLogica logica = EditorialLogica.Instancia;
            int idEditorialInexistente = 1;

            // Act
            bool eliminacionExitosa = logica.Eliminar(idEditorialInexistente);

            // Assert
            Assert.False(eliminacionExitosa);
        }
    }
}
