using Home_Program.Data;
using Home_Program.Model;
using Home_Program.Model.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;


namespace Home_Program.Services
{
    public class ProgramIdeaService : IProgramIdeaService
    {
        private readonly ApplicationDbContext _context;
      

        public ProgramIdeaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProgramIdea>> GetAllProgram()
        {
            var programs = await _context.ProgramIdea.ToListAsync();
            if(programs.Count == 0)
            {
                return Enumerable.Empty<ProgramIdea>();
            };
            return programs;
        }
        public async Task<ProgramIdea> GetProgramById(int id)
        {
            var program = await _context.ProgramIdea.FirstOrDefaultAsync(program => program.Id == id);
            if (program == null)
            {
                return null;
            };
            return program;
        }

        public async Task<bool> DeleteProgramIdea(int id) 
        {
            var program = await _context.ProgramIdea.FirstOrDefaultAsync(program => program.Id == id);
            if (program == null)
            {
                return false;
            };
            _context.ProgramIdea.Remove(program);
            _context.SaveChanges();
            return true;
        }
        
        public async Task<ProgramIdea> UpdateProgramIdea(ProgramIdea program, int id)
        {
            var existingProdramIdea = await _context.ProgramIdea.FirstOrDefaultAsync(p => p.Id == id);
            if (program == null)
            {
                return null;
            };
            if(existingProdramIdea == null)
            {
                return null;
            };
            existingProdramIdea.Name = program.Name;
            existingProdramIdea.IdealWeather = program.IdealWeather;
            existingProdramIdea.Description = program.Description;
     
            _context.ProgramIdea.Update(existingProdramIdea);
      
            await _context.SaveChangesAsync();
            return existingProdramIdea;
        }
        public async Task<IEnumerable<ProgramIdea>> GetProgramByCategory(WeatherType type)
        {
            var programIdeaList = await _context.ProgramIdea.Where(program => program.IdealWeather == type).ToListAsync();
            if(programIdeaList.Count == 0)
            {
                return Enumerable.Empty<ProgramIdea>();
            }
            return programIdeaList;
        }
        public async Task<ProgramIdea> Add(ProgramIdea program, ClaimsPrincipal userClaims)
        {
            if (program == null)
                throw new ArgumentNullException(nameof(program), "ProgramIdea cannot be null");

            if (string.IsNullOrWhiteSpace(program.Name))
                throw new ArgumentException("Name is required");

            if (string.IsNullOrWhiteSpace(program.Description))
                throw new ArgumentException("Description is required");

            if (!Enum.IsDefined(typeof(WeatherType), program.IdealWeather))
                throw new ArgumentException("Invalid WeatherType");

            var userEmail = userClaims.FindFirst(ClaimTypes.Email)?.Value;
           
            if (string.IsNullOrEmpty(userEmail))
            {
                return null;
            }
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (existingUser == null)
            {
                return null; 
            }
            var createdProgramIdea = new ProgramIdea
            {
                Name = program.Name,
                Description = program.Description,
                IdealWeather = program.IdealWeather,
                UserId = existingUser.Id
            };
            _context.Add(createdProgramIdea);
            await _context.SaveChangesAsync();
            return createdProgramIdea;
            
        }
        public async Task<IEnumerable<ProgramIdea>> GetUserProgramIdeas(ClaimsPrincipal userClaims)
        {
            var userEmail =  userClaims.FindFirst(ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userEmail))
            {
                return null;
            }
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (existingUser == null)
            {
                return null;
            }
            var programIdeas = await _context.ProgramIdea
                .Where(p=> p.UserId == existingUser.Id)
                .ToListAsync();
            return programIdeas;
        }
    }
}
