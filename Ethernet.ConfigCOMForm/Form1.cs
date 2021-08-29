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
        DateTime dateTime;
        private Queue<byte> recievedData = new Queue<byte>();
        delegate void SetTextDeleg(byte[] trama);
        string diaActual = "";

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
        byte[] chckTiempoAEnviar = new byte[8];
        byte[] tiempoAEnviar = new byte[8];
        byte[] chckActivarAEnviar = new byte[8];
        byte[] horaMinDiaAEnviar = new byte[24];
        byte[] chckDesactivarAEnviar = new byte[8];
        byte[] horaMinDiaDesactivarAEnviar = new byte[24];

      byte[] horaActual = new byte[3];

        byte[] direccionIP = new byte[4];
        byte[] GatewayIP = new byte[4];
        byte[] MAC = new byte[6];



        List<string> checkactivos = new List<string>();

        byte[] tramaDemo = new byte[] { 
            1,
            192,
            168,
            0,
            90,
          10,
            10,
            10,
            10,
            10,
            10,
            10,
            10,
            10,
          255,
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
          164,
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
             7
            
            ,20
            ,21
            ,3
            ,4
            ,5
            ,6
            ,7
            ,192
            ,168
            ,0
            ,1
            ,124
            ,125
            ,126
            ,127
            ,128
            ,129
            
         

        };

        

        SortedDictionary<String, int> modoCombx = new SortedDictionary<string, int>
        {
            { "Sin Cambios",0 },
            { "Desactivada por timepo",1 },
              { "Activada por Reloj",4 },
              { "Desactivada por Reloj",5 },


        };

        SortedDictionary<int, string> dias = new SortedDictionary<int, string>
        {
           {0,"Domingo" },
          {1,"Lunes" },
          {2,"Martes" },
          {3,"Miercoles"},
          {4,"Jueves" },
          {5,"Viernes" },
          {6,"Sabado" },
          {7,"Todos los dias"},



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
         //   drawer(tramaDemo);

            cmbPorts.DataSource = serial;

        }

        private void inicializarComboxes()
        {

            foreach (var comb in diasComboBoxes)
            {
              

                comb.DataSource = new BindingSource(dias, null);
                comb.DisplayMember = "Value";
                comb.ValueMember = "Key";
                comb.SelectedIndex = -1;
                comb.Enabled = false;
                //comb.Sorted = true;
            }
       

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {





            if (cmbPorts.SelectedIndex == -1)
            {
                MessageBox.Show("No selecciono un puerto");

            }
            else
            {

                try
                {
                    _port = new SerialPort(cmbPorts.SelectedItem.ToString());

            // configure serial port
            _port.BaudRate = 115200;
            _port.DataBits = 8;
            _port.Parity = Parity.None;
            _port.StopBits = StopBits.One;
            _port.ReadTimeout = 5000;
            _port.WriteTimeout = 5000;
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

           drawer(tramaDemo);

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

            if (evento == "ConectarEthernet" && recievedData.Count==81)
            {
                  this.BeginInvoke(new SetTextDeleg(drawer), new object[] { recievedData.ToArray() });
               // recievedData.Clear();
            }


            if (( evento == "CambiarIP" || evento== "btnGrabar" || evento == "CambiarFecha") && recievedData.Count == 1)
            {
                this.BeginInvoke(new SetTextDeleg(drawer), new object[] { recievedData.ToArray() });
             //   recievedData.Clear();

            }
            if ((evento == "DesconectarEthernet") )
            {
                this.BeginInvoke(new SetTextDeleg(drawer), new object[] { new byte[] { recievedData.ElementAt(0) } });
                //   recievedData.Clear();

            }
        }

        private void drawer(byte[] trama)
        {
            //recievedData.Clear();

           // var d = Convert.ToByte("0",8);
           // List<int> vs = new List<int>();
           // byte[] vs1 = new byte[8];
           //var binary = Convert.ToString(Convert.ToInt32(trama[5]), 2).ToCharArray().Select(s=> { return Convert.ToByte(s.ToString(), 8); });

         
            //for (int i = 0; i < binary.Length; i++)
            //{

            //    if (binary.ToArray()[i]=='1')
            //    {
            //        vs1[i] = 1;
            //    }
            //    else
            //    {
            //        vs1[i] = 0;

            //    }


            //}

            if (trama[0] == 1)
            {
                CrearTrama(trama);
              // dias.TryGetValue(Convert.ToInt32(horaActual[2]), out diaActual);
                timer1.Start();
                picLoading.Enabled = false;
                picLoading.Visible = false;

                btnDate.Enabled = true;
                dateTimePicker1.Enabled = true;

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
                cargaGateWayIP(GatewayIP);
                cargaMACIP(MAC);


                //txtTiempoSalida1.Text = trama[13].ToString();
                //txtHoraActivaSalida1.Text = trama[29].ToString();
                //txtMinActivaSalida1.Text = trama[30].ToString();
                //cmbDiaActivaSalida1.SelectedValue = (int)trama[31];



                MessageBox.Show(" Dispositivo conectado");
            }
            else if (trama[0] == 2)
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
                btnDate.Enabled = false;
                dateTimePicker1.Enabled = false;


                MessageBox.Show(" Dispositivo desconectado");

            }
            else if (trama[0] == 4)
            {
            

                MessageBox.Show("Se Grabo correctamente.");

            }
            else if (trama[0] == 5)
            {


                MessageBox.Show("Se fecha y hora actualizada.");

            }
            recievedData.Clear();

   

        }

        private void CrearTrama(byte[] trama)
        {

         

            //  var direccionIP = ;
            direccionIP = trama.SubArray(1, 4);
            // chckTiempo = trama.SubArray(5, 8);
            chckTiempo = Convert.ToString(Convert.ToInt32(trama[5]), 2).PadLeft(8,'0').ToCharArray().Select(s => { return Convert.ToByte(s.ToString(), 8); }).ToArray();
            tiempo = trama.SubArray(6, 8);
            chckActivar = Convert.ToString(Convert.ToInt32(trama[14]), 2).PadLeft(8, '0').ToCharArray().Select(s => { return Convert.ToByte(s.ToString(), 8); }).ToArray();
            horaMinDia = trama.SubArray(15, 24);
            chckDesactivar = Convert.ToString(Convert.ToInt32(trama[39]), 2).PadLeft(8, '0').ToCharArray().Select(s => { return Convert.ToByte(s.ToString(), 8); }).ToArray();
            horaMinDiaDesactivar = trama.SubArray(40, 24);

            chckTiempoAEnviar = Convert.ToString(Convert.ToInt32(trama[5]), 2).PadLeft(8, '0').ToCharArray().Select(s => { return Convert.ToByte(s.ToString(), 8); }).ToArray();
            tiempoAEnviar = trama.SubArray(6, 8);
            chckActivarAEnviar = Convert.ToString(Convert.ToInt32(trama[14]), 2).PadLeft(8, '0').ToCharArray().Select(s => { return Convert.ToByte(s.ToString(), 8); }).ToArray();
            horaMinDiaAEnviar = trama.SubArray(15, 24);
            chckDesactivarAEnviar = Convert.ToString(Convert.ToInt32(trama[39]), 2).PadLeft(8, '0').ToCharArray().Select(s => { return Convert.ToByte(s.ToString(), 8); }).ToArray();
            horaMinDiaDesactivarAEnviar = trama.SubArray(40, 24);

            var posicion1 = Convert.ToString(Convert.ToInt32(trama[64]), 2).PadLeft(8, '0');
            var posicion2 = Convert.ToString(Convert.ToInt32(trama[65]), 2).PadLeft(8, '0');

         
            var año = Convert.ToInt32(posicion1 + posicion2, 2);
            var mes = trama[66];
            var dia = trama[67];
            var hora = trama[68];
            var min = trama[69];
            var seg = trama[70];
            GatewayIP = trama.SubArray(71, 4);
            MAC = trama.SubArray(75, 6);



            dateTime = new DateTime(año, mes, dia, hora, min, seg);

           // horaActual = trama.SubArray(68, 3);


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
        private void cargaGateWayIP(byte[] gateWay)
        {
            txtGateway1.Text = gateWay[0].ToString();
            txtGateway2.Text = gateWay[1].ToString();
            txtGateway3.Text = gateWay[2].ToString();
            txtGateway4.Text = gateWay[3].ToString();

            txtGateway1.Enabled = true;
            txtGateway2.Enabled = true;
            txtGateway3.Enabled = true;
            txtGateway4.Enabled = true;
        }
        private void cargaMACIP(byte[] mac)
        {
            txtMac1.Text = mac[0].ToHexa();
            txtMac2.Text = mac[1].ToHexa();
            txtMac3.Text = mac[2].ToHexa();
            txtMac4.Text = mac[3].ToHexa();
            txtMac5.Text = mac[4].ToHexa();
            txtMac6.Text = mac[5].ToHexa();


            txtMac1.Enabled = true;
            txtMac2.Enabled = true;
            txtMac3.Enabled = true;
            txtMac4.Enabled = true;
            txtMac5.Enabled = true;
            txtMac6.Enabled = true;

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

                    byte[] direccionIP = { Convert.ToByte(txtBye1.Text), Convert.ToByte(txtBye2.Text), Convert.ToByte(txtBye3.Text), Convert.ToByte(txtBye4.Text) };
                    byte[] gatewayIP = { Convert.ToByte(txtGateway1.Text), Convert.ToByte(txtGateway2.Text), Convert.ToByte(txtGateway3.Text), Convert.ToByte(txtGateway4.Text) };
                    byte[] mac = { Convert.ToByte(txtMac1.Text.ToDecimalFromHexa()), Convert.ToByte(txtMac2.Text.ToDecimalFromHexa()), Convert.ToByte(txtMac3.Text.ToDecimalFromHexa())
                            , Convert.ToByte(txtMac4.Text.ToDecimalFromHexa()), Convert.ToByte(txtMac5.Text.ToDecimalFromHexa()), Convert.ToByte(txtMac6.Text.ToDecimalFromHexa()) };

                    byte[] data = { 3,3,2};
                    data = data.Concat(direccionIP)
                        .Concat(gatewayIP)
                        .Concat(mac).ToArray();

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

            actulizarTramaAEnviar(checkBox);
    

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
                        //txtHoraDesactivaSalida1.Enabled = false;
                        //txtMinDesactivaSalida1.Enabled = false;
                        //cmbDiaDesactivaSalida1.Enabled = false;
                        //chckDesactivadasSalida1.Checked = false;
                    }
                    else
                    {
                        txtTiempoSalida1.Enabled = false;

                    }

                    break;
                case "chckTiempoSalida2":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida2.Enabled = true;
                        chckActivadasSalida2.Checked = !checkBox.Checked;
                        txtHoraActivaSalida2.Enabled = false;
                        txtMinActivaSalida2.Enabled = false;
                        cmbDiaActivaSalida2.Enabled = false;
                        //txtHoraDesactivaSalida2.Enabled = false;
                        //txtMinDesactivaSalida2.Enabled = false;
                        //cmbDiaDesactivaSalida2.Enabled = false;
                        //chckDesactivadasSalida2.Checked = false;
                    }
                    else
                    {
                        txtTiempoSalida2.Enabled = false;

                    }

                    break;
                case "chckTiempoSalida3":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida3.Enabled = true;
                        chckActivadasSalida3.Checked = !checkBox.Checked;
                        txtHoraActivaSalida3.Enabled = false;
                        txtMinActivaSalida3.Enabled = false;
                        cmbDiaActivaSalida3.Enabled = false;
                        //txtHoraDesactivaSalida3.Enabled = false;
                        //txtMinDesactivaSalida3.Enabled = false;
                        //cmbDiaDesactivaSalida3.Enabled = false;
                        //chckDesactivadasSalida3.Checked = false;
                    }
                    else
                    {
                        txtTiempoSalida3.Enabled = false;

                    }

                    break;
                case "chckTiempoSalida4":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida4.Enabled = true;
                        chckActivadasSalida4.Checked = !checkBox.Checked;
                        txtHoraActivaSalida4.Enabled = false;
                        txtMinActivaSalida4.Enabled = false;
                        cmbDiaActivaSalida4.Enabled = false;
                        //txtHoraDesactivaSalida4.Enabled = false;
                        //txtMinDesactivaSalida4.Enabled = false;
                        //cmbDiaDesactivaSalida4.Enabled = false;
                        //chckDesactivadasSalida4.Checked = false;
                    }
                    else
                    {
                        txtTiempoSalida4.Enabled = false;

                    }

                    break;
                case "chckTiempoSalida5":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida5.Enabled = true;
                        chckActivadasSalida5.Checked = !checkBox.Checked;
                        txtHoraActivaSalida5.Enabled = false;
                        txtMinActivaSalida5.Enabled = false;
                        cmbDiaActivaSalida5.Enabled = false;
                        //txtHoraDesactivaSalida5.Enabled = false;
                        //txtMinDesactivaSalida5.Enabled = false;
                        //cmbDiaDesactivaSalida5.Enabled = false;
                        //chckDesactivadasSalida5.Checked = false;
                    }
                    else
                    {
                        txtTiempoSalida5.Enabled = false;

                    }

                    break;
                case "chckTiempoSalida6":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida6.Enabled = true;
                        chckActivadasSalida6.Checked = !checkBox.Checked;
                        txtHoraActivaSalida6.Enabled = false;
                        txtMinActivaSalida6.Enabled = false;
                        cmbDiaActivaSalida6.Enabled = false;
                        //txtHoraDesactivaSalida6.Enabled = false;
                        //txtMinDesactivaSalida6.Enabled = false;
                        //cmbDiaDesactivaSalida6.Enabled = false;
                        //chckDesactivadasSalida6.Checked = false;
                    }
                    else
                    {
                        txtTiempoSalida6.Enabled = false;

                    }

                    break;
                case "chckTiempoSalida7":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida7.Enabled = true;
                        chckActivadasSalida7.Checked = !checkBox.Checked;
                        txtHoraActivaSalida7.Enabled = false;
                        txtMinActivaSalida7.Enabled = false;
                        cmbDiaActivaSalida7.Enabled = false;
                        //txtHoraDesactivaSalida7.Enabled = false;
                        //txtMinDesactivaSalida7.Enabled = false;
                        //cmbDiaDesactivaSalida7.Enabled = false;
                        //chckDesactivadasSalida7.Checked = false;
                    }
                    else
                    {
                        txtTiempoSalida7.Enabled = false;

                    }

                    break;
                case "chckTiempoSalida8":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida8.Enabled = true;
                        chckActivadasSalida8.Checked = !checkBox.Checked;
                        txtHoraActivaSalida8.Enabled = false;
                        txtMinActivaSalida8.Enabled = false;
                        cmbDiaActivaSalida8.Enabled = false;
                        //txtHoraDesactivaSalida8.Enabled = false;
                        //txtMinDesactivaSalida8.Enabled = false;
                        //cmbDiaDesactivaSalida8.Enabled = false;
                        //chckDesactivadasSalida8.Checked = false;
                    }
                    else
                    {
                        txtTiempoSalida8.Enabled = false;

                    }

                    break;
                default:
                    break;
            }

        }

        private void actulizarTramaAEnviar(CheckBox checkBox)
        {
            var name = checkBox.Name;
            //chckTiempo = trama.SubArray(5, 8);
            //tiempo = trama.SubArray(13, 8);
            //chckActivar = trama.SubArray(21, 8);
            //horaMinDia = trama.SubArray(29, 24);
            //chckDesactivar = trama.SubArray(53, 8);
            //horaMinDiaDesactivar = trama.SubArray(61, 24);

            if (checkBox.Name.Contains("Tiempo"))
            {
                var index = Convert.ToInt32(name.Substring(16, name.Length - 16)) - 1;

                chckTiempoAEnviar[index] = Convert.ToByte(checkBox.Checked);
            }
            else if (checkBox.Name.Contains("Activadas"))
            {
    
                var index = Convert.ToInt32(name.Substring(19, name.Length - 19)) - 1;

                chckActivarAEnviar[index] = Convert.ToByte(checkBox.Checked);
            }
            else if (checkBox.Name.Contains("Desactivadas"))
            {
                //chckDesactivadasSalida1
                var index = Convert.ToInt32(name.Substring(22, name.Length - 22)) - 1;

                chckDesactivarAEnviar[index] = Convert.ToByte(checkBox.Checked);
            }
        }

        private void chckActivadasAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            actulizarTramaAEnviar(checkBox);

            switch (checkBox.Name)
            {
                case "chckActivadasSalida1":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida1.Enabled = false;
                        txtHoraActivaSalida1.Enabled = true;
                        txtMinActivaSalida1.Enabled = true;
                        cmbDiaActivaSalida1.Enabled = true;
                     //   txtHoraDesactivaSalida1.Enabled = false;
                      //  txtMinDesactivaSalida1.Enabled = false;
                      //  cmbDiaDesactivaSalida1.Enabled = false;
                      //  chckDesactivadasSalida1.Checked = false;
                        chckTiempoSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraActivaSalida1.Enabled = false;
                        txtMinActivaSalida1.Enabled = false;
                        cmbDiaActivaSalida1.Enabled = false;
                    }
                    break;

                case "chckActivadasSalida2":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida2.Enabled = false;
                        txtHoraActivaSalida2.Enabled = true;
                        txtMinActivaSalida2.Enabled = true;
                        cmbDiaActivaSalida2.Enabled = true;
                        //   txtHoraDesactivaSalida1.Enabled = false;
                        //  txtMinDesactivaSalida1.Enabled = false;
                        //  cmbDiaDesactivaSalida1.Enabled = false;
                        //  chckDesactivadasSalida1.Checked = false;
                        chckTiempoSalida2.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraActivaSalida2.Enabled = false;
                        txtMinActivaSalida2.Enabled = false;
                        cmbDiaActivaSalida2.Enabled = false;
                    }
                    break;
                case "chckActivadasSalida3":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida3.Enabled = false;
                        txtHoraActivaSalida3.Enabled = true;
                        txtMinActivaSalida3.Enabled = true;
                        cmbDiaActivaSalida3.Enabled = true;
                        //   txtHoraDesactivaSalida1.Enabled = false;
                        //  txtMinDesactivaSalida1.Enabled = false;
                        //  cmbDiaDesactivaSalida1.Enabled = false;
                        //  chckDesactivadasSalida1.Checked = false;
                        chckTiempoSalida3.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraActivaSalida3.Enabled = false;
                        txtMinActivaSalida3.Enabled = false;
                        cmbDiaActivaSalida3.Enabled = false;
                    }
                    break;
                case "chckActivadasSalida4":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida4.Enabled = false;
                        txtHoraActivaSalida4.Enabled = true;
                        txtMinActivaSalida4.Enabled = true;
                        cmbDiaActivaSalida4.Enabled = true;
                        //   txtHoraDesactivaSalida1.Enabled = false;
                        //  txtMinDesactivaSalida1.Enabled = false;
                        //  cmbDiaDesactivaSalida1.Enabled = false;
                        //  chckDesactivadasSalida1.Checked = false;
                        chckTiempoSalida4.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraActivaSalida4.Enabled = false;
                        txtMinActivaSalida4.Enabled = false;
                        cmbDiaActivaSalida4.Enabled = false;
                    }
                    break;
                case "chckActivadasSalida5":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida5.Enabled = false;
                        txtHoraActivaSalida5.Enabled = true;
                        txtMinActivaSalida5.Enabled = true;
                        cmbDiaActivaSalida5.Enabled = true;
                        //   txtHoraDesactivaSalida1.Enabled = false;
                        //  txtMinDesactivaSalida1.Enabled = false;
                        //  cmbDiaDesactivaSalida1.Enabled = false;
                        //  chckDesactivadasSalida1.Checked = false;
                        chckTiempoSalida5.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraActivaSalida5.Enabled = false;
                        txtMinActivaSalida5.Enabled = false;
                        cmbDiaActivaSalida5.Enabled = false;
                    }
                    break;
                case "chckActivadasSalida6":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida6.Enabled = false;
                        txtHoraActivaSalida6.Enabled = true;
                        txtMinActivaSalida6.Enabled = true;
                        cmbDiaActivaSalida6.Enabled = true;
                        //   txtHoraDesactivaSalida1.Enabled = false;
                        //  txtMinDesactivaSalida1.Enabled = false;
                        //  cmbDiaDesactivaSalida1.Enabled = false;
                        //  chckDesactivadasSalida1.Checked = false;
                        chckTiempoSalida6.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraActivaSalida6.Enabled = false;
                        txtMinActivaSalida6.Enabled = false;
                        cmbDiaActivaSalida6.Enabled = false;
                    }
                    break;
                case "chckActivadasSalida7":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida7.Enabled = false;
                        txtHoraActivaSalida7.Enabled = true;
                        txtMinActivaSalida7.Enabled = true;
                        cmbDiaActivaSalida7.Enabled = true;
                        //   txtHoraDesactivaSalida1.Enabled = false;
                        //  txtMinDesactivaSalida1.Enabled = false;
                        //  cmbDiaDesactivaSalida1.Enabled = false;
                        //  chckDesactivadasSalida1.Checked = false;
                        chckTiempoSalida7.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraActivaSalida7.Enabled = false;
                        txtMinActivaSalida7.Enabled = false;
                        cmbDiaActivaSalida7.Enabled = false;
                    }
                    break;
                case "chckActivadasSalida8":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida8.Enabled = false;
                        txtHoraActivaSalida8.Enabled = true;
                        txtMinActivaSalida8.Enabled = true;
                        cmbDiaActivaSalida8.Enabled = true;
                        //   txtHoraDesactivaSalida1.Enabled = false;
                        //  txtMinDesactivaSalida1.Enabled = false;
                        //  cmbDiaDesactivaSalida1.Enabled = false;
                        //  chckDesactivadasSalida1.Checked = false;
                        chckTiempoSalida8.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraActivaSalida8.Enabled = false;
                        txtMinActivaSalida8.Enabled = false;
                        cmbDiaActivaSalida8.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void chckDesactivadasAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            actulizarTramaAEnviar(checkBox);

            switch (checkBox.Name)
            {
                case "chckDesactivadasSalida1":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida1.Enabled = false;
                        txtHoraDesactivaSalida1.Enabled = true;
                        txtMinDesactivaSalida1.Enabled = true;
                        cmbDiaDesactivaSalida1.Enabled = true;
                        //txtHoraActivaSalida1.Enabled = false;
                      //  txtMinActivaSalida1.Enabled = false;
                        //cmbDiaActivaSalida1.Enabled = false;
                        chckTiempoSalida1.Checked = !checkBox.Checked;
                      //  chckActivadasSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraDesactivaSalida1.Enabled = false;
                        txtMinDesactivaSalida1.Enabled = false;
                        cmbDiaDesactivaSalida1.Enabled = false;
                    }
                    break;
                case "chckDesactivadasSalida2":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida2.Enabled = false;
                        txtHoraDesactivaSalida2.Enabled = true;
                        txtMinDesactivaSalida2.Enabled = true;
                        cmbDiaDesactivaSalida2.Enabled = true;
                        //txtHoraActivaSalida1.Enabled = false;
                        //  txtMinActivaSalida1.Enabled = false;
                        //cmbDiaActivaSalida1.Enabled = false;
                        chckTiempoSalida2.Checked = !checkBox.Checked;
                        //  chckActivadasSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraDesactivaSalida2.Enabled = false;
                        txtMinDesactivaSalida2.Enabled = false;
                        cmbDiaDesactivaSalida2.Enabled = false;
                    }
                    break;
                case "chckDesactivadasSalida3":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida3.Enabled = false;
                        txtHoraDesactivaSalida3.Enabled = true;
                        txtMinDesactivaSalida3.Enabled = true;
                        cmbDiaDesactivaSalida3.Enabled = true;
                        //txtHoraActivaSalida1.Enabled = false;
                        //  txtMinActivaSalida1.Enabled = false;
                        //cmbDiaActivaSalida1.Enabled = false;
                        chckTiempoSalida3.Checked = !checkBox.Checked;
                        //  chckActivadasSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraDesactivaSalida3.Enabled = false;
                        txtMinDesactivaSalida3.Enabled = false;
                        cmbDiaDesactivaSalida3.Enabled = false;
                    }
                    break;
                case "chckDesactivadasSalida4":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida4.Enabled = false;
                        txtHoraDesactivaSalida4.Enabled = true;
                        txtMinDesactivaSalida4.Enabled = true;
                        cmbDiaDesactivaSalida4.Enabled = true;
                        //txtHoraActivaSalida1.Enabled = false;
                        //  txtMinActivaSalida1.Enabled = false;
                        //cmbDiaActivaSalida1.Enabled = false;
                        chckTiempoSalida4.Checked = !checkBox.Checked;
                        //  chckActivadasSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraDesactivaSalida4.Enabled = false;
                        txtMinDesactivaSalida4.Enabled = false;
                        cmbDiaDesactivaSalida4.Enabled = false;
                    }
                    break;
                case "chckDesactivadasSalida5":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida5.Enabled = false;
                        txtHoraDesactivaSalida5.Enabled = true;
                        txtMinDesactivaSalida5.Enabled = true;
                        cmbDiaDesactivaSalida5.Enabled = true;
                        //txtHoraActivaSalida1.Enabled = false;
                        //  txtMinActivaSalida1.Enabled = false;
                        //cmbDiaActivaSalida1.Enabled = false;
                        chckTiempoSalida5.Checked = !checkBox.Checked;
                        //  chckActivadasSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraDesactivaSalida5.Enabled = false;
                        txtMinDesactivaSalida5.Enabled = false;
                        cmbDiaDesactivaSalida5.Enabled = false;
                    }
                    break;
                case "chckDesactivadasSalida6":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida6.Enabled = false;
                        txtHoraDesactivaSalida6.Enabled = true;
                        txtMinDesactivaSalida6.Enabled = true;
                        cmbDiaDesactivaSalida6.Enabled = true;
                        //txtHoraActivaSalida1.Enabled = false;
                        //  txtMinActivaSalida1.Enabled = false;
                        //cmbDiaActivaSalida1.Enabled = false;
                        chckTiempoSalida6.Checked = !checkBox.Checked;
                        //  chckActivadasSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraDesactivaSalida6.Enabled = false;
                        txtMinDesactivaSalida6.Enabled = false;
                        cmbDiaDesactivaSalida6.Enabled = false;
                    }
                    break;
                case "chckDesactivadasSalida7":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida7.Enabled = false;
                        txtHoraDesactivaSalida7.Enabled = true;
                        txtMinDesactivaSalida7.Enabled = true;
                        cmbDiaDesactivaSalida7.Enabled = true;
                        //txtHoraActivaSalida1.Enabled = false;
                        //  txtMinActivaSalida1.Enabled = false;
                        //cmbDiaActivaSalida1.Enabled = false;
                        chckTiempoSalida7.Checked = !checkBox.Checked;
                        //  chckActivadasSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraDesactivaSalida7.Enabled = false;
                        txtMinDesactivaSalida7.Enabled = false;
                        cmbDiaDesactivaSalida7.Enabled = false;
                    }
                    break;
                case "chckDesactivadasSalida8":
                    if (checkBox.Checked)
                    {
                        txtTiempoSalida8.Enabled = false;
                        txtHoraDesactivaSalida8.Enabled = true;
                        txtMinDesactivaSalida8.Enabled = true;
                        cmbDiaDesactivaSalida8.Enabled = true;
                        //txtHoraActivaSalida1.Enabled = false;
                        //  txtMinActivaSalida1.Enabled = false;
                        //cmbDiaActivaSalida1.Enabled = false;
                        chckTiempoSalida8.Checked = !checkBox.Checked;
                        //  chckActivadasSalida1.Checked = !checkBox.Checked;
                    }
                    else
                    {
                        txtHoraDesactivaSalida8.Enabled = false;
                        txtMinDesactivaSalida8.Enabled = false;
                        cmbDiaDesactivaSalida8.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnGrabarSalidas_Click(object sender, EventArgs e)
        {
            evento = "btnGrabar";

            for (int i = 0; i < tiempoCheckBoxes.Count; i++)
            {
                if (tiempoCheckBoxes[i].Checked==true)
                {
                    chckTiempo[i] = chckTiempoAEnviar[i];

                    tiempo[i] = tiempoAEnviar[i];

                }
                else
                {
                    chckTiempo[i] = chckTiempoAEnviar[i];

                }
                if (activarCheckBoxes[i].Checked == true)
                {
                    chckActivar[i] = chckActivarAEnviar[i];

                    List<byte[]> listhoraMinDiaAEnviar = new List<byte[]>();
                    List<byte[]> listhoraMinDia = new List<byte[]>();

                    var contador = 0;

                    while (contador < horaMinDiaAEnviar.Length)
                    {
                        listhoraMinDiaAEnviar.Add(horaMinDiaAEnviar.SubArray(contador, 3));
                        listhoraMinDia.Add(horaMinDia.SubArray(contador, 3));


                        contador += 3;
                    }
                    listhoraMinDia[i] = listhoraMinDiaAEnviar[i];

                  
                    byte[] temp = listhoraMinDia[0];
                    for (int j = 1; j < listhoraMinDia.ToArray().Length; j++)
                    {
                        temp = temp.Concat(listhoraMinDia[j]).ToArray();
                    }
            
                    horaMinDia = temp;

                }
                else
                {
                    chckActivar[i] = chckActivarAEnviar[i];

                
                }
                if (desactivarCheckBoxes[i].Checked == true)
                {
                    chckDesactivar[i] = chckDesactivarAEnviar[i];

                    List<byte[]> listhoraMinDiaDesactivarAEnviar = new List<byte[]>();
                    List<byte[]> listhoraMinDiaDesactivar = new List<byte[]>();

                    var contador = 0;

                    while (contador < horaMinDiaDesactivarAEnviar.Length)
                    {
                        listhoraMinDiaDesactivarAEnviar.Add(horaMinDiaDesactivarAEnviar.SubArray(contador, 3));
                        listhoraMinDiaDesactivar.Add(horaMinDiaDesactivar.SubArray(contador, 3));


                        contador += 3;
                    }
                    listhoraMinDiaDesactivar[i] = listhoraMinDiaDesactivarAEnviar[i];


                    byte[] temp = listhoraMinDiaDesactivar[0];
                    for (int j = 1; j < listhoraMinDiaDesactivar.ToArray().Length; j++)
                    {
                        temp = temp.Concat(listhoraMinDiaDesactivar[j]).ToArray();
                    }

                    horaMinDiaDesactivar = temp;

                }
                else
                {
                    chckDesactivar[i] = chckDesactivarAEnviar[i];


                }
            }


            //var b = Convert.ToByte(str, 8);
            var sbchckTiempo = new System.Text.StringBuilder();
            var sbchckActivar = new System.Text.StringBuilder();
            var sbchckDesactivar = new System.Text.StringBuilder();


            for (int i = 0; i < chckTiempo.Length; i++)
            {
                sbchckTiempo.Append(Convert.ToString(chckTiempo[i], 8));
                sbchckActivar.Append(Convert.ToString(chckActivar[i], 8));
                sbchckDesactivar.Append(Convert.ToString(chckDesactivar[i], 8));


            }

            var b = new byte[] { Convert.ToByte(sbchckTiempo.ToString(), 2) };
            byte[] TramaEnvio = b;

            TramaEnvio = TramaEnvio.Concat(tiempo)
                .Concat(new byte[] { Convert.ToByte(sbchckActivar.ToString(), 2) })
                .Concat(horaMinDia)
                .Concat(new byte[] { Convert.ToByte(sbchckDesactivar.ToString(), 2) })
                .Concat(horaMinDiaDesactivar)

                .ToArray();
            byte[] data = { 3, 3, 4, };
            data= data.Concat(TramaEnvio).ToArray();
            _port.Write(data, 0, data.Length);



        }

        private void actualizarTiempo(string checkactivo)
        {

           // "chckTiempoSalida1"
            var index = Convert.ToInt32(checkactivo.Substring(16, checkactivo.Length-16))-1;

            chckTiempo[index] =(byte) Convert.ToInt32(tiempoTextBoxes.ElementAt(index).Text);

        }

        private void txtAll_KeyPress(object sender,
        KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }
        private void txtAll_Leave(object sender, EventArgs e)
            {
            MetroTextBox textBox = (MetroTextBox)sender;
            var name = textBox.Name;

            //chckTiempo = trama.SubArray(5, 8);
            //tiempo = trama.SubArray(13, 8);
            //chckActivar = trama.SubArray(21, 8);
            //horaMinDia = trama.SubArray(29, 24);
            //chckDesactivar = trama.SubArray(53, 8);
            //horaMinDiaDesactivar = trama.SubArray(61, 24);

            if (name.Contains("Tiempo"))
            {
                var index = Convert.ToInt32(name.Substring(15, name.Length - 15)) - 1;
                tiempoAEnviar[index] = (byte)Convert.ToInt32(textBox.Text);

            }
            else if (name.Contains("HoraActiva"))
            {
                List<byte[]> vs = new List<byte[]>();
                var contador = 0;

                while (contador<horaMinDiaAEnviar.Length)
                {
                    vs.Add(horaMinDiaAEnviar.SubArray(contador, 3));

                    contador += 3;
                }
                var index = Convert.ToInt32(name.Substring(19, name.Length - 19)) - 1;

                vs[index][0] = (byte)Convert.ToInt32(textBox.Text);
                byte[] temp = vs[0];
                for (int i = 1; i < vs.ToArray().Length; i++)
                {
                    temp = temp.Concat(vs[i]).ToArray();
                }

                    horaMinDiaAEnviar = temp;
          

            }

            else if (name.Contains("MinActiva"))
            {
                List<byte[]> vs = new List<byte[]>();
                var contador = 0;

                while (contador < horaMinDiaAEnviar.Length)
                {
                    vs.Add(horaMinDiaAEnviar.SubArray(contador, 3));

                    contador += 3;
                }

                var index = Convert.ToInt32(name.Substring(18, name.Length - 18))-1;
                vs[index][1] = (byte)Convert.ToInt32(textBox.Text);
                byte[] temp = vs[0];
                for (int i = 1; i < vs.ToArray().Length; i++)
                {
                    temp = temp.Concat(vs[i]).ToArray();
                }

                horaMinDiaAEnviar = temp;


            }
            else if (name.Contains("HoraDesactiva"))
            {
                List<byte[]> vs = new List<byte[]>();
                var contador = 0;

                while (contador < horaMinDiaDesactivarAEnviar.Length)
                {
                    vs.Add(horaMinDiaDesactivarAEnviar.SubArray(contador, 3));

                    contador += 3;
                }
                var index = Convert.ToInt32(name.Substring(22, name.Length - 22)) - 1;

                vs[index][0] = (byte)Convert.ToInt32(textBox.Text);
                byte[] temp = vs[0];
                for (int i = 1; i < vs.ToArray().Length; i++)
                {
                    temp = temp.Concat(vs[i]).ToArray();
                }

                horaMinDiaDesactivarAEnviar = temp;


            }

            else if (name.Contains("MinDesactiva"))
            {
                List<byte[]> vs = new List<byte[]>();
                var contador = 0;

                while (contador < horaMinDiaDesactivarAEnviar.Length)
                {
                    vs.Add(horaMinDiaDesactivarAEnviar.SubArray(contador, 3));

                    contador += 3;
                }

                var index = Convert.ToInt32(name.Substring(21, name.Length - 21)) - 1;
                vs[index][1] = (byte)Convert.ToInt32(textBox.Text);
                byte[] temp = vs[0];
                for (int i = 1; i < vs.ToArray().Length; i++)
                {
                    temp = temp.Concat(vs[i]).ToArray();
                }

                horaMinDiaDesactivarAEnviar = temp;


            }
        }

      
        private void cmbDiaAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetroComboBox metroComboBox = (MetroComboBox)sender;

            var name = metroComboBox.Name;
            if (metroComboBox.Name.Contains("DiaActiva"))
            {

                List<byte[]> vs = new List<byte[]>();
                var contador = 0;

                while (contador < horaMinDiaAEnviar.Length)
                {
                    vs.Add(horaMinDiaAEnviar.SubArray(contador, 3));

                    contador += 3;
                }

                var index = Convert.ToInt32(name.Substring(18, name.Length - 18)) - 1;

                vs[index][2] = (byte)metroComboBox.SelectedIndex;
                byte[] temp = vs[0];
                for (int i = 1; i < vs.ToArray().Length; i++)
                {
                    temp = temp.Concat(vs[i]).ToArray();
                }

                horaMinDiaAEnviar = temp;


            }
            else if (metroComboBox.Name.Contains("DiaDesactiva"))
            {

                List<byte[]> vs = new List<byte[]>();
                var contador = 0;

                while (contador < horaMinDiaDesactivarAEnviar.Length)
                {
                    vs.Add(horaMinDiaDesactivarAEnviar.SubArray(contador, 3));

                    contador += 3;
                }
                var index = Convert.ToInt32(name.Substring(21, name.Length - 21)) - 1;

                vs[index][2] = (byte)metroComboBox.SelectedIndex;
                byte[] temp = vs[0];
                for (int i = 1; i < vs.ToArray().Length; i++)
                {
                    temp = temp.Concat(vs[i]).ToArray();
                }

                horaMinDiaDesactivarAEnviar = temp;


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            dateTime=dateTime.AddSeconds(1);
            dateTimePicker1.Value = dateTime;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTime = dateTimePicker1.Value;
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            evento = "CambiarFecha";

            var datMOdificar = dateTimePicker1.Value;

            var AñoBinary = Convert.ToString(datMOdificar.Year, 2).PadLeft(16,'0');

            var añopart1 = (byte)Convert.ToInt32(AñoBinary.Substring(0, 8), 2);
            var añopart2 = (byte)Convert.ToInt32(AñoBinary.Substring(8, 8), 2);


            byte[] data = { 3, 3, 5,añopart1,añopart2,(byte)datMOdificar.Month,(byte)datMOdificar.Day,(byte)datMOdificar.Hour, (byte)datMOdificar.Minute, (byte)datMOdificar.Second };
         //   data = data.Concat(TramaEnvio).ToArray();
            _port.Write(data, 0, data.Length);
        }
    }

}
