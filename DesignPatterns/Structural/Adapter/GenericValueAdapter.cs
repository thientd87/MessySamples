using System;

namespace MessyExample.DesignPatterns.Structural.Adapter
{
    public interface IInteger
    {
        int Value { get; }
    }

    public static class Dimensions
    {
        public class Two : IInteger
        {
            public int Value => 2;
        }

        public class Three : IInteger
        {
            public int Value => 3;
        }
    }

    // Recursive generics type TSelf. A Vector of type(int/float/double..) and dimention(2d, 3c..)
    public class Vector<TSelf, T, D>  where D : IInteger, new()
        where TSelf : Vector<TSelf, T, D>, new()
    {
        protected T[] data;

        public Vector()
        {
            data = new T[new D().Value];
        }

        //You dont know exactly how many param, so use "params T[]" parameter
        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                data[i] = values[i];
        }

        public static TSelf Create(params T[] values)
        {
            var result = new TSelf();
            var requiredSize = new D().Value;
            result.data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                result.data[i] = values[i];

            return result;
        }

        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public T X
        {
            get => data[0];
            set => data[0] = value;
        }
        
        public override string ToString()
        {
            return $"{string.Join(",", data)}";
        }
    }

    public class VectorOfFloat<TSelf, D>
        : Vector<TSelf, float, D>
        where D : IInteger, new()
        where TSelf : Vector<TSelf, float, D>, new()
    {
    }

    public class VectorOfInt<D> : Vector<VectorOfInt<D>, int, D>
        where D : IInteger, new()
    {
        public VectorOfInt()
        {
        }

        public VectorOfInt(params int[] values) : base(values)
        {
        }

        public static VectorOfInt<D> operator +
            (VectorOfInt<D> lhs, VectorOfInt<D> rhs)
        {
            var result = new VectorOfInt<D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }

            return result;
        }
    }

    public class Vector2i : VectorOfInt<Dimensions.Two>
    {
        public Vector2i()
        {
        }

        public Vector2i(params int[] values) : base(values)
        {
        }
        
    }

    public class Vector3f
        : VectorOfFloat<Vector3f, Dimensions.Three>
    {
        public override string ToString()
        {
            return $"{string.Join(",", data)}";
        }
    }

    public class MyGenericValueAdapterSample
    {
        public static void DoSomething()
        {
            ConsoleHelper.CreateHeader(HeaderName: "Design Pattern - Structural - Adapter - Generic value adapter");
            
            var v = new Vector2i(1, 2);
            v[0] = 0;

            var vv = new Vector2i(3, 2);

            var result = v + vv;
            Console.WriteLine($"result of 2 Vector2i:{result}");

            Vector3f u = Vector3f.Create(3.5f, 2.2f, 1);
            Console.WriteLine($"Vector3f:{u}");
            
            ConsoleHelper.CreateFooter();
        }
    }
}