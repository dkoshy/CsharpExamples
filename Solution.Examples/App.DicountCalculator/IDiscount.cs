namespace App.DicountCalculator;

public  interface IDiscountRule
{
     static  decimal CurrentDiscount = 0.0m;
    decimal CalculateDiscount(Customer customer);
}
