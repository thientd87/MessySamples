using System;

namespace MessyExample.DelegatesSamples
{
    public class TaxFormulars
    {
        public delegate float TaxFormular(float price);

        //USA tax = 7%
        public static float UsaTaxFormular(float price)
        {
            return 7 * price / 100;
        }
        //Vn tax = 10%
        public static float VietNamTaxFormular(float price)
        {
            return 10 * price / 100;
        }
        //Default tax = 5%
        public static float DefaultTaxFormular(float price)
        {
            return 5 * price / 100;
        }

        public static TaxFormular GetTaxFormularByCountry(string countryCode)
        {
            switch (countryCode)
            {
                case "vn":
                    return TaxFormulars.VietNamTaxFormular;
                case "usa":
                    return TaxFormulars.UsaTaxFormular;
                default:
                    return TaxFormulars.DefaultTaxFormular;
            }
        }
    }

    public class MyTaxDelegate
    {
        public static void DoSomething()
        {
         
            ConsoleHelper.CreateHeader("Return as Method(Delegate) sample");

            float iphonePrice = 999;

            TaxFormulars.TaxFormular taxFormular = TaxFormulars.GetTaxFormularByCountry("vn");

            var iphoneSalePrice = iphonePrice + taxFormular(iphonePrice);
            Console.WriteLine($"Iphone Price at VN is {iphoneSalePrice}");

            taxFormular = TaxFormulars.GetTaxFormularByCountry("usa");
            iphoneSalePrice = iphonePrice + taxFormular(iphonePrice);
            Console.WriteLine($"Iphone Price at USA is {iphoneSalePrice}");
            
            taxFormular = TaxFormulars.GetTaxFormularByCountry("eu");
            iphoneSalePrice = iphonePrice + taxFormular(iphonePrice);
            Console.WriteLine($"Iphone Price at EU is {iphoneSalePrice}");
            
            ConsoleHelper.CreateFooter();
        }
    }
}