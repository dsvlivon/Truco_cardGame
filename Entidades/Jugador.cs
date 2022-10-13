using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador
    {
        public List<Carta> mano;
        public string nombre;
        public eEquipo equipo;
        public Random r;
        public int turno;
        public int envido;
        public eRoles rol;

        public Jugador(string n, eEquipo e)
        {
            this.equipo = e; this.nombre = n;
            r = new Random();
            this.turno = 0;
            mano = new List<Carta>();
        }
        public string MostarMano()
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in mano)
            {
                s.Append("["+item.MostrarCarta()+"] " );
            }
            return s.ToString();
        }
        public int CalcularEnvido() {
            int envido = 0;
            int auxEnvido = 0;
            if (mano[0].Palo == mano[1].Palo) {
                if (mano[0].Figura && !mano[1].Figura) { envido = mano[1].Numero + 20; }
                else if (!mano[0].Figura && mano[1].Figura) { envido = mano[0].Numero + 20; }
                else { envido = mano[0].Numero + mano[1].Numero + 20; }               
                
            } 
            if (mano[0].Palo == mano[2].Palo) {
                if (mano[0].Figura && !mano[2].Figura) { auxEnvido = mano[2].Numero + 20; }
                else if (!mano[0].Figura && mano[2].Figura) { auxEnvido = mano[0].Numero + 20; }
                else { auxEnvido = mano[0].Numero + mano[2].Numero + 20; }

                if (auxEnvido > envido) { envido = auxEnvido; }
            } 
            if (mano[2].Palo == mano[1].Palo) {
                if (mano[2].Figura && !mano[1].Figura) { auxEnvido = mano[1].Numero + 20; }
                else if (!mano[2].Figura && mano[1].Figura) { auxEnvido = mano[2].Numero + 20; }
                else { auxEnvido = mano[2].Numero + mano[1].Numero + 20; }

                if (auxEnvido > envido) { envido = auxEnvido; }
            }
            return envido;
        }
        public string MostrarDatosJugador()
        {
            return $"Nombre: {this.nombre}, Turno: {this.turno}, el {this.rol}";
        }

        public Carta JugarCarta(Carta c) {
            foreach (var item in mano)
            {
                if(c == item) { //mano.Remove(item);
                                return item; }
            } return null;
        }
    }
}
