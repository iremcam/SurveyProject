using Microsoft.AspNetCore.Mvc;
using SurveyProject.Business;
using SurveyProject.Models;
using SurveyProject.Models.DTOs;

namespace SurveyProject.Controllers
{
    public class AssignmentController : Controller
    {
        SurveyBl SurveyBl = new SurveyBl();
        UserBl userBl = new UserBl();
        AssignmentBl assignmentBl=new AssignmentBl();
        public IActionResult Index()
        {
            return View(assignmentBl.GetAssignmentList());
        }
        [HttpPost]
        public IActionResult AssignmentCreate(Assignment assignment)
        {
            assignmentBl.UserAssignment(assignment);
            return RedirectToAction("Index", new { id = assignment.SurveyId });
        }



        //anket kullanıcı ataması
        public IActionResult AssignmentCreate(int id)
        { 
            UserAssignment dto = new UserAssignment();

            dto.Users = userBl.GetUserList();
            dto.SurveyId = id;
            return  View(dto);
        }
    }
}
