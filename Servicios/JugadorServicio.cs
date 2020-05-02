using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class JugadorServicio
    {
        private static List<Jugador> Lista = new List<Jugador>();

        private static int GenerarId()
        {
            int proxId = 1;
            if (Lista.Count > 0)
            {
                proxId = Lista.Max(o => o.Id) + 1;
            }
            return proxId;
        }

        public static List<Jugador> ObtenerArqueros()
        {
            List<Jugador> arqueros = new List<Jugador>();
            foreach (var jug in Lista)
            {
                if (jug is Arquero)
                {
                    arqueros.Add(jug);
                }
            }

            return arqueros.OrderBy(o=> o.Apellido).ThenBy(o=> o.Nombre).ToList();
        }

        public static Jugador ObtenerJugador(int id)
        {
            return Lista.Find(o => o.Id == id);
        }

        public static void Crear(Jugador jug)
        {
            jug.Id = GenerarId();
            jug.Puntos = jug.CalcularPuntaje();

            Lista.Add(jug);
        }




        // delantero 
        public static List<Jugador> ObtenerDelanteros()
        {
            List<Jugador> delanteros = new List<Jugador>();
            foreach (var jug in Lista)
            {
                if (jug is Delantero)
                {
                    delanteros.Add(jug);
                }
            }

            return delanteros.OrderBy(o=> o.Apellido).ThenBy(o=> o.Nombre).ToList();
        }
    }
}
