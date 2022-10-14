using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Carta
    {
        private int numero;
        private ePalo palo;
        private int valor;
        public int indexer;
        private bool figura;

        public bool Figura { get { return this.figura; } set { this.figura = value; } }
        public int Numero { get { return this.numero; } set { this.numero = value; } }
        public int Valor { get { return this.valor; } }
        public ePalo Palo { get { return this.palo; } set { this.palo = value; } }

        public Carta(int n, ePalo p)
        {
            this.numero = n; this.palo = p;
            ObtenerValor();
            this.indexer = 0;
        }
        public Carta(int n, ePalo p, int i) : this(n, p)
        {
            this.indexer = i;
        }

        public string MostrarCarta() {
            return $"{this.numero} de {this.Palo}";
        }
        private void ObtenerValor()
        {        //1 espada =14
                 //1 basto =13
                 //7 espada = 12
                 //7 oro = 11
                 //3 todos = 10
                 //2 todos =9 
                 //1 copa y 1 oro =8
                 //12 todos =7
                 //11 todos= 6
                 //10 todos = 5
                 //7 basto y 7 copa =4 
                 //6 todos =3
                 //5 todos = 2
                 //4 todos = 1  
            switch (this.numero)
            {
                case 1:
                    if (this.Palo == ePalo.Espada) { this.valor = 14; }
                    else if (this.Palo == ePalo.Basto) { this.valor = 13; }
                    else { this.valor = 13; }
                    break;
                case 2:
                    this.valor = 9;
                    break;
                case 3:
                    this.valor = 10;
                    break;
                case 4:
                    this.valor = 1;
                    break;
                case 5:
                    this.valor = 2;
                    break;
                case 6:
                    this.valor = 3;
                    break;
                case 7:
                    if (this.Palo == ePalo.Espada) { this.valor = 12; }
                    else if (this.Palo == ePalo.Oro) { this.valor = 11; }
                    else { this.valor = 4; }
                    break;
                case 10:
                    this.valor = 5; this.figura = true;
                    break;
                case 11:
                    this.valor = 6; this.figura = true;
                    break;
                case 12:
                    this.valor = 7; this.figura = true;
                    break;

                default:
                    this.valor = 0;
                    break;
            }
        }
        public static bool operator ==(Carta c1, Carta c2)
        {
            if(c1.Numero == c2.Numero && c1.Palo == c2.Palo) { return true; } return false;
        }
        public static bool operator !=(Carta c1, Carta c2) { return !(c1 == c2); }
    }
}
