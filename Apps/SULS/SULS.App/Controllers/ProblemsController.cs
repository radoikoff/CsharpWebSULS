using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using SULS.App.ViewModels.Users;
using SULS.Services;
using SULS.App.ViewModels.Problems;
using System.Linq;
using SULS.App.ViewModels.Submissions;

namespace SULS.App.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }


        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create(ProblemCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Problems/Create");
            }

            this.problemsService.CreateProblem(input.Name, input.TotalPoints);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var problem = this.problemsService.GetProblemById(id);


            var viewModel = new ProblemDetailsViewModel
            {
                Name = problem.Name,
                MaxPoints = problem.Points,
                Submissions = problem.Submissions.Select(s => new SubmissionViewModel
                {
                    Username = s.User.Username,
                    AchievedResult = s.AchievedResult,
                    CreatedOn = s.CreatedOn.ToString("dd/MM/yyyy"),
                    SubmissionId = s.Id
                })
            };



            return this.View(viewModel);
        }

    }
}
