using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF328.Extension
{
  public static  class TramaExtension
    {

        public static List<byte[]> tramaToList(this byte[] trama)
        {

            List<byte[]> listByte = new List<byte[]>();

            var tramaSplit = trama.Split(7);

            foreach (var item in tramaSplit)
            {
                listByte.Add(item.ToArray());
            }

            return listByte;
        }

        public static int[] tramaSalidasTiempo(this byte[] trama)
        {
            var tramasalidas = trama.Skip(1).ToArray().Split(2).ToList();

            int[] tramaTiempo = new int[tramasalidas.Count];
            var contar = 0;
            foreach (var item in tramasalidas)
            {
                var high = Convert.ToInt32(item.ToList()[0]);
                var low = Convert.ToInt32(item.ToList()[1]);

                if (high == 0)
                {
                    tramaTiempo[contar]= low;
                    contar += 1;
                }
                else
                {
                    var highBinary = high.decimalBinario().ToString().PadLeft(8,'0');
                    var lowBinary = low.decimalBinario().ToString().PadLeft(8, '0');

                    var binario = Convert.ToInt64(highBinary + lowBinary).binarioDecimal();

                    tramaTiempo[contar] = Convert.ToInt32(binario);
                    contar += 1;
                }

            }

            return tramaTiempo;
        }

        public static byte[] reordenar(this byte[] trama)
        {

            byte[] vs = new byte[trama.Length];

           var trama2 = trama.Skip(1);
            vs[trama.Length - 1] = trama.Take(1).First();

            var destinos = trama2.Take(3).ToArray();
            var salidas = trama2.Skip(3).ToArray();
            var countdestinos = 0;
            var countsalidas = 0;


            foreach (var index in Enumerable.Range(0,6))
            {
                if( index%2 == 0)
                {
                    vs[index] = destinos[countdestinos];
                    countdestinos += countdestinos;
                }
                else
                {
                    vs[index] = salidas[countsalidas];
                    countsalidas += countsalidas;
                }
                

            }


            return vs;
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int size)
        {
            for (var i = 0; i < (float)array.Length / size; i++)
            {
                yield return array.Skip(i * size).Take(size);
            }
        }
    }
}
