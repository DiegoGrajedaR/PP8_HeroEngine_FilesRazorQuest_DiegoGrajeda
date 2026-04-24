using static System.Net.Mime.MediaTypeNames;
using HeroEngine.Core.Enums;
using HeroEngine.Core.Interfaces;

namespace HeroEngine.Core.Models
{
    public abstract class AAbility : IAbility
    {
        public string Name { get; set; }
        public TypeAbility TypeAbility { get; set; }
        public RarityAbility RarityAbility { get; set; }
        public int ManaCost { get; set; } = 5;

        //Constructor 
        public AAbility(string name, TypeAbility type, RarityAbility rarity)
        {
            Name = name;
            TypeAbility = type;
            RarityAbility = rarity;
        }

        public abstract void Execute(Mage mage);
    }
}
