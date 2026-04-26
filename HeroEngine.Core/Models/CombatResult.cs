using System;
using System.Collections.Generic;
using System.Text;

namespace HeroEngine.Core.Models
{
    public class CombatResult
    {
        public DateTime Date { get; set; }
        public string Participants { get; set; } 
        public string Result { get; set; }   
        public int TotalRounds { get; set; }
        public int TotalDamageDealt { get; set; }
        public string Mvp { get; set; }
    }
}
