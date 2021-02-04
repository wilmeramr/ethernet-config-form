using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ethernet.ConfigCOMForm
{
    public partial class Form1 : MetroForm
    {
        static SerialPort _port;
        private Queue<byte> recievedData = new Queue<byte>();
        delegate void SetTextDeleg(byte[] trama);
        string evento = "";

        SortedDictionary<String, int> userCombx = new SortedDictionary<string, int>
        {
            { "Sin Cambios",0 },
            { "Desactivada por timepo",1 },
              { "Activada por Reloj",4 },
              { "Desactivada por Reloj",5 },


        };
        SortedDictionary<String, int> dias = new SortedDictionary<string, int>
        {
           {"Domingo",0 },
          {"Lunes",1 },
          {"Martes" ,2},
          {"Miercoles",3 },
          {"Jueves" ,4},
          {"Viernes" ,5},
          {"Sabado" ,6},
          {"Todos los dias" ,7},



        };
   

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var serial = SerialPort.GetPortNames();
            //if (serial.Length==0)
            //{
            //    MessageBox.Show("Sin puerto abiertos.");
            //}

            cmbPorts.DataSource = serial;
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            _port = new SerialPort(cmbPorts.SelectedItem.ToString());

            // configure serial port
            _port.BaudRate = 9600;
            _port.DataBits = 8;
            _port.Parity = Parity.None;
            _port.StopBits = StopBits.One;
            _port.ReadTimeout = 500;
            _port.WriteTimeout = 500;
            _port.DataReceived += new
             SerialDataReceivedEventHandler(port_DataReceived);
            _port.Open();

            btnConectar.Enabled = false;
            btnConectar.Style = MetroColorStyle.Green;
            btnDesconectar.Enabled = true;
        }

        private void port_DataReceived(object sender,
                    SerialDataReceivedEventArgs e)
        {
           // Thread.Sleep(8000);
            //string data = _port.ReadLine();
            //byte[] data = new byte[1024];
            //int bytesRead = _port.Read(data, 0, data.Length);
            //var _message = Encoding.ASCII.GetString(data, 0, bytesRead);

            byte[] data = new byte[_port.BytesToRead];
            _port.Read(data, 0, data.Length);

            data.ToList().ForEach(b=>recievedData.Enqueue(b));
            processData();
            // Invokes the delegate on the UI thread, and sends the data that was received to the invoked method.  
            // ---- The "si_DataReceived" method will be executed on the UI thread which allows populating of the textbox.  
      
        }

        private void processData()
        {

            if (recievedData.Count==85)
            {
                  this.BeginInvoke(new SetTextDeleg(drawer), new object[] { recievedData.ToArray() });


                //txtBye1.Text = recievedData.ElementAt(1).ToString();
                //        txtBye2.Text = recievedData.ElementAt(2).ToString();
                //       txtBye3.Text = recievedData.ElementAt(3).ToString();
                //        txtBye4.Text = recievedData.ElementAt(4).ToString();


                //        btnCambiarIP.Enabled = true;
                //        btnDesconectarEthernet.Enabled = true;
                //        btnConectarEthernet.Enabled = false;
                //        txtBye1.Enabled = true;
                //        txtBye2.Enabled = true;
                //        txtBye3.Enabled = true;
                //        txtBye4.Enabled = true;

                //        MessageBox.Show(" Dispositivo conectado");
                
                 //7   MessageBox.Show(recievedData.Count.ToString());
               // recievedData.Clear();

            }

        }

        private void drawer(byte[] trama)
        {
            metroComboBox1.DataSource = new BindingSource(userCombx,null);
            metroComboBox1.DisplayMember = "Key";
            metroComboBox1.ValueMember = "Value";

            metroComboBox9.DataSource = new BindingSource(dias, null);
            metroComboBox9.DisplayMember = "Key";
            metroComboBox9.ValueMember = "Value";

            if (trama[0]==1)
            {

                txtBye1.Text = trama[1].ToString();
                txtBye2.Text = trama[2].ToString();
                txtBye3.Text = trama[3].ToString();
                txtBye4.Text = trama[4].ToString();


                btnCambiarIP.Enabled = true;
                btnDesconectarEthernet.Enabled = true;
                btnConectarEthernet.Enabled = false;
                txtBye1.Enabled = true;
                txtBye2.Enabled = true;
                txtBye3.Enabled = true;
                txtBye4.Enabled = true;
                metroComboBox1.SelectedValue = (int)trama[5];
                metroTextBox1.Text = trama[13].ToString();
                metroTextBox4.Text = trama[29].ToString();
                metroTextBox3.Text = trama[30].ToString();
                metroComboBox9.SelectedValue = (int)trama[31];



                MessageBox.Show(" Dispositivo conectado");
            }else if (trama[0]==2)
            {
                  MessageBox.Show(" Dirección IP Cambiada!!");

            }
            else if (trama[0] == 3)
            {
                btnCambiarIP.Enabled = false;
                btnDesconectarEthernet.Enabled = false;
                btnConectarEthernet.Enabled = true;
                txtBye1.Enabled = false;
                txtBye2.Enabled = false;
                txtBye3.Enabled = false;
                txtBye4.Enabled = false;

                MessageBox.Show(" Dispositivo desconectado");

            }


            //if (txt.Substring(0, 2) == "OK")
            //{
            //    MessageBox.Show(" Dirección IP Cambiada!!");
            //}
            //else if (txt.Substring(0, 9) == "CONECTADO") {

            //    btnCambiarIP.Enabled = true;
            //    btnDesconectarEthernet.Enabled = true;
            //    btnConectarEthernet.Enabled = false;
            //    txtBye1.Enabled = true;
            //    txtBye2.Enabled = true;
            //    txtBye3.Enabled = true;
            //    txtBye4.Enabled = true;

            //    MessageBox.Show(" Dispositivo conectado");

            //}
            //else if (txt.Substring(0, 11) == "DESCONECTADO")
            //{
            //    btnCambiarIP.Enabled = false;
            //    btnDesconectarEthernet.Enabled = false;
            //    btnConectarEthernet.Enabled = true;
            //    txtBye1.Enabled = false;
            //    txtBye2.Enabled = false;
            //    txtBye3.Enabled = false;
            //    txtBye4.Enabled = false;

            //    MessageBox.Show(" Dispositivo desconectado");

            //}

            //if (txt.Contains("Baud Rate"))
            //{
            //    MessageBox.Show(txt);
            //}

        }
        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            _port.Close();
            _port = null;
            btnConectar.Enabled = true;
            btnDesconectar.Enabled = false;
            btnConectar.Style = MetroColorStyle.White;

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_port != null)
                _port.Close();
        }

        private void txtBye1_Click(object sender, EventArgs e)
        {

        }

 
        private void txtBye1_KeyDown(object sender, KeyEventArgs e)
        {
            MetroTextBox textBox = (MetroTextBox)sender;

            if(textBox.Text.Length ==2)
                SendKeys.Send("{TAB}");

            if (e.KeyCode == Keys.Enter)
            {
                    e.Handled = false;
                    SendKeys.Send("{TAB}");
                   e.SuppressKeyPress = true;


            }

        }

        private void btnCambiarIP_Click(object sender, EventArgs e)
        {
            evento = "CambiarIP";

            if (IsAddressValid(txtBye1.Text+"."+ txtBye2.Text + "." + txtBye3.Text + "." + txtBye4.Text))
            {
                if (_port != null)
                {
                    //GUSTAVO

                    byte[] data = { 3,3,2, Convert.ToByte(txtBye1.Text), Convert.ToByte(txtBye2.Text), Convert.ToByte(txtBye3.Text), Convert.ToByte(txtBye4.Text) };
                    _port.Write(data, 0, data.Length);


                }

                else
                {
                    MessageBox.Show("Problemas con el puerto");

                }
            }
            else
            {
                MessageBox.Show("El formato de la  direccion IP es incorrecto los rangos son [0,255]");
            }
        }

        public bool IsAddressValid(string addrString)
        {
            IPAddress address;
            return IPAddress.TryParse(addrString, out address);
        }

        private void btnConectarEthernet_Click(object sender, EventArgs e)
        {
            evento = "ConectarEthernet";
            byte[] data = { 3, 3, 1 };
            _port.Write(data, 0, data.Length);
            //btnCambiarIP.Enabled = true;
            //btnDesconectarEthernet.Enabled = true;
            //btnConectarEthernet.Enabled = false;
            //txtBye1.Enabled = true;
            //txtBye2.Enabled = true;
            //txtBye3.Enabled = true;
            //txtBye4.Enabled = true;

        }

        private void btnDesconectarEthernet_Click(object sender, EventArgs e)
        {
            evento = "DesconectarEthernet";

            byte[] data = { 3, 3, 3 };
            _port.Write(data, 0, data.Length);
            //btnCambiarIP.Enabled = false;
            //btnDesconectarEthernet.Enabled = false;
            //btnConectarEthernet.Enabled = true;
            //txtBye1.Enabled = false;
            //txtBye2.Enabled = false;
            //txtBye3.Enabled = false;
            //txtBye4.Enabled = false;
        }
    }
}
