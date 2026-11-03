using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Refactoring
{
    public enum AccountStatus
    {
        NotRegistered = 1,
        SimpleCustomer = 2,
        ValuableCustomer = 3,
        MostValuableCustomer = 4
    }

    public static class Constants
    {
        public const int MAXIMUM_DISCOUNT_FOR_LOYALTY = 5;
        public const decimal DISCOUNT_FOR_SIMPLE_CUSTOMERS = 0.1m;
        public const decimal DISCOUNT_FOR_VALUABLE_CUSTOMERS = 0.3m;
        public const decimal DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS = 0.5m;
    }

    public static class PriceExtensions
    {
        public static decimal ApplyDiscountForAccountStatus(this decimal price, decimal discountSize)
        {
            return price - (discountSize * price);
        }

        public static decimal ApplyDiscountForTimeOfHavingAccount(this decimal price, int timeOfHavingAccountInYears)
        {
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ? (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY / 100 : (decimal)timeOfHavingAccountInYears / 100;
            return price - (discountForLoyaltyInPercentage * price);
        }
    }

    public class DiscountManager
    {
        public decimal ApplyDiscount(decimal price, int accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;

            switch (accountStatus)
            {
                case (int)AccountStatus.NotRegistered:
                    priceAfterDiscount = price;
                    break;

                case (int)AccountStatus.SimpleCustomer:
                    priceAfterDiscount = price.ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS);
                    break;

                case (int)AccountStatus.ValuableCustomer:
                    priceAfterDiscount = price.ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS);
                    break;

                case (int)AccountStatus.MostValuableCustomer:
                    priceAfterDiscount = price.ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS);
                    break;

                default:
                    throw new NotImplementedException();
            }
            priceAfterDiscount = priceAfterDiscount.ApplyDiscountForTimeOfHavingAccount(timeOfHavingAccountInYears);

            return priceAfterDiscount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the DiscountManager
            DiscountManager manager = new DiscountManager();

            // Set up some test variables
            decimal originalPrice = 1000m;
            int status = (int)AccountStatus.ValuableCustomer;
            int years = 4;

            // Call the method
            decimal priceAfterDiscount = manager.ApplyDiscount(originalPrice, status, years);

            // Print the results
            Console.WriteLine("Original price: " + originalPrice);
            Console.WriteLine("Price after discount: " + priceAfterDiscount);
        }
    }
}