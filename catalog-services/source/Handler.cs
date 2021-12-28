using Jgs.Cqrs;

namespace Shop.Catalog.Services
{
    public abstract class Handler<T, TResult> : ICommandHandler<T, TResult> where T : ICommand
    {
        #region Creation

        protected Handler(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        #region Public Interface

        public IUnitOfWork Uow { get; }

        #endregion

        #region ICommandHandler<T,TResult> Implementation

        public abstract TResult Handle(T command);

        #endregion
    }
}
