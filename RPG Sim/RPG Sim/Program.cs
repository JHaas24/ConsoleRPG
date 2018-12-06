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

            //Weapons
            Magic wand = new Magic(90, "Wand", "Zapped", 100, 90, "m");
            Physical stick = new Physical("stick", "wacked", 80, 99, "p");
            Physical tounge = new Physical("tounge", "slurped", 30, 99, "p");
            Physical godTounge = new Physical("God Tounge", "S L U R P E D", 500, 60, "p");
            Physical pickaxe = new Physical("Pickaxe", "whacked", 20, 10, "p");

            Magic experience = new Magic(50, "Experience", "rejected", 50, 30, "m");
            Magic rocket = new Magic(100, "Rocket Barrage", "Nuked", 600, 30, "m");
            Magic guillotine = new Magic(1, "Guillotine", "Decapactated", 9000000, 10, "m");
           
            //Fighters
            Fighter player = new Fighter("", 1000, 1, new Weapon(), 20, 10, 0, "", 0, 0);

            Fighter e1 = new Fighter("Generic Wizzard", 600, 1, wand, 20, 10, 1, "(WIZ)", 5, 6);          
            Fighter e3 = new Fighter("Default Skin" , 1000, 4, pickaxe, 20, 10, 3, "dance", 5, 1);
            Fighter e5 = new Fighter("Employeer", 3000, 7, experience, 30, 3, 52, "(-_-)", 7, 8);
            Fighter e6 = new Fighter("Metal Woman", 100000, 9, guillotine, 1000, 1, 9, "[]M[]", 2, 12);

            Fighter e2 = new Fighter("Buff Pharah", 100000, 15, rocket, 100, 100, 8, "Rockt", 7, 9);
            Fighter e4 = new Fighter("Ghirahim", 50000, 18, godTounge, 300, 5, 10, "GHIRA", 10, 10);

            //initialize componants
            //index 0 is player
            //add fighters
            void addFIghters()
            {
                world.Fighters[0] = player;
                world.Fighters[1] = e1;
                world.Fighters[2] = e2;
                world.Fighters[3] = e3;
                world.Fighters[4] = e4;
                world.Fighters[5] = e5;
                world.Fighters[6] = e6;
            }
            // Fighter.Fighters[i] = e4;
            // Fighter.Fighters[i] = e5;
            addFIghters();
            String wea = world.Welcome();
            if (wea.Equals("1"))
                player.Weapon = wand;
            else if (wea.Equals("2"))
                player.Weapon = stick;
            else if (wea.Equals("3"))
                player.Weapon = tounge;

            //world.addFighters();
            world.DrawMap();
            //loop game
            Random rnd = new Random();

            Console.Out.WriteLine("Move your character with a WASD key and hit enter to confirm");
            Console.Out.WriteLine("Press h for tips");
            Console.Out.WriteLine("Press q to quit");
            //loop the game until every enemy is conquered
            while (!world.Winner(world.Defeated))
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

                //check if player is next to enemies and determine whether to start a battle
                String start = "";
                for (int i = 0; i < world.Fighters.Length; i++)
                {
                    if (world.NextToPlayer(world.Fighters[i]))
                    {
                        world.DisplayStat(world.Fighters[i]);

                        Console.WriteLine("Would you like to challenge " + world.Fighters[i].Name + "? (y or n)");
                        start = Console.ReadLine();
                        
                        //Start Battle
                        if (start.Equals("y") || Battle.Intentional == false)
                        {
                            Battle.InitiateBattle(player.Name, world.Fighters[i].Name);
                            while (player.Hp > 0 && world.Fighters[i].Hp > 0)
                            {
                                Console.Clear();
                                if (!Battle.Auto.Equals("auto"))
                                {
                                    Console.WriteLine(player.Name + " HP: " + player.Hp);
                                    Console.WriteLine(world.Fighters[i].Name + " HP: " + world.Fighters[i].Hp);
                                    Battle.Auto = Console.ReadLine();
                                }
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
                                player.LevelDown();
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " Defeated " + world.Fighters[i].Name + "!");
                                Console.WriteLine(player.Name + " Leveled up " + world.Fighters[i].Bounty + " times!");
                                Console.WriteLine(player.Name + "'s Stats increased!");
                                player.Levelup(world.Fighters[i].Bounty);
                                bool steal = Battle.StealWeapon(world.Fighters[i]);
                                if (steal)
                                {
                                    player.Weapon = world.Fighters[i].Weapon;
                                }
                                //mark as defeated
                                world.Defeated[i] = 1;
                            }
                            //reset stats and move enemy away
                            player.Hp = player.MaxHp;
                            world.Fighters[i].Hp = world.Fighters[i].MaxHp;
                            world.Fighters[i].XCoord = world.MapSize - 1;
                            world.Fighters[i].YCoord = 0;
                            Battle.Auto = "";
                        }
                        //no battle
                        else
                        {
                            Console.Clear();
                            world.DrawMap();
                        }
                     
                    }
                }             
            }
            Console.Out.WriteLine("#1 Victory Royale!!!");
            Console.Out.WriteLine("Congratulations, despite all odds and limitations, you have defeated all enemies!!!");
            Console.Out.WriteLine("~Thanks For Playing~");
        }
    }
}
