using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public abstract class AHero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public bool IsDefeated => CurrentHP <= 0;

        public AHero(string name, int level)
        {
            Name = name;
            Level = level > 0 ? level : 1;

            MaxHP = 100 + ((Level - 1) * 10);
            CurrentHP = MaxHP;
        }

        public abstract int Attack();

        public virtual string TakeDamage(int damage)
        {
            CurrentHP -= damage;

            if (CurrentHP < 0)
            {
                CurrentHP = 0;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            string resultText = (CurrentHP == 0) ? "DEFETED HERO!!!" : $"{Name} receives {damage} damage. " + ToString();
            Console.ResetColor();
            return resultText;
        }

        public override string ToString() => $"{Name} | Level: {Level} | HP: {CurrentHP}/{MaxHP}";

    }
}
