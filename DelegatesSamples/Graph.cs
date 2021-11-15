using System;

namespace MessyExample.DelegatesSamples
{
    public delegate double MathFunction(double x);

    public class GraphRender
    {
        /* khai báo property thuộc kiểu MathFunction.
        * MathFunction được sử dụng như những kiểu dữ liệu thông thường
        */
        public MathFunction Function { get; set; }
        
        
        /* phương thức này có 1 tham số đầu vào là kiểu delegate MathFunction.
         * Kiểu delegate làm tham số không khác gì kiểu dữ liệu bình thường
         */
        public void Render(MathFunction function, double[] range)
        {
            // có thể gán biến thuộc kiểu delegate như bình thường
            Function = function;
            // vì function là một object bình thường, nó cũng có những thuộc tính
            // và phương thức như các object khác. Thực tế tất cả kiểu delegate đều
            // kế thừa thừa lớp System.Delegate. Ở đây đang dùng thuộc tính Method 
            // của lớp này.
            Console.WriteLine($"Drawing the function graph: {function.Method}");
            foreach (var x in range)
            {
                // mặc dù function là một object nhưng có thể "gọi" như gọi hàm.
                // đây là sự khác biệt giữa object thuộc kiểu delegate với object
                // tạo ra từ class bình thường
                var y = function(x);
                // ngoài cách gọi này còn còn thể dùng cấu trúc dưới đây
                 var z = function.Invoke(x);
                // hoặc
                // var y = function?.Invoke(x);
                Console.Write($"{y:f3}-{z:f3}   ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------");
        }
    }
    
    public class Mathematics
    {
        // đây là một instance method
        public double Cos(double x) => Math.Cos(x);
        // đây là một static method
        public static double Tan(double x) => Math.Tan(x);
        
    }

    public class MyDelegateAsParameter
    {
        private static double Sin(double x)
        {
            return Math.Sin(x);
        }
        
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader("Method parameter is a Delegate");
            var graph = new GraphRender();
            
            // khởi tạo vùng giá trị của x
            double[] range = new double[] { 1.0, 1.2, 1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2.0 };
            
            graph.Render(Sin, range);
        
            graph.Render(Mathematics.Tan, range);
            
            Mathematics math = new Mathematics();
            graph.Render(math.Cos, range);
            
            // tạo một hàm vô danh tuân theo mô tả (double) -> double
            // và gán nó cho biến function
            // biến function là biến thuộc kiểu delegate MathFunction
            MathFunction function = delegate (double x) { return x *= 2; };
            // truyền biến function cho hàm Render
            graph.Render(function, range);

            // khai báo và truyền hàm vô danh trực tiếp tại vị trí tham số
            graph.Render(delegate (double x) { return x++; }, range);
            
            // khai báo và truyền hàm lambda trực tiếp tại vị trí tham số
            graph.Render((double x) => { return x *= 10; }, range);
            
            // truyền một hàm lambda rút gọn làm tham số
            graph.Render(x => x / 10, range);


            ConsoleHelper.CreateFooter();
        }
    }
}