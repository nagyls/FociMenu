using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Focimeccs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Meccs.Init();
            
            while (true)
            {
                int selected = Menu.ShowMenu();


                if (selected == 1)
                {
                    Meccs.MeccsHozzaad();
                } else if (selected == 2)
                {
                    Meccs.MeccsekListazasa();
                } else if (selected == 3)
                {
                    Meccs.MeccsKereses();
                } else if (selected == 4)
                {
                    Meccs.TabellaSzamolas();
                } else if (selected == 5) 
                {
                    Meccs.EgyMeccsTorles();
                } else if (selected == 6)
                {
                    Meccs.OsszesMeccsTorles();
                } else
                {
                    break;
                }
            }
        }
    }
}
