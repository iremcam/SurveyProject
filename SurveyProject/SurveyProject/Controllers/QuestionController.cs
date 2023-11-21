using Microsoft.AspNetCore.Mvc;
using SurveyProject.Business;
using SurveyProject.Models;
using SurveyProject.Models.DTOs;

namespace SurveyProject.Controllers
{


    public class QuestionController : Controller
    {
        QuestionBl questionBl = new QuestionBl();
        public IActionResult Index(int id)  
        {
            ViewBag.SurveyId = id;
            return View(questionBl.GetQuestionList(id));
        }


   
        public IActionResult QuestionCreate(Survey survey)
        {
            QuestionDTO questionDTO = new QuestionDTO();
            questionDTO.SurveyId = survey.Id;

            return View(questionDTO);
        }
        [HttpPost]
        public IActionResult QuestionCreate(Question question)
        {
            questionBl.CreateQuestion(question);
            return RedirectToAction("Index", new { id = question.Id });
        }
    }
}
