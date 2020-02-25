using System;
using System.Collections.Generic;

namespace sieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建List
            List<int> intList = new List<int>();
            for(int i=2; i <= 100; i++)
            {
                intList.Add(i);
            }
            //按照埃氏筛法逐次删去数
            int index=0;//即将处理的数的索引值
            //因为每次筛选后数组都发生了变化，故采用List而非Array，外层采用while循环进行每次的判断
            //当即将处理的数的平方小于数组中最大的数时继续循环
            while(intList[index]* intList[index] < intList[intList.ToArray().Length - 1])
            {
                for(int i=1; i < intList.ToArray().Length-index; i++)//已经处理过并保留下来的数不用再考虑，故Length要减去index值
                {
                    if (0 == intList[index + i] % intList[index])//符合埃氏筛法的删去规则
                    {
                        intList.Remove(intList[index + i]);//依据埃氏筛法删去，之后也不再考虑其作为除数
                    }
                }
                index++;
            }
            //展示数组
            Console.WriteLine("2到100间的质数（筛选后剩余数据）：");
            foreach (int element in intList)
            {
                Console.Write(element+" ");
            }
        }
    }
}
