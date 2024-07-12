using ProyectoBiblioteca.Logica;
using ProyectoBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Xunit;

namespace ProyectoBiblioteca.Tests
{
    public class LibroLogicaTests
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
        public void Listar_DeberiaRetornarListaDeLibros()
        {
            // Arrange
            LibroLogica logica = LibroLogica.Instancia;

            // Act
            var listaLibros = logica.Listar();

            // Assert
            if (listaLibros == null)
            {
                Assert.Null(listaLibros); 
            }
            else
            {
                Assert.NotNull(listaLibros); 
                Assert.NotEmpty(listaLibros); 

                // Verifica cada libro en la lista
                foreach (var libro in listaLibros)
                {
                    Assert.NotNull(libro);
                    Assert.NotNull(libro.oAutor); 
                    Assert.NotNull(libro.oCategoria); 
                    Assert.NotNull(libro.oEditorial); 
                }
            }
        }

        [Fact]
        public void Registrar_DeberiaRegistrarNuevoLibro()
        {
            // Arrange
            LibroLogica logica = LibroLogica.Instancia;
            int uniqueNumber = GetUniqueRandomNumber();
            Libro nuevoLibro = new Libro

            {
                Titulo = $"Moby dick  {uniqueNumber}",
                RutaPortada = "C:\\Imagenes\\Libros",
                NombrePortada = "imagen.jpg",
                oAutor = new Autor { IdAutor = 2 }, // Debes proporcionar un IdAutor existente
                oCategoria = new Categoria { IdCategoria = 1 }, // Debes proporcionar un IdCategoria existente
                oEditorial = new Editorial { IdEditorial = 1 }, // Debes proporcionar un IdEditorial existente
                Ubicacion = "Estantería A",
                Ejemplares = 10,
                Estado = true
            };

            // Act
            int idLibroRegistrado = logica.Registrar(nuevoLibro);

            // Assert
            Assert.NotEqual(0, idLibroRegistrado); // Verifica que se haya registrado correctamente
        }

        [Fact]
        public void Modificar_DeberiaModificarLibroExistente()
        {
            // Arrange
            LibroLogica logica = LibroLogica.Instancia;
            Libro libroExistente = new Libro
            {
                IdLibro = 1, // Debes proporcionar un IdLibro existente
                Titulo = "Libro Modificado",
                oAutor = new Autor { IdAutor = 1 }, // Debes proporcionar un IdAutor existente
                oCategoria = new Categoria { IdCategoria = 1 }, // Debes proporcionar un IdCategoria existente
                oEditorial = new Editorial { IdEditorial = 1 }, // Debes proporcionar un IdEditorial existente
                Ubicacion = "Estantería B",
                Ejemplares = 10,
                Estado = true
            };

            // Act
            bool modificacionExitosa = logica.Modificar(libroExistente);

            // Assert
            Assert.True(modificacionExitosa);
        }

        [Fact]
        public void ActualizarRutaImagen_DeberiaActualizarRutaDeImagen()
        {
            // Arrange
            LibroLogica logica = LibroLogica.Instancia;
            Libro libro = new Libro
            {
                IdLibro = 2, // Debes proporcionar un IdLibro existente
                NombrePortada = "nuevo_nombre.jpg"
            };

            // Act
            bool actualizacionExitosa = logica.ActualizarRutaImagen(libro);

            // Assert
            Assert.True(actualizacionExitosa);
        }

        [Fact]
        public void Eliminar_DeberiaEliminarLibroExistente()
        {
            // Arrange
            LibroLogica logica = LibroLogica.Instancia;
            int idLibro = 3; // Debes proporcionar un IdLibro existente

            // Act
            bool eliminacionExitosa = logica.Eliminar(idLibro);

            // Assert
            Assert.True(eliminacionExitosa);
        }
    }
}
