using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Egy hardver cég többféle monitort árul. A monitorokról a következő adatokat tároljuk: a monitor gyártója; típusa; mérete; ára; 
            //illetve amelyik kifejezetten játékra való, ott még megadják azt is, hogy gamer. 
            //A méret colban van, az ár nettó és forintban értjük. 
            //Feladatok: 
            //Lehetőleg minden kiírást a főprogram végezzen el. Próbálj minél több kódot újrahasznosítani. Minden feladatot meg kell oldani hagyományosan, és azután, ha tudod, LINQ-val is.
            //1. Hozz létre egy osztályt a monitorok adatai számára. Olvasd be a fájl tartalmát.
            var monitorok = new List<Monitor>();
            using StreamReader sr = new StreamReader(
                path: "../../../src/Monitorok.txt",
                Encoding.UTF8);
            _ = sr.ReadLine();

            Console.WriteLine("1.Feladat: Beolvasás");
            while (!sr.EndOfStream)
            {
                monitorok.Add(new Monitor(sr.ReadLine()));
            }
            //2. Írd ki a monitorok összes adatát virtuális metódussal, soronként egy monitort a képernyőre. A kiírás így nézzen ki: 
            //Gyártó: Samsung; Típus: S24D330H; Méret: 24 col; Nettó ár: 33000 Ft 
            //Tárold az osztálypéldányokban a bruttó árat is (ÁFA: 27%, konkrétan a 27-tel számolj, ne 0,27-tel vagy más megoldással.) 
            Console.WriteLine("2.Feladat:");
            foreach (var monitor in monitorok) {Console.WriteLine($"\tGyártó: {monitor.Gyarto}; Típus: {monitor.Tipus}; Méret: {monitor.Meret}; Nettó ár: {monitor.Ar} Ft");}

            //3. Tételezzük fel, hogy mindegyik monitorból 15 db van készleten, ez a nyitókészlet. Mekkora a nyitó raktárkészlet bruttó (tehát áfával növelt) értéke?
            //Írj egy metódust, ami meghívásakor kiszámolja a raktárkészlet aktuális bruttó értékét. A főprogram írja ki az értéket. 
            Console.WriteLine($"3.Feladat: A raktárkészlet aktuális bruttó értéke: {KezdoKeszlet(monitorok)} Ft");

            //4. Írd ki egy új fájlba, és a képernyőre az 50.000 Ft feletti nettó értékű monitorok összes adatát (a darabszámmal együtt) úgy,
            //hogy a szöveges adatok nagybetűsek legyenek, illetve az árak ezer forintba legyenek átszámítva.
            //Az ezer forintba átszámítást egy külön függvényben valósítsd meg. 
            using StreamWriter writer = new StreamWriter(path: "../../../src/50-felett.txt", append: false);
            Console.WriteLine("4.Feladat: Kiírás");
            foreach (var monitor in monitorok)
            {
                if (monitor.Ar > 50000) { writer.WriteLine($"{monitor.Gyarto.ToUpper()};{monitor.Tipus.ToUpper()};{monitor.Meret};{monitor.Darab},{Ezres(monitor.Ar)}EZER");}
            }

            //5. Egy vevő keresi a HP EliteDisplay E242 monitort. Írd ki neki a képernyőre, hogy hány darab ilyen van a készleten.
            //Ha nincs a készleten, ajánlj neki egy olyan monitort, aminek az ára az átlaghoz fölülről közelít. Ehhez használd az átlagszámító függvényt (később lesz feladat). 
            Console.WriteLine("5.Feladat:");
            var keresettDarab = monitorok.Where(m => m.Tipus == "EliteDisplay E242").Select(m => m.Darab);
            double atlag = monitorok.Average(m => m.Ar);
            var atlagFelso = monitorok.OrderBy(m => m.Ar).First(m => m.Ar > atlag);

            if (keresettDarab.FirstOrDefault() == 0)
            {
                Console.WriteLine("\tA HP EliteDisplay E242 sajnos nincs a készleten.");
                Console.WriteLine($"\tHelyette ajánlom a(z) {atlagFelso.Gyarto} {atlagFelso.Tipus} monitort ami csak {atlagFelso.Ar}Ft-ba kerül.");
            }
            else {Console.WriteLine(keresettDarab.FirstOrDefault() + "db van raktáron.");}

            //6. Egy újabb vevőt csak az ár érdekli. Írd ki neki a legolcsóbb monitor méretét, és árát. 
            Console.WriteLine("6.Feladat:");
            var min = monitorok.OrderBy(m => m.Ar).First();
            Console.WriteLine($"\tA legolcsóbb monitor ára {min.Ar}, a mérete pedig {min.Meret}.");

            //7. A cég akciót hirdet. A 70.000 Ft fölötti árú Samsung monitorok bruttó árából 5%-ot elenged.
            //Írd ki, hogy mennyit veszítene a cég az akcióval, ha az összes akciós monitort akciósan eladná
            Console.WriteLine("7.Feladat:");
            int maxProfit = 0;
            foreach (var monitor in monitorok) {maxProfit += monitor.Ar * monitor.Darab;}
            Console.WriteLine($"\tMaximum profit: {maxProfit}");

            double saleProfit = 0;
            foreach (var monitor in monitorok) {saleProfit += (monitor.Ar * 0.95) * monitor.Darab; }
            Console.WriteLine($"\tMaximum profit a leárazás után: {saleProfit}");

            //8. Írd ki a képernyőre minden monitor esetén, hogy az adott monitor nettó ára a nettó átlag ár alatt van-e, vagy fölötte
            //esetleg pontosan egyenlő az átlag árral. Ezt is a főprogram írja ki
            Console.WriteLine("8.Feladat:");
            foreach (var monitor in monitorok)
            {
                string result = monitor.Ar > atlag ? "drágább" :
                                monitor.Ar < atlag ? "olcsóbb" : "ugyanannyi";
                Console.WriteLine($"\tA(z) {monitor.Gyarto} {monitor.Tipus} monitor {result} mint az átlag.");
            }

            //9. Modellezzük, hogy megrohamozták a vevők a boltot. 5 és 15 közötti random számú vásárló 1 vagy 2 random módon kiválasztott monitort vásárol
            //ezzel csökkentve az eredeti készletet. Írd ki, hogy melyik monitorból mennyi maradt a boltban
            //Vigyázz, hogy nulla darab alá ne mehessen a készlet. Ha az adott monitor éppen elfogyott, ajánlj neki egy másikat (lásd fent
            Random rnd = new Random();
            int customerCount = rnd.Next(5, 16);
            for (int i = 0; i < customerCount; i++)
            {
                int boughtAmnt = rnd.Next(1, 3);
                int monitorIndex = rnd.Next(0, monitorok.Count);
            }

            //10. Írd ki a képernyőre, hogy a vásárlások után van-e olyan monitor, amelyikből mindegyik elfogyott (igen/nem
            //11. Írd ki a gyártókat abc sorrendben a képernyőre. Oldd meg úgy is, hogy a metódus írja ki, és úgy is, hogy a főprogram
            //12. Csökkentsd a legdrágább monitor bruttó árát 10%-kal, írd ki ezt az értéket a képernyőre. 
        }
        static int KezdoKeszlet(List<Monitor> monitorok)
        {
            int keszlet = 0;
            foreach (var monitor in monitorok) {keszlet += monitor.Brutto * monitor.Darab;}
            return keszlet;
        }

        static int Ezres(int ar)
        {
            int ezres = ar / 1000;
            return ezres;
        }
    }
}
