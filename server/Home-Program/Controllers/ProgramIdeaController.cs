using Home_Program.Model;
using Home_Program.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Home_Program.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramIdeaController : ControllerBase
    {
        private readonly IProgramIdeaService _programIdeaService;


        public ProgramIdeaController(IProgramIdeaService programIdeaService)
        {
            _programIdeaService = programIdeaService;

        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<ProgramIdea>>> GetAllProgramIdeaListAsync()
        {
            try
            {
                var programIdeaList = await _programIdeaService.GetAllProgram();
                if (programIdeaList == null || !programIdeaList.Any())
                {
                    return NotFound("No program ideas found.");
                }
                return Ok(programIdeaList);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("id")]
        public async Task<ActionResult<ProgramIdea>> GetProgramIdeaByIdAsync(int id)
        {
            try
            {
                var existingProgramIdea = await _programIdeaService.GetProgramById(id);
                if (existingProgramIdea == null)
                {
                    return NotFound("Program idea not found.");
                }
                return Ok(existingProgramIdea);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("id")]
        public async Task<ActionResult<bool>> DeleteProgramIdeaByIdAsync(int id)
        {
            try
            {
                var existingProgramIdea = await _programIdeaService.DeleteProgramIdea(id);
                if (!existingProgramIdea)
                {
                    return NotFound("Program idea not found or unable to delete.");
                }
                return Ok(existingProgramIdea);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<ProgramIdea>>> GetProgramIdeaListByCategoryAsync(WeatherType type)
        {
            try
            {
                var existingProgramIdeas = await _programIdeaService.GetProgramByCategory(type);
                if (existingProgramIdeas == null || !existingProgramIdeas.Any())
                {
                    return NotFound("No program ideas found for the given category.");
                }
                return Ok(existingProgramIdeas);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPatch("id")]
        public async Task<ActionResult<ProgramIdea>> UpdateProgramIdeaAsync(int id, [FromBody] ProgramIdea programIdea)
        {
            try
            {
                var update = await _programIdeaService.UpdateProgramIdea(programIdea, id);
                if (update == null)
                {
                    return NotFound("Program idea not found or unable to update.");
                }
                return Ok(update);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<ProgramIdea>> AddProgramIdeaAsync([FromBody] ProgramIdea programIdea)
        {
            try
            {
                var update = await _programIdeaService.Add(programIdea, User);
                if (update == null)
                {
                    return BadRequest("Failed to add program idea.");
                }
                return CreatedAtAction(nameof(GetProgramIdeaByIdAsync), new { id = update.Id }, update);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("user-program-ideas")]
        public async Task<ActionResult<IEnumerable<ProgramIdea>>> GetUserProgramIdeasAsync()
        {
            try
            {
                var programIdeas = await _programIdeaService.GetUserProgramIdeas(User);
                if (programIdeas == null || !programIdeas.Any())
                {
                    return NotFound("No program ideas found for the user.");
                }

                return Ok(programIdeas);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
    
}
