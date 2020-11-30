using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiBackend.ModelosTablasBaseDatos
{
    public class Colaborador
    {
        [Key]
        public int ColaboradorId
        {
            get;
            set;
        }
        [Required]
        public string Nombre
        {
            get;
            set;
        }
    }
}
