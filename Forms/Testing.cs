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
        public Testing()
        {
            InitializeComponent();
            Truco.IniciarJuego(eTipoPartida.v2);
            DeterminarPosiciones();
            SetInicialDeCartas();
        }
        
        private void btnCarta0_Click(object sender, EventArgs e)
        {
            Truco.Azul.miembros[0].JugarCarta(0);
            btnCarta0.Hide();
        }
        private void btnCarta1_Click(object sender, EventArgs e)
        {
            Truco.Azul.miembros[0].JugarCarta(1);
            btnCarta1.Hide();
            
        }
        private void btnCarta2_Click(object sender, EventArgs e)
        {
            Truco.Azul.miembros[0].JugarCarta(2);
            btnCarta2.Hide();
        }
        private void RevelarCarta0(Image image)
        {
            if (image != null)
            {
                if (playedCard0.BackgroundImage == null)
                {
                    playedCard0.Show();
                    playedCard0.BackgroundImageLayout = ImageLayout.Stretch;
                    playedCard0.BackgroundImage = image;
                }
                else if (playedCard1.BackgroundImage == null)
                {
                    playedCard1.Show();
                    playedCard1.BackgroundImageLayout = ImageLayout.Stretch;
                    playedCard1.BackgroundImage = image;
                }
                else
                {
                    playedCard2.Show();
                    playedCard2.BackgroundImageLayout = ImageLayout.Stretch;
                    playedCard2.BackgroundImage = image;
                }
            }else { }
        }
       
        private void DeterminarPosiciones()
        {
            //by defualt the player who shuffle and deal the cards it´s going to be the last player of each team.
            if (Truco.Azul.miembros[1].rol == eRoles.Pie)
            {
                RepartirMazo.Location = new Point(1110, 13);
            }
            else if (Truco.Rojo.miembros[1].rol == eRoles.Pie)
            {
                RepartirMazo.Location = new Point(660, 679);
            }
            rtbXXX.Text = Truco.Azul.MostrarJugadores() + "\n" + Truco.Rojo.MostrarJugadores();
        }
        private void TurnoX()
        {
            if (Truco.Rojo.empezar) {
                if (Truco.Rojo.miembros[0].mano.Count == 3)
                {
                    Carta c;
                    btnCarta0.Enabled = false; btnCarta1.Enabled = false; btnCarta2.Enabled = false;
                    //Truco.Rojo.miembros[0].JugarCarta(c = Truco.Rojo.miembros[0].IA.DecidirCartaParaPrimera());
                    button4.Hide();
                    //RevelarCarta(Image.FromFile(cards + Truco.Azul.miembros[0].mano[0].Numero.ToString() + Truco.Azul.miembros[0].mano[0].Palo + ".png"));
                    //RevelarCarta2(23,Image.FromFile(cards + c.Numero.ToString() + c.Palo + ".png"));
                }
            }
            else { }
        }
        public void SetInicialDeCartas()
        {
            Truco.Azul.miembros[0].CargarAcciones(playedCard0, playedCard1, playedCard2);
            Truco.Rojo.miembros[0].CargarAcciones(bot0Card0, bot0Card1, bot0Card2);
            if (Truco.partida != eTipoPartida.v1) { 
                Truco.Azul.miembros[1].CargarAcciones(bot1Card0, bot1Card1, bot1Card2);
                Truco.Rojo.miembros[1].CargarAcciones(bot2Card0, bot2Card1, bot2Card2);
                //if(Truco.partida == eTipoPartida.v3) {
                //    Truco.Azul.miembros[2].CargarAcciones(bot3Card0, bot3Card1, bot3Card2);
                //    Truco.Rojo.miembros[2].CargarAcciones(bot4Card0, bot4Card1, bot4Card2);
                //}
            }
            button4.BackgroundImage = Image.FromFile(SideBoard.dorso); button4.BackgroundImageLayout = ImageLayout.Stretch;
            button5.BackgroundImage = Image.FromFile(SideBoard.dorso); button5.BackgroundImageLayout = ImageLayout.Stretch;
            button6.BackgroundImage = Image.FromFile(SideBoard.dorso); button6.BackgroundImageLayout = ImageLayout.Stretch;
            button7.BackgroundImage = Image.FromFile(SideBoard.dorso); button7.BackgroundImageLayout = ImageLayout.Stretch;
            button8.BackgroundImage = Image.FromFile(SideBoard.dorso); button8.BackgroundImageLayout = ImageLayout.Stretch;
            button9.BackgroundImage = Image.FromFile(SideBoard.dorso); button9.BackgroundImageLayout = ImageLayout.Stretch;
            button10.BackgroundImage = Image.FromFile(SideBoard.dorso); button10.BackgroundImageLayout = ImageLayout.Stretch;
            button11.BackgroundImage = Image.FromFile(SideBoard.dorso); button11.BackgroundImageLayout = ImageLayout.Stretch;
            button12.BackgroundImage = Image.FromFile(SideBoard.dorso); button12.BackgroundImageLayout = ImageLayout.Stretch;

            btnCarta0.BackgroundImage = Truco.Azul.miembros[0].mano[0].frente; btnCarta0.BackgroundImageLayout = ImageLayout.Stretch;
            btnCarta1.BackgroundImage = Truco.Azul.miembros[0].mano[1].frente; btnCarta1.BackgroundImageLayout = ImageLayout.Stretch;
            btnCarta2.BackgroundImage = Truco.Azul.miembros[0].mano[2].frente; btnCarta2.BackgroundImageLayout = ImageLayout.Stretch;
        }
    } 
}
