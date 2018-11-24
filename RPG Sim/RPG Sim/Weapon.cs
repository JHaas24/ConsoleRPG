using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Weapon
    {
        private String _name;
        private String _verb;
        private int _dmg;
        private double _critChance;
        private char _type;

        public Weapon(String name, String verb, int dmg, double critChance, char type)
        {
            this._name = name;
            this._verb = verb;
            this._dmg = dmg;
            this._critChance = critChance;
            this._type = type;
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
        public String Verb
        {
            get
            {
                return _verb;
            }
            set
            {
                _verb = value;
            }
        }

        public int Dmg
        {
            get
            {
                return _dmg;
            }
            set
            {
                _dmg = value;
            }
        }

        public double CritChance
        {
            get
            {
                return _critChance;
            }
            set
            {
                _critChance = value;
            }
        }

        public char Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        //Create Weapons Here ^-^ or not *-*

    }
}
