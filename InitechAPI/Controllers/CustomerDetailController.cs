using InitechAPI.BusinessTier;
using InitechAPI.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InitechAPI.Controllers
{
    public class CustomerDetailController : ApiController
    {
        [HttpGet]
        [Route("api/CustomerDetail/{page?}/{pageSize?}")]
        public HttpResponseMessage Get(int page = 1, int pageSize = 2)
        {
            var customerPagedListAPIResult = new CustomerPagedListAPIResult
            {
                Page = page,
                PageSize = pageSize,
                Usage = "HttpGet:~/api/CustomerDetail/{page?}/{pageSize?} or {args} can be on querystring, {args?} are optional"
            };

            customerPagedListAPIResult.CustomerList = CustomerBusinessLayer.GetCustomers(page, pageSize);

            if (customerPagedListAPIResult.CustomerList == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, customerPagedListAPIResult);
            }

            return Request.CreateResponse(HttpStatusCode.OK, customerPagedListAPIResult);
        }

        [HttpPut]
        [Route("api/CustomerDetail/{id}")]
        public HttpResponseMessage Put(int id, Customer customer)
        {
            var successAPIResult = new SuccessAPIResult()
            {
                Usage = "HttpPut:~/api/CustomerDetail/{id} with Customer json in body"
            };

            successAPIResult.Successful = new DBLayer().UpdateEntity<Customer>(customer, id);

            if (!successAPIResult.Successful)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, successAPIResult);
            }

            return Request.CreateResponse(HttpStatusCode.OK, successAPIResult);
        }
    }
}
