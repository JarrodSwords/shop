using System;

namespace Shop.Sales.Services
{
    public record OrderDto(
        Guid Id,
        string Email,
        decimal Balance,
        decimal Paid,
        decimal Refunded,
        decimal Subtotal,
        decimal Tip
    );
}
