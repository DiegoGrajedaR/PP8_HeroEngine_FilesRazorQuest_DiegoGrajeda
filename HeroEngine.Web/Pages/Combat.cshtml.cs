using HeroEngine.Core.Combat;
using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Web.Pages
{
    public class CombatModel : PageModel
    {
        private readonly CombatLogService _logService = new CombatLogService();
        public string DisplayLog { get; set; }

        public void OnGet()
        {
            // Es carrega la pàgina i mostrem el que hi ha al fitxer .txt
            DisplayLog = _logService.ReadFullLog();
        }

        public IActionResult OnPostSimulate()
        {
            // 1. Preparem dades de prova JSON
            var myHeroes = new List<AHero> 
            { 
                new Warrior("Lancelot", UIconfig.lvlOperator.Next(1, 5), "Eternal darkness!"),
                new Mage("Gandalf", UIconfig.lvlOperator.Next(1, 7), 3),
                new Rogue("Hood", UIconfig.lvlOperator.Next(1, 7), 15) 
            };
            var myEnemies = new List<AEnemy> 
            {
                new Minion("Slime", UIconfig.lvlOperator.Next(1, 4)),
                new Minion("Goblin", UIconfig.lvlOperator.Next(1, 4)),
                new Minion("Dark Goblin", UIconfig.lvlOperator.Next(1, 4)),
                new Elite("Warrior Skeleton", UIconfig.lvlOperator.Next(4, 6)),
                new Boss("Baldur the Dark Emperor", UIconfig.lvlOperator.Next(7, 10), "DARK PROJECTILE")
            };

            // 2. Executem el motor per obtenir el Log/text
            List<string> resultLines = CombatEngine.StartBattle(myHeroes, myEnemies);

            // 3. Guardem el resultat al fitxer .txt
            _logService.SaveLogToFile(resultLines);

            return RedirectToPage();
        }
    }

}
