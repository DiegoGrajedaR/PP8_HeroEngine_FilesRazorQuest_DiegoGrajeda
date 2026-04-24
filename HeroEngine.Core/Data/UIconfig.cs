using HeroEngine.Core.Enums;
using HeroEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Data
{
    public class UIconfig
    {
        public static string MSG_numberHeroes = "How many heroes will join the battle? (1-4): ";
        public static string MSG_errorNumberHeroes = "[Error] Please enter a number between {0} and {1}.";
        public static string MSG_classesHero = "Class [1.Warrior | 2.Rogue | 3.Mage]: ";
        public static string MSG_battleStart = "========= BATTLE START =========";
        public static string MSG_battleFinish = "========= BATTLE FINISHED =========";
        public static string MSG_battleRound = "\nBATTLE LOG - Round {0}";
        public static string MSG_victory = "VICTORY! The heroes have purged the darkness.";
        public static string MSG_defeat = "DEFEAT... Try again.";
        public static string MSG_heroesTurn = "\nHEROES TURN";
        public static string MSG_enemiesTurn = "\nENEMIES TURN";
        public static string MSG_ramainHeroesAndEnemies = "--------------------------------------------------\r\n  Remaining enemies: {0} | Heroes standing: {1}\r\n==================================================\r\n";

        public static int maxHeroes = 4;
        public static int minheroes = 1;
        public static Random lvlOperator = new Random();


        public static List<AHero> SetupHeroes()
        {
            List<AHero> heroesParty = new List<AHero>();
            int numHeroes = 0;
            bool validNumHeroOption = false;


            while (!validNumHeroOption)
            {
                Console.Write(MSG_numberHeroes);
                if (int.TryParse(Console.ReadLine(), out numHeroes) && numHeroes >= minheroes && numHeroes <= maxHeroes)
                {
                    validNumHeroOption = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(MSG_errorNumberHeroes, minheroes, maxHeroes);
                    Console.ResetColor();
                }
            }

            for (int i = 1; i <= numHeroes; i++)
            {
                bool validHeroClassOption = false;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n--- CREATING HERO {i} ---");
                Console.Write("Name: ");
                string name = Console.ReadLine() ?? $"Hero_{i}";
                Console.ResetColor();

                int classChoice = 0;
                int randomLevel = lvlOperator.Next(1, 8);

                while (!validHeroClassOption)
                {
                    Console.Write(MSG_classesHero);
                    if (int.TryParse(Console.ReadLine(), out classChoice) && classChoice >= 1 && classChoice <= 3)
                    {
                        validHeroClassOption = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(MSG_errorNumberHeroes, 1, 3);
                        Console.ResetColor();
                    }
                }

                if (classChoice == 1)
                {
                    heroesParty.Add(new Warrior(name, randomLevel, "Eternal darkness"));
                }
                else if (classChoice == 2)
                {
                    heroesParty.Add(new Rogue(name, randomLevel, 10));
                }
                else if (classChoice == 3)
                {
                    Mage mage = new Mage(name, randomLevel, 3);

                    AAbility fireball = new AttackAbility("Fireball", RarityAbility.LEGENDARY);
                    AAbility healing = new AttackAbility("Healing", RarityAbility.EPIC);

                    mage.EquipAbility(fireball);
                    mage.EquipAbility(healing);

                    mage.ShowOrderedAbilities();

                    heroesParty.Add(mage);
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"=> {name} (Level {randomLevel}) joined the party!");
                Console.ResetColor();
                Console.ReadKey();
            }
            Console.Clear();
            return heroesParty;
        }
    }
}
