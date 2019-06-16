namespace SULS.Services
{
    public interface ISubmissionsService
    {
        string CreateSubmission(string problemId, string userId, string code);
        bool DeleteSubmissionById(string id);
    }

}
