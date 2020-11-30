using MvcUserInterface.Models;
using MvcUserInterface.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace MvcUserInterface.Controllers
{
    public class TareaController : Controller
    {
        #region Metodos del controlador
        // GET: Es la pantalla inicial donde se listan las tareas
        public ActionResult Index(FormCollection formCollection)
        {
            try
            {
                MetodosHttp<Tarea> api = new MetodosHttp<Tarea>();
                MetodosHttp<ListaColaborador> apiColaborador = new MetodosHttp<ListaColaborador>();
                CargaCombos cargaCombos = new CargaCombos();
                ViewBag.Colaboradores = cargaCombos.ToSelectListColaboradores(apiColaborador.metodoGet("ListarColaboradores").colaborador);
                ViewBag.Prioridades = cargaCombos.ToSelectListPrioridades();
                ViewBag.Estados = cargaCombos.ToSelectListEstados();

                if (formCollection.Count > 0) { 
                    string colaboradorId = formCollection["ddlColaboradores"];
                    string estado = formCollection["ddlEstados"];
                    string prioridad = formCollection["ddlPrioridades"];
                    string fechaInicio = formCollection["FechaInicio"];
                    string fechaFin = formCollection["FechaFin"];
                    return View(api.metodoGet("ListarTareasFiltro/" + colaboradorId.ToString() + "/" + estado + "/" + prioridad + "/" + fechaInicio + "/" + fechaFin).tarea);
                }

                return View(api.metodoGet("ListarTareas").tarea);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return RedirectToAction("Index");
            }
        }

        // GET: Muestra la pantalla para agregar las tareas
        public ActionResult Agregar()
        {
            try
            {
                MetodosHttp<ListaColaborador> api = new MetodosHttp<ListaColaborador>();
                CargaCombos cargaCombos = new CargaCombos();
                ViewBag.Colaboradores = cargaCombos.ToSelectListColaboradoresDos(api.metodoGet("ListarColaboradores").colaborador);
                ViewBag.Prioridades = cargaCombos.ToSelectListPrioridadesDos();
                ViewBag.Estados = cargaCombos.ToSelectListEstadosDos();

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return RedirectToAction("Index");
            }
        }

        // POST: Se encarga de agregar la tarea
        [HttpPost]
        public ActionResult Agregar(ListaTarea tarea)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    MetodosHttp<ListaColaborador> apiColaboradores = new MetodosHttp<ListaColaborador>();
                    CargaCombos cargaCombos = new CargaCombos();
                    ViewBag.Colaboradores = cargaCombos.ToSelectListColaboradoresDos(apiColaboradores.metodoGet("ListarColaboradores").colaborador);
                    ViewBag.Prioridades = cargaCombos.ToSelectListPrioridadesDos();
                    ViewBag.Estados = cargaCombos.ToSelectListEstadosDos();

                    return View();
                }

                tarea.ColaboradorId = tarea.Colaborador.ColaboradorId;
                tarea.Colaborador = null;
                MetodosHttp<ListaTarea> api = new MetodosHttp<ListaTarea>();
                api.metodoPost("AgregarTarea", tarea);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return RedirectToAction("Index");
            }            
        }

        // GET: Muestra la pantalla para editar las tareas
        public ActionResult Editar(int id)
        {
            try
            {
                MetodosHttp<ListaColaborador> apiColaboradores = new MetodosHttp<ListaColaborador>();
                CargaCombos cargaCombos = new CargaCombos();
                ViewBag.Colaboradores = cargaCombos.ToSelectListColaboradoresDos(apiColaboradores.metodoGet("ListarColaboradores").colaborador);
                ViewBag.Prioridades = cargaCombos.ToSelectListPrioridadesDos();
                ViewBag.Estados = cargaCombos.ToSelectListEstadosDos();
                MetodosHttp<TareaEditar> api = new MetodosHttp<TareaEditar>();

                return View(api.metodoGet("ObtenerTarea/" + id.ToString()).tarea);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return RedirectToAction("Index");
            }
        }

        // POST: Se encarga de editar la tarea
        [HttpPost]
        public ActionResult Editar(ListaTarea tarea)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    MetodosHttp<ListaColaborador> apiColaboradores = new MetodosHttp<ListaColaborador>();
                    CargaCombos cargaCombos = new CargaCombos();
                    ViewBag.Colaboradores = cargaCombos.ToSelectListColaboradoresDos(apiColaboradores.metodoGet("ListarColaboradores").colaborador);
                    ViewBag.Prioridades = cargaCombos.ToSelectListPrioridadesDos();
                    ViewBag.Estados = cargaCombos.ToSelectListEstadosDos();

                    return View();
                }
                
                MetodosHttp<ListaTarea> api = new MetodosHttp<ListaTarea>();
                api.metodoPost("EditarTarea", tarea);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return RedirectToAction("Index");
            }
        }

        // GET: Se encarga de eliminar la tarea
        public ActionResult Eliminar(int id)
        {
            try
            {
                MetodosHttp<ListaColaborador> apiColaboradores = new MetodosHttp<ListaColaborador>();
                CargaCombos cargaCombos = new CargaCombos();
                ViewBag.Colaboradores = cargaCombos.ToSelectListColaboradores(apiColaboradores.metodoGet("ListarColaboradores").colaborador);
                ViewBag.Prioridades = cargaCombos.ToSelectListPrioridades();
                ViewBag.Estados = cargaCombos.ToSelectListEstados();
                MetodosHttp<TareaEditar> api = new MetodosHttp<TareaEditar>();
                TareaEditar tareaEditar =  api.metodoGet("EliminarTarea/" + id.ToString());

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}