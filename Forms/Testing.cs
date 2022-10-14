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
        public string basePath = "C:\\Users\\L54556\\OneDrive - Kimberly-Clark\\Desktop\\Truco\\Media\\"; //this need to change
        public string dorso;
        public string cards;


        public Testing()
        {
            InitializeComponent();

            dorso = basePath + "dorsos\\dorso0.jpg";
            cards = basePath + "cartas asart\\";

            Truco.IniciarJuego(eTipoPartida.v2);
            DeterminarPosiciones();


            btnCarta0.BackgroundImage = Image.FromFile(cards + Truco.Azul.miembros[0].mano[0].Numero.ToString() + Truco.Azul.miembros[0].mano[0].Palo + ".png");
            btnCarta0.BackgroundImageLayout = ImageLayout.Stretch;
            btnCarta1.BackgroundImage = Image.FromFile(cards + Truco.Azul.miembros[0].mano[1].Numero.ToString() + Truco.Azul.miembros[0].mano[1].Palo + ".png");
            btnCarta1.BackgroundImageLayout = ImageLayout.Stretch;
            btnCarta2.BackgroundImage = Image.FromFile(cards + Truco.Azul.miembros[0].mano[2].Numero.ToString() + Truco.Azul.miembros[0].mano[2].Palo + ".png");
            btnCarta2.BackgroundImageLayout = ImageLayout.Stretch;

            playedCard0.Hide();
            playedCard1.Hide();
            playedCard2.Hide();
            bot0Card0.Hide();
            bot0Card1.Hide();
            bot0Card2.Hide();
            bot1Card0.Hide();
            bot1Card1.Hide();
            bot1Card2.Hide();
            bot2Card0.Hide();
            bot2Card1.Hide();
            bot2Card2.Hide();

            button4.BackgroundImage = Image.FromFile(dorso); button4.BackgroundImageLayout = ImageLayout.Stretch;
            button5.BackgroundImage = Image.FromFile(dorso); button5.BackgroundImageLayout = ImageLayout.Stretch;
            button6.BackgroundImage = Image.FromFile(dorso); button6.BackgroundImageLayout = ImageLayout.Stretch;
            button7.BackgroundImage = Image.FromFile(dorso); button7.BackgroundImageLayout = ImageLayout.Stretch;
            button8.BackgroundImage = Image.FromFile(dorso); button8.BackgroundImageLayout = ImageLayout.Stretch;
            button9.BackgroundImage = Image.FromFile(dorso); button9.BackgroundImageLayout = ImageLayout.Stretch;
            button10.BackgroundImage = Image.FromFile(dorso); button10.BackgroundImageLayout = ImageLayout.Stretch;
            button11.BackgroundImage = Image.FromFile(dorso); button11.BackgroundImageLayout = ImageLayout.Stretch;
            button12.BackgroundImage = Image.FromFile(dorso); button12.BackgroundImageLayout = ImageLayout.Stretch;

            playedCard0.BackgroundImage = null;
            playedCard1.BackgroundImage = null;
            playedCard2.BackgroundImage = null;
            bot0Card0.BackgroundImage = null;
            bot0Card1.BackgroundImage = null;
            bot0Card2.BackgroundImage = null;
            bot1Card0.BackgroundImage = null;
            bot1Card1.BackgroundImage = null;
            bot1Card2.BackgroundImage = null;
            bot2Card0.BackgroundImage = null;
            bot2Card1.BackgroundImage = null;
            bot2Card2.BackgroundImage = null;

            //TurnoX();
        }
        private void btnCarta0_Click(object sender, EventArgs e)
        {
            //playedCard2.Show();
            //playedCard2.BackgroundImageLayout = ImageLayout.Stretch;
            //playedCard2.BackgroundImage = btnCarta2.BackgroundImage;
            //Truco.Azul.miembros[0].JugarCarta(new Carta(Truco.Azul.miembros[0].mano[2].Numero, Truco.Azul.miembros[0].mano[2].Palo));
            //btnCarta2.Hide();
            Truco.Azul.miembros[0].JugarCarta(new Carta(Truco.Azul.miembros[0].mano[0].Numero, Truco.Azul.miembros[0].mano[0].Palo));
            btnCarta0.Hide();
            RevelarCarta(btnCarta0.BackgroundImage);
        }
        private void btnCarta1_Click(object sender, EventArgs e)
        {
            Truco.Azul.miembros[0].JugarCarta(new Carta(Truco.Azul.miembros[0].mano[1].Numero, Truco.Azul.miembros[0].mano[1].Palo));
            btnCarta1.Hide();
            RevelarCarta(btnCarta1.BackgroundImage);
        }
        private void btnCarta2_Click(object sender, EventArgs e)
        {
            Truco.Azul.miembros[0].JugarCarta(new Carta(Truco.Azul.miembros[0].mano[2].Numero, Truco.Azul.miembros[0].mano[2].Palo));
            btnCarta2.Hide();
            RevelarCarta2(12,btnCarta2.BackgroundImage);
        }
        private void RevelarCarta(Image image)
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
        }
        private void RevelarCarta2(int i, Image image)
        {
            if (this.Controls[i].BackgroundImage == null)
            {
                this.Controls[i].Show();
                this.Controls[i].BackgroundImageLayout = ImageLayout.Stretch;
                this.Controls[i].BackgroundImage = image;
            }            
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
                    Truco.Rojo.miembros[0].JugarCarta(c = Truco.Rojo.miembros[0].DecidirCartaParaPrimera());
                    button4.Hide();
                    //RevelarCarta(Image.FromFile(cards + Truco.Azul.miembros[0].mano[0].Numero.ToString() + Truco.Azul.miembros[0].mano[0].Palo + ".png"));
                    RevelarCarta2(23,Image.FromFile(cards + c.Numero.ToString() + c.Palo + ".png"));
                }
            }
            else { }
        }


    } 
}
