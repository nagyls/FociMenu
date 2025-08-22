using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Focimeccs
{
    internal class Menu
    {
        public static int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\tMenu");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("   1. Meccs hozzáadása");
            Console.WriteLine("   2. Meccsek listázása");
            Console.WriteLine("   3. Meccs keresése");
            Console.WriteLine("   4. Tabella megtekintése");
            Console.WriteLine("   5. Egy meccs törlése");
            Console.WriteLine("   6. Összes meccs törlése");
            Console.WriteLine("   7. Kilépés");
            Console.WriteLine("---------------------------------------");
            int selected = BeolvasSzam(" Válassz a megadott opciók közül: ", 1, 7);
            Console.WriteLine();
            return selected;
        }
        
       /// <summary>
       /// Write a question and read a number from console.
       /// </summary>
       /// <param name="kerdes">The question</param>
       /// <returns></returns>
        public static int BeolvasSzam(string kerdes)
        {
            return BeolvasSzam(kerdes, 0, int.MaxValue);
        }

        public static int BeolvasSzam(string kerdes, int minSzam, int maxSzam)
        {
            while(true)
            {
                Console.Write(kerdes);
                try
                {
                    int valasz = int.Parse(Console.ReadLine());
                    if (valasz < minSzam)
                    {
                        Console.WriteLine($"{minSzam} vagy annál nagyobb számot adj meg");
                        continue;
                    } else if (valasz > maxSzam)
                    {
                        Console.WriteLine($"{maxSzam} vagy annál kisebb számot adj meg");
                        continue;
                    }
                    return valasz;
                }
                catch (Exception)
                {
                    Console.WriteLine("Hiba! Számot adj meg.");
                }
            }
        }
        public static void Folytatas()
        {
            Console.WriteLine();
            Console.WriteLine("Nyomj egy gombot a folytatáshoz.");
            Console.ReadKey();
        }
    }
}
