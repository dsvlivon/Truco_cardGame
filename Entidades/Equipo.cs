using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        public List<IAJugador> miembros;
        public eEquipo equipo;
        public int puntos;
        public bool empezar;
        public Random r;

        public Equipo()
        {
            this.miembros = new List<IAJugador>();
            r = new Random();
        }

        public string MostrarJugadores()
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in this.miembros)
            {
                s.AppendLine(item.MostrarDatosJugador() + "\nMano: " + item.MostarMano());
            }
            return s.ToString();
        }
        public void AsignarPosiciones(bool x)
        {
            int i = 0;//empezar significa q juega primero, osea q el otro equipo reparte
            if (x) { i = 1; } else { i = 2; }
            this.empezar = x;
            foreach (var item in this.miembros)
            {
                item.turno = i;
                i = i + 2;
            }
        }
        public void DeterminarRoles()
        {
            foreach (var item in miembros)
            {
                if (item.turno == 1) { item.rol = eRoles.Mano; }
                else if (item.turno == 6) { item.rol = eRoles.Pie; }
                else if (item.turno == 5) { item.rol = eRoles.AntePie; }

                if (item.turno == 2)
                {
                    if (this.miembros.Count() == 1)
                    {
                        item.rol = eRoles.Pie;
                    }
                    else { item.rol = eRoles.Jugador; }// 1v1
                }

                if (item.turno == 3)
                {
                    if (this.miembros.Count() == 3)
                    {
                        item.rol = eRoles.Jugador; //3v3
                    }
                    else { item.rol = eRoles.AntePie; } //2v2
                }

                else if (item.turno == 4)
                {
                    if (this.miembros.Count() == 2) //2v2
                    {
                        item.rol = eRoles.Pie;
                    }
                    else { item.rol = eRoles.Jugador; } //3v3
                }
            }
        }        

    }
}
