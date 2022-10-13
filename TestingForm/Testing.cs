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
        public string basePath = "C:\\Users\\L54556\\OneDrive - Kimberly-Clark\\Desktop\\Truco\\Media\\";
        public string dorso;
        public string cards;



        public Testing()
        {
            dorso = basePath + "dorsos\\dorso0.jpg";
            cards = basePath + "cartas asart\\";
            InitializeComponent();
            Truco.j1 = new Jugador("Tino", eEquipo.Ellos);
            Truco.j2 = new Jugador("Yo", eEquipo.Nostros);
            Truco.j3 = new Jugador("Galle", eEquipo.Ellos);
            Truco.j4 = new Jugador("Pepe", eEquipo.Nostros);
            Truco.j5 = new Jugador("Jr", eEquipo.Ellos);
            Truco.j6 = new Jugador("Davi", eEquipo.Nostros);
            Truco.IniciarJuego(eTipoPartida.v3);

            richTextBox1.Text = button4.BackgroundImage.ToString();
            //button7.BackgroundImage =
            //path = "";

            string a = Truco.Azul.miembros[0].mano[0].Numero.ToString()+ Truco.Azul.miembros[0].mano[0].Palo;
            string s = Truco.Azul.miembros[0].mano[1].Numero.ToString() + Truco.Azul.miembros[0].mano[1].Palo;
            string d = Truco.Azul.miembros[0].mano[2].Numero.ToString() + Truco.Azul.miembros[0].mano[2].Palo;


            btnCarta1.BackgroundImage = Image.FromFile(cards+a+".png");
            btnCarta1.BackgroundImageLayout = ImageLayout.Stretch;
            btnCarta2.BackgroundImage = Image.FromFile(cards + s + ".png");
            btnCarta2.BackgroundImageLayout = ImageLayout.Stretch;
            btnCarta3.BackgroundImage = Image.FromFile(cards + d + ".png");
            btnCarta3.BackgroundImageLayout = ImageLayout.Stretch;


            button7.BackgroundImage = Image.FromFile(dorso);
            button7.BackgroundImageLayout = ImageLayout.Stretch;
            button8.BackgroundImage = Image.FromFile(dorso);
            button8.BackgroundImageLayout = ImageLayout.Stretch;
            button9.BackgroundImage = Image.FromFile(dorso);
            button9.BackgroundImageLayout = ImageLayout.Stretch;
            button10.BackgroundImage = Image.FromFile(dorso);
            button10.BackgroundImageLayout = ImageLayout.Stretch;
            button11.BackgroundImage = Image.FromFile(dorso);
            button11.BackgroundImageLayout = ImageLayout.Stretch;
            button12.BackgroundImage = Image.FromFile(dorso);
            button12.BackgroundImageLayout = ImageLayout.Stretch;
            //btnCarta1.Image = Truco.Azul.miembros[1].mano[1];
        }

    }
}
