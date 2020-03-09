using System;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for(int x = 0; x < 10; x++)
            {
                list.Add(x);
            }
            //打印链表元素
            list.ForEach(m => Console.Out.WriteLine(m));
            //求值
            int sum = 0;
            int max = int.MinValue;
            int min = int.MaxValue;
            list.ForEach(m => max = m > max ? m : max);
            list.ForEach(m => min = m < min ? m : min);
            list.ForEach(m => sum += m);
            Console.Out.WriteLine("MaxValue is " + max);
            Console.Out.WriteLine("MinValue is " + min);
            Console.Out.WriteLine("SumValue is " + sum);
        }
    }
}
