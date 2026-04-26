using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HeroEngine.Web.Pages.Heroes
{
    public class CreateModel : PageModel
    {
        private readonly HeroRepository _repo = new HeroRepository();
        [BindProperty]
        public HeroInputModel Input { get; set; } = new HeroInputModel();

        public class HeroInputModel 
        {
            public string Name { get; set; }
            public string ClassType { get; set; }
        
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid) return Page();

            AHero newHero;
            switch (Input.ClassType)
            {
                case "Warrior":
                    newHero = new Warrior(Input.Name, 1, "For the eternal darkness!");
                    break;
                case "Mage":
                    newHero = new Mage(Input.Name, 1, 5);
                    break;
                case "Rogue":
                    newHero = new Rogue(Input.Name, 1, 15);
                    break;
                default:
                    ModelState.AddModelError("", $"Error: Type '{Input.ClassType}' not recognized.");
                    return Page();
            }

            _repo.AddHeroes(newHero);

            return RedirectToPage("/Heroes/List");
        }
    }
}
