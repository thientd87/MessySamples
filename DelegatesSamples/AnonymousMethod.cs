using System;

namespace MessyExample.DelegatesSamples
{
    public static class AnonymousMethod
    {
        // Một Delegate đại diện cho các hàm kiểu: (float) -> (float).
        // Tính thuế dựa trên lương.
        public delegate float SalaryTaxFormula(float salary);
        
        public static SalaryTaxFormula GetSalaryTaxFormulaByCountry(string countryCode)
        {
            if ("usa" == countryCode)
            {
                SalaryTaxFormula usaFormula = delegate(float salary)
                {
                    return 10 * salary / 100;
                };
                return usaFormula;
            }
            else if ("vn" == countryCode)
            {
                SalaryTaxFormula vnFormula = delegate(float salary)
                {
                    return 5 * salary / 100;
                };
                return vnFormula;
            }
            return delegate(float salary)
            {
                return 7 * salary / 100;
            };
        }
    }

    public static class MyAnynomousDelegate
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Anonymous Delegate sample");

            float mysalary = 2000;

            AnonymousMethod.SalaryTaxFormula taxFormular = AnonymousMethod.GetSalaryTaxFormulaByCountry(countryCode: "vn");
            var salaryAfterTax = mysalary - taxFormular(salary: mysalary);
            Console.WriteLine(value: $"My salary after tax at VN is {salaryAfterTax}");

            taxFormular = AnonymousMethod.GetSalaryTaxFormulaByCountry(countryCode: "usa");
            salaryAfterTax = mysalary - taxFormular(salary: mysalary);
            Console.WriteLine(value: $"My salary after tax at VN is {salaryAfterTax}");


            ConsoleHelper.CreateFooter();
        }
    }
}