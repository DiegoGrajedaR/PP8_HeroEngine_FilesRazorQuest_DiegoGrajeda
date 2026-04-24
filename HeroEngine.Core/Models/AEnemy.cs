using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public abstract class AEnemy
    {
        public string Species { get; set; }
        public int Hp { get; set; }
        public int BaseDamage { get; set; }
        public bool IsDefeated => Hp <= 0;

        public AEnemy(string species, int hp, int baseDamage)
        {
            Species = species;
            Hp = hp;
            BaseDamage = baseDamage;
        }

        public abstract int Attack();

        public virtual void TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp < 0)
            {
                Hp = 0;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ENEMY] {Species} takes {damage} damage! Remaining HP: {Hp}");
            if (Hp == 0) Console.WriteLine("DEFETED ENEMY!!!");
            Console.ResetColor();
        }
    }
}
