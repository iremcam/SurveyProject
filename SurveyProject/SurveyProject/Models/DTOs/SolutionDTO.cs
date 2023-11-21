namespace SurveyProject.Models.DTOs
{
    public class SolutionDTO
    {
        public Question Question { get; set; }
        public List<Option> Option { get; set; }
        public List<Question> Questions { get; set; }
        public int AssignmentId { get; set; }
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public int Status { get; set; }
        

        //status eklenebilir
    }
}
