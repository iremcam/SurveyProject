using SurveyProject.Models;
using SurveyProject.Models.DTOs;

namespace SurveyProject.Business
{
    public class SurveyBl
    {


        SurveyProjectContext context=new SurveyProjectContext();


        public List<Survey> GetSurveyList()
        {
            List<Survey> list = context.Survey.ToList();
            return list;
        }

        public bool CreateSurvey(Survey survey)
        {
            context.Survey.Add(survey);
            context.SaveChanges();
            return true;
        }

        public List<AssignmentDTO> AssignmentList( int userId)
        {
            List<Assignment> UserAssignments = context.Assignment.Where(a=>a.UserId == userId).ToList();
            List<AssignmentDTO> assignmentList =new List<AssignmentDTO>();
            foreach (var item in UserAssignments)
            {
                AssignmentDTO assignment = new AssignmentDTO();
                assignment.AssignmentUserId = item.Id;
                assignment.Survey=context.Survey.FirstOrDefault(a=>a.Id==item.SurveyId);
                List<Solution> solutions=context.Solution.Where(a=>a.UserId==userId && a.SurveyId==item.SurveyId).ToList();


                assignmentList.Add(assignment);
            }

            return assignmentList;
        }
    }
}
