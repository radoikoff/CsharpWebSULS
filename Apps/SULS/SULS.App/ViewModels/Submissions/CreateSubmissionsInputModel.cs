using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Submissions
{
    public class CreateSubmissionsInputModel
    {

        private const string CodeErrorMessage = "Codebase should be between 30, 800 symbols!";

        public string ProblemId { get; set; }

        [RequiredSis]
        [StringLengthSis(30, 800, CodeErrorMessage)]
        public string Code { get; set; }
    }
}
