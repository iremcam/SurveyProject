namespace SurveyProject.Models
{
    public partial class UserType:Base
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }
        public virtual ICollection<User> Users { get; set; }
        public string? Name { get; set; }
    }
}
