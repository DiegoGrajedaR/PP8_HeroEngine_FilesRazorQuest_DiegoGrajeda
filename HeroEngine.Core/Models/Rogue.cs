using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class Rogue : AHero
    {
        public double StealthMultiplier { get; set; }
        public int HiddenDaggers { get; set; }

        //Rogue Constructor to instantiate
        public Rogue(string name, int level, int hiddenDaggers) : base(name, level)
        {
            HiddenDaggers = hiddenDaggers;
            StealthMultiplier = 1 + ((level - 1) * 0.2);
        }

        //CHAPTER 1 - Overriden methods of the parent class AHero
        public override int Attack()
        {
            if (HiddenDaggers > 0)
            {
                HiddenDaggers--;
                int damage = Convert.ToInt32(25 * StealthMultiplier);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"-> [HERO/Rogue] {Name} throws a dagger! Deals {damage} damage. (Daggers left: {HiddenDaggers})");
                Console.ResetColor();
                return damage;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"-> [HERO/Rogue] {Name} has no daggers! Deals 15 physical damage.");
                Console.ResetColor();
                return 15;
            }
        }

        public override string ToString() => $"\n[HERO/Rogue] {base.ToString()} | Stealth Multiplier: {StealthMultiplier} | Daggers: {HiddenDaggers}";
    }
}
