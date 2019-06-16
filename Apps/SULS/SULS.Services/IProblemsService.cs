using SULS.Models;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemsService
    {
        IEnumerable<Problem> GetAllProblems();
        string CreateProblem(string name, int totalPoints);
        Problem GetProblemById(string id);
    }
}
