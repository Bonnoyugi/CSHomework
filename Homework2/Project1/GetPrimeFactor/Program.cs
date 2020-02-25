using System;

namespace GetPrimeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            //接收一个正整数
            Console.WriteLine("请输入一个正整数：");
            int number;
            while (true)
            {
                try
                {
                    number=Convert.ToInt32(Console.ReadLine());//输入的不是整数抛出异常
                    if (number <= 0)
                    {
                        throw new Exception();//输入非正整数抛出异常
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("\n输入的不是正整数，请重新输入");
                    continue;
                }
                break;
            }
            //处理一个正整数
            Console.WriteLine("该数所有的素数因子：");
            for(int i = 2; i <=(number/2); i++)
            {
                if (0 == number % i)
                {
                    if(isPrime(i))
                        Console.WriteLine(i.ToString());
                }
            }
            //考虑一个大于或等于2的数是否是一个质数
            bool isPrime(int number)
            {
                if (2 == number)
                    return true;
                for(int i = 2; i * i <= number; i++)
                {
                    if (0 == number % i)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
