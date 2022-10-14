using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class IAJugador:Jugador
    {
        public IAJugador(string n, eEquipo e):base(n,e) { }

        public Carta DecidirCartaParaPrimera()
        {
            Carta c = new Carta(0, ePalo.Comodin);
            foreach (var item in mano)
            {
                if(c.Valor == 0 || item.Valor > c.Valor)
                {
                    c = item;
                }
            }
            return c;
        }
    }
}
