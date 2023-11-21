using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyProject.Business;
using SurveyProject.Models;

namespace SurveyProject.Controllers
{
    [Authorize]
   
    public class SurveyController:Controller
    {
        SurveyBl surveyBl = new SurveyBl();
        SolutionBl solutionBl = new SolutionBl();
        QuestionBl questionBl = new QuestionBl();

        [HttpGet]
        public IActionResult Index()
        {
            return View(surveyBl.GetSurveyList());           
        }

        public IActionResult SurveyCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SurveyCreate(Survey survey)
        {
            surveyBl.CreateSurvey(survey);
            return RedirectToAction("Index");
        }

        public IActionResult SurveyAnswers(int id)
        {
            ViewBag.SurveyId = id;
            return View(solutionBl.GetSolutionList(id));        

        }
    }
}
