using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Data
{
    public class CombatLogService
    {
        private readonly string _filePath = "Data/combat_history.txt";

        public void SaveLogToFile(List<string> combatLines)
        {
            // Assegurem que la carpeta existeix
            Directory.CreateDirectory("Data");

            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine($"\n--- COMBAT LOG: {DateTime.Now} ---");
                foreach (var line in combatLines)
                {
                    sw.WriteLine(line);
                }
                sw.WriteLine("------------------------------------------");
            }
        }

        public string ReadFullLog()
        {
            if (!File.Exists(_filePath)) return "No history yet.";
            return File.ReadAllText(_filePath);
        }
    }
}