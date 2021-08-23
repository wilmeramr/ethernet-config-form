using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MF328.Helpers
{
    public static class ValidatorTxt
    {
        public static void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            var btn = ((MetroTextBox)sender);
          
            if ((!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) )
            {
                // MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
