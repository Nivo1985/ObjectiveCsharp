using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_NullChecks
{
    class Program
    {
        static void ClaimWarranty(SoldArticle article)
        {
            var now = DateTime.Now;

            article.MoneyBackGuatantee.Claim(now, () => Console.WriteLine("Money can be given back"));

            article.ExpressWarranty.Claim(now, () => Console.WriteLine("Offer repair"));
            
        }
        static void Main(string[] args)
        {
            var sellingDate = new DateTime(2016, 11, 28);
            var moneyBackTimeSpam = TimeSpan.FromDays(30);
            var warrantySpan = TimeSpan.FromDays(365);

            var moneyBack = new TimeLimitedWarranty(sellingDate, moneyBackTimeSpam);
            var repairWarranty = new TimeLimitedWarranty(sellingDate, warrantySpan);

            var goods = new SoldArticle(VoidWarranty.Instance, repairWarranty);
            //var goods = new SoldArticle(moneyBack, repairWarranty);

            ClaimWarranty(goods);

            Console.ReadLine();
        }
    }
}
