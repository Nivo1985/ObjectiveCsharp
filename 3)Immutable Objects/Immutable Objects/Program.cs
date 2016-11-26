using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immutable_Objects
{
    class Program
    {
        static bool IsHappyHour { get; set; }



        static MoneyAmount Reserve(MoneyAmount cost)
        {
            decimal factory = 1;

            if (IsHappyHour)
            {
                factory = .5M;
            }

            Console.WriteLine("Reserved cost {0}", cost);
            return cost * factory;
        }

        static void Buy(MoneyAmount wallet, MoneyAmount cost)
        {
            var enoughtMoney = wallet.Amount >= cost.Amount;

            var finalCost = Reserve(cost);

            var finalEnough = wallet.Amount >= finalCost.Amount;

            if (enoughtMoney && finalEnough)
                Console.WriteLine("You will pay {0} with your {1}", cost, wallet);
            else if (finalEnough)
            {
                Console.WriteLine("This time, {0} will be enough to pay {1}", wallet, finalEnough);
            }
            else
                Console.WriteLine("You cannot pay {0} with your {1}", cost, wallet);
        }

        static void Main(string[] args)
        {
            #region Buying Flow
            //Buy(new MoneyAmount(12, "USD"),
            //    new MoneyAmount(10, "USD"));

            //Buy(new MoneyAmount(7, "USD"),
            //    new MoneyAmount(10, "USD"));

            //IsHappyHour = true;
            //Buy(new MoneyAmount(7, "USD"),
            //    new MoneyAmount(10, "USD")); 
            #endregion

            #region Equels
            //var x = new MoneyAmount(2, "USD");
            //var y = new MoneyAmount(4, "USD");

            //if (x.Equals(y))
            //{
            //    Console.WriteLine("x == y");
            //}
            //if ((x * 2).Equals(y))
            //{
            //    Console.WriteLine("x * 2 == y"); 
            //}
            #endregion

            #region Hash

            var x = new MoneyAmount(2,"USD");
            var y = new MoneyAmount(2, "USD");

            HashSet<MoneyAmount> set = new HashSet<MoneyAmount>();

            set.Add(x);

            if (set.Contains(y))
                Console.WriteLine("cannot add value");
            else
                set.Add((y));

            Console.WriteLine("Count = {0}", set.Count);

            #endregion

            Console.ReadLine();
        }
    }
}

