using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace MF328
{
    public partial class MainForm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        static SerialPort _port;
        DateTime dateTime;
        private Queue<byte> recievedData = new Queue<byte>();
        delegate void SetTextDeleg(byte[] trama);

        public MainForm()
        {
            InitializeComponent();

            var serial = SerialPort.GetPortNames();
            cmbPorts.DataSource = serial;
            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);

            materialLabel1.BackColor = Color.Transparent;

            materialLabel2.BackColor = Color.Transparent;
            materialLabel3.BackColor = Color.Transparent;


        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
        }



        private void MaterialButton3_Click(object sender, EventArgs e)
        {
            var builder = new StringBuilder("Batch operation report:\n\n");
            var random = new Random();
            var result = 0;

            for (int i = 0; i < 200; i++)
            {
                result = random.Next(1000);

                if (result < 950)
                {
                    builder.AppendFormat(" - Task {0}: Operation completed sucessfully.\n", i);
                }
                else
                {
                    builder.AppendFormat(" - Task {0}: Operation failed! A very very very very very very very very very very very very serious error has occured during this sub-operation. The errorcode is: {1}).\n", i, result);
                }
            }

            var batchOperationResults = builder.ToString();
            var mresult = MaterialMessageBox.Show(batchOperationResults, "Batch Operation");
        }

        private void materialTextBox2_LeadingIconClick(object sender, EventArgs e)
        {

        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            MaterialSnackBar SnackBarMessage = new MaterialSnackBar("SnackBar started succesfully", "OK", true);
            SnackBarMessage.Show(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void materialContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDireccion.Text))
            {
                MaterialSnackBar SnackBarMessage = new MaterialSnackBar("Debe ingresar la Direccion", "OK", true);
                SnackBarMessage.Show(this);
            }
            splitContainer2.Panel1.BackColor = Color.LawnGreen;
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
               // MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnConectarCOM_Click(object sender, EventArgs e)
        {
            if (cmbPorts.SelectedIndex == -1)
            {
                sendMaterialSnackBar("No selecciono un puerto", "OK");
                return;
            }
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
                //_port.DataReceived += new
                // SerialDataReceivedEventHandler(port_DataReceived);
                _port.Open();

                btnConectarCOM.Enabled = false;
                btnDesconectarCOM.Enabled = true;
                splitContainer2.Panel1.BackColor = Color.LawnGreen;
                sendMaterialSnackBar($"Se ha conectado con exito", "OK");
                
            }
            catch (Exception)
            {
                splitContainer2.Panel1.BackColor = Color.DarkRed;

                sendMaterialSnackBar($"Error el conectar al puerto {cmbPorts.SelectedItem}", "ERROR");

            }

        }

        public void sendMaterialSnackBar(string message,string action)
        {
            MaterialSnackBar SnackBarMessage = new MaterialSnackBar(message, action, true);
            SnackBarMessage.Show(this);
        }
        }
}
