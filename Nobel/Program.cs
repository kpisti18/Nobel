using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel
{
    class Program
    {
        static List<Dij> dijak = new List<Dij>(); //a static azonnal használhatóvá teszi
        static void Main(string[] args)
        {
            adatokBeolvasasa();
            harmadik();
            negyedik();
            otodik();
            
            Console.WriteLine("\nProgram vége");
            Console.ReadKey();
        }

        private static void otodik()
        {
            Console.WriteLine($"5. feladat:");

            List<Dij> talatiLista = dijak.FindAll(x => x.Ev >= 1990 && x.Ev <= DateTime.Now.Year && x.Tipus.Equals("béke") && String.IsNullOrEmpty(x.VezetekNev)); //A FindAll az összes találatot fogja visszaadni.

            foreach (Dij sor in talatiLista)
            {
                Console.WriteLine($"\t{sor.Ev}: {sor.KeresztNev}");
            }
        }

        private static void negyedik()
        {
            Dij keresettSzemely = dijak.Find(x => x.Ev == 2017 && x.Tipus.Equals("irodalmi"));

            Console.WriteLine($"4. feladat: {keresettSzemely.KeresztNev} {keresettSzemely.VezetekNev}");
        }

        private static void harmadik()
        {
            //a lambda operátorhoz hozzárendelhetünk egy műveletsort. objektum => {}
            //a Find az első találatot adja vissza
            Dij keresettTipus = dijak.Find(x => x.KeresztNev.Equals("Arthur B."));
            
            Console.WriteLine($"3. feladat: {keresettTipus.Tipus}");
        }

        static void adatokBeolvasasa() //ha nincs ott a private, és nem public, akkor private automatikusan
        {
            using (StreamReader sr = new StreamReader("nobel.csv"))
            {
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string[] sor = sr.ReadLine().Split(';');
                    Dij dij = new Dij(int.Parse(sor[0]), sor[1], sor[2], sor[3]);
                    dijak.Add(dij);
                }
            } // a using leköti az erőforrást, ahogy vége a blokknak, abban a pillanatban újra használható más programok számára (pl sr.Close() már így nem kell)
        }
    }
}
