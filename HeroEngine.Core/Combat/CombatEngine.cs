using HeroEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using HeroEngine.Core.Data;

namespace HeroEngine.Core.Combat
{
    public class CombatEngine
    {
        public static void StartBattle(List<AHero> heroes, List<AEnemy> enemies)
        {
            int round = 1;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(UIconfig.MSG_battleStart);
            Console.ResetColor();

            while (heroes.Any(h => !h.IsDefeated) && enemies.Any(e => !e.IsDefeated))
            {
                int ramainingHeroes = 0;
                int ramainingEnemies = 0;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(UIconfig.MSG_battleRound, round);
                Console.ResetColor();

                foreach (var hero in heroes.Where(h => !h.IsDefeated))
                {
                    Console.WriteLine(hero.ToString());
                }

                //Heroes turn
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(UIconfig.MSG_heroesTurn);
                Console.ResetColor();

                foreach (var hero in heroes.Where(h => !h.IsDefeated))
                {
                    Console.ReadKey();

                    var targetEnemy = enemies.FirstOrDefault(e => !e.IsDefeated);
                    if (targetEnemy == null) break;

                    int damageH = hero.Attack();
                    targetEnemy.TakeDamage(damageH);
                }

                Thread.Sleep(1000);

                //Enemy turn
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(UIconfig.MSG_enemiesTurn);
                Console.ResetColor();

                foreach (var enemy in enemies.Where(e => !e.IsDefeated))
                {
                    Console.ReadKey();

                    var targetHero = heroes.FirstOrDefault(h => !h.IsDefeated);
                    if (targetHero == null) break;

                    int damageE = enemy.Attack();
                    targetHero.TakeDamage(damageE);
                }


                //Count of living heroes and enemies
                foreach (var hero in heroes.Where(h => !h.IsDefeated)) ramainingHeroes++;
                foreach (var enemy in enemies.Where(e => !e.IsDefeated)) ramainingEnemies++;

                Console.WriteLine(UIconfig.MSG_ramainHeroesAndEnemies, ramainingEnemies, ramainingHeroes);
                Console.ReadKey();
                Console.Clear();
                round++;
            }

            //Final message at the end of the game
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(UIconfig.MSG_battleFinish);
            if (heroes.Any(h => !h.IsDefeated))
            {
                Console.WriteLine(UIconfig.MSG_victory);
            }
            else
            {
                Console.WriteLine(UIconfig.MSG_defeat);
            }
            Console.ResetColor();
        }
    }
}
