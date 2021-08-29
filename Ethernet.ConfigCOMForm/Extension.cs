using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethernet.ConfigCOMForm
{
  public static class Extension
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static string ToHexa(this byte data)
        {
           
            return string.Format("{0:x}", Convert.ToInt32(data)).ToUpper(); 
        }

        public static string ToDecimalFromHexa(this string hexValue)
        {

            return Convert.ToInt64(hexValue, 16).ToString(); 
        }

    }
}
