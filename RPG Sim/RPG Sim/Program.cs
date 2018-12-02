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
            Magic wand = new Magic(90, "Wand", "Zapped", 100, 90, "m");
            Physical stick = new Physical("stick", "wacked", 80, 99, "p");
            Physical tounge = new Physical("tounge", "slurped", 30, 99, "p");
            Physical godTounge = new Physical("God Tounge", "S L U R P E D", 500, 60, "p");
            Physical pickaxe = new Physical("Pickaxe", "whacked", 20, 10, "p");

            Magic Rocket = new Magic(100, "Rocket Barrage", "Nuked", 600, 30, "m");
           
            //Fighters
            Fighter player = new Fighter("", 1000, 1, new Weapon(), 20, 10, "", 0, 0);

            Fighter e1 = new Fighter("Generic Wizzard", 600, 1, wand, 20, 10, "(WIZ)", 5, 6);          
            Fighter e3 = new Fighter("Default Skin" , 1000, 4, pickaxe, 20, 10, "dance", 5, 1);

            Fighter e2 = new Fighter("Buff Pharah", 100000, 15, Rocket, 100, 100, "Rockt", 7, 9);
            Fighter e4 = new Fighter("Ghirahim", 50000, 18, godTounge, 300, 5, "GHIRA", 10, 10);

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
                            Battle.InitiateBattle(player.Name, world.Fighters[i].Name);
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
                                player.LevelDown();
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " Defeated " + world.Fighters[i].Name + "!");
                                Console.WriteLine(player.Name + " Leveled up!");
                                Console.WriteLine(player.Name + "'s Stats increased!");
                                player.Levelup();
                                bool steal = Battle.StealWeapon(world.Fighters[i]);
                                if (steal)
                                {
                                    player.Weapon = world.Fighters[i].Weapon;
                                }
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
