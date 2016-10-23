using System;

namespace Example
{
    public class Frozen: IAccountStare
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }
        public IAccountStare Deposit(Action addToBalance)
        {
            this.OnUnfreeze();
            addToBalance();
            return new Active(this.OnUnfreeze);
        }

        public IAccountStare Withdraw(Action substractFromBalance)
        {
            this.OnUnfreeze();
            substractFromBalance();
            return new Active(this.OnUnfreeze);
        }

        public IAccountStare Freeze() => this;
        public IAccountStare HolderVerified() => new Active(this.OnUnfreeze);

        public IAccountStare Close() => new Closed();
    }
}