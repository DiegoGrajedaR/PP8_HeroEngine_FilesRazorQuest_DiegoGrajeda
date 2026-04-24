using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using HeroEngine.Core.Enums;
using HeroEngine.Core.Combat;

namespace HeroEngine.Core.Models
{
    public class HealingAbility : AAbility
    {
        public int BaseHeal { get; set; }

        public HealingAbility(string name, RarityAbility rarity, int manaCost) : base(name, TypeAbility.Attack, rarity)
        {
            BaseHeal = 10;
        }

        public override void Execute(Mage mage)
        {
            double multiplier = RarityHelper.RarityMultiplier(RarityAbility);
            int finalHeal = Convert.ToInt32(BaseHeal * multiplier);
            int finalCost = Convert.ToInt32(ManaCost * multiplier);

            Console.WriteLine($"\nActivating '{Name}' [{RarityAbility}]...");
            Console.WriteLine($"{mage.Name} casts a healing spell! Restores {finalHeal} HP. (Cost: {finalCost})");
        }
    }
}
