using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Fighter
    {
        private String _name;
        private int _hp;
        private int _level;
        private Weapon _weapon;
        private int _atkStat;
        private int _defStat;

        public Fighter(String name, int hp, int level, Weapon weapon, int attStat, int defStat)
        {
            this._name = name;
            this._hp = hp;
            this._level = level;
            this._weapon = weapon;
            this._atkStat = attStat;
            this._defStat = defStat;
        }

        

        public void Levelup(Fighter[] f)
        {
            throw new NotImplementedException();
        }

        public void DisplayStats(Fighter f)
        {
            Console.WriteLine(f.Name);
            Console.WriteLine("Fighter Information:");
            Console.WriteLine("Fighter Information:");
            Console.WriteLine("Fighter Information:");
        }


        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Hp
        {
            get
            {
                return _hp;
            }
            set
            {
                _hp = value;
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
            }
        }

        public Weapon Weapon
        {
            get
            {
                return _weapon;
            }
            set
            {
                _weapon = value;
            }
        }

        public int AtkStat
        {
            get
            {
                return _atkStat;
            }
            set
            {
                _atkStat = value;
            }
        }

        public int DefStat
        {
            get
            {
                return _defStat;
            }
            set
            {
                _defStat = value;
            }
        }
    }
}
