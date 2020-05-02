using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DirectorTecnico : IPuntuar
    {
        public int Puntos { get; set; }
        public int Id { get; set; }
        public string NombreDeUsuario { get; set; }

        #region Opcion 1
        public Jugador Arquero { get; set; }
        public Jugador Delantero1 { get; set; }
        public Jugador Delantero2 { get; set; }

        #endregion

        #region Opcion 2
        public List<Jugador> Jugadores = new List<Jugador>();

        #endregion

        #region Opcion 3
        public enum Posicion
        {
            Arquero = 1,
            Delantero1 = 2,
            Delantero2 = 3
        }
        public Dictionary<Posicion, Jugador> JugadoresMap { get; set; }

        #endregion

        public int CalcularPuntaje()
        {
            //[Puntos batalla de los penales] = [Puntos de arquero] + [Puntos de delantero1] + [Puntos de delantero2]
            int puntajeTotal = 0;
            foreach (Jugador jug in Jugadores)
            {
                puntajeTotal += jug.CalcularPuntaje();
            }

            //forma resumida usando la expresion lambda Sum
            //int puntajeTotal = Jugadores.Sum(o => o.CalcularPuntaje());

            return puntajeTotal;
        }
    }
}
