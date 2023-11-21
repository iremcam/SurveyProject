namespace SurveyProject.Models.DTOs
{
    public class AssignmentDTO
    {
        public int AssignmentUserId { get; set; }
        //public int UserId { get; set; }
        
        public Survey Survey { get; set; }
        public int Status { get; set; }
        
    }
}
