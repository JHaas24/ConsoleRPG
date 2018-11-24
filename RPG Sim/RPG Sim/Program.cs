using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Sim
{


    class Program
    {
        public static Magic f1 = new Magic(69, "GGFF", "DDD", 44, 4, 'm');
        public static Physical f2 = new Physical(6, "qqqqq", "zzzzz", 44, 4, 'p');
        static void Main(string[] args)
        {
       
            Console.WriteLine(f1);
            Console.ReadLine();
        }
    }
}
