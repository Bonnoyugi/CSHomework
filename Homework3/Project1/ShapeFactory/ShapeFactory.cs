using System;
using System.Collections.Generic;
using System.Text;

namespace ShapeFac
{
    class ShapeFactory
    {
        public static IShape GetShape(ShapeTypes shapeType,params double[] sides)
        {
            IShape productShape = null;
            switch (shapeType)
            {
                case ShapeTypes.Triangle:
                    productShape = CreateTriangle(sides);
                    break;
                case ShapeTypes.Rectangle:
                    productShape = CreateRectangle(sides);
                    break;
                case ShapeTypes.Square:
                    productShape = CreateSquare(sides);
                    break;
                default:
                    //
                    break;
            }
            return productShape;
        }

        private static IShape CreateTriangle(double[] sides)
        {
            if (3 == sides.Length)
                return new Triangle(sides[0], sides[1], sides[2]);
            else if (1 == sides.Length)
                return new Triangle(sides[0], sides[0], sides[0]);
            else
                return null;
        }
        private static IShape CreateRectangle(double[] sides)
        {
            if (2 == sides.Length)
                return new Rectangle(sides[0], sides[1]);
            else if (1 == sides.Length)
                return new Rectangle(sides[0], sides[0]);
            else
                return null;
        }
        private static IShape CreateSquare(double[] sides)
        {
            if (1 == sides.Length)
                return new Square(sides[0]);
            else
                return null;
        }
    }
}
