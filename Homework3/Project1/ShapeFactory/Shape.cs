using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeFac
{
    //枚举形状
    public enum ShapeTypes { Triangle, Rectangle, Square, }

    //形状接口
    interface IShape
    {
        bool IsLegal();//判断是否合法
        double GetArea();//计算面积
    }

    //长方形
    class Rectangle : IShape
    {
        protected double _side1, _side2;//两条边
        public double Side1
        {
            get
            {
                return _side1;
            }
            set
            {
                _side1 = value;
            }
        }
        public double Side2
        {
            get
            {
                return _side2;
            }
            set
            {
                _side2 = value;
            }
        }

        public Rectangle(double side1,double side2)
        {
            _side1 = side1;
            _side2 = side2;
        }

        public double GetArea()
        {
            if (!IsLegal())
                return double.NaN;
            return _side1 * _side2;
        }

        virtual public bool IsLegal()
        {
            return _side1 > 0 && _side2 > 0;
        }
    }

    //正方形
    class Square : Rectangle
    {
        public double Side
        {
            get
            {
                return _side1;
            }
            set
            {
                _side1 = value;
                _side2 = value;
            }
        }

        public Square(double side1, double side2) : base(side1, side2) { }

        public Square(double side) : base(side, side) { }

        override public bool IsLegal()
        {
            return base.IsLegal() && _side1 == _side2;
        }
    }

    //三角形
    class Triangle : IShape
    {
        private double _side1, _side2, _side3;
        public double Side1
        {
            get
            {
                return _side1;
            }
            set
            {
                _side1 = value;
            }
        }
        public double Side2
        {
            get
            {
                return _side2;
            }
            set
            {
                _side2 = value;
            }
        }
        public double Side3
        {
            get
            {
                return _side3;
            }
            set
            {
                _side3 = value;
            }
        }

        public Triangle(double side1,double side2,double side3)
        {
            _side1 = side1;
            _side2 = side2;
            _side3 = side3;
        }

        public double GetArea()
        {
            if(!IsLegal())
                return double.NaN;
            double p= (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p*(p-Side1)*(p-Side2)*(p-Side3));
        }

        public bool IsLegal()
        {
            if (Side1 <= 0 || Side2 <= 0 || Side3 <= 0)
                return false;
            if (Side1 + Side2 <= Side3 || Side2 + Side3 <= Side1 || Side1 + Side3 <= Side2)
                return false;
            return true;
        }
    }
}
