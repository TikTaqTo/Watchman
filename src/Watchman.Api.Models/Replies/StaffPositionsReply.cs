using System.Collections.Generic;
using Watchman.Api.Models.Dictionaries;

namespace Watchman.Api.Models.Replies
{
    public class StaffPositionsReply : CommonReply
    {
        public IEnumerable<StaffPosition> StaffPositions { get; set; }
    }
}