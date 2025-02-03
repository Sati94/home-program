using Microsoft.AspNetCore.Identity;

namespace Home_Program.Model.User
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ProgramIdea> programIdeas { get; set; }

        public ApplicationUser(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
    }
}
