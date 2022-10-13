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

            //richTextBox1.Text = button4.BackgroundImage.ToString();
            

            btnCarta0.BackgroundImage = Image.FromFile(cards + Truco.Azul.miembros[0].mano[0].Numero.ToString() + Truco.Azul.miembros[0].mano[0].Palo + ".png");
            btnCarta0.BackgroundImageLayout = ImageLayout.Stretch;
            btnCarta1.BackgroundImage = Image.FromFile(cards + Truco.Azul.miembros[0].mano[1].Numero.ToString() + Truco.Azul.miembros[0].mano[1].Palo + ".png");
            btnCarta1.BackgroundImageLayout = ImageLayout.Stretch;
            btnCarta2.BackgroundImage = Image.FromFile(cards + Truco.Azul.miembros[0].mano[2].Numero.ToString() + Truco.Azul.miembros[0].mano[2].Palo + ".png");
            btnCarta2.BackgroundImageLayout = ImageLayout.Stretch;

            playedCard0.Hide();
            playedCard1.Hide();
            playedCard2.Hide();


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

        private void btnCarta1_Click(object sender, EventArgs e)
        {
            playedCard0.Show();
            playedCard0.BackgroundImageLayout = ImageLayout.Stretch;
            playedCard0.BackgroundImage = btnCarta0.BackgroundImage;
            Truco.Azul.miembros[0].JugarCarta(new Carta(Truco.Azul.miembros[0].mano[0].Numero, Truco.Azul.miembros[0].mano[0].Palo));
            btnCarta0.Hide();
        }

        private void btnCarta2_Click(object sender, EventArgs e)
        {
            playedCard1.Show();
            playedCard1.BackgroundImageLayout = ImageLayout.Stretch;
            playedCard1.BackgroundImage = btnCarta1.BackgroundImage;
            Truco.Azul.miembros[0].JugarCarta(new Carta(Truco.Azul.miembros[0].mano[1].Numero, Truco.Azul.miembros[0].mano[1].Palo));
            btnCarta1.Hide();
        }

        private void btnCarta3_Click(object sender, EventArgs e)
        {
            playedCard2.Show();
            playedCard2.BackgroundImageLayout = ImageLayout.Stretch;
            playedCard2.BackgroundImage = btnCarta2.BackgroundImage;
            Truco.Azul.miembros[0].JugarCarta(new Carta(Truco.Azul.miembros[0].mano[2].Numero, Truco.Azul.miembros[0].mano[2].Palo));
            btnCarta2.Hide();
        }
    }
}
