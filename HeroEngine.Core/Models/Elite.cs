using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class Elite : AEnemy
    {
        public Elite(string species, int level) : base(species, 60 + (level * 20), 10 + (level * 3)) { }

        public override int Attack()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"-> [ENEMY] {Species} (Elite) executes a heavy and precise strike!");
            Console.ResetColor();
            return BaseDamage;
        }
    }
}
