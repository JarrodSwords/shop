using System;

namespace Shop.ApplicationServices.Sales
{
    public record CustomerDto(
        string Email,
        string FirstName,
        string LastName,
        Guid id = default
    );
}
