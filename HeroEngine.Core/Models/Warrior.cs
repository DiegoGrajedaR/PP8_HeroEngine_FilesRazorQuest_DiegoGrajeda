using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class Warrior : AHero
    {
        public int Armor { get; set; }
        public string BattleCry { get; set; }

        //Warrior Constructor to instantiate
        public Warrior(string name, int level, string battleCry) : base(name, level)
        {
            BattleCry = battleCry;

            Armor = 20 + ((Level - 1) * 10);
        }

        //Overriden methods of the parent class AHero
        public override int Attack()
        {
            int damage = 30 + (Level * 5);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-> [HERO/Warrior] {Name} screams: '{BattleCry}' {Name} attacks! Deals {damage} damage.");
            Console.ResetColor();
            return damage;
        }

        public override void TakeDamage(int damage)
        {
            int realDamage = damage - Armor;

            if (realDamage < 0)
            {
                realDamage = 0;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[HERO/Warrior] {Name} receives {damage} damage -> absorbed {Math.Min(damage, Armor)} by armor -> real damage: {realDamage}");
            Console.ResetColor();
            base.TakeDamage(realDamage);
        }

        public override string ToString() => $"\n[HERO/Warrior] {base.ToString()} | Armor: {Armor} | Battle Cry: {BattleCry}";
    }
}
