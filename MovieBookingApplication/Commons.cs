using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieBookingApplication
{
    public class Commons
    {


        // For Checking String Input
        public static bool CheckEmpty(string input)
        {
            if (input == null || input == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        // For Checking Integer Input
        public static bool CheckEmptyInt(int input)
        {
            if (input == 0 || input == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckEmptyDecimal(decimal input)
        {
            if (input == 0 || input == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public static Regex GetRegex(string str)
        {
            return new Regex(str);
        }


    }
}
