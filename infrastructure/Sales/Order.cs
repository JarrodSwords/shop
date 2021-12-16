using System;
using DomainOrder = Shop.Domain.Sales.Order;

namespace Shop.Infrastructure.Sales
{
    public partial class Order : Entity
    {
        #region Creation

        public Order(Guid id) : base(id)
        {
        }

        public Order(DomainOrder order) : base(order.Id)
        {
            Baguettes = order.Details.Baguettes;
            CouplesBoxes = order.Details.CouplesBoxes;
            CustomerId = order.CustomerId;
            DessertBoxes = order.Details.DessertBoxes;
            FamilyBoxes = order.Details.FamilyBoxes;
            IsGift = order.Details.IsGift;
            IsSpecialOccasion = order.Details.IsSpecialOccasion;
            LunchBoxes = order.Details.LunchBoxes;
            PartyBoxes = order.Details.PartyBoxes;
            Strawberries = order.Details.Strawberries;
        }

        #endregion

        #region Public Interface

        public ushort Baguettes { get; set; }
        public ushort CouplesBoxes { get; set; }
        public Guid CustomerId { get; set; }
        public ushort DessertBoxes { get; set; }
        public ushort FamilyBoxes { get; set; }
        public bool IsGift { get; set; }
        public bool IsSpecialOccasion { get; set; }
        public ushort LunchBoxes { get; set; }
        public ushort PartyBoxes { get; set; }
        public ushort Strawberries { get; set; }

        #endregion

        #region Static Interface

        public static implicit operator Order(DomainOrder source) => new(source);

        #endregion
    }
}
