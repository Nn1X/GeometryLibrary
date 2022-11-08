using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibrary
{
    public static class Area
    {
        public static double GetArea(IArea area)
        {
            return area.GetArea();
        }
    }
}
