using BowlingAPI.Models;
using BowlingAPI.ViewModels; // Include this if BowlerTeamInfo is located in the ViewModels namespace
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BowlingAPI.Controllers
{
    // Adjust the route here if you want the controller itself to be accessed differently
    [Route("[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private readonly IBowlRepository _bowlRepository;

        public BowlerController(IBowlRepository temp)
        {
            _bowlRepository = temp;
        }

        // This action now serves the combined Bowler and Team information
        // Adjusted to use the root of the controller for simplicity
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BowlerTeamInfo>>> GetBowlerTeamInfo()
        {
            try
            {
                var bowlerTeamInfo = await _bowlRepository.GetBowlerTeamInfoAsync();

                if (bowlerTeamInfo == null || bowlerTeamInfo.Count == 0)
                {
                    return NotFound("No bowler team info found.");
                }

                return Ok(bowlerTeamInfo);
            }
            catch
            {
                // This is a simple catch-all error handling. 
                // Consider more specific error handling based on your requirements.
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
