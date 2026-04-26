using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace HeroEngine.Core.Combat
{
    public class CombatEngine
    {
        // Ara el mètode retorna una List<string> amb tot el que ha passat
        public static List<string> StartBattle(List<AHero> heroes, List<AEnemy> enemies)
        {
            List<string> log = new List<string>();
            int round = 1;

            log.Add("--- BATTLE START ---");

            while (heroes.Any(h => !h.IsDefeated) && enemies.Any(e => !e.IsDefeated))
            {
                int ramainingHeroes = 0;
                int ramainingEnemies = 0;

                log.Add($"--- ROUND {round} ---");
                foreach (var hero in heroes.Where(h => !h.IsDefeated))
                {
                    log.Add(hero.ToString());
                }

                // Heroes turn
                log.Add(UIconfig.MSG_heroesTurn);
                foreach (var hero in heroes.Where(h => !h.IsDefeated))
                {
                    var targetEnemy = enemies.FirstOrDefault(e => !e.IsDefeated);
                    if (targetEnemy == null) break;

                    int damageH = hero.Attack();
                    if (hero is Warrior warrior)
                    {
                        log.Add($"-> [HERO/Warrior] {warrior.Name} screams: '{warrior.BattleCry}' {warrior.Name} attacks! Deals {damageH} damage.");
                    }
                    else if (hero is Mage mage)
                    {
                        log.Add($"-> [HERO/Mage] {mage.Name} casts a spell! Deals {damageH} damage. Remaining Mana: {mage.Mana}");
                    }
                    else if (hero is Rogue rogue)
                    {
                        log.Add($"-> [HERO/Rogue] {rogue.Name} throws a dagger! Deals {damageH} damage. (Daggers left: {rogue.HiddenDaggers}");
                    }

                    log.Add(targetEnemy.TakeDamage(damageH));

                }

                // Enemy turn
                log.Add(UIconfig.MSG_enemiesTurn);
                foreach (var enemy in enemies.Where(e => !e.IsDefeated))
                {
                    var targetHero = heroes.FirstOrDefault(h => !h.IsDefeated);
                    if (targetHero == null) break;

                    int damageE = enemy.Attack();
                    if (enemy is Minion minion)
                    {
                        log.Add($"-> [ENEMY] {minion.Species} lunges forward! Attacks {targetHero.Name} for {damageE} damage.");
                    }
                    else if (enemy is Elite elite)
                    {
                        log.Add($"-> [ENEMY] {elite.Species} (Elite) executes a heavy and precise strike! Attacks {targetHero.Name} for {damageE} damage.");
                    }
                    else if (enemy is Boss boss)
                    {
                        log.Add($"-> [ENEMY] {boss.Species} uses ULTIMATE: {boss.Ultimate}! Attacks {targetHero.Name} for {damageE} damage.");
                    }

                    targetHero.TakeDamage(damageE);
                }

                //Count of living heroes and enemies
                foreach (var hero in heroes.Where(h => !h.IsDefeated)) ramainingHeroes++;
                foreach (var enemy in enemies.Where(e => !e.IsDefeated)) ramainingEnemies++;

                log.Add($"--------------------------------------------------\r\n  Remaining enemies: {ramainingEnemies} | Heroes standing: {ramainingHeroes}\r\n==================================================\r\n");
                round++;
                if (round > 50) break; // Seguretat per evitar bucles infinits
            }

            string finalResult = heroes.Any(h => !h.IsDefeated) ? "VICTORY" : "DEFEAT";
            log.Add($"--- BATTLE FINISHED: {finalResult} ---");

            return log;
        }
    }

}
