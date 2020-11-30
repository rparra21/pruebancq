using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUserInterface.Models
{
    //Modelos para Colaborador
    public class ListaColaborador
    {
        public List<Colaborador> colaborador { get; set; }
    }
    public class Colaborador
    {
        public int ColaboradorId
        {
            get;
            set;
        }
        
        public string Nombre
        {
            get;
            set;
        }
    }
}