using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Physical : Weapon
    {
        int _sharpness;
        String _name;
        String _verb;
        int _dmg;
        double _critChance;

        public Physical(int sharpness, String name, String verb, int dmg, double critChance, char type) : base(name, verb, dmg, critChance, type)
        {
            this._sharpness = sharpness;
            this._name = name;
            this._verb = verb;
            this._critChance = critChance;
        }

        public int Sharpness
        {
            get
            {
                return _sharpness;
            }
            set
            {
                _sharpness = value;
            }
        }


        public int DullWeapon(Physical p)
        {
            throw new NotImplementedException();
        }

    }
}
