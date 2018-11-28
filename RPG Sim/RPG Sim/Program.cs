using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Sim
{

    class Program
    {

        static void Main(string[] args)
        {
            int playerx = 0;
            int playery = 0;

            Fighter fight = new Fighter();
            //Declare Overworld
            Overworld world = new Overworld(16);

            //Weapons
            Magic wand = new Magic(90, "Stick", "Smacked", 100, .10, 'm');
            Physical stick = new Physical("stick", "wacked", 80, .2, 'p');
            Physical tounge = new Physical("tounge", "slurped", 30, .5, 'p');


            //Fighters
            Fighter player = new Fighter("", 1000, 1, stick, 20, 10, "", 0, 0);

            Fighter e1 = new Fighter("MT", 1000, 1, stick, 20, 10, "(lll)", 5, 6);
            Fighter e2 = new Fighter("MT", 1000, 2, stick, 20, 10, "BOSS ", 7, 9);
            Fighter e3 = new Fighter("MT", 1000, 4, stick, 20, 10, "WWWWW", 5, 1);

            //initialize componants
            //index 0 is player
            //add fighters
            
            world.Fighters[0] = player;
            world.Fighters[1] = e1;
            world.Fighters[2] = e2;
            world.Fighters[3] = e3;
            // Fighter.Fighters[i] = e4;
            // Fighter.Fighters[i] = e5;
            
            world.Welcome();
            
            //world.addFighters();
            world.DrawMap();
            //loop game
            String done; 
            Console.Out.WriteLine("Move your character with a WASD key and hit enter to confirm");
            Console.Out.WriteLine("Press q to quit");
            while (true)
            {
                done = world.Walk();
                if (done == "q")
                    break;

                bool test;
                test = world.CheckForBattle();
                Console.WriteLine(test);
            }
        }
    }
}
