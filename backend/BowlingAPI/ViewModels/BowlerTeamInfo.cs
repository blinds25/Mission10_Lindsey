using System.ComponentModel.DataAnnotations;

namespace BowlingAPI.ViewModels
{
    // In BowlerTeamInfo.cs
    public class BowlerTeamInfo
    {
        [Key]
        public int BowlerId { get; set; }
        public string BowlerName { get; set; }
        public string TeamName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
    }

}
