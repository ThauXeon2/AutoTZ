namespace AutoTZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 15. feladat – Auto

            // Készíts egy Auto nevű recordot!

            // A record az alábbi adatokat tárolja:
            // - Brand : string – public, immutable
            // - Type : string – public, immutable
            // - Price : int – private, mutable
            // - Rating : double – public, mutable
            // - AverageConsumption : double – private, mutable
            // - Hp : int – public, immutable
            // - Owner : string – private, immutable

            // Készíts Get függvényt az AverageConsumption értékéhez!
            // Készíts Get függvényt az Owner értékéhez!
            // Készíts Get függvényt az Price értékéhez!
            // Készíts Set függvényt az AverageConsumption értékéhez!
            // Készíts Set függvényt az Price értékéhez!


            // 1.feladat
            // Készíts egy public függvényt, amely eldönti, hogy az autó erősnek számít-e!
            // Egy autó akkor számít erősnek, ha legalább 200 lóerős.


            // 2.feladat
            // Készíts egy public függvényt, amely eldönti, hogy az autó jó értékelésű-e!
            // Egy autó akkor számít jó értékelésűnek, ha a Rating legalább 8.5.



            // 3.feladat
            // Készíts egy public függvényt, amely paraméterként kap egy maximális árat!
            // A függvény döntse el, hogy az autó ára nem haladja-e meg a megadott összeget!


            // 4.feladat
            // Készíts egy public függvényt, amely paraméterként kap egy százalékos kedvezményt!
            // Ha a kedvezmény 1 és 30 százalék közé esik, csökkentse ennek megfelelően az autó Price értékét!


            // 5.feladat
            // Készíts egy public függvényt, amely paraméterként kap egy megtett távolságot kilométerben!
            // A függvény számítsa ki, hogy az autó átlagosan hány liter üzemanyagot használna el a megadott távolság megtételéhez!
            // Az AverageConsumption érték 100km-re vonatkozik


            // 6.feladat
            // Készíts egy public függvényt, amely paraméterként kap egy üzemanyagárat és egy távolságot!
            // A függvény számítsa ki, hogy az adott távolság megtétele mennyibe kerülne az autóval!


            // 7.feladat
            // Készíts egy public függvényt, amely paraméterként kap egy új értékelést!
            // Ha az értékelés 1 és 10  közé esik, állítsa be az új értékelést, amúgy maradjon a régi.

            // 8.feladat
            // Készíts egy public függvényt, amely visszaadj egy szöveget, az alábbi példa alapján :
            // "Az autót a BMW cég gyártotta, ez a M5 Competition (F90) típusú, Kiss János a gazdája és 30000000 forintba került"


            // Használd az alábbi listát, az adatokat helyetesen állítsd be:
            //Az adatok sorrendje : márka, típus, ár, értékelés, átlagfogyasztás, lóerő, tulajdonos

            List<Auto> autos = new List<Auto>()
            {
                new Auto("Toyota", "Corolla", 140, "Nagy Peter"){Price=9500000, Rating=8.7, AverageConsumption=5.8},
                new Auto("BMW", "330i", 245, "Kiss Adam") { Price = 18500000, Rating = 9.1, AverageConsumption = 7.2 },
                new Auto("Tesla", "Model 3", 410, "Zsár Dániel") { Price = 9000000, Rating = 4.3, AverageConsumption = 0.4 },
                new Auto("Honda", "Civic", 220, "Zsár Dániel") { Price = 2000000, Rating = 7.3, AverageConsumption = 10.2 },
                new Auto("Toyota", "Camry", 218, "Kiss Adam") { Price = 14500000, Rating = 8.8, AverageConsumption = 6.4 },
                new Auto("BMW", "520i", 208, "Szabo David") { Price = 22500000, Rating = 8.9, AverageConsumption = 6.8 },
                new Auto("Ford", "Mustang", 450, "Szabo David") { Price = 24000000, Rating = 9.2, AverageConsumption = 10.5 }
            };

            autos[2].Cheaper(10);
            Console.WriteLine(autos[2].IsGRating());
            Console.WriteLine(autos[2].IsMoreEx(9000001));
            Console.WriteLine(autos[2].IsStrong());
            Console.WriteLine(autos[2].PriceDistance(100,1000));
            autos[2].NewRating(4.5);
            Console.WriteLine(autos[2]);
            // LINQ FELADATOK


            // 1.feladat
            // LINQ segítségével számold meg, hány Toyota márkájú autó található a listában!
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(autos.Count(x=>x.Brand=="Toyota"));

            // 2.feladat
            // LINQ segítségével számítsd ki az összes autó Price értékének összegét!
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(autos.Sum(x=>x.Price));

            // 3.feladat
            // LINQ segítségével számítsd ki a BMW márkájú autók átlagos teljesítményét (lóerő)!
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(autos.Where(y=>y.Brand=="BMW").Average(x=>x.Hp));

            // 4.feladat
            // LINQ segítségével keresd meg a legolcsóbb autónak a típusát!
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(autos.MinBy(x=>x.Price).Type);

            // 5.feladat
            // LINQ segítségével add meg az összes autómárkát!
            // Minden márka csak egyszer szerepeljen az eredményben!
            Console.WriteLine("------------------------------------------");
            autos.Select(x => x.Brand).Distinct().ToList().ForEach(x => Console.WriteLine(x));

            // 6.feladat
            // LINQ segítségével add vissza márkánként, hogy hány autó tartozik az adott márkához!
            Console.WriteLine("------------------------------------------");
            foreach (KeyValuePair<string, int> auto in autos.GroupBy(x => x.Brand).ToDictionary(y => y.Key, y => y.Count()))
            {
                Console.WriteLine(auto);
            }


            // 7.feladat
            // LINQ segítségével számítsd ki tulajdonosonként az autók árának értékeinek összegét!
            Console.WriteLine("------------------------------------------");
            foreach (KeyValuePair<string,int> auto in autos.GroupBy(x => x.Owner).ToDictionary(y => y.Key, y => y.Sum(z => z.Price)))
            {
                Console.WriteLine(auto);
            }

            // 8.feladat
            // LINQ segítségével add vissza márkánként az autók átlagos értékelését!
            Console.WriteLine("------------------------------------------");
            foreach (KeyValuePair<string, double> auto in autos.GroupBy(x => x.Brand).ToDictionary(y => y.Key, y => y.Average(z => z.Rating)))
            {
                Console.WriteLine(auto);
            }

            // 9.feladat
            // LINQ segítségével add vissza márkánként a legjobb értékelésű autójának típusát!
            Console.WriteLine("------------------------------------------");
            foreach (KeyValuePair<string, string> auto in autos.GroupBy(x => x.Brand).ToDictionary(y => y.Key, y => y.MaxBy(z=>z.Rating).Type))
            {
                Console.WriteLine(auto);
            }

            // 10.feladat
            // LINQ segítségével keresd meg minden tulajdonos legdrágább autójának típusát!
            Console.WriteLine("------------------------------------------");
            foreach (KeyValuePair<string, string> auto in autos.GroupBy(x => x.Owner).ToDictionary(y => y.Key, y => y.MaxBy(z=>z.Price).Type))
            {
                Console.WriteLine(auto);
            }

            // 11..feladat
            // LINQ segítségével számítsd ki márkánként az autók átlagos árát, 
            // de csak azokat mentsd el, amelyek átlagos értékelése legalább 8.8!
            Console.WriteLine("------------------------------------------");
            foreach (KeyValuePair<string, double> auto in autos.Where(z => z.Rating >= 8.8).GroupBy(x => x.Brand).ToDictionary(y => y.Key, y => y.Average(z => z.Price)))
            {
                Console.WriteLine(auto);
            }

            // 12.feladat
            // LINQ segítségével számítsd ki tulajdonosonként
            // az autók átlagos árát, majd keresd meg azt a tulajdonost, akinek az autói átlagosan a legdrágábbak!
            Console.WriteLine("------------------------------------------");
            var pH = autos.GroupBy(x=>x.Owner).ToDictionary(y=>y.Key, y=>y.Average(z=>z.Price));
            foreach (KeyValuePair<string, double> auto in pH)
            {
                Console.WriteLine(auto);
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(pH.MaxBy(h => h.Value).Key);
        }
    }
}
