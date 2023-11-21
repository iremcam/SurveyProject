using Microsoft.AspNetCore.Mvc;
using SurveyProject.Models;
using SurveyProject.Models.DTOs;

namespace SurveyProject.Business
{
    public class AssignmentBl
    {
         SurveyProjectContext context =new SurveyProjectContext();
        public List<Assignment> GetAssignmentList()
        {
            List<Assignment> assignments = context.Assignment.ToList();
            return assignments;
        }
        public bool UserAssignment(Assignment assignment)
        {
            assignment.Id = 0;
            context.Assignment.Add(assignment);
            context.SaveChanges();
            return true;

        }
        public bool  UpdateStatus(int id)
        {
            Assignment assignment = context.Assignment.FirstOrDefault(x => x.Id == id);
            if (assignment.Status == null)
            {
                assignment.Status = 1;
                context.Assignment.Update(assignment);
                context.SaveChanges();
            }
            return true;
        }
    }
}
