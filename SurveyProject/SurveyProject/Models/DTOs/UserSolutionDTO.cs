namespace SurveyProject.Models.DTOs
{
    public class UserSolutionDTO
    {
        public int SurveyId { get; set; }
        public int AssignmentId { get; set; }    
        public int UserId { get; set; }
        public int OptionId { get; set; }
        public int QuestionId { get; set; }
       
        public Dictionary<int, int> SelectedOptions { get; set; }

    }
}
