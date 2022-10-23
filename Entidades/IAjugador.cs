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

        
        public int DecidirCartaParaPrimera()
        {
            //Carta c = new Carta(0, ePalo.Comodin);
            int index = 0; int valor = 0;
            for (int i = 0; i < mano.Count(); i++)
            {
                if (valor == 0 || mano[i].Valor > valor)
                {
                    index = i;
                }
            }
            return index;
        }public int DecidirCartaParaPrimera(Carta nosotrosUno, Carta nosotrosDos, Carta ellosUno, Carta ellosDos, Carta ellosTres)
        {
            //Carta c = new Carta(0, ePalo.Comodin);
            int index = 0; int valor = 0;
            for (int i = 0; i < mano.Count(); i++)
            {
                if (valor == 0 || mano[i].Valor > valor)
                {
                    index = i;
                }
            }
            return index;
        }
    }
}
