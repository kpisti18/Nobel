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
            harmadikLambdaNelkul();
            negyedik();
            negyedikLambdaNelkul();
            otodik();
            otodikLambdaNelkul();
            hatodik();
            hatodikLambdaNelkul();
            hetedik();
            hetedikLambdaNelkul();
            nyolcadik();
            
            Console.WriteLine("\nProgram vége");
            Console.ReadKey();
        }
        private static void nyolcadik()
        {
            Console.WriteLine("8. feladat: orvosi.txt");

            List<Dij> orvosiDijasok = dijak.OrderBy(x => x.Ev).Where(x => x.Tipus.Equals("orvosi")).ToList();
            using (var fajlba = new StreamWriter("orvosi.txt", false, Encoding.UTF8))
            {
                foreach (Dij sor in orvosiDijasok)
                {
                    fajlba.WriteLine($"{sor.Ev}:{sor.VezetekNev} {sor.KeresztNev}");
                }
            }
        }

        private static void hetedikLambdaNelkul()
        {
            Console.WriteLine("7. feladat (lambda nélkül):");
            var statisztika = new Dictionary<string, int>();

            foreach (Dij sor in dijak)
            {
                if (statisztika.ContainsKey(sor.Tipus))
                {
                    statisztika[sor.Tipus]++;
                }
                else
                {
                    statisztika[sor.Tipus] = 1;
                }
            }

            foreach (var sor in statisztika)
            {
                Console.WriteLine($"\t{sor.Key}\t\t\t{sor.Value} db");
            }
        }

        private static void hetedik()
        {
            Console.WriteLine("7. feladat:");

            dijak.GroupBy(x => x.Tipus).ToList().ForEach(x => Console.WriteLine($"\t{x.Key}\t\t\t{x.Count()} db"));
        }

        private static void hatodikLambdaNelkul()
        {
            Console.WriteLine("6. feladat (lambda nélkül):");

            foreach (Dij sor in dijak)
            {
                if (sor.VezetekNev.Contains("Curie"))
                {
                    Console.WriteLine($"\t{sor.Ev}: {sor.KeresztNev} {sor.VezetekNev} ({sor.Tipus})");
                }
            }
        }

        private static void hatodik()
        {
            Console.WriteLine("6. feladat:");

            List<Dij> talatiLista = dijak.FindAll(x => x.VezetekNev.Contains("Curie"));

            foreach (Dij sor in talatiLista)
            {
                Console.WriteLine($"\t{sor.Ev}: {sor.KeresztNev} {sor.VezetekNev} ({sor.Tipus})");
            }
        }

        private static void otodikLambdaNelkul()
        {
            Console.WriteLine("5. feladat (lambda nélkül):");

            foreach (Dij sor in dijak)
            {
                if (sor.Ev >= 1990 && sor.Ev <= DateTime.Now.Year && sor.Tipus.Equals("béke") && sor.VezetekNev.Equals(""))
                {
                    Console.WriteLine($"\t{sor.Ev}: {sor.KeresztNev}");
                }
            }
        }

        private static void otodik()
        {
            Console.WriteLine("5. feladat:");

            List<Dij> talatiLista = dijak.FindAll(x => x.Ev >= 1990 && x.Ev <= DateTime.Now.Year && x.Tipus.Equals("béke") && String.IsNullOrEmpty(x.VezetekNev)); //A FindAll az összes találatot fogja visszaadni.

            foreach (Dij sor in talatiLista)
            {
                Console.WriteLine($"\t{sor.Ev}: {sor.KeresztNev}");
            }
        }
        private static void negyedikLambdaNelkul()
        {
            string keresettVnev = string.Empty;
            string keresettKnev = string.Empty;

            foreach (Dij sor in dijak)
            {
                if (sor.Ev == 2017 && sor.Tipus.Equals("irodalmi"))
                {
                    keresettVnev = sor.VezetekNev;
                    keresettKnev = sor.KeresztNev;
                }
            }

            Console.WriteLine($"4. feladat (lambda nélkül): {keresettKnev} {keresettVnev}");
        }

        private static void negyedik()
        {
            Dij keresettSzemely = dijak.Find(x => x.Ev == 2017 && x.Tipus.Equals("irodalmi"));

            Console.WriteLine($"4. feladat: {keresettSzemely.KeresztNev} {keresettSzemely.VezetekNev}");
        }
        private static void harmadikLambdaNelkul()
        {
            string keresettTipus = string.Empty;

            foreach (Dij sor in dijak)
            {
                if (sor.KeresztNev.Equals("Arthur B."))
                {
                    keresettTipus = sor.Tipus;
                }
            }

            Console.WriteLine($"3. feladat (lambda nélkül): {keresettTipus}");
        }

        private static void harmadik()
        {
            Dij keresettTipus = dijak.Find(x => x.KeresztNev.Equals("Arthur B."));
            
            Console.WriteLine($"3. feladat: {keresettTipus.Tipus}");
        }

        static void adatokBeolvasasa()
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
