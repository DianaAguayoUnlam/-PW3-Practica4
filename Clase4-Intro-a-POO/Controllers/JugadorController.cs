using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clase4_Intro_a_POO.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        [HttpGet]
        public ActionResult AltaArquero()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaArquero(Arquero arquero)
        {
            JugadorServicio.Crear(arquero);
            //Request["PenalesAtajados"];
            return View();
        }




        // alta delantero
        [HttpGet]
        public ActionResult AltaDelantero()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AltaDelantero(Delantero delantero)
        {
            JugadorServicio.Crear(delantero);
            //Request["PenalesAtajados"];
            return View();
        }
    }
}