using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.App.ViewModels.Problems
{
    public class ProblemCreateInputModel
    {
        private const string ProblemErrorMessage = "Problem name lenght should be between 5 and 20 symbols!";
        private const string TotalPointsErrorMessage = "Problem totla points should be between 50 and 300!";


        [RequiredSis]
        [StringLengthSis(5,20, ProblemErrorMessage)]
        public string Name { get; set; }

        [RequiredSis]
        [RangeSis(50, 300, TotalPointsErrorMessage)]
        public int TotalPoints { get; set; }
    }
}
