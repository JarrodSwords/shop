using System.Collections.Generic;
using System.Linq;
using Jgs.Cqrs;
using Microsoft.AspNetCore.Mvc;
using Shop.Sales.Services;

namespace Shop.Api.Sales
{
    [Route("api/sales/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IQueryHandler<FetchCustomers, IEnumerable<CustomerDto>> _fetchCustomers;
        private readonly IQueryHandler<FindCustomer, CustomerDto> _findCustomer;

        #region Creation

        public CustomersController(
            IQueryHandler<FetchCustomers, IEnumerable<CustomerDto>> fetchCustomers,
            IQueryHandler<FindCustomer, CustomerDto> findCustomer
        )
        {
            _fetchCustomers = fetchCustomers;
            _findCustomer = findCustomer;
        }

        #endregion

        #region Public Interface

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> FetchCustomers() => _fetchCustomers.Handle(new()).ToList();

        [HttpGet("{email}")]
        public ActionResult<CustomerDto> FindCustomer(string email) => _findCustomer.Handle(email);

        #endregion
    }
}
