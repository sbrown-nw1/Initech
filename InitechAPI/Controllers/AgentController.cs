using InitechAPI.BusinessTier;
using InitechAPI.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InitechAPI.Controllers
{
    public class AgentController : ApiController
    {
        [HttpGet]
        [Route("api/Agent/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var agentAPIResult = new AgentAPIResult()
            {
                Usage = "HttpGet:~/api/Agent/{id} or {args} can be on querystring, {args?} are optional"
            };

            agentAPIResult.Agent = AgentBusinessLayer.GetAgent(id);

            if (agentAPIResult.Agent == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, agentAPIResult);
            }

            return Request.CreateResponse(HttpStatusCode.OK, agentAPIResult);
        }

        [HttpPut]
        [Route("api/Agent/{id}")]
        public HttpResponseMessage Put(int id, Agent agent)
        {
            var successAPIResult = new SuccessAPIResult()
            {
                Usage = "HttpPut:~/api/Agent/{id} with Agent json in body"
            };

            successAPIResult.Successful = AgentBusinessLayer.UpdateAgent(id, agent);

            if (!successAPIResult.Successful)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, successAPIResult);
            }

            return Request.CreateResponse(HttpStatusCode.OK, successAPIResult);   
        }
    }
}
