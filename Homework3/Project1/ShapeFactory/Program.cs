using System;

namespace ShapeFac
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MinSide = 1;
            const int MaxSide = 20;
            //随机生成十个形状
            IShape[] shapes = new IShape[10];
            Random rd = new Random();
            for(int i = 0; i < 10; i++)
            {
                switch (rd.Next(0, 3))
                {
                    case 0:
                        //三角形的限制
                        int side1 = rd.Next(MinSide,MaxSide+1);
                        int side2 = rd.Next(MinSide, MaxSide + 1);
                        int side3 = rd.Next(Math.Abs(side1 - side2) + 1, side1 + side2);
                        shapes[i] = ShapeFactory.GetShape(ShapeTypes.Triangle, side1, side2, side3);
                        break;
                    case 1:
                        shapes[i] = ShapeFactory.GetShape(ShapeTypes.Rectangle, rd.Next(MinSide, MaxSide + 1), rd.Next(MinSide, MaxSide + 1));
                        break;
                    case 2:
                        shapes[i] = ShapeFactory.GetShape(ShapeTypes.Square, rd.Next(MinSide, MaxSide + 1));
                        break;
                    default:
                        shapes[i] = null;
                        break;
                }
            }
            //计算面积和
            double sum = 0;
            foreach(IShape shape in shapes)
            {
                sum += shape.GetArea();
            }
            //输出
            Console.WriteLine(sum.ToString());
        }
    }
}
