using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApiBackend;
using RestApiBackend.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterfaceMvc.Controllers
{
    public class TareaController : Controller
    {
        static ILogger<WeatherForecastController> logger;
        static PostgreSqlContext context;

        WeatherForecastController api = new WeatherForecastController(logger, context);
        public IActionResult Index()
        {
            return View(api.ListarTareas());
        }
    }
}
