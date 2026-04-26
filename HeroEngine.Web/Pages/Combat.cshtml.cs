using HeroEngine.Core.Combat;
using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Web.Pages
{
    public class CombatModel : PageModel
    {
        private readonly CombatLogService _logTxtService = new CombatLogService();
        private readonly CsvStatsWriter _csvService = new CsvStatsWriter();
        private readonly HeroRepository _jsonHeroRepoService = new HeroRepository();
        public string DisplayLog { get; set; }

        public void OnGet()
        {
            // Load the page and show what is in the .txt file
            DisplayLog = _logTxtService.ReadFullLog();
        }

        public IActionResult OnPostSimulate()
        {
            // 1. Prepare JSON test data
            var allHeroes = _jsonHeroRepoService.GetAllHeroes();
            if (allHeroes.Count == 0) return RedirectToPage("/Heroes/Create"); // Si no hi ha herois, anem a crear-ne un
            
            var myHero = allHeroes[0];

            var myEnemies = new List<AEnemy> 
            {
                new Minion("Slime", UIconfig.lvlOperator.Next(1, 4)),
                new Minion("Goblin", UIconfig.lvlOperator.Next(1, 4)),
                new Minion("Dark Goblin", UIconfig.lvlOperator.Next(1, 4)),
                new Elite("Warrior Skeleton", UIconfig.lvlOperator.Next(4, 6)),
                new Boss("Baldur the Dark Emperor", UIconfig.lvlOperator.Next(7, 10), "DARK PROJECTILE")
            };

            // 2. Execute the engine to obtain the Log/text
            List<string> resultLines = CombatEngine.StartBattle(allHeroes, myEnemies);

            // 3. Save the result to the fitxer .txt
            _logTxtService.SaveLogToFile(resultLines);

            // 4.Persistence in CSV. Let's calculate some quick statistics for the CSV
            var stats = new CombatResult
            {
                Date = DateTime.Now,
                Participants = $"{myHero.Name} vs {myEnemies[0].Species}",
                Result = myHero.IsDefeated ? "Defeat" : "Victory",
                TotalRounds = resultLines.Count(l => l.Contains("ROUND")),
                TotalDamageDealt = 50,
                Mvp = myHero.Name
            };
            _csvService.AppendCombatStats(stats);

            return RedirectToPage();
        }
    }

}
