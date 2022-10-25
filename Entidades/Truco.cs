using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static int cantDeCartas;
        public static int cantDeTurnos;
        public static int turnoActual;
        public static int auxTurno;
        public static Jugador play;
        public static Thread hilo;
        public static List<Carta> cartasJugadas;
        public static List<Jugada> historial;

        static Truco()
        {
            cartas = new List<Carta>();
            cartasJugadas = new List<Carta>();
            historial = new List<Jugada>();
            jugadores = new List<Jugador>();
            Azul = new Equipo();
            Rojo = new Equipo();
            r = new Random();
            CrearCartas();            
            Barajar();
            turnoActual = 1;
        }

        public static void IniciarJuego(eTipoPartida e)
        {
            CrearJugadores(e);
            Truco.AsignarEquipoQueEmpieza();
            Truco.AsignarRoles();
            Truco.Repartir();            
        }
        private static void Barajar()
        {
            List<int> x = new List<int>();
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
                }
            }
            cartas = cartas.OrderBy(i => i.Numero).ToList();
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
            cantDeCartas = 3 * jugadores.Count();
            cantDeTurnos = cantDeCartas;
            int indexJugador = 0;
            int contador = 0;

            for (int i = 1; i < cantDeCartas+1; i++)
            {
                jugadores[indexJugador].mano.Add(Truco.RepartirCarta(i));
                contador++;
                if (contador == 3) { contador = 0; indexJugador++; }
            }
        }
        public static string MostrarJugadores()
        {
            StringBuilder s1 = new StringBuilder();
            StringBuilder s2 = new StringBuilder();
            
            foreach (var item in jugadores)
            {
                if (item.equipo == eEquipo.Nostros)
                {
                    s1.AppendLine(item.MostrarDatosJugador() + "\nMano: " + item.MostarMano());
                }
                else { s2.AppendLine(item.MostrarDatosJugador() + "\nMano: " + item.MostarMano()); }
            }
            return "Nosotros: \n" + s1.ToString() + "\nEllos\n" + s2.ToString();
        }
        public static void AsignarEquipoQueEmpieza()
        {
            if (Truco.r.Next(1, 10) > Truco.r.Next(1, 10)) {
                Truco.AsignarTurnos(eEquipo.Nostros);
            } else { Truco.AsignarTurnos(eEquipo.Ellos); }
        }
        public static void AsignarTurnos(eEquipo e)
        {
            int nosotros = 0; int ellos = 0;
            if (e==eEquipo.Nostros) { nosotros = 1; ellos = 2; } else { nosotros = 2; ellos = 1; }
            foreach (var item in jugadores) {
                if(item.equipo == eEquipo.Nostros) { 
                    item.turno = nosotros;
                    nosotros = nosotros + 2;
                } else {
                    item.turno = ellos;
                    ellos = ellos+ 2;
                }
            }
            List<Jugador> SortedList = jugadores.OrderBy(o => o.turno).ToList();
            jugadores = SortedList;
        }
        public static void AsignarRoles()
        {
            foreach (var item in jugadores) {
                if (item.turno == 1) { item.rol = eRoles.Mano; }
                else if (item.turno == 6) { item.rol = eRoles.Pie; }
                else if (item.turno == 5) { item.rol = eRoles.AntePie; }

                if (item.turno == 2)
                {
                    if (partida == eTipoPartida.v1)
                    {
                        item.rol = eRoles.Pie;
                    }
                    else { item.rol = eRoles.Jugador; }// 3v3 y 2v2
                }
                if (item.turno == 3) 
                {
                    if (partida == eTipoPartida.v2)
                    {
                        item.rol = eRoles.AntePie; //2v2
                    }
                    else { item.rol = eRoles.Jugador; } //3v3
                }
                else if (item.turno == 4)
                {
                    if (partida == eTipoPartida.v2) //2v2
                    {
                        item.rol = eRoles.Pie;
                    }
                    else { item.rol = eRoles.Jugador; } //3v3
                }
            }
        }
        public static Jugador RetornarJugadorQueDebeJugar() {
            Jugador j = null;
            foreach (var item in jugadores)
            {
                if(item.turno == turnoActual) { j = item; }
            } return j;
        }
        public static Jugador RetornarJugador()
        {
            Jugador j = null;
            foreach (var item in jugadores)
            {
                if (!item.ia) { j = item; }
            }
            return j;
        }
        public static Jugador RetornarJugadorPie()
        {
            Jugador j = null;
            foreach (var item in jugadores)
            {
                if (item.rol == eRoles.Pie) { j = item; }
            }
            return j;
        }
        public static Jugador RetornarJugadorPorTurno(int i)
        {
            Jugador j = null;
            foreach (var item in jugadores)
            {
                if (i == item.turno) { j = item; }
            }
            return j;
        }
        public static int Jugar(int cont)
        {
            int acccionesActual = 0;
            for (int i = 0; i < cont; i++)
            {
                if (play is null)
                {
                    play = Truco.RetornarJugadorQueDebeJugar();
                }
                acccionesActual = play.acciones.Count();//para q era esto?
                if (play.ia)
                {
                    //Thread.Sleep(Truco.r.Next(500, 2000));
                    //cartasJugadas.Add(play.JugarCarta(play.IA.JugarCartaMasBaja()));
                    historial.Add(new Jugada(play, play.JugarCarta(play.IA.JugarCartaMasBaja())));
                } else
                {
                    return turnoActual;
                }
                Truco.turnoActual++;
                if(turnoActual > cont) { turnoActual = 1;
                    //evaluar puntos 1ra ronda
                    CalularPuntos();
                }
                play = null;
            }
            return cantDeTurnos;
        }
        /////////////////////////////////////////
        public static void CalularPuntos() {
            foreach (var item in historial)
            {
                /*yo se q el jugador s/ia tiene turnos 1,3,5 o bien 2,4,6 
                 ahi clavas un if para determinar cuales cartas son de un equipo y cuales d otro
                 */
            }
        }
        public static void CantaronEnvido() { }
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
            bool flag = false;
            Jugador x = new Jugador("Angel", eEquipo.Nostros);                
            Truco.jugadores.Add(x);//jugador p testear

            int cont = 0;
            if (partida == eTipoPartida.v1)
            {
                AgregarBot(r.Next(1, 7), eEquipo.Ellos);
            } else {
                if (partida == eTipoPartida.v2) { cont = 4; } else { cont = 6; }
                while (jugadores.Count() < cont)
                {
                    if (flag) { AgregarBot(r.Next(1, 10), eEquipo.Nostros); flag = false; }
                    else { AgregarBot(r.Next(1, 10), eEquipo.Ellos); flag = true; }
                }
            }             
        }
        private static void AgregarBot(int num, eEquipo e) {            
            switch (num)
            {
                case 1:
                    //Jugador j1 = new Jugador("Ogi", true);
                    //if (e == eEquipo.Nostros) { Truco.Azul.miembros.Add(j1); }
                    //else { Truco.Rojo.miembros.Add(j1); }
                    Jugador j1 = new Jugador("Ogi", true, e);
                    Truco.jugadores.Add(j1);
                    break;
                case 2:
                    Jugador j2 = new Jugador("Tino", true, e);
                    Truco.jugadores.Add(j2);
                    break;
                case 3:
                    Jugador j3 = new Jugador("Galle", true, e);
                    Truco.jugadores.Add(j3);
                    break;
                case 4:
                    Jugador j4 = new Jugador("Pepe", true, e);
                    Truco.jugadores.Add(j4);
                    break;
                case 5:
                    Jugador j5 = new Jugador("Jr", true, e);
                    Truco.jugadores.Add(j5);
                    break;
                case 6:
                    Jugador j6 = new Jugador("Davi", true, e);
                    Truco.jugadores.Add(j6);
                    break;
                case 7:
                    Jugador j7 = new Jugador("Pipo", true, e);
                     Truco.jugadores.Add(j7);
                    break;
                case 8:
                    Jugador j8 = new Jugador("Nelson", true, e);
                    Truco.jugadores.Add(j8);
                    break;
                case 9:
                    Jugador j9 = new Jugador("Vitu", true, e);
                    Truco.jugadores.Add(j9);
                    break;
                case 10:
                    Jugador j10 = new Jugador("Capi", true, e);
                    Truco.jugadores.Add(j10);
                    break;
                default:
                    break;
            }
        }
    }
}
