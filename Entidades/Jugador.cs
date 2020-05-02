using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Jugador : IPuntuar    
    {
        public int Puntos { get; set; }
        public const int PUNTAJE_EXPULSADO = 50;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Expulsado { get; set; }


        public abstract int CalcularPuntaje();
    }
}
