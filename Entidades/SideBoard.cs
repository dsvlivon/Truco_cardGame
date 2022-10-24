using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class SideBoard
    {
        public static string basePath = "C:\\Users\\L54556\\OneDrive - Kimberly-Clark\\Desktop\\DANIEL\\Truco\\Media\\"; //this need to change
        public static string dorso;
        public static string cards;

        static SideBoard()
        {
            dorso = basePath + "dorsos\\dorso0.jpg";
            cards = basePath + "cartas asart\\";
        }
        
    }
}
