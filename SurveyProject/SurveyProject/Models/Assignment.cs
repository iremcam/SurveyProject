namespace SurveyProject.Models
{
    public partial class Assignment:Base
    {
        public virtual Survey? Survey { get; set; }
        public virtual User? User { get; set; }
        public int SurveyId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }

    }
}
