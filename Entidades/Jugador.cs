using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public class Jugador
    {
        public List<Carta> mano;
        public Queue<PictureBox> acciones;
        public string nombre;
        public eEquipo equipo;
        public Random r;
        public int turno;
        public int envido;
        public eRoles rol;
        public IA IA;
        public bool ia;
        public Point silla;

        public Jugador(string n)
        {
            this.nombre = n;
            r = new Random();
            this.turno = 0;
            acciones = new Queue<PictureBox>();
            mano = new List<Carta>();
            //this.envido = CalcularEnvido();
        }
        public Jugador(string n, bool ia):this(n)
        {
            IA = new IA(mano);
            this.ia = ia;
        }
        public Jugador(string n, bool ia, eEquipo e) : this(n, ia)
        {
            equipo = e;
        }
        public Jugador(string n, eEquipo e) : this(n)
        {
            equipo = e;
        }
        public string MostarMano()
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in mano)
            {
                s.Append("["+item.MostrarCarta()+"] " );
            }
            return s.ToString();
        }
        public int CalcularEnvido() {
            int envido = 0;
            int auxEnvido = 0;
            if (mano[0].Palo == mano[1].Palo) {
                if (mano[0].Figura && !mano[1].Figura) { envido = mano[1].Numero + 20; }
                else if (!mano[0].Figura && mano[1].Figura) { envido = mano[0].Numero + 20; }
                else { envido = mano[0].Numero + mano[1].Numero + 20; }
            } 
            if (mano[0].Palo == mano[2].Palo) {
                if (mano[0].Figura && !mano[2].Figura) { auxEnvido = mano[2].Numero + 20; }
                else if (!mano[0].Figura && mano[2].Figura) { auxEnvido = mano[0].Numero + 20; }
                else { auxEnvido = mano[0].Numero + mano[2].Numero + 20; }

                if (auxEnvido > envido) { envido = auxEnvido; }
            } 
            if (mano[2].Palo == mano[1].Palo) {
                if (mano[2].Figura && !mano[1].Figura) { auxEnvido = mano[1].Numero + 20; }
                else if (!mano[2].Figura && mano[1].Figura) { auxEnvido = mano[2].Numero + 20; }
                else { auxEnvido = mano[2].Numero + mano[1].Numero + 20; }

                if (auxEnvido > envido) { envido = auxEnvido; }
            }
            return envido;
        }
        public string MostrarDatosJugador()
        {
            return $"Nombre: {this.nombre}, Turno: {this.turno}, el {this.rol}";
        }
        public Carta JugarCarta(int n) {
            Carta x = mano[n];
            //mano.Remove(x);
            PictureBox pic = acciones.Dequeue();
            pic.Show();
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.BackgroundImage = x.frente;
            return x;
        }
        public Carta JugarCarta(Carta c)
        {
            if (this.mano == c)
            {
                PictureBox pic = acciones.Dequeue();
                pic.Show();
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.BackgroundImage = c.frente;
                mano.Remove(c);
                return c;
            }
            return null;
        }
        public void CargarControles(PictureBox a, PictureBox b, PictureBox c, TextBox t, Point s)
        {
            this.silla = s;
            acciones.Enqueue(a); acciones.Enqueue(b); acciones.Enqueue(c);
            foreach (var item in acciones)
            {
                item.BackgroundImage = null; item.Hide();
            }
            t.Text = this.nombre;
        }
        public static bool operator ==(Jugador j1, Jugador j2)
        {
            if (j1.silla == j2.silla && j1.nombre == j2.nombre && j1.ia == j2.ia) { return true; }
            return false;
        }
        public static bool operator !=(Jugador j1, Jugador j2) { return !(j1 == j2); }
        //private void RevelarCarta(PictureBox cardBox, Image image)
        //{
        //    if (image != null)
        //    {
        //        cardBox.Show();
        //        cardBox.BackgroundImageLayout = ImageLayout.Stretch;
        //        cardBox.BackgroundImage = image;
        //    }
        //    else
        //    {
        //        cardBox.Hide();
        //        cardBox.Image = null;
        //    }
        //}
    }
}
