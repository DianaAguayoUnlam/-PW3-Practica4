using Clase4_Intro_a_POO.Models;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clase4_Intro_a_POO.Controllers
{
    public class DirectorTecnicoController : Controller
    {

        private DirectorTecnicoAltaVM ObtenerDirectorTecnicoAltaVM()
        {
            List<Jugador> arqueros = JugadorServicio.ObtenerArqueros();
            List<Jugador> delanteros = JugadorServicio.ObtenerDelanteros();
            DirectorTecnicoAltaVM model = new DirectorTecnicoAltaVM();
            model.Arqueros = arqueros;
            model.Delanteros = delanteros;

            return model;
        }

        // GET: DirectorTecnico
        [HttpGet]
        public ActionResult Alta()
        {
            var model = ObtenerDirectorTecnicoAltaVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult Alta(DirectorTecnico dt)
        {
            Int32.TryParse(Request["IdArquero"], out int idArquero);
            Int32.TryParse(Request["idDelantero1"], out int idDelantero1);
            Int32.TryParse(Request["idDelantero2"], out int idDelantero2);

            DirectorTecnicoServicio.Crear(dt, idArquero, idDelantero1, idDelantero2);

            var model = ObtenerDirectorTecnicoAltaVM();
            return View(model);
        }

        public ActionResult Todos()
        {
            List<DirectorTecnico> DTs = DirectorTecnicoServicio.ObtenerTodos();
            


            return View(DTs);
        }


        /*5. **Pantalla Ganador del premio “batalla de los penales”**, visualizando:
            **DT Ganador:** [Nombre de usuario]
            **Puntos Totales:** [Puntos batalla de los penales]
            **Arquero:** [Apellido], [Nombre] ([Puntos de arquero])
            **Delantero1:** [Apellido], [Nombre] ([Puntos de delantero])
            **Delantero2:** [Apellido], [Nombre] ([Puntos de delantero])
         */

        public ActionResult Ganador() 
        {
            DirectorTecnico ganador = DirectorTecnicoServicio.ObtenerGanador();
                    
            return View(ganador);
        }

    }
}