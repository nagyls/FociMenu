using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;

namespace Focimeccs
{
    internal class FileUtils
    {
        public static void FileKiir(List<Meccs> listaMeccsek)
        {
            string[] text = new string[listaMeccsek.Count];
            for (int i = 0; i < listaMeccsek.Count; i++)
            {
                text[i] = listaMeccsek[i].ToString();
            }
            File.WriteAllLines("foci.txt", text, Encoding.UTF8);
        }
        public static List<Meccs> FileBeolvas()
        {
            if(!File.Exists("foci.txt"))
            {
                return new List<Meccs>();
            }
            
            List<Meccs> meccsek = new List<Meccs>();
            string[] lines = File.ReadAllLines("foci.txt", Encoding.UTF8);
            for (int i = 0; i < lines.Length; i++)
            {
                Meccs ujMeccs = new Meccs(lines[i]);
                meccsek.Add(ujMeccs);
            }
            return meccsek;
        }
    }
}
