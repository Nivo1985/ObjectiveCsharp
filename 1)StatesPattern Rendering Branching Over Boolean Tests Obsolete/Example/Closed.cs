using System;

namespace Example
{
    public class Closed: IAccountStare
    {
        public IAccountStare Deposit(Action addToBalance) => this;

        public IAccountStare Withdraw(Action substractFromBalance) => this;

        public IAccountStare Freeze() => this;

        public IAccountStare HolderVerified() => this;

        public IAccountStare Close() => this;
    }
}