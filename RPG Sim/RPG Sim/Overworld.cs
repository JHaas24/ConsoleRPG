using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Overworld
    {
        private int _mapSize;
        private int[,] _map;

        public Overworld(int mapSize)
        {
            this._mapSize = mapSize;
            this._map = new int[mapSize, mapSize];
        }

        public int[,] Map
        {
            get { return _map; }
            set { _map = value; }      
        }

        public int MapSize
        {
            get { return _mapSize; }
            set { _mapSize = value; }
        }

        public void DrawMap()
        {
            for(int i = 0; i < MapSize; i++)
            {
                for(int j = 0; j < MapSize; j++)
                {
                    Console.Out.Write("[] ");
                }
                Console.Out.WriteLine();
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
