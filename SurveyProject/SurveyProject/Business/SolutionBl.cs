using SurveyProject.Models;

namespace SurveyProject.Business
{
    public class SolutionBl
    {

        SurveyProjectContext context = new SurveyProjectContext();

        public bool SolutionCreate(Solution solution)
        {
            
            context.Solution.Add(solution);
            context.SaveChanges();
            return true;
        }
        public List<Solution> GetSolutionList(int surveyId)
        {
            List<Solution> list = context.Solution.Where(a => a.SurveyId == surveyId).ToList();
            return list;
        }
    }
}
