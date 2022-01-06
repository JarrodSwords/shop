using System;
using Jgs.Cqrs;
using Jgs.Functional;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog;
using Shop.Catalog.Services;

namespace Shop.Api.Catalog
{
    [Route("api/catalog/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IQueryHandler<FindVendor, VendorDto> _findVendor;
        private readonly ICommandHandler<RegisterVendor, Result<VendorRegistered>> _registerVendor;

        #region Creation

        public VendorsController(
            IQueryHandler<FindVendor, VendorDto> findVendor,
            ICommandHandler<RegisterVendor, Result<VendorRegistered>> registerVendor
        )
        {
            _findVendor = findVendor;
            _registerVendor = registerVendor;
        }

        #endregion

        #region Public Interface

        [HttpGet("{id:guid}", Name = "FindVendor")]
        public ActionResult<VendorDto> FindVendor(Guid id) => _findVendor.Handle(id);

        [HttpPost]
        public ActionResult<VendorRegistered> RegisterVendor([FromBody] RegisterVendor command)
        {
            var vendor = _registerVendor.Handle(command);

            return CreatedAtRoute(
                nameof(FindVendor),
                vendor,
                vendor
            );
        }

        #endregion
    }
}
