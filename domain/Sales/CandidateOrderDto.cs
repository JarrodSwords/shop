namespace Shop.Domain.Sales
{
    public record CandidateOrderDto : IOrderBuilder
    {
        #region IOrderBuilder Implementation

        public Customer GetCustomer() => new();

        #endregion
    }
}
