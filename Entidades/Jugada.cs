using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugada
    {
        public Jugador jugador;
        public Carta carta;
        public bool cantoEnvido;
        public bool cantoTruco;

        public Jugada(Jugador j, Carta c)
        {
            this.jugador = j; this.carta = c;
        }
        public Jugada(Jugador j, Carta c, bool env, bool truco): this(j, c)
        {
            this.cantoEnvido = env; this.cantoTruco = truco;
        }
    }
}
