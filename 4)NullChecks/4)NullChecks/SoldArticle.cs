using System;

namespace _4_NullChecks
{
    public class SoldArticle
    {
        public IWarranty MoneyBackGuatantee { get; private set; }
        public IWarranty ExpressWarranty { get; private set; }

        private IWarranty NotOperationalWarranty { get; }

        public SoldArticle(IWarranty moneyBackGuatantee, IWarranty expressWarranty)
        {
            if (moneyBackGuatantee == null)
            {
                throw new ArgumentNullException(nameof(moneyBackGuatantee));
            }

            if (expressWarranty == null)
            {
                throw new ArgumentNullException(nameof(expressWarranty));
            }

            this.MoneyBackGuatantee = moneyBackGuatantee;
            this.ExpressWarranty = VoidWarranty.Instance;
            this.NotOperationalWarranty = expressWarranty;
        }

        public void VisibleDamage()
        {
            this.MoneyBackGuatantee = VoidWarranty.Instance;
        }

        public void NotOperational()
        {
            this.MoneyBackGuatantee = VoidWarranty.Instance;
            this.ExpressWarranty = this.NotOperationalWarranty;
        }
    }
}