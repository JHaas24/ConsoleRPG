using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Overworld
    {
        private int _mapSize;
        private static String[,] _map;

        public Overworld(int mapSize)
        {
            this._mapSize = mapSize;
            _map = new String[mapSize, mapSize];
        }

        public static String[,] Map
        {
            get { return _map; }
            set { _map = value; }      
        }

        public int MapSize
        {
            get { return _mapSize; }
            set { _mapSize = value; }
        }

        public void Welcome()
        {
            Console.Out.WriteLine("Welcome to RPG Sim!!! ");
            Console.Out.WriteLine("What is your name???");

            Fighter.Fighters[0].Name = Console.In.ReadLine();
            Console.Out.WriteLine("Welcome " + Fighter.Fighters[0].Name + "!");
            Console.Out.WriteLine("Choose your map icon. (up to five characters long) ex: (*.*)");

            Fighter.Fighters[0].Icon = Console.In.ReadLine();
            Console.Out.WriteLine("Alright " + Fighter.Fighters[0].Name + "! Welcome to the battle royale! (press enter)");
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
                    for (int k = 0; k < Fighter.NumOfFighters; k++)
                    {
                        if (Fighter.Fighters[k].XCoord == i && Fighter.Fighters[k].YCoord == j)
                        {
                            Map[i, j] = "[" + Fighter.Fighters[k].Icon + "]";
                            Console.Out.WriteLine(Fighter.Fighters[k].XCoord +", " + Fighter.Fighters[k].YCoord);
                        }
                    }
                    Console.Out.Write(Map[i,j]);
                }
                Console.Out.WriteLine();
            }
        }

        public void addFighters()
        {
            for(int i = 0; i < MapSize; i++)
            {
                for(int j = 0; j < MapSize; j++)
                {
                    for(int k = 0; k < Fighter.NumOfFighters; k++)
                    {
                        if (Fighter.Fighters[k].XCoord == i && Fighter.Fighters[k].YCoord == j)
                            Map[i,j] = Fighter.Fighters[k].Icon;
                    }
                }
            }
        }

        public void CheckForBattle()
        {
            throw new NotImplementedException();
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
