using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class UIExeptions : Exception
    {
        public string ErrorInClass { get; private set; }
        public UIExeptions(string message, string errorInClass) : base(message)
        {
            ErrorInClass = errorInClass;
        }
    }

    class WidthException : UIExeptions
    {
        public int Width { get; private set; }
        public WidthException(string message, string errorInClass, int width) : base(message, errorInClass)
        {
            Width = width;
        }
    }

    class AreaException : UIExeptions
    {
        public int Area { get; private set; }

        public AreaException(string message, string ErrorInClass, int area) : base(message, ErrorInClass)
        {
            Area = area;
        }
    }
}
