using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Home;
using SULS.Services;
using System.Collections.Generic;
using System.Linq;

namespace SULS.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }


        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var viewModel = new List<AllProblemsViewModel>();

                viewModel = this.problemsService.GetAllProblems().Select(p => new AllProblemsViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    SubmissionsCount = p.Submissions.Count
                }).ToList();


                return this.View(viewModel, "IndexLoggedIn");
            }
            else
            {
                return this.View();
            }
        }
    }
}