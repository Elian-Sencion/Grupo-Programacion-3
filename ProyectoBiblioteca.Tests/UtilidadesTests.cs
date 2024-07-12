using Moq;
using ProyectoBiblioteca.Logica;
using ProyectoBiblioteca.Models;
using System;
using System.IO;
using Xunit;
using Moq;

namespace ProyectoBiblioteca.Tests
{
    public class UtilidadesTests
    {

        [Fact]
        public void ConvertirBase64_DeberiaLanzarExcepcionSiRutaArchivoNoExiste()
        {
            // Arrange
            string rutaArchivo = "archivo_inexistente.txt";  // Una ruta que no existe

            // Act y Assert
            Assert.Throws<FileNotFoundException>(() => Utilidades.convertirBase64(rutaArchivo));
        }
    }
}
