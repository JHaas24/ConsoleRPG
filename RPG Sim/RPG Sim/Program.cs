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
 
            Fighter fight = new Fighter();
            //Declare Overworld
            Overworld world = new Overworld(16);

            //Declare battle instance
            Battle battle = new Battle();//may be static

            //Weapons
            Magic wand = new Magic(90, "Stick", "Smacked", 100, .10, "m");
            Physical stick = new Physical("stick", "wacked", 80, .99, "p");
            Physical tounge = new Physical("tounge", "slurped", 30, .5, "p");


            //Fighters
            Fighter player = new Fighter("", 1000, 1, stick, 20, 10, "", 0, 0);

            Fighter e1 = new Fighter("MT", 1000, 1, stick, 20, 10, "(lll)", 5, 6);
            Fighter e2 = new Fighter("MT", 1000, 2, stick, 20, 10, "BOSS ", 7, 9);
            Fighter e3 = new Fighter("MT", 1000, 4, stick, 20, 10, "WWWWW", 5, 1);

            //initialize componants
            //index 0 is player
            //add fighters
            void addFIghters()
            {
                world.Fighters[0] = player;
                world.Fighters[1] = e1;
                world.Fighters[2] = e2;
                world.Fighters[3] = e3;
            }
            // Fighter.Fighters[i] = e4;
            // Fighter.Fighters[i] = e5;
            addFIghters();
            world.Welcome();
            
            //world.addFighters();
            world.DrawMap();
            //loop game
            Random rnd = new Random();

            Console.Out.WriteLine("Move your character with a WASD key and hit enter to confirm");
            Console.Out.WriteLine("Press h for tips");
            Console.Out.WriteLine("Press q to quit");
            while (true)
            {
                String move = "";
                move = Console.In.ReadLine();
                world.Walk(world.Fighters[0], move);
                //move enemies
                for (int i = 1; i < world.Fighters.Length; i++)
                {
                    String res = "";
                    do
                    {
                        Console.Out.WriteLine(world.Fighters.Length);
                        int num = rnd.Next(4);
                        String str = num.ToString();
                        res = world.Walk(world.Fighters[i], str);
                    } while (res.Equals("fail"));
                }
                world.DrawMap();

                String start = "";
                for (int i = 0; i < world.Fighters.Length; i++)
                {
                    if (world.NextToPlayer(world.Fighters[i]))
                    {
                        world.DisplayStat(world.Fighters[i]);

                        Console.WriteLine("Would you like to challenge " + world.Fighters[i].Name + "? (y or n)");
                        start = Console.ReadLine();
                        
                        if (start.Equals("y") || Battle.Intentional == false)
                        {
                            battle.InitiateBattle(player.Name, world.Fighters[i].Name);
                            while (player.Hp > 0 && world.Fighters[i].Hp > 0)
                            {
                                Console.WriteLine(player.Name + " HP: " + player.Hp);
                                Console.WriteLine(world.Fighters[i].Name + " HP: " + world.Fighters[i].Hp);
                                Console.ReadLine();
                                Battle.Attack(player, world.Fighters[i]);
                                if (player.Hp < 0 || world.Fighters[i].Hp < 0)
                                    break; 
                                Battle.Attack(world.Fighters[i], player);
                               
                            }
                            //restore health after battle
                            //warp enemy away
                            if (player.Hp <= 0 && player.Level > 0)
                            {
                                Console.WriteLine(player.Name + " Was Crushed By " + world.Fighters[i].Name + "!");
                                Console.WriteLine(player.Name + " Leveled down!");
                                player.Level--;
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " Defeated " + world.Fighters[i].Name + "!");
                                Console.WriteLine(player.Name + " Leveled up!");
                                Console.WriteLine(player.Name + "'s Stats increased!");
                                player.Level++;
                            }
                            player.Hp = player.MaxHp;
                            world.Fighters[i].Hp = world.Fighters[i].MaxHp;
                            world.Fighters[i].XCoord = world.MapSize - 1;
                            world.Fighters[i].YCoord = 0;
                        }
                        else
                        {
                            Console.Clear();
                            world.DrawMap();
                        }
                     
                    }
                }

               
            }
        }
    }
}
