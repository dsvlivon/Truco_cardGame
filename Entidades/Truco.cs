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
        public static List<IAJugador> jugadores;

        static Truco()
        {
            cartas = new List<Carta>();
            jugadores = new List<IAJugador>();
            Azul = new Equipo();
            Rojo = new Equipo();

            r = new Random();
            CrearCartas();
            
            Barajar();
        }

        public static void CantaronEnvido() { }
        public static void IniciarJuego(eTipoPartida e)
        {
            CrearJugadores(e);
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
            bool flag = true;
            foreach (var item in jugadores)
            {
                if(flag){
                    item.equipo = eEquipo.Nostros;
                    Azul.miembros.Add(item);
                    flag = false; 
                } else {
                    item.equipo = eEquipo.Ellos;
                    Rojo.miembros.Add(item); 
                    flag = true; 
                }
            }
        }
        private static void Barajar()
        {
            List<int> x = new List<int>();
            //string buf = "X: ";
            //string aux = "N° Cartas: ";
            foreach (var item in cartas)
            {
                x.Add(item.indexer);
            }

            foreach (var item in cartas)
            {
                if (item.indexer == 0) {
                    item.indexer = r.Next(1, 40);
                    while (x.Contains(item.indexer))
                    {
                        item.indexer = r.Next(1, 41);
                    }
                    x.Add(item.indexer);
                    //buf = buf + item.indexer + ",";
                    //Console.WriteLine(buf);
                }
                //aux = aux + item.indexer + ",";
                //Console.WriteLine(aux);
            }
            cartas = cartas.OrderBy(i => i.Numero).ToList();
            //Console.WriteLine(aux);
        }
        private static Carta RepartirCarta(int i) {
            Carta c = null;
            foreach (var item in cartas)
            {
                if (item.indexer == i)
                {
                    cartas.Remove(item);
                    return item;
                }
            }
            return c;
        } 
        private static void Repartir() {
            int cartasXJugador = 3;
            int numeroJugador = 0;
            int jugadores = 0;

            if (partida == eTipoPartida.v1) { jugadores = 1;
            } else { jugadores = (partida == eTipoPartida.v2) ? 2 : 3; }
            cartasXJugador = cartasXJugador * (jugadores * 2);

            for (int i = 1; i < cartasXJugador +1; i++)
            {
                if ((i % 2) == 0) {
                    Rojo.miembros[numeroJugador].mano.Add(Truco.RepartirCarta(i));
                    numeroJugador++;
                } else { Azul.miembros[numeroJugador].mano.Add(Truco.RepartirCarta(i)); }
                if (numeroJugador == jugadores)
                { numeroJugador = 0; }
            }
        }
        public static void CalularPuntos() 
        {
            eEquipo RondaUno;
            eEquipo RondaDos;
            eEquipo RondaTres;
            

        }
        /////////////////////////////////////////
        private static void CrearCartas()
        {
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
        public static void CrearJugadores(eTipoPartida e)
        {
            partida = e;
            IAJugador x = new IAJugador("Angel", eEquipo.Nostros); Truco.jugadores.Add(x);//jugador p testear
            
            if (partida == eTipoPartida.v1) {
                AgregarBot(r.Next(1, 7));
            }
            else if (partida == eTipoPartida.v2)
            {
                for (int i = 0; i < 3; i++)
                {
                    AgregarBot(r.Next(1, 7));
                }
            } else
            {
                for (int i = 0; i < 4; i++)
                {
                    AgregarBot(r.Next(1, 7));
                }
            }            
        }
        private static void AgregarBot(int num) {            
            switch (num)
            {
                case 1:
                    IAJugador j1 = new IAJugador("Ogi", eEquipo.Ellos);
                    Truco.jugadores.Add(j1);
                    break;
                case 2:
                    IAJugador j2 = new IAJugador("Tino", eEquipo.Ellos);
                    Truco.jugadores.Add(j2);
                    break;
                case 3:
                    IAJugador j3 = new IAJugador("Galle", eEquipo.Ellos);
                    Truco.jugadores.Add(j3);
                    break;
                case 4:
                    IAJugador j4 = new IAJugador("Pepe", eEquipo.Ellos);
                    Truco.jugadores.Add(j4);
                    break;
                case 5:
                    IAJugador j5 = new IAJugador("Jr", eEquipo.Ellos);
                    Truco.jugadores.Add(j5);
                    break;
                case 6:
                    IAJugador j6 = new IAJugador("Davi", eEquipo.Ellos);
                    Truco.jugadores.Add(j6);
                    break;
                case 7:
                    IAJugador j7 = new IAJugador("Pipo", eEquipo.Ellos);
                    Truco.jugadores.Add(j7);
                    break;
                default:
                    break;
            }
        }
    }
}
