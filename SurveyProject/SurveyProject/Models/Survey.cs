namespace SurveyProject.Models
{
    public partial class Survey:Base
    {
        public string? Title { get; set; }
        public Survey()
        {
             Questions = new HashSet<Question>();
            Assignments = new HashSet<Assignment>();
            Solutions= new HashSet<Solution>();
        }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }
    }
}
