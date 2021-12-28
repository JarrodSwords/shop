using System;
using Jgs.Cqrs;
using Jgs.Ddd;
using Microsoft.AspNetCore.Mvc;
using Shop.Catalog.Services;

namespace Shop.Api.Catalog
{
    [Route("api/catalog/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IQueryHandler<FindCompany, CompanyDto> _findCompanyHandler;
        private readonly ICommandHandler<RegisterCompany, Id> _registerCompanyHandler;

        #region Creation

        public CompaniesController(
            IQueryHandler<FindCompany, CompanyDto> findCompanyHandler,
            ICommandHandler<RegisterCompany, Id> registerCompanyHandler
        )
        {
            _findCompanyHandler = findCompanyHandler;
            _registerCompanyHandler = registerCompanyHandler;
        }

        #endregion

        #region Public Interface

        [HttpGet("{id:guid}", Name = "FindCompany")]
        public ActionResult<CompanyDto> FindCompany(Guid id) => _findCompanyHandler.Handle(id);

        [HttpPost]
        public ActionResult<CompanyDto> RegisterCompany([FromBody] RegisterCompany command)
        {
            var id = _registerCompanyHandler.Handle(command);

            return CreatedAtRoute(
                nameof(FindCompany),
                new { id },
                new CompanyDto(id, command.Name)
            );
        }

        #endregion
    }
}
