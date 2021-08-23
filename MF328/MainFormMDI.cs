using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework.Forms;
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
    public partial class MainFormMDI : Form
    {
        private readonly MaterialSkinManager materialSkinManager;

        static SerialPort _port;
        public static string evento;
        public static Queue<byte> recievedData = new Queue<byte>();
        delegate void SetTextDeleg(byte[] trama);
        private Form formActual;

        public MainFormMDI()
        {
            InitializeComponent();
            progressBar.ForeColor = Color.Green;
            btnDesconectarCOM.Enabled = false;
            cnxDispositivo.Enabled = false;
            var puertos = SerialPort.GetPortNames().ToList();
            List<object> objPorts = new List<object>();
            puertos.ForEach(puerto=> objPorts.Add((object)puerto));
            cmbPorts.ComboBox.Items.AddRange(objPorts.ToArray());
        }

        private void conectarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  byte[] TramaSample = new byte[] { 1, 3, 240, 20, 240, 20, 240,  20, 2, 240, 20, 240, 20, 240,  20, 2, 240, 20, 240, 20, 240,  20, 3, 0, 150, 1, 70, 0, 160, 100 };
           //  byte[] TramaSample = new byte[] {1, 1, 2, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 0, 20, 20, 30, 30, 40, 40, 100 };

            //drawer(TramaSample);
            if (cmbPorts.SelectedIndex == -1)
            {
                sendMaterialSnackBar("No selecciono un puerto", "OK");
                return;
            }
            try
            {

                _port = new SerialPort(cmbPorts.SelectedItem.ToString());

                // configure serial port
                _port.BaudRate = 9600;
                _port.DataBits = 8;
                _port.Parity = Parity.None;
                _port.StopBits = StopBits.One;
                _port.ReadTimeout = 5000;
                _port.WriteTimeout = 5000;
                _port.DataReceived += new
                 SerialDataReceivedEventHandler(port_DataReceived);
                _port.Open();

                btnConectarCOM.Enabled = false;
                btnDesconectarCOM.Enabled = true;
                cnxDispositivo.Enabled = true;


                progressBar.ForeColor = Color.Green;
                progressBar.Value = 100;
                lblProcessBar.Text = "Conectando a Puerto COM";
                sendMaterialSnackBar($"Se ha conectado con exito", "OK");

            }
            catch (Exception)
            {
                progressBar.ForeColor = Color.Red;
                lblProcessBar.Text = "Error con el Puerto COM";
                cnxDispositivo.Enabled = false;

                progressBar.Value = 100;
                sendMaterialSnackBar($"Error el conectar al puerto {cmbPorts.SelectedItem}", "ERROR");

            }

        }


        public void sendMaterialSnackBar(string message, string action)
        {
            MaterialSnackBar SnackBarMessage = new MaterialSnackBar(message, action, true);
            SnackBarMessage.Show(this);
        }

        private void btnDesconectarCOM_Click(object sender, EventArgs e)
        {
            _port.Close();
            _port = null;

            cnxDispositivo.Enabled = false;
            btnConectarCOM.Enabled = true;
            btnDesconectarCOM.Enabled = false;
           // btnConectar.Style = MetroColorStyle.White;
        }

        private void btnConectarDispositivo_Click(object sender, EventArgs e)
        {

            if (!_port.IsOpen)
            {
                  sendMaterialSnackBar("Puerto COM no conectado", "ERROR");
                   return;
            }

            try
            {
                evento = "ConectarEthernet";
                recievedData.Clear();
                byte[] data = {(byte) Convert.ToInt32(txtDireccion.Text), 3, 250 };
                _port.Write(data, 0, data.Length);

                progressBar.ForeColor = Color.Green;
                progressBar.Value = 50;
                lblProcessBar.Text = "Conectando a Dispositivo";


            }
            catch (Exception)
            {
                sendMaterialSnackBar("Puerto COM no conectado", "ERROR");
                progressBar.ForeColor = Color.Red;
                progressBar.Value = 100;
                lblProcessBar.Text = "Error al conectando a Dispositivo";

                //   lblEthernetEvent.BackColor = Color.Red;

            }
        }


        private void port_DataReceived(object sender,
                    SerialDataReceivedEventArgs e)
        {
       

            byte[] data = new byte[_port.BytesToRead];
            _port.Read(data, 0, data.Length);

            data.ToList().ForEach(b => recievedData.Enqueue(b));
            processData();
          
        }

        private void processData()
        {

            if (recievedData.ElementAt(0) == 1 && evento == "ConectarEthernet" && recievedData.Count == 30 )
            {
                this.BeginInvoke(new SetTextDeleg(drawer), new object[] { recievedData.ToArray() });
                // recievedData.Clear();
            }

            
            if (evento == "grabar" && recievedData.Count == 1)
            {
                this.BeginInvoke(new SetTextDeleg(drawer), new object[] { recievedData.ToArray() });
                //   recievedData.Clear();

            }

            if (evento == "desconectar" && recievedData.Count == 1)
            {
                this.BeginInvoke(new SetTextDeleg(drawer), new object[] { recievedData.ToArray() });
                //   recievedData.Clear();

            }
            if (evento == "cambiar" && recievedData.Count == 1)
            {
                this.BeginInvoke(new SetTextDeleg(drawer), new object[] { recievedData.ToArray() });
                //   recievedData.Clear();

            }
            //if ((evento == "DesconectarEthernet"))
            //{
            //    this.BeginInvoke(new SetTextDeleg(drawer), new object[] { new byte[] { recievedData.ElementAt(0) } });
            //    //   recievedData.Clear();

            //}
        }

        private void drawer(byte[] trama)
        {

            if (evento == "grabar" && trama[0]==4)
            {
                sendMaterialSnackBar("Se grabo correctamente", "OK");
                return;
            }

            if (evento == "desconectar" && trama[0] == 3)
            {
                sendMaterialSnackBar("Se desconecto correctamente", "OK");
                return;
            }
            if (evento == "cambiar" && trama[0] == 1)
            {
                sendMaterialSnackBar("Se cambio correctamente", "OK");
                return;
            }
            if (formActual == null)
            {
                formActual = new Modelo1Form(_port,trama);
                formActual.FormClosed += new FormClosedEventHandler(CerrarForm);
                formActual.MdiParent= this;
                formActual.Width = Convert.ToInt32(this.Width * 0.85);
                formActual.Height = Convert.ToInt32(this.Height * 0.85);
                formActual.Show();
            }
            else
            {
                formActual.Activate();
            }


        }

        private void CerrarForm(object sender, FormClosedEventArgs e)
        {
            formActual = null;
            recievedData.Clear();


        }

        private void cmbPorts_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            recievedData.Clear();
            evento = "desconectar";
            byte[] data = { 250,2 };
            _port.Write(data, 0, data.Length);
        }
    }
}
