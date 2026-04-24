using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class Minion : AEnemy
    {
        public Minion(string species, int level) : base(species, 40 + (level * 10), 5 + (level * 2)) { }

        public override int Attack()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"-> [ENEMY] {Species} lunges forward!");
            Console.ResetColor();
            return BaseDamage;
        }
    }
}
