using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace System
{
    public class ElementRectangle
    {
        public  double X, Y, X1, Y1;
        public FrameworkElement Owner;
        public double Delta;
        public ElementRectangle(FrameworkElement owner,  double x, double y, double x1, double y1)
        {
            X = x;
            X1 = x1;
            Y = y;
            Y1 = y1;
            Delta = (x1 - x) + (y1 - y);
            Owner = owner;
        }
    }

    public static class ElementRectangleExtension
    {
        public static ElementRectangle FindElementFromPoint(this List<ElementRectangle> elements , Point point)
        {

            ElementRectangle element = null;
            foreach (ElementRectangle rectangle in elements.OrderBy(x => x.Delta))
            {
                if(rectangle.X <= point.X &&  rectangle.Y <= point.Y && rectangle.X1>= point.X && rectangle.Y1 >= point.Y)
                {
                    return rectangle;
                }
            }
            return null;

        }
    }
}
