using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SurveyProject.Business;
using SurveyProject.Models;
using SurveyProject.Models.DTOs;
using System.Diagnostics;

namespace SurveyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        SurveyBl surveyBl = new SurveyBl();
        SurveyProjectContext context= new SurveyProjectContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login","Login");
        }


        //kullanıcıya ait anketlerin görüntülendiği ana sayfa
        public IActionResult UserIndex()
        {
            string uId =User.Claims.Where(x => x.Type == "KullaniciId").Select(x => x.Value).SingleOrDefault();
            int userId = Convert.ToInt32(uId);
            
            List<int> solvedSurveys = context.Solution.Where(s => s.UserId == userId).Select(s => s.SurveyId).Distinct().ToList();

            
            List<AssignmentDTO> allAssignments = surveyBl.AssignmentList(userId);

            List<AssignmentDTO> unsolvedAssignments = allAssignments.Where(a => !solvedSurveys.Contains(a.Survey.Id)).ToList();
            return View(unsolvedAssignments);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}