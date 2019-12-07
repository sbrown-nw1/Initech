using System.Collections.Generic;

namespace InitechAPI.Models
{
    public class AgentPagedListAPIResult : PagedListAPIResult
    {
        public List<Agent> AgentList { get; set; }
    }
}