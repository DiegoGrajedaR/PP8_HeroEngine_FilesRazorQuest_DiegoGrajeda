using HeroEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace HeroEngine.Core.Data
{
    public class HeroRepository
    {
        private readonly string _filePath;
        private readonly JsonSerializerOptions _jsonOptions;

        public HeroRepository(string filePath = "Data/list_heroes.json")
        {
            _filePath = filePath;

            // JSON option to make it prettier
            _jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };
        }

        // Reads all heroes from the JSON file.
        public List<AHero> GetAllHeroes()
        {
            if (!File.Exists(_filePath))
            {
                return new List<AHero>(); // Return an empty list if it does not exists
            }

            try
            {
                string jsonString = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<AHero>>(jsonString, _jsonOptions) ?? new List<AHero>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] Could not load heroes: {ex.Message}");
                return new List<AHero>();
            }
        }

        // Saves the given list of heroes to the JSON file.
        public void SaveAllHeroes(List<AHero> heroes)
        {
            // Assegurem-nos que la carpeta "Data" existeix abans de guardar
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string jsonString = JsonSerializer.Serialize(heroes, _jsonOptions);
            File.WriteAllText(_filePath, jsonString);
        }

        // Add a new hero to the JSON
        public void AddHeroes(AHero hero)
        {
            var heroes = GetAllHeroes(); // Load the current ones
            heroes.Add(hero);            // Add the new one
            SaveAllHeroes(heroes);       // Save all
        }

        // Delete a hero from the JSON
        public void DeleteHeroes(string nom)
        {
            var heroes = GetAllHeroes();
            heroes.RemoveAll(h => h.Name.Equals(nom, StringComparison.OrdinalIgnoreCase));
            SaveAllHeroes(heroes);
        }
    }
}
