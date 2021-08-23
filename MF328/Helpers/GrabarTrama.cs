using MetroFramework.Controls;
using MF328.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MF328.Helpers
{
    public static class GrabarTrama
    {
        public static byte[] ObtenerTramaEntradas( List<GroupBox> groupBoxes)
        {
            List<byte> tramaresultante = new List<byte>();
            
            foreach (var groupBox in groupBoxes)
            {
                List<byte> tramaGroup = new List<byte>();
                var valorCheck = 0;

                foreach (var control in groupBox.Controls)
                {
                    if (control.GetType().Name.Contains("Text"))
                    {
                        var valor = Convert.ToByte(((MetroTextBox)control).Text);
                        tramaGroup.Add(valor);
                    }

                    if (control.GetType().Name.Contains("Check"))
                    {
                        valorCheck += ((MetroCheckBox)control).Checked?1:0;
                    }
                }
                
                tramaGroup.Add((byte)valorCheck);
                tramaGroup.Reverse();
                tramaresultante.AddRange(tramaGroup.ToArray());
            }
       
            return tramaresultante.ToArray();
        }

        public static byte[] ObtenerTramaSalidas(List<GroupBox> groupBoxes)
        {
            List<byte> tramaresultante = new List<byte>();
            List<byte> tramaGroup = new List<byte>();
            List<byte> cantidadSalida = new List<byte>();


            var SalidasCombo = String.Empty;

            foreach (var groupBox in groupBoxes)
            {
                var valorCheck = 0;

                foreach (var control in groupBox.Controls)
                {
                    if (control.GetType().FullName.Contains("Text"))
                    {
                      var textValor = Convert.ToInt64( ((MetroTextBox)control).Text);

                        if (textValor <= 254)
                        {
                            tramaGroup.Add(Convert.ToByte(0));
                            tramaGroup.Add(Convert.ToByte(textValor));

                        }
                        else
                        {
                            var valorBinario = ((int)textValor).decimalBinario().ToString().PadLeft(16,'0');
                            var high = Convert.ToInt64(valorBinario.Substring(0,8)).binarioDecimal();
                            var low = Convert.ToInt64(valorBinario.Substring(8, 8)).binarioDecimal();

                            tramaGroup.Add(Convert.ToByte(high));
                            tramaGroup.Add(Convert.ToByte(low));
                        }
                      
                    }

                    if (control.GetType().FullName.Contains("Combo"))
                    {
                        SalidasCombo+=((MetroComboBox)control).SelectedValue.ToString();
                       
                    }
                }

              
            }

            var cantidadSalidas = Convert.ToByte( Convert.ToInt64(SalidasCombo).binarioDecimal());
            cantidadSalida.Add(cantidadSalidas);
            cantidadSalida.AddRange(tramaGroup);
            return cantidadSalida.ToArray();
        }
    }
}
