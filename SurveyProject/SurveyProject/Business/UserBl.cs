using SurveyProject.Models;

namespace SurveyProject.Business
{
    public class UserBl
    {
        SurveyProjectContext Context = new SurveyProjectContext();
        public List<User> GetUserList()
        {
            List<User> users = Context.User.ToList();

            return users;
        }
        public User? UserControl(User users)
        {
            users = Context.User.FirstOrDefault(x => x.UserName == users.UserName && x.UserPassword == users.UserPassword);
            if (users == null)
            {
                return null;
            }
            users.UserType = Context.UserType.FirstOrDefault(x => x.Id == users.UserTypeId);
            return users;
        }

    }
}
