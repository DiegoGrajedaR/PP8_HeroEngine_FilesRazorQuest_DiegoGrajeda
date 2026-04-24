using HeroEngine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Combat
{
    public class RarityHelper
    {
        public static double RarityMultiplier(RarityAbility rarity)
        {
            return rarity switch
            {
                RarityAbility.COMMON => 1.0,
                RarityAbility.RARE => 3.0,
                RarityAbility.EPIC => 5.0,
                RarityAbility.LEGENDARY => 8.0,
                _ => 1.0
            };
        }
    }
}
