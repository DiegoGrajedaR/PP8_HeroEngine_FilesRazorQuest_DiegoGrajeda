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

        public virtual string TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp < 0)
            {
                Hp = 0;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            string resultText = (Hp == 0) ? "DEFETED ENEMY!!!" : $"[ENEMY] {Species} takes {damage} damage! Remaining HP: {Hp}";
            Console.ResetColor();
            return resultText;
        }
    }
}
