using System;
using System.Runtime.CompilerServices;

namespace _4_NullChecks
{
    public class LifeTimeWarranty : IWarranty
    {
        private DateTime IssuingDate { get; }

        public LifeTimeWarranty(DateTime issuingDate)
        {
            this.IssuingDate = issuingDate;
        }

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!this.IsValid(onDate))
                return;

            onValidClaim();
        }

        private bool IsValid(DateTime date) => date.Date >= this.IssuingDate;
    }
}