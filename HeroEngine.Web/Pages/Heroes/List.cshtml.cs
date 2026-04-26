using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Web.Pages.Heroes
{
    public class IndexModel : PageModel
    {
        private readonly HeroRepository _repo = new HeroRepository();
        public List<AHero> HeroesList { get; set; } = new List<AHero>();

        public void OnGet()
        {
            HeroesList = _repo.GetAllHeroes();

        }
    }
}
