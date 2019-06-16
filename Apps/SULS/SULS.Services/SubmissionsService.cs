using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {

        private readonly SULSContext db;
        private readonly IProblemsService problemService;

        public SubmissionsService(SULSContext db, IProblemsService problemService)
        {
            this.db = db;
            this.problemService = problemService;
        }


        public string CreateSubmission(string problemId, string userId, string code)
        {
            var problemPoints = this.problemService.GetProblemById(problemId).Points;

            Random rnd = new Random();
            int achievedResult = rnd.Next(0, problemPoints);

            var submission = new Submission
            {
                ProblemId = problemId,
                UserId = userId,
                Code = code,
                CreatedOn = DateTime.UtcNow,
                AchievedResult = achievedResult
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();

            return submission.Id;
        }

        public bool DeleteSubmissionById(string id)
        {
            var submissionToDelete = this.GetSubmissionById(id);

            this.db.Submissions.Remove(submissionToDelete);
            var result = this.db.SaveChanges();

            if (result != 0)
            {
                return true;
            }

            return false;
        }

        private Submission GetSubmissionById(string id)
        {
            var submission = this.db.Submissions.Find(id);
            return submission;
        }
    }

}
