using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyelvvizsga
{
    class Vizsgazok
    {
        public int Azonsoito;
        public int ASmodulSzazalek;
        public string AmodulSzoveg;
        public int BmodulSzazalek;
        public string BmodulSzoveg;
        public int Osszpont;

               

        public Vizsgazok(string sor)
        {
            string[] d = sor.Split(';');
            this.Azonsoito = int.Parse(d[0]);
            this.ASmodulSzazalek = int.Parse(d[1]);
            this.AmodulSzoveg = d[2];
            this.BmodulSzazalek = int.Parse(d[3]);
            this.BmodulSzoveg = d[4];
            


        }



    }
}
