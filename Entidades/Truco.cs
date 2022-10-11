using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Truco
    {
        public static eTipoPartida partida;
        public static List<Carta> cartas;
        public static Equipo Azul;
        public static Equipo Rojo;
        public static Random r;
        public static List<Jugador> jugadores;
        public static Jugador j1;
        public static Jugador j2;
        public static Jugador j3;
        public static Jugador j4;
        public static Jugador j5;
        public static Jugador j6;
        static Truco()
        {
            cartas = new List<Carta>();
            jugadores = new List<Jugador>();
            Azul = new Equipo();
            Rojo = new Equipo();

            r = new Random();
            CrearCartas();
            Barajar();
        }

        public static void CantaronEnvido() { }
        public static void IniciarJuego(eTipoPartida e)
        {
            Truco.ListarJugadores(e);
            Truco.AsignarEquipoQueEmpieza();
            Truco.Repartir();
        }
        public static void AsignarEquipoQueEmpieza()
        {
            if (Azul.r.Next(1, 10) > Rojo.r.Next(1, 10)) {
                Azul.AsignarPosiciones(true);
                Rojo.AsignarPosiciones(false);
            } else {
                Azul.AsignarPosiciones(false);
                Rojo.AsignarPosiciones(true);
            }
            Azul.DeterminarRoles();
            Rojo.DeterminarRoles();
        }
        public static void ListarJugadores(eTipoPartida v) 
        {
            partida = v;
            if (partida == eTipoPartida.v1)
            {
                if (j1 != null) { Azul.miembros.Add(j1); }
                if (j2 != null) { Rojo.miembros.Add(j2); }
            }
            else if (partida == eTipoPartida.v2)
            {
                if (j1 != null) { Azul.miembros.Add(j1); }
                if (j2 != null) { Azul.miembros.Add(j2); }

                if (j3 != null) { Rojo.miembros.Add(j3); }
                if (j4 != null) { Rojo.miembros.Add(j4); }
            }
            else {
                if (j1 != null) { Azul.miembros.Add(j1); }
                if (j2 != null) { Azul.miembros.Add(j2); }
                if (j3 != null) { Azul.miembros.Add(j3); }
                
                if (j4 != null) { Rojo.miembros.Add(j4); }
                if (j5 != null) { Rojo.miembros.Add(j5); }
                if (j6 != null) { Rojo.miembros.Add(j6); }
            }
        }
        private static void Barajar()
        {
            List<int> x = new List<int>();
            string buf = "X: ";
            string v = "N° Cartas: ";
            foreach (var item in cartas)
            {
                x.Add(item.indexer);                
            }
            
            foreach (var item in cartas)
            {
                if(item.indexer == 0) { 
                    item.indexer = r.Next(1, 40); 
                    while (x.Contains(item.indexer))
                    {
                        item.indexer = r.Next(1, 41);                        
                    }
                    x.Add(item.indexer);
                    buf = buf + item.indexer + ",";
                    //Console.WriteLine(buf);
                }
                v = v + item.indexer + ",";
                //Console.WriteLine(v);
            }
            cartas = cartas.OrderBy(i => i.Numero).ToList();
            //Console.WriteLine(v);
        }
        private static void CrearCartas() {
            Carta e1 = new Carta(1, ePalo.Espada); cartas.Add(e1);
            Carta e2 = new Carta(2, ePalo.Espada); cartas.Add(e2);
            Carta e3 = new Carta(3, ePalo.Espada); cartas.Add(e3);
            Carta e4 = new Carta(4, ePalo.Espada); cartas.Add(e4);
            Carta e5 = new Carta(5, ePalo.Espada); cartas.Add(e5);
            Carta e6 = new Carta(6, ePalo.Espada); cartas.Add(e6);
            Carta e7 = new Carta(7, ePalo.Espada); cartas.Add(e7);
            Carta e10 = new Carta(10, ePalo.Espada); cartas.Add(e10);
            Carta e11 = new Carta(11, ePalo.Espada); cartas.Add(e11);
            Carta e12 = new Carta(12, ePalo.Espada); cartas.Add(e12);

            Carta b1 = new Carta(1, ePalo.Basto); cartas.Add(b1);
            Carta b2 = new Carta(2, ePalo.Basto); cartas.Add(b2);
            Carta b3 = new Carta(3, ePalo.Basto); cartas.Add(b3);
            Carta b4 = new Carta(4, ePalo.Basto); cartas.Add(b4);
            Carta b5 = new Carta(5, ePalo.Basto); cartas.Add(b5);
            Carta b6 = new Carta(6, ePalo.Basto); cartas.Add(b6);
            Carta b7 = new Carta(7, ePalo.Basto); cartas.Add(b7);
            Carta b10 = new Carta(10, ePalo.Basto); cartas.Add(b10);
            Carta b11 = new Carta(11, ePalo.Basto); cartas.Add(b11);
            Carta b12 = new Carta(12, ePalo.Basto); cartas.Add(b12);

            Carta o1 = new Carta(1, ePalo.Oro); cartas.Add(o1);
            Carta o2 = new Carta(2, ePalo.Oro); cartas.Add(o2);
            Carta o3 = new Carta(3, ePalo.Oro); cartas.Add(o3);
            Carta o4 = new Carta(4, ePalo.Oro); cartas.Add(o4);
            Carta o5 = new Carta(5, ePalo.Oro); cartas.Add(o5);
            Carta o6 = new Carta(6, ePalo.Oro); cartas.Add(o6);
            Carta o7 = new Carta(7, ePalo.Oro); cartas.Add(o7);
            Carta o10 = new Carta(10, ePalo.Oro); cartas.Add(o10);
            Carta o11 = new Carta(11, ePalo.Oro); cartas.Add(o11);
            Carta o12 = new Carta(12, ePalo.Oro); cartas.Add(o12);

            Carta c1 = new Carta(1, ePalo.Copa); cartas.Add(c1);
            Carta c2 = new Carta(2, ePalo.Copa); cartas.Add(c2);
            Carta c3 = new Carta(3, ePalo.Copa); cartas.Add(c3);
            Carta c4 = new Carta(4, ePalo.Copa); cartas.Add(c4);
            Carta c5 = new Carta(5, ePalo.Copa); cartas.Add(c5);
            Carta c6 = new Carta(6, ePalo.Copa); cartas.Add(c6);
            Carta c7 = new Carta(7, ePalo.Copa); cartas.Add(c7);
            Carta c10 = new Carta(10, ePalo.Copa); cartas.Add(c10);
            Carta c11 = new Carta(11, ePalo.Copa); cartas.Add(c11);
            Carta c12 = new Carta(12, ePalo.Copa); cartas.Add(c12);
        }
        private static Carta RepartirCarta(int i) {
            Carta c = null;
            foreach (var item in cartas)
            {
                if(item.indexer == i)
                {
                    cartas.Remove(item);
                    return item;
                }
            }
            return c;
        }
        private static void Repartir() {
            
            int c = 3;//3 Cartas x jugador
            int r = 0;
            if(partida == eTipoPartida.v1) {
                c = c * 2;
                for (int i = 1; i < c+1; i++)
                {
                    if ((i % 2) == 0) {
                        Rojo.miembros[0].mano.Add(Truco.RepartirCarta(i));
                    } else { Azul.miembros[0].mano.Add(Truco.RepartirCarta(i)); }
                }
            }
            else if(partida == eTipoPartida.v2) {
                c = c * 4;
                for (int i = 1; i < c + 1; i++)
                {
                    if ((i % 2) == 0)
                    {
                        Azul.miembros[r].mano.Add(Truco.RepartirCarta(i));
                        r++;
                    }
                    else { Rojo.miembros[r].mano.Add(Truco.RepartirCarta(i)); }
                    if (r == 2)
                    { r = 0; }
                }
            }
            else {
                c = c * 6;
                for (int i = 1; i < c + 1; i++)
                {
                    if (r == 1) {
                        j1.mano.Add(Truco.RepartirCarta(i)); r++; }
                    else if (r == 3) { Azul.miembros[i - 1].mano.Add(Truco.RepartirCarta(i)); r++; }
                    else if (r == 4) { Rojo.miembros[i - 1].mano.Add(Truco.RepartirCarta(i)); r++; }
                    else if (r == 5) { Azul.miembros[i - 1].mano.Add(Truco.RepartirCarta(i)); r++; }
                    else if (r == 6) { Rojo.miembros[i - 1].mano.Add(Truco.RepartirCarta(i)); r++; r = 1; }
                }
            }
        
        }
    }
}
