using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessiblee
{
    public static class StaticUtils
    {
        public static double DistanceBetweenPoints(System.Drawing.Point from, System.Drawing.Point to)
        {
            var result = Math.Sqrt(Math.Pow((from.X - to.X), 2) + Math.Pow((from.Y - to.Y), 2));
            return result;
        }

        public static InputStates GetNextEnumValue(InputStates current)
        {
            int nextValue = ((int)current + 1) % Enum.GetValues(typeof(InputStates)).Length;
            return (InputStates)nextValue;
        }
    }
}
