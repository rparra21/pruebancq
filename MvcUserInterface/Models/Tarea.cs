using MvcValidationExtensions.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcUserInterface.Models
{
    //Modelos para Tarea
    public class Tarea {
        public List<ListaTarea> tarea { get; set; }
    }
    public class TareaEditar
    {
        public ListaTarea tarea { get; set; }
    }
    public class ListaTarea
    {
        public int TareaId
        {
            get;
            set;
        }
        [Required(ErrorMessage = "La descripción es requerida.")]
        public string Descripcion
        {
            get;
            set;
        }
        public Colaborador Colaborador { get; set; }
        public int ColaboradorId { get; set; }

        public string Estado
        {
            get;
            set;
        }
        public string Prioridad
        {
            get;
            set;
        }
        [Required(ErrorMessage = "La fecha de inicio es requerida.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaInicio
        {
            get;
            set;
        }
        [GreaterThanEqualTo("FechaInicio", ErrorMessage = "La fecha fin debe ser igual o mayor a la fecha inicio")]
        [Required(ErrorMessage = "La fecha de fin es requerida.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Las notas son requeridas.")]
        public string Notas
        {
            get;
            set;
        }
    }

}