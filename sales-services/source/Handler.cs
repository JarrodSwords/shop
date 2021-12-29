using Jgs.Cqrs;

namespace Shop.Sales.Services
{
    public abstract class Handler<T> : ICommandHandler<T> where T : ICommand
    {
        #region Creation

        protected Handler(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        #region Protected Interface

        protected IUnitOfWork Uow { get; }

        #endregion

        #region ICommandHandler<T> Implementation

        public abstract void Handle(T args);

        #endregion
    }

    public abstract class Handler<T, TResult> : ICommandHandler<T, TResult> where T : ICommand
    {
        #region Creation

        protected Handler(IUnitOfWork uow)
        {
            Uow = uow;
        }

        #endregion

        #region Protected Interface

        protected IUnitOfWork Uow { get; }

        #endregion

        #region ICommandHandler<T,TResult> Implementation

        public abstract TResult Handle(T args);

        #endregion
    }
}
