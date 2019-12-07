using System.Collections.Generic;

namespace InitechAPI.Models
{
    public class CustomerPagedListAPIResult : PagedListAPIResult
    {
        public List<Customer> CustomerList { get; set; }
    }
}