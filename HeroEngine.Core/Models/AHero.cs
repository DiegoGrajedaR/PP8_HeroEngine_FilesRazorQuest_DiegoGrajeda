using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public abstract class AHero
    {
        public string Name { get; set; }
        protected int Level { get; set; }
        protected int MaxHP { get; set; }
        protected int CurrentHP { get; set; }
        public bool IsDefeated => CurrentHP <= 0;

        public AHero(string name, int level)
        {
            Name = name;
            Level = level > 0 ? level : 1;

            MaxHP = 100 + ((Level - 1) * 10);
            CurrentHP = MaxHP;
        }

        public abstract int Attack();

        public virtual void TakeDamage(int damage)
        {
            CurrentHP -= damage;

            if (CurrentHP < 0)
            {
                CurrentHP = 0;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{Name} receives {damage} damage. " + ToString());
            if (IsDefeated) Console.WriteLine("DEFETED HERO!!!");
            Console.ResetColor();
        }

        public override string ToString() => $"{Name} | Level: {Level} | HP: {CurrentHP}/{MaxHP}";

    }
}
