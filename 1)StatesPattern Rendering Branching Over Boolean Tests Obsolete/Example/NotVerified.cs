using System;

namespace Example
{
    public class NotVerified: IAccountStare
    {
        private Action OnUnfreeze { get; }

        public NotVerified(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountStare Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountStare Withdraw(Action substractFromBalance) => this;

        public IAccountStare Freeze() => this;

        public IAccountStare HolderVerified() => new Active(this.OnUnfreeze);

        public IAccountStare Close() => new Closed();
    }
}