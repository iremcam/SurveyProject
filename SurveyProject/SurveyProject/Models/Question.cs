namespace SurveyProject.Models
{
    public partial class Question:Base
    {
        public Question()
        {
            Options = new HashSet<Option>();
            Solutions=new HashSet<Solution>();
        }
        public virtual ICollection<Option> Options { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }
        public string? Description { get; set; }

        public virtual Survey? Survey { get; set;}
        public int SurveyId { get; set; }
        public int Order { get; set; }

    }
}
