using System;
using Entidades;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Trucardi!");

            //CAMBIO A TENER CLASE EQUIPO
            //Hay q adaptar el metodo Repartir

            //jugadores + repartir testing
            Truco.j1 = new Jugador("Tino", eEquipo.Ellos);
            Truco.j2 = new Jugador("Yo", eEquipo.Nostros);
            Truco.j3 = new Jugador("Galle", eEquipo.Ellos);
            Truco.j4 = new Jugador("Pepe", eEquipo.Nostros);
            //Truco.j5 = new Jugador("Jr", eEquipo.Ellos);
            //Truco.j6 = new Jugador("Davi", eEquipo.Nostros);
            //Truco.Repartir(eTipoPartida.v1);

            //barajar testing
            //Truco.Barajar(Truco.cartas);
            //Carta c = Mazo.RepartirCarta(4);
            //Console.WriteLine((Truco.Repartir(1)).MostrarCarta());

            // Roles testing
            //Truco.IniciarJuego(eTipoPartida.v3);//OK
            Truco.IniciarJuego(eTipoPartida.v2);//OK
            //Truco.IniciarJuego(eTipoPartida.v1);//OK
            Console.WriteLine(Truco.Azul.MostrarJugadores());
            Console.WriteLine(Truco.Rojo.MostrarJugadores());

            //Truco.Repartir(eTipoPartida.v3);// OK
            //Console.WriteLine(Truco.j1.MostarMano());s
            //Console.WriteLine(Truco.j2.MostarMano());
            //Console.WriteLine(Truco.j3.MostarMano());
            //Console.WriteLine(Truco.j4.MostarMano());
            //Console.WriteLine(Truco.j5.MostarMano());
            //Console.WriteLine(Truco.j6.MostarMano());

            //Truco.Repartir(eTipoPartida.v2); // OK
            //Console.WriteLine(Truco.j1.MostarMano());
            //Console.WriteLine(Truco.j2.MostarMano());
            //Console.WriteLine(Truco.j3.MostarMano());
            //Console.WriteLine(Truco.j4.MostarMano());

            //Truco.Repartir(eTipoPartida.v3); //OK
            //Console.WriteLine(Truco.j1.MostarMano());
            //Console.WriteLine(Truco.j2.MostarMano());

            //auto-repartir testing OK
            //Truco.Repartir(eTipoPartida.v1);
            //Console.WriteLine(Truco.j1.MostarMano());
            //Console.WriteLine(Truco.j2.MostarMano());

            //envido testing OK
            //Carta b5 = new Carta(5, ePalo.Oro);
            //Carta b6 = new Carta(6, ePalo.Basto);
            //Carta b7 = new Carta(7, ePalo.Basto);
            //Carta b11 = new Carta(11, ePalo.Basto);
            //Truco.j1.mano.Add(b5);
            //Truco.j1.mano.Add(b11);
            //Truco.j1.mano.Add(b7);

            //Console.WriteLine(Truco.j1.MostarMano());
            //Console.WriteLine(Truco.j2.MostarMano());
            //Console.WriteLine(Truco.j1.CalcularEnvido());
            //Console.WriteLine(Truco.j2.CalcularEnvido());


        }
    }
}
