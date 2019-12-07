using InitechAPI.BusinessTier;
using InitechAPI.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InitechAPI.Controllers
{
    public class AgentsController : ApiController
    {
        [HttpGet]
        [Route("api/Agents/{page?}/{pageSize?}")]
        public HttpResponseMessage Get(int page = 1, int pageSize = 2)
        {
            var agentPagedListAPIResult = new AgentPagedListAPIResult
            {
                Page = page,
                PageSize = pageSize,
                Usage = "HttpGet:~/api/Agents/{page?}/{pageSize?} or {args} can be on querystring, {args?} are optional"
            };

            agentPagedListAPIResult.AgentList = AgentBusinessLayer.GetAgents(page, pageSize);

            if (agentPagedListAPIResult.AgentList == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, agentPagedListAPIResult);
            }

            return Request.CreateResponse(HttpStatusCode.OK, agentPagedListAPIResult);
        }

        [HttpPost]
        [Route("api/Agents")]
        public HttpResponseMessage Create(Agent agent)
        {
            var idAPIResult = new IdAPIResult
            {
                Usage = "HttpPost:~/api/Agents with Agent json in body"
            };

            idAPIResult.Id = AgentBusinessLayer.CreateAgent(agent);

            return Request.CreateResponse(HttpStatusCode.OK, idAPIResult);
        }
    }
}
