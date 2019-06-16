using Microsoft.EntityFrameworkCore;
using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext db;

        public ProblemsService(SULSContext db)
        {
            this.db = db;
        }

        public string CreateProblem(string name, int totalPoints)
        {
            // TODO: Check if problem already exisits
            var problem = new Problem
            {
                Name = name,
                Points = totalPoints
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();

            return problem.Id;
        }

        public IEnumerable<Problem> GetAllProblems()
        {
            var problems = this.db.Problems.Include(p => p.Submissions).ToList();
            return problems;
        }

        public Problem GetProblemById(string id)
        {
            var problem = this.db.Problems
                              .Include(p => p.Submissions)
                              .ThenInclude(s => s.User)
                              .SingleOrDefault(s => s.Id == id);
            return problem;
        }
    }
}
