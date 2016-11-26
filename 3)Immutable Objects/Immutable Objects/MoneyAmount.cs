using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Immutable_Objects
{
    sealed class MoneyAmount: IEquatable<MoneyAmount>
    {
        public decimal Amount { get;}
        public string CurrencySymbol { get;}

        public MoneyAmount(decimal amount, string currencySymbol)
        {
            Amount = amount;
            CurrencySymbol = currencySymbol;
        }
        
        public override string ToString() => $"{this.Amount} {this.CurrencySymbol}";

        public static MoneyAmount operator *(MoneyAmount amount, decimal factory) => amount.Scale(factory);

        public static bool operator ==(MoneyAmount a, MoneyAmount b) =>
            (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) ||
            (!object.ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(MoneyAmount a, MoneyAmount b) => !(a == b);

        public MoneyAmount Scale(decimal factor) =>
            new MoneyAmount(this.Amount * factor, this.CurrencySymbol);

        public override int GetHashCode() =>
            this.Amount.GetHashCode() ^ this.CurrencySymbol.GetHashCode();

        public override bool Equals(object obj) =>
            this.Equals(obj as MoneyAmount);

        public bool Equals(MoneyAmount other) =>
            other != null &&
            this.Amount == other.Amount &&
            this.CurrencySymbol == other.CurrencySymbol;
    }
}
