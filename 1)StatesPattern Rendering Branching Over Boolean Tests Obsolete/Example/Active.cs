using System;

namespace Example
{
    public class Active: IAccountStare
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountStare Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountStare Withdraw(Action substractFromBalance)
        {
            substractFromBalance();
            return this;
        }

        public IAccountStare Freeze() => new Frozen(this.OnUnfreeze);
        public IAccountStare HolderVerified() => this;

        public IAccountStare Close() => new Closed();
    }
}