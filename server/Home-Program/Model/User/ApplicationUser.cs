using Microsoft.AspNetCore.Identity;

namespace Home_Program.Model.User
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ProgramIdea> programIdeas = new List<ProgramIdea>();

        public ApplicationUser(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
    }
}
