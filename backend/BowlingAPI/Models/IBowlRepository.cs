using BowlingAPI.ViewModels;

namespace BowlingAPI.Models
{
    public interface IBowlRepository
    {
        IEnumerable<Bowler> Bowlers { get; }
        Task<List<BowlerTeamInfo>> GetBowlerTeamInfoAsync();
    }
}
