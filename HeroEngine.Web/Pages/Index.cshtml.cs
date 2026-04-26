using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HeroRepository _repo = new HeroRepository();
        public List<AHero> HeroesList { get; set; } = new List<AHero>();
        public int RegisteredHeroesCount { get; set; }
        public void OnGet()
        {
            HeroesList = _repo.GetAllHeroes();
            RegisteredHeroesCount = HeroesList.Count();
        }
    }
}
