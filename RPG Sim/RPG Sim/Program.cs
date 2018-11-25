using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Sim
{


    class Program
    {
        //Declare Overworld

        public static Overworld world = new Overworld(24);

        public static Magic wand = new Magic(90, "Stick", "Smacked", 100, .10, 'm');
        public static Physical stick = new Physical( "stick", "wacked", 80, .2, 'p');
        public static Physical tounge = new Physical("tounge", "slurped", 30, .5, 'p');


        public static List<Fighter> fighters = new List<Fighter>();
        public static Fighter player = new Fighter("MT", 1000, 1, stick, 20, 10);

        
        /*
        public static Fighter e1 = new Fighter("MT", 1000, 1, stick, 20, 10);
        public static Fighter e2 = new Fighter("MT", 1000, 2, stick, 20, 10);
        public static Fighter e4 = new Fighter("MT", 1000, 4, stick, 20, 10);
        public static Fighter e5 = new Fighter("MT", 1000, 6, stick, 20, 10);
        public static Fighter e6 = new Fighter("MT", 1000, 8, stick, 20, 10);
        public static Fighter e7 = new Fighter("MT", 1000, 9, stick, 20, 10);
        public static Fighter e8 = new Fighter("MT", 1000, 11, stick, 20, 10);
        public static Fighter e9 = new Fighter("MT", 1000, 12, stick, 20, 10);
        public static Fighter e10 = new Fighter("MT", 1000, 20, stick, 20, 10);
        */
        static void Main(string[] args)
        {
            //index 0 is player
            fighters.Add(new Fighter("MT", 1000, 1, stick, 20, 10));
            world.DrawMap();
            Console.ReadLine();
        }
    }
}
