using System;

namespace _4_NullChecks
{
    public interface IWarranty
    {
        void Claim(DateTime onDate, Action onValidClaim);
    }
}