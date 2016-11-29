using System;
using System.Runtime.CompilerServices;

namespace _4_NullChecks
{
    public class TimeLimitedWarranty: IWarranty
    {
        private DateTime DateIssued
        {
            get;
        }

        private TimeSpan Duration
        {
            get;
        }

        public TimeLimitedWarranty(DateTime dateIssued, TimeSpan duration)
        {
            this.DateIssued = dateIssued;
            this.Duration = TimeSpan.FromDays(duration.Days);
        }

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!this.IsValid(onDate))
            return;

            onValidClaim();
        }

        private bool IsValid(DateTime date) =>
            date.Date >= this.DateIssued && date.Date < this.DateIssued + this.Duration;
    }
}