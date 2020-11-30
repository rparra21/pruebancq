using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiBackend.ModelosTablasBaseDatos
{
    public class Tarea
    {
        [Key]
        public int TareaId
        {
            get;
            set;
        }
        [Required]
        public string Descripcion
        {
            get;
            set;
        }

        public Colaborador Colaborador { get; set; }
        public int ColaboradorId { get; set; }

        [Required]
        public string Estado
        {
            get;
            set;
        }
        [Required]
        public string Prioridad
        {
            get;
            set;
        }
        [Required]
        public DateTime FechaInicio
        {
            get;
            set;
        }
        [Required]
        public DateTime FechaFin
        {
            get;
            set;
        }
        [Required]
        public string Notas
        {
            get;
            set;
        }
    }
}
