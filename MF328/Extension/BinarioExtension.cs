using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF328.Extension
{
  public static  class BinarioExtension
    {

        public static long decimalBinario(this int numero)
        {

            long binario = 0;

            const int DIVISOR = 2;
            long digito = 0;

            for (int i = numero % DIVISOR, j = 0; numero > 0; numero /= DIVISOR, i = numero % DIVISOR, j++)
            {
                digito = i % DIVISOR;
                binario += digito * (long)Math.Pow(10, j);
            }


            return binario;
        }


        public static long binarioDecimal(this long binario)
        {

            long numero = 0;
            long digito = 0;
            const int DIVISOR = 10;

            for (long i = binario, j = 0; i > 0; i /= DIVISOR, j++)
            {
                digito = (long)i % DIVISOR;
                if (digito != 1 && digito != 0)
                {
                    return -1;
                }
                numero += digito * (int)Math.Pow(2, j);
            }

            return numero;
        }
    }
}
