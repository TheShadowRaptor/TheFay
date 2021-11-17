using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFay
{
    class Program
    {
        static string[] story = new string[10];
        static char[] splits = { '%' };
        static void Main(string[] args)
        {
            Page(1);

            Console.ReadKey(true);
        }

        static void Page(int choice)
        {
            //--------------------Arrays-----------------------------
            story[0] = ("The Temple of Mictlantecuhtli,");
            story[1] = ("You take a deep breath of fresh forest air.%The trees sway back and forth from the wind, yet the sky sat obscured by the meny leaves above.%More jungle lays before you, sounds of insects and animals were heard within its darkness.%%You are an archaeologist.%%You have heard rumors about a so called temple deep in this jungle.%It is said to be home of the Aztec god of death... Mictlantecuhtli.%The first of meny choices lay before you.%%Will you;%%A - Adventure Onward, or B - Leave The Forest");                      
            story[2] = ("Page2");
            story[3] = ("Page3");
            story[4] = ("Page4");
            story[5] = ("Page5");
            story[6] = ("Page6");
            story[7] = ("Page7");
            story[8] = ("Page8");
            story[9] = ("Page9");

            string[] page = story[choice].Split(splits);

            foreach (string sub in page)
            {
                Console.WriteLine($"{sub}");
            }

            //------------------------------------------------------

        }
        static void Test()
        {
           
        }
    }
}
