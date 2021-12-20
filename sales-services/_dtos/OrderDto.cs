using System;

namespace Shop.Sales.Services
{
    public record OrderDto(
        Guid Id,
        string Email,
        decimal Subtotal,
        decimal Tip,
        decimal Total
    );
}
