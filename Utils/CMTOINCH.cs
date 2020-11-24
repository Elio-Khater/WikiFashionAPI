using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class CMTOINCH
    {
        public static string Conversion(int centimeter)
        {
            if ( centimeter >= 0)
            {
                const double INCH_IN_CM = 2.54;
                int numInches = (int)(centimeter / INCH_IN_CM);
                int feet = numInches / 12;
                int inches = numInches % 12;
                return feet + "' " + inches + "\"";
            }
            else
            {
                return "";
            }
        }
    }
}
