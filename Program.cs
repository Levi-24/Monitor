using System;

namespace Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Monitor vásár 

            //Egy hardver cég többféle monitort árul. A monitorokról a következő adatokat tároljuk: a monitor gyártója; típusa; mérete; ára; 

            //illetve amelyik kifejezetten játékra való, ott még megadják azt is, hogy gamer. 

            //A méret colban van, az ár nettó és forintban értjük. 

            //Forrásfájl tartalma (a tartalmat használd így, ahogy van, az első sort majd nem kell figyelembe venni beolvasáskor): 

            //Keszleten levo monitorok 

            //Samsung;S24D330H;24;33000  

            //Acer;V227Qbi;21.5;31000  

            //AOC;24G2U;23.8;66000  

            //Samsung;Odyssey G9 C49g95TSSU;49;449989;gamer 

            //LG;25UM58-P;25;56000  

            //Samsung;C27JG50QQU;27.5;91000  



            //Feladatok: 
            //Lehetőleg minden kiírást a főprogram végezzen el. Próbálj minél több kódot újrahasznosítani. Minden feladatot meg kell oldani hagyományosan, és azután, ha tudod, LINQ-val is.

            //1. Hozz létre egy osztályt a monitorok adatai számára. Olvasd be a fájl tartalmát.
            //2. Írd ki a monitorok összes adatát virtuális metódussal, soronként egy monitort a képernyőre. A kiírás így nézzen ki: 
            //Gyártó: Samsung; Típus: S24D330H; Méret: 24 col; Nettó ár: 33000 Ft 

            //2. Tárold az osztálypéldányokban a bruttó árat is (ÁFA: 27%, konkrétan a 27-tel számolj, ne 0,27-tel vagy más megoldással.) 
            //3. Tételezzük fel, hogy mindegyik monitorból 15 db van készleten, ez a nyitókészlet. Mekkora a nyitó raktárkészlet bruttó (tehát áfával növelt) értéke?
            //Írj egy metódust, ami meghívásakor kiszámolja a raktárkészlet aktuális bruttó értékét. A főprogram írja ki az értéket. 

            //4. Írd ki egy új fájlba, és a képernyőre az 50.000 Ft feletti nettó értékű monitorok összes adatát (a darabszámmal együtt) úgy,
            //hogy a szöveges adatok nagybetűsek legyenek, illetve az árak ezer forintba legyenek átszámítva.
            //Az ezer forintba átszámítást egy külön függvényben valósítsd meg. 

            //5. Egy vevő keresi a HP EliteDisplay E242 monitort. Írd ki neki a képernyőre, hogy hány darab ilyen van a készleten.
            //Ha nincs a készleten, ajánlj neki egy olyan monitort, aminek az ára az átlaghoz fölülről közelít. Ehhez használd az átlagszámító függvényt (később lesz feladat). 

            //6. Egy újabb vevőt csak az ár érdekli. Írd ki neki a legolcsóbb monitor méretét, és árát. 
            //7. A cég akciót hirdet. A 70.000 Ft fölötti árú Samsung monitorok bruttó árából 5%-ot elenged.
            //Írd ki, hogy mennyit veszítene a cég az akcióval, ha az összes akciós monitort akciósan eladná

            //8. Írd ki a képernyőre minden monitor esetén, hogy az adott monitor nettó ára a nettó átlag ár alatt van-e, vagy fölötte
            //esetleg pontosan egyenlő az átlag árral. Ezt is a főprogram írja ki

            //9. Modellezzük, hogy megrohamozták a vevők a boltot. 5 és 15 közötti random számú vásárló 1 vagy 2 random módon kiválasztott monitort vásárol
            //ezzel csökkentve az eredeti készletet. Írd ki, hogy melyik monitorból mennyi maradt a boltban
            //Vigyázz, hogy nulla darab alá ne mehessen a készlet. Ha az adott monitor éppen elfogyott, ajánlj neki egy másikat (lásd fent

            //10. Írd ki a képernyőre, hogy a vásárlások után van-e olyan monitor, amelyikből mindegyik elfogyott (igen/nem
            //11. Írd ki a gyártókat abc sorrendben a képernyőre. Oldd meg úgy is, hogy a metódus írja ki, és úgy is, hogy a főprogram
            //12. Csökkentsd a legdrágább monitor bruttó árát 10%-kal, írd ki ezt az értéket a képernyőre. 
        }
    }
}
