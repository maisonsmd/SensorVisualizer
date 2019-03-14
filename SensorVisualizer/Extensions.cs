using System;
using System.Linq;

namespace SensorVisualizer {

    public static class MyExtensions {

        public static Double Map(this Double x, Double in_min, Double in_max, Double out_min, Double out_max) => (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;

        public static Double Constrain(this Double x, Double min, Double max) {
            if (x < min)
                x = min;
            if (x > max)
                x = max;
            return x;
        }

        public static Int32 Constrain(this Int32 x, Int32 min, Int32 max) {
            if (x < min)
                x = min;
            if (x > max)
                x = max;
            return x;
        }

        //lowercase method name to avoid confusing with existing string.Substring(startIndex, length) method
        public static String Substring2Indexes(this String s, Int32 startIndex, Int32 endIndex) {
            if (startIndex > endIndex)
                return String.Empty;

            if (endIndex > s.Length)
                return String.Empty;

            Int32 length = endIndex - startIndex;
            return s.Substring(startIndex, length);
        }
    }
}