using ProyectoBiblioteca.Logica;
using ProyectoBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace ProyectoBiblioteca.Controllers
{
    public class PrestamoController : Controller
    {
        // GET: Prestamo
        public ActionResult Registrar()
        {
            return View();
        }

        public ActionResult Consultar()
        {
            return View();
        }

        public void EnviarCorreo(string destinatario, string asunto, string cuerpo)
        {
            // Configuración del cliente SMTP
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true, // Activar SSL/TLS
                Credentials = new NetworkCredential("librarybooks0509@gmail.com", "libr@ry12346789")
            };

            // Creación del mensaje
            var mailMessage = new MailMessage
            {
                From = new MailAddress("librarybooks0509@gmail.com"),
                Subject = asunto,
                Body = cuerpo,
                IsBodyHtml = true
            };

            mailMessage.To.Add("francisco121372@gmail.com");

            // Enviar el correo
            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar correo: {ex.Message}");
            }
        }

        [HttpPost]
        public JsonResult GuardarPrestamos(Prestamo objeto)
        {
            bool _respuesta = false;
            string _mensaje = string.Empty;

            _respuesta = PrestamoLogica.Instancia.Existe(objeto);

            if (_respuesta)
            {
                _respuesta = false;
                _mensaje = "El lector ya tiene un préstamo pendiente con el mismo libro";
            }
            else
            {
                _respuesta = PrestamoLogica.Instancia.Registrar(objeto);
                _mensaje = _respuesta ? "Registro completo" : "No se pudo registrar";

                if (_respuesta)
                {
                    try
                    {
                        EnviarCorreo("francisco121372@gmail.com", "Registro de Préstamo de Libro", "El préstamo del libro ha sido registrado correctamente.");
                        _mensaje += " y se ha enviado una notificación por correo.";
                    }
                    catch (Exception ex)
                    {
                        _mensaje += " pero no se pudo enviar la notificación por correo. Error: " + ex.Message;
                    }
                }
            }

            return Json(new { resultado = _respuesta, mensaje = _mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarEstados()
        {
            List<EstadoPrestamo> oLista = new List<EstadoPrestamo>();
            oLista = PrestamoLogica.Instancia.ListarEstados();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Listar(int idestadoprestamo, int idpersona)
        {
            List<Prestamo> oLista = new List<Prestamo>();
            oLista = PrestamoLogica.Instancia.Listar(idestadoprestamo, idpersona);
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Devolver(string estadorecibido, int idprestamo)
        {
            bool respuesta = false;
            respuesta = PrestamoLogica.Instancia.Devolver(estadorecibido, idprestamo);
            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}
