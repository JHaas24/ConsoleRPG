using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Magic : Weapon
    {
        public double _accuracy;
        String _name;
        String _verb;
        int _dmg;
        double _critChance;

        public Magic(double accuracy, String name, String verb, int dmg, double critChance, String type) : base(name, verb, dmg, critChance, type)
        {
            this._accuracy = accuracy;
            this._dmg = dmg;
            this._name = name;
            this._verb = verb;
            this._dmg = dmg;
            this._critChance = critChance;
        }

        public double Accuracy
        {
            get{ return _accuracy; }
            set{ _accuracy = value;}
        }

    }
}
