using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Drawing.Imaging;

namespace TestingForm
{
    public partial class Testing : Form
    {
        Jugador jugador;
        Carta Uno; Carta Dos; Carta Tres;
        
        public Testing()
        {
            InitializeComponent();
            Truco.IniciarJuego(eTipoPartida.v2);
            jugador = Truco.RetornarJugador();
            Uno = jugador.mano[0]; Dos = jugador.mano[1]; Tres = jugador.mano[2];
            SetInicialDeCartas();
            DeterminarPosicionDelMazo();//NEED TO BE FIXED
            Truco.play = Truco.RetornarJugadorQueDebeJugar();
            txtTurno.Text = "Turno: " + Truco.turnoActual + "- " + Truco.play.nombre;
        }
        
        private void btnCarta0_Click(object sender, EventArgs e)
        {
            if (Truco.play == jugador) {
                //Truco.cartasJugadas.Add(Truco.play.JugarCarta(Uno));
                Truco.historial.Add(new Jugada(Truco.play, Truco.play.JugarCarta(Uno)));
                btnP0Carta0.Hide();
                Truco.turnoActual++;
                Truco.play = Truco.RetornarJugadorQueDebeJugar();
                txtTurno.Text = "Turno: " + Truco.turnoActual + " - " + Truco.play.nombre;
            } else { MessageBox.Show("Tranca Pa!... no te toca todavia... "); } 
        }
        private void btnCarta1_Click(object sender, EventArgs e)
        {
            if (Truco.play == jugador) {
                //Truco.cartasJugadas.Add(Truco.play.JugarCarta(Dos));
                Truco.historial.Add(new Jugada(Truco.play, Truco.play.JugarCarta(Dos)));
                btnP0Carta1.Hide();
                Truco.turnoActual++;
                Truco.play = Truco.RetornarJugadorQueDebeJugar();
                txtTurno.Text = "Turno: " + Truco.turnoActual + " - " + Truco.play.nombre;
        } else { MessageBox.Show("Tranca Pa!... no te toca todavia... "); }
}
        private void btnCarta2_Click(object sender, EventArgs e)
        {
            if (Truco.play == jugador) {
                //Truco.cartasJugadas.Add(Truco.play.JugarCarta(Tres));
                Truco.historial.Add(new Jugada(Truco.play, Truco.play.JugarCarta(Tres)));
                btnP0Carta2.Hide();
                Truco.turnoActual++;
                Truco.play = Truco.RetornarJugadorQueDebeJugar();
                txtTurno.Text = "Turno: " + Truco.turnoActual + " - " + Truco.play.nombre;
            } else { MessageBox.Show("Tranca Pa!... no te toca todavia... "); }
        }
        private void DeterminarPosicionDelMazo()
        {
            Jugador j = Truco.RetornarJugadorPie();
            RepartirMazo.Location = j.silla;
            rtbXXX.Text = Truco.MostrarJugadores();
        }
        public void SetInicialDeCartas()
        {
            int b = 0; int c = 0; int d = 0;
            switch (jugador.turno)
            {
                case 1: b = 2; c = 3; d = 4;
                    break;
                case 2: b = 3; c = 4; d = 1;
                    break;
                case 3: b = 4; c = 1; d = 2;
                    break;
                case 4: b = 1; c = 2; d = 3;
                    break;
                default:
                    break;
            }
            
            jugador.CargarControles(p0Card0, p0Card1, p0Card2, txtP0Nombre, new Point(1754, 462));
            btnP0Carta0.BackgroundImage = jugador.mano[0].frente; btnP0Carta0.BackgroundImageLayout = ImageLayout.Stretch;
            btnP0Carta1.BackgroundImage = jugador.mano[1].frente; btnP0Carta1.BackgroundImageLayout = ImageLayout.Stretch;
            btnP0Carta2.BackgroundImage = jugador.mano[2].frente; btnP0Carta2.BackgroundImageLayout = ImageLayout.Stretch;
            ////////////////////////////////////////////////////////////////////
            Truco.RetornarJugadorPorTurno(b).CargarControles(p1Card0, p1Card1, p1Card2, txtP1Nombre, new Point(1098, 12));
            Truco.RetornarJugadorPorTurno(c).CargarControles(p2Card0, p2Card1, p2Card2, txtP2Nombre, new Point(20, 236));
            Truco.RetornarJugadorPorTurno(d).CargarControles(p3Card0, p3Card1, p3Card2, txtP3Nombre, new Point(660, 682));
            ////////////////////////////////////////////////////////////////////
            btnP1Carta0.BackgroundImage = Image.FromFile(SideBoard.dorso); btnP1Carta0.BackgroundImageLayout = ImageLayout.Stretch;
            btnP1Carta2.BackgroundImage = Image.FromFile(SideBoard.dorso); btnP1Carta2.BackgroundImageLayout = ImageLayout.Stretch;
            btnP1Carta1.BackgroundImage = Image.FromFile(SideBoard.dorso); btnP1Carta1.BackgroundImageLayout = ImageLayout.Stretch;
            btnP2Carta0.BackgroundImage = Image.FromFile(SideBoard.dorso); btnP2Carta0.BackgroundImageLayout = ImageLayout.Stretch;
            btnP2Carta1.BackgroundImage = Image.FromFile(SideBoard.dorso); btnP2Carta1.BackgroundImageLayout = ImageLayout.Stretch;
            btnP2Carta2.BackgroundImage = Image.FromFile(SideBoard.dorso); btnP2Carta2.BackgroundImageLayout = ImageLayout.Stretch;
            btnP3Carta2.BackgroundImage = Image.FromFile(SideBoard.dorso); btnP3Carta2.BackgroundImageLayout = ImageLayout.Stretch;
            btnP3Carta1.BackgroundImage = Image.FromFile(SideBoard.dorso); btnP3Carta1.BackgroundImageLayout = ImageLayout.Stretch;
            btnP3Carta0.BackgroundImage = Image.FromFile(SideBoard.dorso); btnP3Carta0.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Truco.auxTurno = Truco.Jugar(Truco.jugadores.Count());
            txtTurno.Text = "Turno: " + Truco.turnoActual + " - " + Truco.play.nombre; 
        }
    } 
}
