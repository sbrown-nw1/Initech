using InitechAPI.BusinessTier;
using InitechAPI.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InitechAPI.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        [Route("api/Customers/{agentId}/{page?}/{pageSize?}")]
        public HttpResponseMessage Get(int agentId, int page = 1, int pageSize = 2)
        {
            var customerPagedListAPIResult = new CustomerPagedListAPIResult
            {
                Page = page,
                PageSize = pageSize,
                Usage = "HttpGet:~/api/Customers/{agentId}/{page?}/{pageSize?} or {args} can be on querystring, {args?} are optional"
            };

            customerPagedListAPIResult.CustomerList = CustomerBusinessLayer.GetCustomersByAgentId(agentId, page, pageSize);

            if (customerPagedListAPIResult.CustomerList == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, customerPagedListAPIResult);
            }

            return Request.CreateResponse(HttpStatusCode.OK, customerPagedListAPIResult);
        }

        [HttpPost]
        [Route("api/Customers")]
        public HttpResponseMessage Create(Customer customer)
        {
            var idAPIResult = new IdAPIResult()
            {
                Usage = "HttpPost:~/api/Customers with Customer json in body"
            };

            idAPIResult.Id = CustomerBusinessLayer.CreateCustomer(customer);

            return Request.CreateResponse(HttpStatusCode.OK, idAPIResult);
        }

        [HttpDelete]
        [Route("api/Customers/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var successAPIResult = new SuccessAPIResult()
            {
                Usage = "HttpDelete:~/api/Customers/{id} or {args} can be on querystring, {args?} are optional"
            };

            successAPIResult.Successful = CustomerBusinessLayer.DeleteCustomer(id);

            if (!successAPIResult.Successful)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, successAPIResult);
            }

            return Request.CreateResponse(HttpStatusCode.OK, successAPIResult);
        }
    }
}
