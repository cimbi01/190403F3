using System;

namespace _190403F3
{
    internal static class AdatBekeres
    {
        #region Public Methods

        // csak kiírja a bekeroszoveget és beker egy adatot ellenorzes nélkül
        public static string Bekeres(string bekeroszoveg = "Add meg a bekért adatot!")
        {
            string adat = "";
            Console.WriteLine(bekeroszoveg);
            adat = Console.ReadLine();
            return adat;
        }
        // meghívja bekerst majd visszaadja, hogy a bekert adat egyenlo-e igazszoveggel
        public static bool EldöntendoBekeres(string bekeroszoveg, string igazszoveg)
        {
            string adat = Bekeres(bekeroszoveg);
            return (adat == igazszoveg);
        }
        // visszaadja a bekéréstípusának megfelelően vagy ha üres, akkor üresen
        public static T EllenorzottBekeres<T>(string bekeroszoveg = "Add meg a bekért adatot!")
        {
            string adat = Bekeres(bekeroszoveg);
            // a kovnertált adat attól függően milyen típusú adatot várunk vissza
            T adatkonvertált = default(T);
            // ha az adat üres
            if (adat == "")
            {
                //megkérdezi hogy biztos üresen maradjon-e
                bool adatmaradjonures = EldöntendoBekeres("Biztos, hogy nem adsz meg semmilyen adatot?\n Ha nem szeretnél megadni semmilyen adatot, nyomj egy entert", "");
                // ha ne maradjon üresen akkor meghívja önmagát
                if (!adatmaradjonures)
                {
                    adatkonvertált = EllenorzottBekeres<T>(bekeroszoveg);
                }
            }
            // ha az adat nem üres
            else if (adat != "")
            {
                try
                {
                    // megpróbálja a kapott adatot T típusúvá tenni
                    adatkonvertált = (T)Convert.ChangeType(adat, typeof(T));
                }
                // ha nem sikerult konvertálni
                catch (FormatException e)
                {
                    Console.WriteLine("Hibás adatbevitel");
                    Console.WriteLine(e.Message);
                    // ujra meghívja magát, amíg a konvertálás nem jó
                    adatkonvertált = EllenorzottBekeres<T>(bekeroszoveg);
                }
            }
            return adatkonvertált;
        }
        // Bekér egy adatot majd megvizsgálja ha kovnertálható majd megnézi hogy benne van-e a //
        // megadott tombben majd tömbben van függvényében visszaad egy értéket
        public static char EllenorzottBekeres(Func<char, bool> intomb, string bekeroszoveg = "Add meg a bekért adatot!", bool tombben = true)
        {
            //bekéri adatkonvertált
            char adatkonvertált = EllenorzottBekeres<char>(bekeroszoveg);
            // ha benne van pedig nem kéne
            if ((intomb(adatkonvertált) && !tombben) ||
                // vagy ha nincs benne pedig bent kéne
                (!intomb(adatkonvertált) && tombben))
            {
                // ujra bekéri
                Console.WriteLine("Nincs ilyen adat a megadott paraméterek alapján!\n");
                adatkonvertált = EllenorzottBekeres(intomb, bekeroszoveg, tombben);
            }
            return adatkonvertált;
        }

        // bekér egy adatot, amit addig kér amig nem double-é konvertálható és ha kisebb mint a MIN
        // akk visszaadja, ha nem akkor meghivja újra önmagát nem lehet generikus, mert min-t és T-t
        // nem lehet osszeegyeztetni
        public static int EllenorzottBekeres(string bekeroszoveg = "Add meg a bekért adatot!", int MIN = 0)
        {
            //bekéri adatkonvertált
            int adatkonvertált = EllenorzottBekeres<int>(bekeroszoveg);
            // ha kisebb mint a min akkor ujra
            if (adatkonvertált <= MIN)
            {
                Console.WriteLine("A megadott adat kisebb vagy egyenlő, mint {0}", MIN);
                adatkonvertált = EllenorzottBekeres(bekeroszoveg, 0);
            }
            return adatkonvertált;
        }
        // bekér egy adatot, amit addig kér amig nem double-é konvertálható és ha kisebb mint a MIN
        // akk visszaadja, ha nem akkor meghivja újra önmagát nem lehet generikus, mert min-t és T-t
        // nem lehet osszeegyeztetni
        public static int EllenorzottBekeres(string bekeroszoveg = "Add meg a bekért adatot!", int MIN = 2, int MAX = 10)
        {
            //bekéri adatkonvertált
            int adatkonvertált = EllenorzottBekeres<int>(bekeroszoveg);
            // ha kisebb mint a min akkor ujra
            if (adatkonvertált < MIN || adatkonvertált >= MAX)
            {
                Console.WriteLine("A megadott adat kisebb vagy egyenlő, mint {0}", MIN);
                adatkonvertált = EllenorzottBekeres(bekeroszoveg, 2, 10);
            }
            return adatkonvertált;
        }

        #endregion Public Methods
    }
}
