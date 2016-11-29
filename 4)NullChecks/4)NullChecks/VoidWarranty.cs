using System;

namespace _4_NullChecks
{
    public class VoidWarranty: IWarranty // null object // singleton
    {
        private static VoidWarranty instance;

        private VoidWarranty()
        {
        }

        public static VoidWarranty Instance => instance ?? (instance = new VoidWarranty());


        public void Claim(DateTime onDate, Action onValidClaim)
        {
        }
    }
}