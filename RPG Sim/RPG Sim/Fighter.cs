﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Fighter
    {
        private String _name;
        private double _maxHp;
        private double _hp;
        private int _level;
        private Weapon _weapon;
        private double _atkStat;
        private double _defStat;
        private String _icon;
        private int _bounty;

        private int _xCoord = -1;
        private int _yCoord = -1;

        

       

        public Fighter()
        {

        }
        public Fighter(String name, int maxHp, int level, Weapon weapon, int attStat, int defStat, int bounty, String icon, int xCoord, int yCoord)
        {
            this._name = name;
            this._maxHp = maxHp;
            this._level = level;
            this._weapon = weapon;
            this._atkStat = attStat;
            this._defStat = defStat;
            this._bounty = bounty;
            this._icon = icon;
            this._xCoord = xCoord;
            this._yCoord = yCoord;
            this._hp = _maxHp;
        }

        //Overloaded function (-.0)
        public void Levelup()
        {
            this.Weapon.Dmg += 10;
            this.Weapon.CritChance += 1;
        }

        public void Levelup(int times)
        {
            this.Level += times;
            this.AtkStat *= .2 * times + 1;
            this.DefStat *= .2 * times + 1;
            this.MaxHp *= .2 * times + 1;

        }
        public void LevelDown()
        {
            this.Level--;
            this.AtkStat *= .8;
            this.DefStat *= .8;
            this.MaxHp *= .8;
        }

        public int Bounty
        {
            get { return _bounty; }
            set { _bounty = value; }
        }

        public double MaxHp
        {
            get { return _maxHp; }
            set { _maxHp = value; }
        } 

        public int XCoord
        {
            get{ return _xCoord;}
            set{ _xCoord = value;}
        }

        public int YCoord
        {
            get{ return _yCoord; }
            set{ _yCoord = value;}
        }

        public String Icon
        {
            get{ return _icon; }
            set{ _icon = value;}
        }

        public String Name
        {
            get{ return _name; }
            set{ _name = value;}
        }

        public double Hp
        {
            get{ return _hp; }
            set{ _hp = value;}
        }

        public int Level
        {
            get{ return _level; }
            set{ _level = value;}
        }

        public Weapon Weapon
        {
            get{ return _weapon; }
            set{ _weapon = value;}
        }

        public double AtkStat
        {
            get{ return _atkStat; }
            set{ _atkStat = value;}
        }

        public double DefStat
        {
            get{ return _defStat; }
            set{ _defStat = value;}
        }
    }
}
