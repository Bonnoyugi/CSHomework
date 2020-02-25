using System;
using System.Collections.Generic;

namespace AnalyzeIntArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targetList = new List<int>();
            Console.WriteLine("请依次输入一个整数数组中的各项，连续按下回车停止输入：");
            //输入数组
            while (true)
            {
                int elementNumber;
                try
                {
                    string inputMsg = Console.ReadLine();
                    if("" == inputMsg)
                    {
                        break;//输入完成
                    }
                    elementNumber = Convert.ToInt32(inputMsg);
                }
                catch(Exception e)
                {
                    Console.WriteLine("输入了错误的信息，请重新输入");
                    continue;
                }
                targetList.Add(elementNumber);
            }
            //处理数组
            int[] intArray = targetList.ToArray();
            if (0 == intArray.Length)
            {
                Console.WriteLine("这是一个空数组");
                return;
            }
            
                int maxValue = intArray[0];
                int minValue = intArray[0];
                int sum=0;
                for(int i=1;i<intArray.Length;i++)
                {
                    int elemValue = intArray[i];
                    if (elemValue > maxValue)
                        maxValue = elemValue;
                    else if (elemValue < minValue)
                        minValue = elemValue;
                    sum += elemValue;
                }
                Console.WriteLine("最大值为" + maxValue);
                Console.WriteLine("最小值为" + minValue);
                Console.WriteLine("和为" + sum);
                Console.WriteLine("平均值为" + (double)sum / intArray.Length);
        }
    }
}
