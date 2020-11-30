using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestApiBackend.ModelosTablasBaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace RestApiBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiTareaController : Controller
    {
        private readonly PostgreSqlContext _context;
        public IConfiguration Configuration { get; }
        private readonly ILogger<ApiTareaController> _logger;

        //Controlador
        public ApiTareaController(ILogger<ApiTareaController> logger, PostgreSqlContext context)
        {
            _logger = logger;
            _context = context;
        }

        #region Metodos expuestos por el Rest Api

        // GET: Index
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(new { estado = "Rest Api Funciona Correctamente"});
        }

        // GET: Metodo que se encarga de listar las tareas
        [HttpGet("ListarTareas")]
        public JsonResult ListarTareas()
        {
            try
            {
                List<Tarea> resultado = new List<Tarea>();
                resultado = _context.Tareas.OrderBy(x => x.FechaInicio).Include("Colaborador").ToList();

                if (resultado == null)
                {
                    return Json(new { tarea = "", codigoEstado = 404, mensaje = "Tareas no encontradas" });
                }

                return Json(new { tarea = resultado, codigoEstado = 200, mensaje = "Ok" });
            }
            catch (Exception ex)
            {
                return Json(new { tarea = "", codigoEstado = 500, mensaje = "Error al listar las tareas", excepcion = ex.Message });
            }
        }

        // GET: Metodo que se encarga de listar las tareas con los filtros enviados
        [HttpGet("ListarTareasFiltro/{colaboradorId}/{estado}/{prioridad}/{fechaInicio}/{fechaFin}")]
        public JsonResult ListarTareasFiltro(int colaboradorId, string estado, string prioridad, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                List<Tarea> resultado = new List<Tarea>();
                resultado = FiltrarTareas(colaboradorId, estado, prioridad, fechaInicio, fechaFin);

                if (resultado == null)
                {
                    return Json(new { tarea = "", codigoEstado = 404, mensaje = "Tareas no encontradas" });
                }

                return Json(new { tarea = resultado, codigoEstado = 200, mensaje = "Ok" });
            }
            catch (Exception ex)
            {
                return Json(new { tarea = "", codigoEstado = 500, mensaje = "Error al listar las tareas", excepcion = ex.Message });
            }

        }

        // POST: Metodo que se encarga de agregar una tarea
        [HttpPost("AgregarTarea")]
        public JsonResult AgregarTarea([FromBody] Tarea tarea)
        {
            try
            {
                _context.Tareas.Add(tarea);
                _context.SaveChanges();

                return Json(new { tarea = tarea, codigoEstado = 201, mensaje = "Tarea Agregada" });
            }
            catch (Exception ex)
            {
                return Json(new { tarea = "", codigoEstado = 500, mensaje = "Error al agregar la tarea", excepcion = ex.Message });
            }
        }

        // POST: Metodo que se encarga de editar una tarea
        [HttpPost("EditarTarea")]
        public JsonResult EditarTarea([FromBody] Tarea tarea)
        {
            try
            {
                Tarea tareaEditar = _context.Tareas.Find(tarea.TareaId);

                if (tareaEditar == null) {
                    return Json(new { tarea = "", codigoEstado = 404, mensaje = "Tarea no encontrada" });
                }

                tareaEditar.Descripcion = tarea.Descripcion;
                tareaEditar.ColaboradorId = tarea.ColaboradorId;
                tareaEditar.Estado = tarea.Estado;
                tareaEditar.Prioridad = tarea.Prioridad;
                tareaEditar.FechaInicio = tarea.FechaInicio;
                tareaEditar.FechaFin = tarea.FechaFin;
                tareaEditar.Notas = tarea.Notas;
                _context.SaveChanges();

                return Json(new { tarea = tareaEditar, codigoEstado = 200, mensaje = "Tarea Editada" });
            }
            catch (Exception ex)
            {
                return Json(new { tarea = "", codigoEstado = 500, mensaje = "Error al editar tarea", excepcion = ex.Message });
            }
        }

        // GET: Metodo que se encarga de obtener una tarea
        [HttpGet("ObtenerTarea/{id}")]
        public JsonResult ObtenerTarea(int id)
        {
            try
            {
                Tarea resultado = _context.Tareas.Where(x => x.TareaId == id).FirstOrDefault();

                if (resultado == null)
                {
                    return Json(new { tarea = "", codigoEstado = 404, mensaje = "Tarea no encontrada" });
                }

                return Json(new { tarea = resultado, codigoEstado = 200, mensaje = "Ok" });
            }
            catch (Exception ex)
            {
                return Json(new { tarea = "", codigoEstado = 500, mensaje = "Error al obtener la tarea", excepcion = ex.Message });
            }
 
        }

        // GET: Metodo que se encarga de eliminar una tarea
        [HttpGet("EliminarTarea/{id}")]
        public JsonResult EliminarTarea(int id)
        {
            try
            {
                Tarea resultado = _context.Tareas.Where(x => x.TareaId == id).FirstOrDefault();

                if (resultado == null)
                {
                    return Json(new { tarea = "", codigoEstado = 404, mensaje = "Tarea no encontrada" });
                }

                _context.Tareas.Remove(resultado);
                _context.SaveChanges();

                return Json(new { tarea = resultado, codigoEstado = 200, mensaje = "Ok" });
            }
            catch (Exception ex)
            {
                return Json(new { tarea = "", codigoEstado = 500, mensaje = "Error al eliminar la tarea", excepcion = ex.Message });
            }
        }

        // GET: Metodo que se encarga de listar los colaboradores
        [HttpGet("ListarColaboradores")]
        public JsonResult ListarColaboradores()
        {
            try
            {
                List<Colaborador> resultado = new List<Colaborador>();
                resultado = _context.Colaboradores.ToList();

                if (resultado == null)
                {
                    return Json(new { tarea = "", codigoEstado = 404, mensaje = "Colaboradores no encontrados" });
                }

                return Json(new { colaborador = resultado, codigoEstado = 200, mensaje = "Ok" });
            }
            catch (Exception ex)
            {
                return Json(new { colaborador = "", codigoEstado = 500, mensaje = "Error al listar los colaboradores", excepcion = ex.Message });
            }
        }
        #endregion  

        //Metodo que se encarga de filtrar las tareas
        public List<Tarea> FiltrarTareas(int colaboradorId, string estado, string prioridad, DateTime fechaInicio, DateTime fechaFin) {

            List<Tarea> resultado = new List<Tarea>();
            if (colaboradorId == 0 && estado == "Todos" && prioridad == "Todos")
            {

                resultado = _context.Tareas.Where(x => x.FechaInicio >= fechaInicio &&
                                                       x.FechaFin <= fechaFin).OrderBy(x => x.FechaInicio).Include("Colaborador").ToList();
            }
            else if (colaboradorId == 0 && estado == "Todos" && prioridad != "Todos")
            {
                resultado = _context.Tareas.Where(x => x.Prioridad == prioridad && x.FechaInicio >= fechaInicio &&
                                                       x.FechaFin <= fechaFin).OrderBy(x => x.FechaInicio).Include("Colaborador").ToList();
            }

            else if (colaboradorId == 0 && estado != "Todos" && prioridad == "Todos")
            {
                resultado = _context.Tareas.Where(x => x.Estado == estado && x.FechaInicio >= fechaInicio &&
                                                       x.FechaFin <= fechaFin).OrderBy(x => x.FechaInicio).Include("Colaborador").ToList();
            }

            else if (colaboradorId != 0 && estado == "Todos" && prioridad == "Todos")
            {
                resultado = _context.Tareas.Where(x => x.ColaboradorId == colaboradorId && x.FechaInicio >= fechaInicio &&
                                                       x.FechaFin <= fechaFin).OrderBy(x => x.FechaInicio).Include("Colaborador").ToList();
            }

            else if (colaboradorId != 0 && estado != "Todos" && prioridad == "Todos")
            {
                resultado = _context.Tareas.Where(x => x.ColaboradorId == colaboradorId && x.Estado == estado && x.FechaInicio >= fechaInicio &&
                                                       x.FechaFin <= fechaFin).OrderBy(x => x.FechaInicio).Include("Colaborador").ToList();
            }

            else if (colaboradorId != 0 && estado == "Todos" && prioridad != "Todos")
            {
                resultado = _context.Tareas.Where(x => x.ColaboradorId == colaboradorId && x.Prioridad == prioridad && x.FechaInicio >= fechaInicio &&
                                                       x.FechaFin <= fechaFin).OrderBy(x => x.FechaInicio).Include("Colaborador").ToList();
            }
            else if (colaboradorId == 0 && estado != "Todos" && prioridad != "Todos")
            {
                resultado = _context.Tareas.Where(x => x.Estado == estado && x.Prioridad == prioridad && x.FechaInicio >= fechaInicio &&
                                                       x.FechaFin <= fechaFin).OrderBy(x => x.FechaInicio).Include("Colaborador").ToList();
            }

            return resultado;
        }
    }
}
