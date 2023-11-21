

namespace SurveyProject.Models
{
    public partial class Option:Base
    {
        
        public string? Name { get; set; }
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
