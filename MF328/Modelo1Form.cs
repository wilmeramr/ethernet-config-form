using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MF328
{
    public partial class Modelo1Form : Form
    {
        private  SerialPort _port;
        private  byte[] _trama;

        public Modelo1Form(SerialPort port, byte[] trama)
        {
            InitializeComponent();
            _port = port;
            _trama = trama;
        }

        protected override void OnLoad(EventArgs e)
        {
            materialLabel1.Text = $"Puesto conectado : {_port?.IsOpen} ";
            

            base.OnLoad(e);
        }
    }
}
