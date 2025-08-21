using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Focimeccs
{
    internal class Meccs
    {
        static List<Meccs> listaMeccsek = new List<Meccs>();

        public string csapat1;
        public string csapat2;
        public int csapat1Gol;
        public int csapat2Gol;

        public void Print()
        {
            Console.WriteLine($"{csapat1} {csapat1Gol} - {csapat2} {csapat2Gol}");
        }
        override
        public string ToString()
        {
            return $"{csapat1};{csapat1Gol};{csapat2};{csapat2Gol}";
        }

        public Meccs(string line)
        {
            string[] parts = line.Split(';');
            csapat1 = parts[0];
            csapat1Gol = int.Parse(parts[1]);
            csapat2 = parts[2];
            csapat2Gol = int.Parse(parts[3]);
        }
        public Meccs() { }


        public static void MeccsHozzaad()
        {
            Meccs meccs = new Meccs();
            Console.Write("Add meg a csapat nevét: ");
            meccs.csapat1 = Console.ReadLine();

            meccs.csapat1Gol = Menu.BeolvasSzam("Add meg hány gólt szerzett: ");

            Console.Write("Add meg az ellenfél csapat nevét: ");
            meccs.csapat2 = Console.ReadLine();

            meccs.csapat2Gol = Menu.BeolvasSzam("Add meg hány gólt szerzett: ");

            listaMeccsek.Add(meccs);
            FileUtils.FileKiir(listaMeccsek);
        }


        public static void MeccsekListazasa()
        {
            Console.WriteLine($"Ennyi meccs lett lementve: {listaMeccsek.Count}");

            for (int i = 0; i < listaMeccsek.Count; i++)
            {
                Console.Write($"{i + 1}. meccs eredménye: ");
                listaMeccsek[i].Print();
            }
            Menu.Folytatas();
        }


        public static void MeccsKereses()
        {
            List<string> csapatok = Csapatok(listaMeccsek);
            if (csapatok.Count == 0)
            {
                Console.WriteLine("Hiba! Jelenleg nincs elérhető csapat.");
                Menu.Folytatas();
                return;
            }
            Console.WriteLine("Melyik csapat meccsét szeretnéd megnézni?");
            for (int i = 0; i < csapatok.Count; i++)
            {
                Console.WriteLine(csapatok[i]);
            }
            Console.WriteLine();
            
            while (true)
            {
                Console.Write("Írd le melyik csapatnak az eredményeit szeretnéd megnézni: ");
                string csapatNev = Console.ReadLine();
                if (!csapatok.Contains(csapatNev))
                {
                    Console.WriteLine("Hiba! Ilyen csapat nincsen a felsoroltak között.");
                    Menu.Folytatas(); ;
                }
                else
                {
                    for (int i = 0; i < listaMeccsek.Count; i++)
                    {
                        if (listaMeccsek[i].csapat1 == csapatNev || listaMeccsek[i].csapat2 == csapatNev)
                        {
                            listaMeccsek[i].Print();
                            Menu.Folytatas();
                        }
                    }
                    break;
                }
            }
        }


        public static void EgyMeccsTorles()
        {
            if (listaMeccsek.Count == 0)
            {
                Console.WriteLine("Hiba! Jelenleg nincs egyetlen meccs sem.");
                Menu.Folytatas();
                return;
            }
            Console.WriteLine("Meccsek:");
            for (int i = 0; i < listaMeccsek.Count; i++)
            {
                Console.Write($"{i + 1}. meccs: ");
                listaMeccsek[i].Print();
            }
            Console.WriteLine();
            int valasz = Menu.BeolvasSzam("Melyik meccset szeretnéd törölni(0 = Mégsem): ", 0, listaMeccsek.Count);
            if (valasz == 0)
            {
                Menu.Folytatas();
                return;
            }
            Console.WriteLine();
            Meccs meccs = listaMeccsek[valasz - 1];
            int kerdes = Menu.BeolvasSzam($"Biztos vagy benne, hogy törölni szeretnéd a {meccs.csapat1} - {meccs.csapat2} meccsét? (Nem=0/Igen=1): ", 0, 1);
            if (kerdes == 1)
            {
                listaMeccsek.Remove(meccs);
                FileUtils.FileKiir(listaMeccsek);
                Console.WriteLine("Sikeresen törölve.");
                Menu.Folytatas();
            }
        }

        public static void OsszesMeccsTorles()
        {
            if (listaMeccsek.Count == 0)
            {
                Console.WriteLine("Hiba! Jelenleg nincs egyetlen meccs sem.");
                Menu.Folytatas();
                return;
            }
            Console.WriteLine("Meccsek:");
            for (int i = 0; i < listaMeccsek.Count; i++)
            {
                Console.Write($"{i + 1}. meccs: ");
                listaMeccsek[i].Print();
            }
            Console.WriteLine();
            int kerdes = Menu.BeolvasSzam("Biztos vagy benne, hogy törölni szeretnéd az összes meccset? (Nem=0/Igen=1): ", 0, 1);
            if (kerdes == 1)
            {
                listaMeccsek.Clear();
                FileUtils.FileKiir(listaMeccsek);
            }
            Menu.Folytatas();
        }


        public static void Init()
        {
            listaMeccsek = FileUtils.FileBeolvas();
        }


        static List<string> Csapatok(List<Meccs> meccsek)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < meccsek.Count; i++)
            {
                if (!list.Contains(meccsek[i].csapat1))
                {
                    list.Add(meccsek[i].csapat1);
                }
                if (!list.Contains(meccsek[i].csapat2))
                {
                    list.Add(meccsek[i].csapat2);
                }
            }
            return list;
        }
    }
}
