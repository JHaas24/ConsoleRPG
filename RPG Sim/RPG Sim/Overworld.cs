using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Overworld
    {
        private int _mapSize;
        private String[,] _map;
        public Fighter[] _fighters = new Fighter[20];
        private int _numOfFighters = 4;
        
        public Overworld(int mapSize)
        {
            this._mapSize = mapSize;
            _map = new String[mapSize, mapSize];
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
                    for (int k = 0; k < NumOfFighters; k++)
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
        /*
        public void addFighters()
        {
            for(int j = 0; j < MapSize; j++)
            {
                for(int i = 0; i < MapSize; i++)
                {
                    for(int k = 0; k < NumOfFighters; k++)
                    {
                        if (Fighters[k].XCoord == i && Fighters[k].YCoord == j)
                            Map[i,j] = Fighters[k].Icon;
                    }
                }
            }
        }
        */
        public String Walk()
        {
            String move = "";
            move = Console.In.ReadLine();
            Fighter player = Fighters[0];

            switch (move)
            {
                case "w":
                    if(player.YCoord != 0)
                        player.YCoord--;
                    break;
                case "a":
                    if (player.XCoord != 0)
                        player.XCoord--;
                    break;
                case "s":
                    if (player.YCoord != MapSize - 1)
                        player.YCoord++;
                    break;
                case "d":
                    if (player.XCoord != MapSize - 1)
                        player.XCoord++;
                    break;
                default:
                    Console.WriteLine("Send w, a, s, or d to move");
                    break;
                
            }
            DrawMap();
            return move;
        }

        public bool CheckForBattle()
        {
            Fighter player = Fighters[0];
            for(int i = 1; i < NumOfFighters; i++)
            {
                if (player.XCoord == Fighters[i].XCoord && player.YCoord == Fighters[i].YCoord)
                {
                    return true;
                }
            }
            return false;

        }

        public Fighter[] StartBattle()
        {
            throw new NotImplementedException();
        }

        public void DisplayStat(Fighter f)
        {
            throw new NotImplementedException();
        }
    }
}
