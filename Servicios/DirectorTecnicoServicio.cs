using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class DirectorTecnicoServicio
    {
        private static List<DirectorTecnico> Lista = new List<DirectorTecnico>();

        private static int GenerarId()
        {
            int proxId = 1;
            if (Lista.Count > 0)
            {
                proxId = Lista.Max(o => o.Id) + 1;
            }
            return proxId;
        }

        public static void Crear(DirectorTecnico dt, int idArquero, int idDelantero1, int idDelantero2)
        {
            dt.Id = GenerarId();

            Jugador arquero = JugadorServicio.ObtenerJugador(idArquero);
            Jugador delantero1 = JugadorServicio.ObtenerJugador(idDelantero1);
            Jugador delantero2 = JugadorServicio.ObtenerJugador(idDelantero2);
            dt.Arquero = arquero;
            dt.Delantero1 = delantero1;
            dt.Delantero2 = delantero2;
            dt.Jugadores.Add(arquero);
            dt.Jugadores.Add(delantero1);
            dt.Jugadores.Add(delantero2);

            dt.Puntos = dt.CalcularPuntaje();

            Lista.Add(dt);
        }

        public static List<DirectorTecnico> ObtenerTodos ()
        {
            return Lista.OrderBy(o => o.NombreDeUsuario).ToList();
        }

        public static DirectorTecnico ObtenerGanador()
        {
            int maxPuntaje = 0;
            DirectorTecnico ganador = null;
            foreach (var dt in Lista)
            {
                int puntajeDT = dt.CalcularPuntaje();
                if (puntajeDT > maxPuntaje)
                {
                    maxPuntaje = puntajeDT;
                    ganador = dt;
                }
            }

            return ganador;
        }
    }
}
