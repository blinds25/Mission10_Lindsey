using BowlingAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingAPI.Models
{
    public class EFBowlRepository : IBowlRepository
    {
        private AppDbContext _context;

        public EFBowlRepository(AppDbContext temp)
        {
            _context = temp;
        }

        public IEnumerable<Bowler> Bowlers => _context.Bowlers;

        public async Task<List<BowlerTeamInfo>> GetBowlerTeamInfoAsync()
        {
            return await _context.Bowlers
                .Include(b => b.Team) // Ensure you are loading the Team information
                .Where(b => b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")
                .Select(b => new BowlerTeamInfo
                {
                    // Construct the BowlerName from the first, middle (if it exists), and last names
                    BowlerId = b.BowlerId,
                    BowlerName = $"{b.BowlerFirstName} {(string.IsNullOrEmpty(b.BowlerMiddleInit) ? "" : b.BowlerMiddleInit + " ")}{b.BowlerLastName}",
                    TeamName = b.Team != null ? b.Team.TeamName : "No Team", // Handle bowlers without a team
                    Address = b.BowlerAddress,
                    City = b.BowlerCity,
                    State = b.BowlerState,
                    Zip = b.BowlerZip,
                    PhoneNumber = b.BowlerPhoneNumber
                }).ToListAsync();
        }
    }
}
