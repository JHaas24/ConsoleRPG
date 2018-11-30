using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Overworld
    {
        private int _mapSize;
        private String[,] _map;
        private int _numOfFighters = 4;
        public Fighter[] _fighters;
       
        
        public Overworld(int mapSize)
        {
            this._mapSize = mapSize;
            _map = new String[mapSize, mapSize];
            _fighters = new Fighter[_numOfFighters];
        }

        public String[,] Map
        {
            get { return _map; }
            set { _map = value; }      
        }

        public int MapSize
        {
            get { return _mapSize; }
            set { _mapSize = value; }
        }

        public Fighter[] Fighters
        {
            get { return _fighters; }
            set { _fighters = value; }
        }

        public int NumOfFighters
        {
            get { return _numOfFighters; }
            set { _numOfFighters = value; }
        }

        public void Welcome()
        {
            Console.Out.WriteLine("Welcome to RPG Sim!!! ");
            Console.Out.WriteLine("What is your name???");

            Fighters[0].Name = Console.In.ReadLine();
            Console.Out.WriteLine("Welcome " + Fighters[0].Name + "!");
            Console.Out.WriteLine("Choose your map icon. (one to five characters long) ex: (*.*)");
            Fighters[0].Icon = Console.In.ReadLine();
            while (Fighters[0].Icon.Length > 5 || Fighters[0].Icon.Length < 1)
            {                
                Console.Out.WriteLine("Icon should be one to five characters long...");
                Fighters[0].Icon = Console.In.ReadLine();
            }
            while (Fighters[0].Icon.Length != 5)
                Fighters[0].Icon += " ";

            Console.Out.WriteLine("Alright " + Fighters[0].Name + "! Welcome to the battle royale! (press enter)");
            Console.In.ReadLine();
        }

        public void DrawMap()
        {
            Console.Clear();
            for(int i = 0; i < MapSize; i++)
            {
                for(int j = 0; j < MapSize; j++)
                {
                    Map[i,j] = "[     ]";
                    for (int k = NumOfFighters- 1; k >= 0; k--)
                    {
                        if (Fighters[k].XCoord == j && Fighters[k].YCoord == i)
                        {
                            Map[i, j] = "[" + Fighters[k].Icon + "]";
                        }
                    }

                    Console.Out.Write(Map[i,j]);
                }
                Console.Out.WriteLine();
            }
        }

        //Called in Walk
        public void Tips()
        {
            Console.Clear();
            String advance = "";
            Console.WriteLine("Welcome to hints!");
            Console.WriteLine("(Send {Enter} to advance and {r} to return)");
            advance = Console.ReadLine();
            if (advance.Equals("r"))
                return;
            Console.WriteLine("There are actually two different types of Weapons in this world");
            advance = Console.ReadLine();
            if (advance.Equals("r"))
                return;
            Console.WriteLine("Some weapons make direct contact with their opponent, but will become less effective as the battle draws out.");
            Console.WriteLine("Others are magical based attacks, however, these weapons may miss their target occasionally.");
            advance = Console.ReadLine();
            if (advance.Equals("r"))
                return;
            Console.WriteLine("When viewing an enemy in the overworld, you can see a majority of their stats and compare how you line up.");
            Console.WriteLine("However, you cannot see their weapon's stats.");
            Console.WriteLine("You will have to analyze the battle log to and estimate how it stacks up to your weapon.");
            advance = Console.ReadLine();
            if (advance.Equals("r"))
                return;
            Console.WriteLine("Regardless of weapon type, all have hidden weapon damage and a critical-hit rate");
            advance = Console.ReadLine();
        }
      
        public bool NextToPlayer(Fighter f)
        {
            Fighter player = Fighters[0];
            if (f != player)
            {
                if ((f.XCoord - 1 == player.XCoord) && f.YCoord == player.YCoord )                
                        return true;
                else
                     if (f.XCoord + 1 == player.XCoord && f.YCoord == player.YCoord)
                        return true;
                else
                     if (f.YCoord + 1 == player.YCoord && f.XCoord == player.XCoord)
                    return true;
                else
                     if (f.YCoord - 1 == player.YCoord && f.XCoord == player.XCoord)
                    return true;
                else
                     if (f.YCoord == player.YCoord && f.XCoord == player.XCoord)
                    return true;
                else
                        return false;
            }
            else
                return false;
        } 

        public String Walk(Fighter f, String dir)
        {
            //move = Console.In.ReadLine();
            //Fighter player = Fighters[0];
            if (!NextToPlayer(f))
            {

                if (dir.Equals("w") || dir.Equals("0"))
                {
                    if (f.YCoord != 0)
                        f.YCoord--;
                    else
                        return "fail";
                }
                if (dir.Equals("a") || dir.Equals("1"))
                {
                    if (f.XCoord != 0)
                        f.XCoord--;
                    else
                        return "fail";
                }
                if (dir.Equals("s") || dir.Equals("2"))
                {
                    if (f.YCoord != MapSize - 1)
                        f.YCoord++;
                    else
                        return "fail";
                }
                if (dir.Equals("d") || dir.Equals("3"))
                {
                    if (f.XCoord != MapSize - 1)
                        f.XCoord++;
                    else
                        return "fail";
                }
                if (dir.Equals("q"))
                    Environment.Exit(0);
                if (dir.Equals("t"))
                    Tips();
            }           
                    
            DrawMap();
            return "";


        }
        //return index of fighter player is on
        //0 means no fighter found
        public int CheckForBattle()
        {
            Fighter player = Fighters[0];
            for(int i = 1; i < NumOfFighters; i++)
            {
                if (player.XCoord == Fighters[i].XCoord && player.YCoord == Fighters[i].YCoord)
                {
                    return i;
                }
            }
            return 0;
        }

        /*
        Display all of these:

        private String _name;
        private int _hp;
        private int _level;
        private Weapon _weapon;
        private int _atkStat;
        private int _defStat;
        */
        //Only called when player is on an enemy
        public void DisplayStat(int index)
        {
            Fighter player = Fighters[0];
            Fighter enemy =  Fighters[index];

            Console.WriteLine("          <---" + player.Name + " VS " + enemy.Name + "--->");
            Console.WriteLine("___________________________________________");
            Console.WriteLine("Level:   " + player.Level + "|" + enemy.Level);
            Console.WriteLine("HP:      " + player.Hp + "|" + enemy.Hp);
            Console.WriteLine("Weapon:  " + player.Weapon.Name + "|" + enemy.Weapon.Name);
            Console.WriteLine("Attack:  " + player.AtkStat + "|" + enemy.AtkStat);
            Console.WriteLine("Defense: " + player.DefStat + "|" + enemy.DefStat);
        }

        public Fighter[] StartBattle()
        {
            throw new NotImplementedException();
        }       
    }
}
