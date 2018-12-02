using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Sim
{
    public class Battle
    {
        private static bool _intentional;
        private static String _auto = "";

        public static void Attack(Fighter off, Fighter def)
        {
            double amt = 0;
            Random rando = new Random();
            double chance;
            bool critHit = false;
            bool miss = false;

            //Offense damage
            amt = off.AtkStat + off.Weapon.Dmg;

            chance = rando.Next(100) + 1;
            if (off.Weapon.CritChance >= chance)
            {
                critHit = true;
                amt += off.Weapon.Dmg;
            }

            //Defense blocked
            amt -= def.DefStat;
            if (off.Weapon.Type.Equals("p"))
            {
                Physical p = (Physical)off.Weapon;
                amt -= p.Dmg * p.Sharpness;

                p.DullWeapon(p);
            }
            if (off.Weapon.Type.Equals("m"))
            {
                chance = rando.Next(100) + 1;
                Magic m = (Magic)off.Weapon;
 
                if (chance >= m.Accuracy)
                {
                    amt = 0;
                    miss = true;
                }
            }
            if(amt >= 0)
                def.Hp -= amt;

            // Console.WriteLine(off.Weapon.Dmg);
            if (!Auto.Equals("auto"))
            {
                if (!miss)
                    Console.Out.WriteLine(off.Name + " " + off.Weapon.Verb + " " + def.Name + " for " + amt + " damage!");
                else
                    Console.WriteLine(off.Name + " Missed!");

                if (critHit)
                    Console.WriteLine("It was a Critical Hit!");

                Auto = Console.ReadLine();

                
            }
        }

        public static void InitiateBattle(String pName, String eName)
        {
            Console.Clear();
            if (Intentional == false)
                Console.Out.WriteLine(pName + " stepped on " + eName + " and it attacked anyway!!!");
            else
                Console.Out.WriteLine(pName + " Challenged " + eName + " to a fight!!!");
            Console.Out.WriteLine("Battle!");
            Console.ReadLine();
        }

        public static bool StealWeapon(Fighter f)
        {
            String choice = "";
            while (!(choice.Equals("y") || choice.Equals("n"))) {


                Console.WriteLine("Would you like to steal " + f.Name + "'s " + f.Weapon.Name + "? (y/n)");
                choice = Console.ReadLine();
            }
            if (choice.Equals("y"))
                return true;
            else
                return false;
        }

        public static bool Intentional
        {
            get { return _intentional; }
            set { _intentional = value; }
        }

        public static String Auto
        {
            get { return _auto; }
            set { _auto = value; }
        }
    }
}
