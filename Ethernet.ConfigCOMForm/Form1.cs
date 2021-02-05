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
        List<CheckBox> tiempoCheckBoxes = new List<CheckBox>();
        List<CheckBox> activarCheckBoxes = new List<CheckBox>();
        List<CheckBox> desactivarCheckBoxes = new List<CheckBox>();


        List<MetroComboBox> diasComboBoxes = new List<MetroComboBox>();
        List<MetroTextBox> tiempoTextBoxes = new List<MetroTextBox>();
        List<MetroTextBox> activarHoraTextBoxes = new List<MetroTextBox>();
        List<MetroTextBox> activarMinTextBoxes = new List<MetroTextBox>();
        List<MetroTextBox> desactivarHoraTextBoxes = new List<MetroTextBox>();
        List<MetroTextBox> desactivarMinTextBoxes = new List<MetroTextBox>();

        byte[] chckTiempo = new byte[8];
        byte[] tiempo = new byte[8];
        byte[] chckActivar = new byte[8];
        byte[] horaMinDia = new byte[24];
        byte[] chckDesactivar = new byte[8];
        byte[] horaMinDiaDesactivar = new byte[24];

        byte[] tramaDemo = new byte[] { 
            1,
            192,
            168,
            0,
            90,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            10,
            10,
            10,
            10,
            10,
            10,
            10,
            10,
            1,
             1,
             1,
             1,
             1,
             1,
             1,
             1,
             16,
             45,
             1,
             16,
             45,
             1,
            16,
             45,
             1,
            16,
             45,
             1,
            16,
             45,
             1,
            16,
             45,
             1,
            16,
             45,
             1,
            16,
             45,
             1,
              1,
             1,
             1,
             1,
             1,
             1,
             1,
             1,
                16,
             55,
             7,
                16,
             55,
             7,
   16,
             55,
             7,
   16,
             55,
             7,
   16,
             55,
             7,
   16,
             55,
             7,
   16,
             55,
             7,
   16,
             55,
             7,


        };

        

        SortedDictionary<String, int> modoCombx = new SortedDictionary<string, int>
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
            //modoComboBoxes.AddRange(new List<MetroComboBox> 
            //{ cmbModoSalida1, cmbModoSalida2, cmbModoSalida3, cmbModoSalida4, 
            // cmbModoSalida5, cmbModoSalida6, cmbModoSalida7, cmbModoSalida8 });

            tiempoCheckBoxes.AddRange(new List<CheckBox>
            { chckTiempoSalida1, chckTiempoSalida2,chckTiempoSalida3,chckTiempoSalida4,
            chckTiempoSalida5,chckTiempoSalida6,chckTiempoSalida7,chckTiempoSalida8});
            diasComboBoxes.AddRange(new List<MetroComboBox>
            { cmbDiaActivaSalida1, cmbDiaActivaSalida2,cmbDiaActivaSalida3,cmbDiaActivaSalida4,
                cmbDiaActivaSalida5,cmbDiaActivaSalida6,cmbDiaActivaSalida7,cmbDiaActivaSalida8,
                cmbDiaDesactivaSalida1,cmbDiaDesactivaSalida2,cmbDiaDesactivaSalida3,cmbDiaDesactivaSalida4,
                cmbDiaDesactivaSalida5,cmbDiaDesactivaSalida6,cmbDiaDesactivaSalida7,cmbDiaDesactivaSalida8
            });
            tiempoTextBoxes.AddRange(new List<MetroTextBox> 
            {txtTiempoSalida1,txtTiempoSalida2,txtTiempoSalida3,txtTiempoSalida4,
            txtTiempoSalida5,txtTiempoSalida6,txtTiempoSalida7,txtTiempoSalida8
            });

            activarCheckBoxes.AddRange(new List<CheckBox>
            { chckActivadasSalida1,chckActivadasSalida2,chckActivadasSalida3,chckActivadasSalida4,
            chckActivadasSalida5,chckActivadasSalida6,chckActivadasSalida7,chckActivadasSalida8});

            activarHoraTextBoxes.AddRange(new List<MetroTextBox> 
            {txtHoraActivaSalida1,txtHoraActivaSalida2,txtHoraActivaSalida3,txtHoraActivaSalida4,
            txtHoraActivaSalida5,txtHoraActivaSalida6,txtHoraActivaSalida7,txtHoraActivaSalida8
            });
            activarMinTextBoxes.AddRange(new List<MetroTextBox> 
            {txtMinActivaSalida1,txtMinActivaSalida2,txtMinActivaSalida3,txtMinActivaSalida4,
            txtMinActivaSalida5,txtMinActivaSalida6,txtMinActivaSalida7,txtMinActivaSalida8});

            desactivarCheckBoxes.AddRange(new List<CheckBox> { 
            chckDesactivadasSalida1,chckDesactivadasSalida2,chckDesactivadasSalida3,chckDesactivadasSalida4,
                chckDesactivadasSalida5,chckDesactivadasSalida6,chckDesactivadasSalida7,chckDesactivadasSalida8
            });
            desactivarHoraTextBoxes.AddRange(new List<MetroTextBox> 
            {txtHoraDesactivaSalida1,txtHoraDesactivaSalida2,txtHoraDesactivaSalida3,txtHoraDesactivaSalida4,
            txtHoraDesactivaSalida5,txtHoraDesactivaSalida6,txtHoraDesactivaSalida7,txtHoraDesactivaSalida8
            });
            desactivarMinTextBoxes.AddRange(new List<MetroTextBox> 
            {txtMinDesactivaSalida1,txtMinDesactivaSalida2,txtMinDesactivaSalida3,txtMinDesactivaSalida4,
            txtMinDesactivaSalida5,txtMinDesactivaSalida6,txtMinDesactivaSalida7,txtMinDesactivaSalida8,
            });
            for (int i = 0; i < 8; i++)
            {
                tiempoCheckBoxes[i].Enabled = false;
                activarCheckBoxes[i].Enabled = false;
                desactivarCheckBoxes[i].Enabled = false;


            }
            inicializarComboxes();
       //     drawer(tramaDemo);

            cmbPorts.DataSource = serial;

        }

        private void inicializarComboxes()
        {

            foreach (var comb in diasComboBoxes)
            {
                comb.DataSource = new BindingSource(dias, null);
                comb.DisplayMember = "Key";
                comb.ValueMember = "Value";
                comb.SelectedIndex = -1;
                comb.Enabled = false;
            }
       

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {


   


            if (cmbPorts.SelectedIndex==-1)
            {
                MessageBox.Show("No selecciono un puerto");

            }
            else {

                try
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
                    lblCOMEvent.BackColor = Color.Green;
                    btnConectarEthernet.Enabled = true;
                }
                catch (Exception)
                {
                    lblCOMEvent.BackColor = Color.Red;


                }



            }

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

            if (evento == "ConectarEthernet" && recievedData.Count==85)
            {
                  this.BeginInvoke(new SetTextDeleg(drawer), new object[] { recievedData.ToArray() });
            }

            if ((evento == "DesconectarEthernet" || evento == "CambiarIP") && recievedData.Count == 1)
            {
                this.BeginInvoke(new SetTextDeleg(drawer), new object[] { recievedData.ToArray() });
            }
        }

        private void drawer(byte[] trama)
        {

            //  var direccionIP = ;
            var direccionIP = trama.SubArray(1,4);
             chckTiempo = trama.SubArray(5,8);
             tiempo = trama.SubArray(13, 8);
             chckActivar = trama.SubArray(21,8);
             horaMinDia = trama.SubArray(29, 24);
             chckDesactivar = trama.SubArray(53, 8);
             horaMinDiaDesactivar = trama.SubArray(61, 24);



            if (trama[0]==1)
            {
                picLoading.Enabled = false;
                picLoading.Visible = false;


                btnCambiarIP.Enabled = true;
                btnDesconectarEthernet.Enabled = true;
                btnConectarEthernet.Enabled = false;
                btnGrabarSalidas.Enabled = true;

                for (int i = 0; i < 8; i++)
                {
                    tiempoCheckBoxes[i].Enabled = true;
                    activarCheckBoxes[i].Enabled = true;
                    desactivarCheckBoxes[i].Enabled = true;


                }

                cargaDireccionIP(direccionIP);
                cargaCheckTiempoSalidas(chckTiempo);
                cargaTiempoSalidas(tiempo);
                cargaCheckActivarSalidas(chckActivar);
                cargaTextHoraActivarSalidas(horaMinDia);
                cargaCheckDesactivarSalidas(chckDesactivar);
                cargaTextHoraDesactivarSalidas(horaMinDiaDesactivar);



                //txtTiempoSalida1.Text = trama[13].ToString();
                //txtHoraActivaSalida1.Text = trama[29].ToString();
                //txtMinActivaSalida1.Text = trama[30].ToString();
                //cmbDiaActivaSalida1.SelectedValue = (int)trama[31];



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

        private void cargaTextHoraDesactivarSalidas(byte[] horaMinDia)
        {
            txtHoraDesactivaSalida1.Text = horaMinDia[0].ToString();
            txtMinDesactivaSalida1.Text = horaMinDia[1].ToString();
            cmbDiaDesactivaSalida1.SelectedValue = (int)horaMinDia[2];

            txtHoraDesactivaSalida2.Text = horaMinDia[3].ToString();
            txtMinDesactivaSalida2.Text = horaMinDia[4].ToString();
            cmbDiaDesactivaSalida2.SelectedValue = (int)horaMinDia[5];


            txtHoraDesactivaSalida3.Text = horaMinDia[6].ToString();
            txtMinDesactivaSalida3.Text = horaMinDia[7].ToString();
            cmbDiaDesactivaSalida3.SelectedValue = (int)horaMinDia[8];


            txtHoraDesactivaSalida4.Text = horaMinDia[9].ToString();
            txtMinDesactivaSalida4.Text = horaMinDia[10].ToString();
            cmbDiaDesactivaSalida4.SelectedValue = (int)horaMinDia[11];


            txtHoraDesactivaSalida5.Text = horaMinDia[12].ToString();
            txtMinDesactivaSalida5.Text = horaMinDia[13].ToString();
            cmbDiaDesactivaSalida5.SelectedValue = (int)horaMinDia[14];


            txtHoraDesactivaSalida6.Text = horaMinDia[15].ToString();
            txtMinDesactivaSalida6.Text = horaMinDia[16].ToString();
            cmbDiaDesactivaSalida6.SelectedValue = (int)horaMinDia[17];


            txtHoraDesactivaSalida7.Text = horaMinDia[18].ToString();
            txtMinDesactivaSalida7.Text = horaMinDia[19].ToString();
            cmbDiaDesactivaSalida7.SelectedValue = (int)horaMinDia[20];


            txtHoraDesactivaSalida8.Text = horaMinDia[21].ToString();
            txtMinDesactivaSalida8.Text = horaMinDia[22].ToString();
            cmbDiaDesactivaSalida8.SelectedValue = (int)horaMinDia[23];
        }

        private void cargaCheckDesactivarSalidas(byte[] chckDesactivar)
        {
            int i = 0;
            foreach (var check in desactivarCheckBoxes)
            {
                check.Checked = Convert.ToBoolean((int)chckDesactivar[i]);
                i++;
            }
        }

        private void cargaTextHoraActivarSalidas(byte[] horaMinDia)
        {
            txtHoraActivaSalida1.Text = horaMinDia[0].ToString();
            txtMinActivaSalida1.Text = horaMinDia[1].ToString();
            cmbDiaActivaSalida1.SelectedValue = (int)horaMinDia[2];

            txtHoraActivaSalida2.Text = horaMinDia[3].ToString();
            txtMinActivaSalida2.Text = horaMinDia[4].ToString();
            cmbDiaActivaSalida2.SelectedValue = (int)horaMinDia[5];


            txtHoraActivaSalida3.Text = horaMinDia[6].ToString();
            txtMinActivaSalida3.Text = horaMinDia[7].ToString();
            cmbDiaActivaSalida3.SelectedValue = (int)horaMinDia[8];


            txtHoraActivaSalida4.Text = horaMinDia[9].ToString();
            txtMinActivaSalida4.Text = horaMinDia[10].ToString();
            cmbDiaActivaSalida4.SelectedValue = (int)horaMinDia[11];


            txtHoraActivaSalida5.Text = horaMinDia[12].ToString();
            txtMinActivaSalida5.Text = horaMinDia[13].ToString();
            cmbDiaActivaSalida5.SelectedValue = (int)horaMinDia[14];


            txtHoraActivaSalida6.Text = horaMinDia[15].ToString();
            txtMinActivaSalida6.Text = horaMinDia[16].ToString();
            cmbDiaActivaSalida6.SelectedValue = (int)horaMinDia[17];


            txtHoraActivaSalida7.Text = horaMinDia[18].ToString();
            txtMinActivaSalida7.Text = horaMinDia[19].ToString();
            cmbDiaActivaSalida7.SelectedValue = (int)horaMinDia[20];


            txtHoraActivaSalida8.Text = horaMinDia[21].ToString();
            txtMinActivaSalida8.Text = horaMinDia[22].ToString();
            cmbDiaActivaSalida8.SelectedValue = (int)horaMinDia[23];
        }

        private void cargaCheckActivarSalidas(byte[] chckActivar)
        {
            int i = 0;
            foreach (var check in activarCheckBoxes)
            {
                check.Checked = Convert.ToBoolean((int)chckActivar[i]);
                i++;
            }
        }

        private void cargaTiempoSalidas(byte[] tiempo)
        {
            int i = 0;
            foreach (var Text in tiempoTextBoxes)
            {
                Text.Text = tiempo[i].ToString();
                i++;
            }
        }

        private void cargaCheckTiempoSalidas(byte[] tiempo)
        {
            int i = 0;
            foreach (var check in tiempoCheckBoxes)
            {
                check.Checked = Convert.ToBoolean((int)tiempo[i]);
                i++;
            }


        }

        private void cargaDireccionIP(byte[] direccionIP)
        {
            txtBye1.Text = direccionIP[0].ToString();
            txtBye2.Text = direccionIP[1].ToString();
            txtBye3.Text = direccionIP[2].ToString();
            txtBye4.Text = direccionIP[3].ToString();

            txtBye1.Enabled = true;
            txtBye2.Enabled = true;
            txtBye3.Enabled = true;
            txtBye4.Enabled = true;
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
            try
            {
                evento = "ConectarEthernet";
                byte[] data = { 3, 3, 1 };
                _port.Write(data, 0, data.Length);

                picLoading.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "loading.gif");
                picLoading.Width = 450;
                picLoading.Height = 350;
                picLoading.Location = new Point(picLoading.Height, picLoading.Width / 4);
                picLoading.SizeMode = PictureBoxSizeMode.StretchImage;

                picLoading.Enabled = true;
                picLoading.Visible = true;

                lblEthernetEvent.BackColor = Color.Green;
      
            }
            catch (Exception)
            {

                lblEthernetEvent.BackColor = Color.Red;

            }

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

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void chckTiempoAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            switch (checkBox.Name)
            {
                case "chckTiempoSalida1":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida1.Enabled = true;
                        chckActivadasSalida1.Checked = !checkBox.Checked;
                        txtHoraActivaSalida1.Enabled = false;
                        txtMinActivaSalida1.Enabled = false;
                        cmbDiaActivaSalida1.Enabled = false;
                        txtHoraDesactivaSalida1.Enabled = false;
                        txtMinDesactivaSalida1.Enabled = false;
                        cmbDiaDesactivaSalida1.Enabled = false;
                        chckDesactivadasSalida1.Checked = false;
                    }
                    else
                    {
                        txtTiempoSalida1.Enabled = false;

                    }

                    break;
                default:
                    break;
            }

        }

        private void chckActivadasAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            switch (checkBox.Name)
            {
                case "chckActivadasSalida1":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida1.Enabled = false;
                        txtHoraActivaSalida1.Enabled = true;
                        txtMinActivaSalida1.Enabled = true;
                        cmbDiaActivaSalida1.Enabled = true;
                        txtHoraDesactivaSalida1.Enabled = false;
                        txtMinDesactivaSalida1.Enabled = false;
                        cmbDiaDesactivaSalida1.Enabled = false;
                        chckDesactivadasSalida1.Checked = false;
                        chckTiempoSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraActivaSalida1.Enabled = false;
                        txtMinActivaSalida1.Enabled = false;
                        cmbDiaActivaSalida1.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void chckDesactivadasAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            switch (checkBox.Name)
            {
                case "chckDesactivadasSalida1":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida1.Enabled = false;
                        txtHoraDesactivaSalida1.Enabled = true;
                        txtMinDesactivaSalida1.Enabled = true;
                        cmbDiaDesactivaSalida1.Enabled = true;
                        txtHoraActivaSalida1.Enabled = false;
                        txtMinActivaSalida1.Enabled = false;
                        cmbDiaActivaSalida1.Enabled = false;
                        chckTiempoSalida1.Checked = !checkBox.Checked;
                        chckActivadasSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraDesactivaSalida1.Enabled = false;
                        txtMinDesactivaSalida1.Enabled = false;
                        cmbDiaDesactivaSalida1.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }

}
