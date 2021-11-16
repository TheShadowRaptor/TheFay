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
        static char[] splits = { ',' };
        static void Main(string[] args)
        {
            Page(1);

            Console.ReadKey(true);
        }

        static void Page(int choice)
        {
            //--------------------Arrays-----------------------------
            story[0] = ("The Temple of Mictlantecuhtli,");
            story[1] = ("You take a deep breath of fresh forest air.,Sup opp uoop");                      
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
