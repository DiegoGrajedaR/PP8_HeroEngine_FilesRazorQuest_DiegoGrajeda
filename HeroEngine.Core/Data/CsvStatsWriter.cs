using HeroEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Data
{
    public class CsvStatsWriter
    {
        private readonly string _filePath = "Data/combat_stats.csv";

        // Result text addes at he final of CSV file.
        public void AppendCombatStats(CombatResult result)
        {
            Directory.CreateDirectory("Data"); // Check that the folder exists

            bool isNewFile = !File.Exists(_filePath);

            using (StreamWriter sw = File.AppendText(_filePath))
            {
                if (isNewFile)
                {
                    sw.WriteLine("Date,Participants,Outcome,TotalRounds,TotalDamage,MVP");
                }

                string line = $"{result.Date:yyyy-MM-dd HH:mm},{result.Participants},{result.Result},{result.TotalRounds},{result.TotalDamageDealt},{result.Mvp}";
                sw.WriteLine(line);
            }
        }

        // Read CSV an returne the last 10 instances.
        public List<CombatResult> GetLast10Combats()
        {
            var results = new List<CombatResult>();

            if (!File.Exists(_filePath)) return results;

            string[] lines = File.ReadAllLines(_filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                string[] parts = lines[i].Split(',');

                if (parts.Length >= 6)
                {
                    results.Add(new CombatResult
                    {
                        Date = DateTime.Parse(parts[0]),
                        Participants = parts[1],
                        Result = parts[2],
                        TotalRounds = int.Parse(parts[3]),
                        TotalDamageDealt = int.Parse(parts[4]),
                        Mvp = parts[5]
                    });
                }
            }

            // Only return 10 stats
            results.Reverse(); // First the most recent
            if (results.Count > 10)
            {
                return results.GetRange(0, 10);
            }

            return results;
        }
    }
}
