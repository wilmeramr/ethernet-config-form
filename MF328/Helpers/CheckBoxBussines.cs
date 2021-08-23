using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MF328.Helpers
{
    public static class CheckBoxBussines
    {

        public static void Checked (object sender, EventArgs e, Modelo1Form modelo1Form)
        {

            List<Control> controls = new List<Control>();
            
            var objChek = (MetroCheckBox)sender;

            var nameDestinoChek = objChek.Name;
            var nameSalidaChek = $"TxtEntrada{nameDestinoChek.Substring(11, 1)}NSalida{nameDestinoChek.Substring(nameDestinoChek.Length-1,1)}";
            var name = $"Txt{nameDestinoChek.Substring(4, nameDestinoChek.Length-4)}";
            controls.AddRange(  modelo1Form.Controls.Find($"{name}", true).ToList());
            controls.AddRange(modelo1Form.Controls.Find($"{nameSalidaChek}", true).ToList());

            foreach (var item in controls)
            {
                item.Enabled = objChek.Checked;
            }

        }
    }
}
