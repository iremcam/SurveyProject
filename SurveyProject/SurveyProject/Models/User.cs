namespace SurveyProject.Models
{
    public partial class User:Base
    {
        public User()
        {
            Assignments = new HashSet<Assignment>();
            Solutions =new HashSet<Solution>();
        }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public virtual UserType? UserType { get; set; }
        public int UserTypeId { get; set; }
        
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }

    }
}
