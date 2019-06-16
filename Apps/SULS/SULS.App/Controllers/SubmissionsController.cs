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
using SULS.App.ViewModels.Submissions;

namespace SULS.App.Controllers
{
    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;
        private readonly IProblemsService problemService;

        public SubmissionsController(ISubmissionsService submissionsService, IProblemsService problemService)
        {
            this.submissionsService = submissionsService;
            this.problemService = problemService;
        }


        [Authorize]
        public IActionResult Create(string id)
        {
            var problem = this.problemService.GetProblemById(id);
            ;
            var viewModel = new CreateSubmissionsViewModel()
            {
                Name = problem.Name,
                ProblemId = id
            };
            return this.View(viewModel);
        }


        [Authorize]
        [HttpPost]
        public IActionResult Create(CreateSubmissionsInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"/Submissions/Create?id={input.ProblemId}");
            }

            this.submissionsService.CreateSubmission(input.ProblemId, this.User.Id, input.Code);

            return this.Redirect("/");
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return this.Redirect("/");
            }

            this.submissionsService.DeleteSubmissionById(id);

            return this.Redirect("/");
        }
    }
}
