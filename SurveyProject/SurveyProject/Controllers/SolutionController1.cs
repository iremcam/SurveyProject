using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using SurveyProject.Business;
using SurveyProject.Models;
using SurveyProject.Models.DTOs;

namespace SurveyProject.Controllers
{
    public class SolutionController1 : Controller
    {
        SolutionBl solutionBl = new SolutionBl();
        SurveyBl surveyBl = new SurveyBl();
        QuestionBl questionBl = new QuestionBl();
        AssignmentBl assignmentBl = new AssignmentBl();
        SurveyProjectContext context = new SurveyProjectContext();

        public IActionResult Index(int id)
        {
            int userId = Convert.ToInt32(User.Claims.Where(a => a.Type == "KullaniciId").Select(x => x.Value).SingleOrDefault().ToString());
            List<SolutionDTO> dtoList = new List<SolutionDTO>();
            SolutionDTO dto = questionBl.BringtheQuestion(id, userId);
          
            return View(dto);
        }

        [HttpPost]
        public IActionResult SolutionCreate(UserSolutionDTO dto)
        {
            int userId = Convert.ToInt32(User.Claims.Where(x => x.Type == "KullaniciId").Select(x => x.Value).SingleOrDefault().ToString());

            foreach (var questionId in dto.SelectedOptions.Keys)
            {
                Solution solution = new Solution
                {
                    QuestionId = questionId,
                    OptionId = dto.SelectedOptions[questionId],
                    SurveyId = context.Question.Where(a => a.Id == questionId).Select(a => a.SurveyId).FirstOrDefault(),
                    UserId = userId
                };

                solutionBl.SolutionCreate(solution);
            }



            return RedirectToAction("Index", new { id = dto.AssignmentId });
        }
    }
}
