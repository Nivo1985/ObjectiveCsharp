using System;

namespace Example
{
    public interface IAccountStare
    {
        IAccountStare Deposit(Action addToBalance);
        IAccountStare Withdraw(Action substractFromBalance);
        IAccountStare Freeze();
        IAccountStare HolderVerified();
        IAccountStare Close();

    }
}