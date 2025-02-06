using Home_Program.Model;
using System.Security.Claims;

namespace Home_Program.Services
{
    public interface IProgramIdeaService
    {
        Task<IEnumerable<ProgramIdea>> GetAllProgram();
        Task<IEnumerable<ProgramIdea>> GetProgramByCategory(WeatherType type );
        Task<bool> DeleteProgramIdea(int id);
        Task<ProgramIdea> GetProgramById(int id);
        Task<ProgramIdea> UpdateProgramIdea(ProgramIdea program, int id);
        Task<ProgramIdea> Add(ProgramIdea program, ClaimsPrincipal userClaims);
        Task<IEnumerable<ProgramIdea>> GetUserProgramIdeas(ClaimsPrincipal userClaims);
    }
}
