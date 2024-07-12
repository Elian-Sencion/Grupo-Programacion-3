using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoBiblioteca.Logica;
using ProyectoBiblioteca.Models;
using Xunit;

namespace ProyectoBiblioteca.Tests
{
    public class CategoriaLogicaTests
    {
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

        [Fact]
        public void Eliminar_DeberiaEliminarCategoriaExistente()
        {
            // Arrange
            CategoriaLogica logica = CategoriaLogica.Instancia;
            Categoria categoria = new Categoria { IdCategoria = 4, Descripcion = "Categoría de Prueba", Estado = true };

            // Act
            bool eliminacionExitosa = logica.Eliminar(categoria.IdCategoria);

            // Assert
            Assert.True(eliminacionExitosa);
        }

        [Fact]
        public void Eliminar_NoDeberiaEliminarCategoriaInexistente()
        {
            // Arrange
            CategoriaLogica logica = CategoriaLogica.Instancia;
            int idCategoriaInexistente = 1; // ID que no existe en la base de datos

            // Act
            bool eliminacionExitosa = logica.Eliminar(idCategoriaInexistente);

            // Assert
            Assert.False(eliminacionExitosa);
        }

        [Fact]
        public void Registrar_DeberiaRegistrarNuevaCategoria()
        {
            // Arrange
            CategoriaLogica logica = CategoriaLogica.Instancia;
            int uniqueNumber = GetUniqueRandomNumber();
            Categoria nuevaCategoria = new Categoria { Descripcion = $"Nueva Categoría {uniqueNumber}", Estado = true };

            // Act
            bool registroExitoso = logica.Registrar(nuevaCategoria);

            // Assert
            Assert.True(registroExitoso);
        }

        [Fact]
        public void Registrar_NoDeberiaRegistrarCategoriaExistente()
        {
            // Arrange
            CategoriaLogica logica = CategoriaLogica.Instancia;
            Categoria categoriaExistente = new Categoria { IdCategoria = 15, Descripcion = "Categoría Existente", Estado = true };

            // Act
            bool registroExitoso = logica.Registrar(categoriaExistente);

            // Assert
            Assert.False(registroExitoso);
        }

        [Fact]
        public void Modificar_DeberiaModificarCategoriaExistente()
        {
            // Arrange
            CategoriaLogica logica = CategoriaLogica.Instancia;
            Categoria categoriaExistente = new Categoria { IdCategoria = 1, Descripcion = "Categoría Modificada", Estado = true };

            // Act
            bool modificacionExitosa = logica.Modificar(categoriaExistente);

            // Assert
            Assert.True(modificacionExitosa);
        }

        [Fact]
        public void Modificar_NoDeberiaModificarCategoriaInexistente()
        {
            // Arrange
            CategoriaLogica logica = CategoriaLogica.Instancia;
            Categoria categoriaInexistente = new Categoria { IdCategoria = 1, Descripcion = "Categoría Inexistente", Estado = true };

            // Act
            bool modificacionExitosa = logica.Modificar(categoriaInexistente);

            // Assert
            Assert.False(modificacionExitosa);
        }
    }
}
