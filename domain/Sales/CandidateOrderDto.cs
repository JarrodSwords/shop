namespace Shop.Domain.Sales
{
    public record CandidateOrderDto : IOrderBuilder
    {
        #region IOrderBuilder Implementation

        public Customer GetCustomer() =>
            new(
                "john.doe@gmail.com",
                "John",
                "Doe"
            );

        #endregion
    }
}
