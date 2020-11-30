using Microsoft.EntityFrameworkCore;
using RestApiBackend.ModelosTablasBaseDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiBackend
{
    //Clase que se encarga del contexto con la base de datos postgresql
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) { }
        
        //Se setean las tablas de la base de datos
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
    }
}
