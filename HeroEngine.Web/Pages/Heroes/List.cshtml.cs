using HeroEngine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Web.Pages.Heroes
{
    public class IndexModel : PageModel
    {
        public List<AHero> HeroesList { get; set; } = new List<AHero>();

        public void OnGet()
        {
            HeroesList = new List<AHero>
            {
                new Warrior("Lancelot", 3, "Eternal darkness!"),
                new Mage("Gandalf", 2, 3),
                new Rogue("Hood", 2, 15)
            };

        }
    }
}
