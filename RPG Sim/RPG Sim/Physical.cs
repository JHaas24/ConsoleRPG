using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Physical : Weapon
    {
        private double _sharpness;
        private String _name;
        private String _verb;
        private int _dmg;
        private double _critChance;

        public Physical(String name, String verb, int dmg, double critChance, String type) : base(name, verb, dmg, critChance, type)
        {
            _sharpness = 0;
            this._dmg = dmg;
            this._name = name;
            this._verb = verb;
            this._critChance = critChance;
            this.Type = type;
        }

        public double Sharpness
        {
            get{ return _sharpness; }
            set{ _sharpness = value;}
        }


        public void DullWeapon(Physical p)
        {
            p.Sharpness += .01;
        }

    }
}
