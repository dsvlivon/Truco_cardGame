using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class IA
    {
        public List<Carta> mano;
        public IA(List<Carta> m){ this.mano = m; }


        //public int JugarCartaMasAlta()
        //{
        //    //Carta c = new Carta(0, ePalo.Comodin);
        //    int index = 0; int valor = 0;
        //    for (int i = 0; i < mano.Count(); i++)
        //    {
        //        if (valor == 0 || mano[i].Valor > valor)
        //        {
        //            index = i;
        //        }
        //    }
        //    return index;
        //}
        public Carta JugarCartaMasBaja()
        {
            Carta c = new Carta(0, ePalo.Comodin);
            int valor = 0;
            foreach (var item in this.mano)
            {
                if (valor == 0 || item.Valor < valor)
                {
                    c = item; valor = c.Valor;
                }
            }
            return c;
        }
        public Carta JugarCartaMasAlta()
        {
            Carta c = new Carta(0, ePalo.Comodin);
            int valor = 0;
            foreach (var item in this.mano)
            {
                if (valor == 0 || item.Valor > valor)
                {
                    c = item; valor = c.Valor;
                }
            }
            return c;
        }
        public int DecidirCartaParaPrimera(List<Carta> cartasJugadas)
        {
            Carta max = null;
            Carta jMax = null;
            Carta jMin = null;
            int iMax = 0;
            int iMin = 0;
            int valor = 0;

            for (int i = 0; i < mano.Count(); i++)
            {
                if (valor == 0 || mano[i].Valor > valor)
                {
                    jMax = mano[i];
                    iMax = i;
                }
                if (valor == 0 || mano[i].Valor < valor)
                {
                    jMin = mano[i];
                    iMin = i;
                }
            }
            if (cartasJugadas.Count > 0) { 
                foreach (var item in cartasJugadas)
                {
                    if (valor == 0 || item.Valor > valor)
                    {
                        max = item;
                    }
                }
                if (jMax.Valor > max.Valor){ return iMax; }
                else { return iMin; }
            }
            return iMax;
        }
        public void InterpretarSeña(eSeñas seña)
        {
            switch (seña)
            {
                case eSeñas.AnchoEspada:
                    break;
                case eSeñas.AnchoBasto:
                    break;
                case eSeñas.SieteEspada:
                    break;
                case eSeñas.SieteOro:
                    break;
                case eSeñas.Tres:
                    break;
                case eSeñas.Dos:
                    break;
                case eSeñas.Figuras:
                    break;
                case eSeñas.Matar:
                    break;
                case eSeñas.AndaBajito:
                    break;
                case eSeñas.CantaEnvido:
                    break;
                case eSeñas.CantaTruco:
                    break;
                case eSeñas.NosVamos:
                    break;
                default:
                    break;
            }
        }
    }
}
