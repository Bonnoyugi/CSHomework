using System;

namespace Calculator
{
    class Program
    {
        static void Main(String[] args)
        {
            double parameter1, parameter2, result;
            string sign;
            //进入多次计算循环
            while (true)
            {
                result = double.NaN;//每次计算前将输出归零
                //输入阶段
                //进入多次输入循环
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Calculator");
                        Console.WriteLine("\n请输入第一个操作数");
                        parameter1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("\n请输入第二个操作数");
                        parameter2 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("\n请输入操作符");
                        Console.WriteLine("(\'+\'、\'-\'、\'*\'or\'/\')");
                        sign = Console.ReadLine();
                        //输入完成，退出输入的循环
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("\n按任意键再次输入");
                        Console.ReadKey();
                    }
                }
                //计算阶段
                switch(sign)
                {
                    case "+":
                        result = parameter1 + parameter2;
                        break;
                    case "-":
                        result = parameter1 - parameter2;
                        break;
                    case "*":
                        result = parameter1 * parameter2;
                        break;
                    case "/":
                        if (0 == parameter2)
                        {
                            Console.WriteLine("除数不能为0");
                            break;
                        }
                        result = parameter1 / parameter2;
                        break;
                    default:
                        Console.WriteLine("无效的操作符");
                        break;
                }
                //输入阶段
                Console.WriteLine("\n计算结果为{0}", result);
                Console.WriteLine("\n按任意键再次输入");
                Console.ReadKey();
            }
        }
    }
}