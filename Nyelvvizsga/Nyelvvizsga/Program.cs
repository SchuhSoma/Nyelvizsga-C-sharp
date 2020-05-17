using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Nyelvvizsga
{
    class Program
    {
        static List<Vizsgazok> VizsgazokList;
        static List<double> Atlagok;
        static void Main(string[] args)
        {
            Beolvas();
            Vizsgaszama();
            NemFeleltMeg();
            LegjobbÁtlag();
            KiválóanMegfelelt();
            VizsgaEredmény();

            Console.ReadKey();

        }

        private static void VizsgaEredmény()
        {
            Console.WriteLine("\n7.Feladat");
            int db = 0;
            int db2 = 0;
            int db3 = 0;
            int db4 = 0;

            foreach (var v in VizsgazokList)
            {
                if (v.AmodulSzoveg == "kiválóan megfelelt" && v.BmodulSzoveg == "kiválóan megfelelt" || v.AmodulSzoveg == "megfelelt" && v.BmodulSzoveg == "megfelelt" || v.AmodulSzoveg == "kiválóan megfelelt" && v.BmodulSzoveg == "megfelelt" || v.AmodulSzoveg == "megfelelt" && v.BmodulSzoveg == "kiválóan megfelelt")
                {
                    db++;

                   // Console.WriteLine("Azonosító:{0, -5},  TÍPUS: C , Amodul: {1, -14}, Bmodul: {2, -14}", v.Azonsoito, v.AmodulSzoveg, v.BmodulSzoveg);

                }
            }
            Console.WriteLine("{0} db C vizsga", db);

            foreach (var v in VizsgazokList)
            {
                if (v.AmodulSzoveg == "kiválóan megfelelt" && v.BmodulSzoveg == "nem felelt meg" || v.AmodulSzoveg == "megfelelt" && v.BmodulSzoveg == "nem felelt meg")
                {
                    db2++;

                    //Console.WriteLine("Azonosító:{0, -5},  TÍPUS: A , Amodul: {1, -14}, Bmodul: {2, -14}", v.Azonsoito, v.AmodulSzoveg, v.BmodulSzoveg);

                }
            }
            Console.WriteLine("{0} db A vizsga", db2);

            foreach (var v in VizsgazokList)
            {
                if (v.BmodulSzoveg == "kiválóan megfelelt" && v.AmodulSzoveg == "nem felelt meg" || v.BmodulSzoveg == "megfelelt" && v.AmodulSzoveg == "nem felelt meg")
                {
                    db3++;

                   // Console.WriteLine("Azonosító:{0, -5},  TÍPUS: A , Amodul: {1, -14}, Bmodul: {2, -14}", v.Azonsoito, v.AmodulSzoveg, v.BmodulSzoveg);

                }
            }
            Console.WriteLine("{0} db B vizsga", db3);

            foreach (var v in VizsgazokList)
            {
                if (v.AmodulSzoveg == "nem felelt meg" && v.BmodulSzoveg == "nem felelt meg")
                {
                    db4++;

                    //Console.WriteLine("Azonosító:{0, -5},  Amodul: {1, -14}, Bmodul: {2, -14}", v.Azonsoito, v.AmodulSzoveg, v.BmodulSzoveg);

                }
            }
            Console.WriteLine("{0} db sikertelen vizsga volt", db4);
            Console.WriteLine("\nlétszám:{0}", db + db2 + db3+db4);
        }
    

        private static void KiválóanMegfelelt()
        {
            Console.WriteLine("\n6.Feladat");
            int db = 0;
            Console.WriteLine("Kiváló Vizsgázok: ");
            foreach (var v in VizsgazokList)
            {
                if (v.AmodulSzoveg == "kiválóan megfelelt" && v.BmodulSzoveg == "kiválóan megfelelt")
                {
                    db++;

                   // Console.WriteLine("Azonosító:{0, -5},  Amodul: {1, -14}, Bmodul: {2, -14}", v.Azonsoito, v.AmodulSzoveg, v.BmodulSzoveg);

                }
            }
            Console.WriteLine("{0} db kiválóan megfelet vizsgázó volt", db);
        }

        private static void LegjobbÁtlag()
        {
            Console.WriteLine("\n5.Feladat");
            int db = 0;
            int osszeg = 0;
            double  atlag = 0;

            foreach (var v in VizsgazokList)
            {
                db++;
                osszeg = v.ASmodulSzazalek + v.BmodulSzazalek;
                atlag = (double)osszeg / 2;
                Console.WriteLine("\t {0, -5} Azonosítő: {1, -5}, Átlag: {2, -3}", db ,v.Azonsoito, atlag);
                
            }
            
        }

        private static void NemFeleltMeg()
        {
            Console.WriteLine("\n4.Feladat");
            int db = 0;
            Console.WriteLine("Sikertelen Vizsgázok: ");
            foreach (var v in VizsgazokList)
            {
                if(v.AmodulSzoveg=="nem felelt meg" && v.BmodulSzoveg=="nem felelt meg")
                {
                    db++;
                    
                    Console.WriteLine("Azonosító:{0, -5},  Amodul: {1, -14}, Bmodul: {2, -14}", v.Azonsoito, v.AmodulSzoveg, v.BmodulSzoveg );
                    
                }
            }
            Console.WriteLine("{0} db sikertelen vizsga volt", db);
        }

        private static void Vizsgaszama()
        {
            Console.WriteLine("\n3.Feladat");
            Console.WriteLine("Összesen ennyi vizsgázó volt: {0}", VizsgazokList.Count);
        }

        private static void Beolvas()
        {
            VizsgazokList = new List<Vizsgazok>();
            var sr = new StreamReader(@"nyvizsga.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                VizsgazokList.Add(new Vizsgazok(sr.ReadLine()));
            }
            sr.Close();
        }
    }
}
