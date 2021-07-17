using MetroFramework.Forms;
using MetroFramework;
using MetroFramework.Controls;
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
using MF328.Helpers;
using MF328.Extension;

namespace MF328
{
    public partial class Modelo1Form : MetroForm
    {
        private  SerialPort _port;
        private  byte[] _trama;
        private byte NDivice;
        List<MetroComboBox> ModoSalidasComboBox = new List<MetroComboBox>();
        List<GroupBox> EntradasGroupBox = new List<GroupBox>();
        List<MetroTextBox> EntradasMetroTextBox = new List<MetroTextBox>();
        List<GroupBox> SalidasGroupBox = new List<GroupBox>();


        List<byte[]> listByte = new List<byte[]>();

        byte[] TramaSample = new byte[] { 1, 3, 240, 240, 240, 20, 20, 20, 2, 240, 240, 240, 20, 20, 20, 2, 240, 240, 240, 20, 20, 20, 3, 0, 150, 1, 70, 0, 160, 100 };
       
        SortedDictionary<int, string> ModoSalidas = new SortedDictionary<int, string>
        {
           {0,"Normal" },
            {1,"Desactivar" },
        };

        public Modelo1Form(SerialPort port, byte[] trama)
        {
            _port = port;
            TramaSample = trama;
            NDivice = trama[0];

            InitializeComponent();
            var t = TramaSample.Skip(1).Take(28);
            listByte = t.ToArray().tramaToList();
            ModoSalidasComboBox.AddRange(new List<MetroComboBox>() { CombSalida1 });
            EntradasGroupBox.AddRange(new List<GroupBox>() { GroupEntrada1, GroupEntrada2, GroupEntrada3 });
            SalidasGroupBox.AddRange(new List<GroupBox>() { GroupSalida1, GroupSalida2, GroupSalida3 });

            EntradasMetroTextBox.AddRange(new List<MetroTextBox>() { TxtEntrada1Destino1, TxtEntrada1NSalida1, TxtEntrada1Destino2, TxtEntrada1NSalida2, TxtEntrada1Destino3, TxtEntrada1NSalida3 });

            inicializarComboxes();
            inicializarEntradas();
            inicializarSalidas();

          
            
        }
        public Modelo1Form()
        {
            InitializeComponent();
            var t = TramaSample.Skip(1).Take(28);
            listByte = t.ToArray().tramaToList();
            ModoSalidasComboBox.AddRange(new List<MetroComboBox>() { CombSalida1 } ) ;
            EntradasGroupBox.AddRange(new List<GroupBox>() { GroupEntrada1,GroupEntrada2,GroupEntrada3 });
            SalidasGroupBox.AddRange(new List<GroupBox>() { GroupSalida1, GroupSalida2, GroupSalida3 });

            EntradasMetroTextBox.AddRange(new List<MetroTextBox>() { TxtEntrada1Destino1,TxtEntrada1NSalida1,TxtEntrada1Destino2,TxtEntrada1NSalida2,TxtEntrada1Destino3,TxtEntrada1NSalida3 });

            inicializarComboxes();
            inicializarEntradas();
            inicializarSalidas();

        }
        private void inicializarComboxes()
        {

            foreach (var groupBox in SalidasGroupBox)
            {
                foreach (var item in groupBox.Controls)
                {
                    if (item.GetType().FullName.Contains("Combo"))
                    {
                        MetroComboBox comboCurrent = ((MetroComboBox)item);
                        comboCurrent.DataSource = new BindingSource(ModoSalidas, null);
                        comboCurrent.DisplayMember = "Value";
                        comboCurrent.ValueMember = "Key";
                        comboCurrent.SelectedIndex = -1;
                        comboCurrent.Enabled = true;
                      
                    }
                };

            }
        }

        private void inicializarEntradas()
        {
           
            foreach (var groupBox in EntradasGroupBox)
            {
                var count = 5;
                var checkecount = 2;
                var index = Convert.ToInt32(groupBox.Name.Substring(groupBox.Name.Length - 1, 1))-1;
              //  var reordenar = listByte[index].reordenar();

                var checke = new Boolean[] { false,false,false};

                foreach (var i in Enumerable.Range(0, listByte[index][0]))
                {
                    checke[i] = true;
                }

                foreach (var item in groupBox.Controls)
                {
                    if (item.GetType().FullName.Contains("Text"))
                    {
                        ((MetroTextBox)item).Text = listByte[index].Skip(1).ToArray()[count].ToString();
                        count -= 1;
                    }

                    if (item.GetType().FullName.Contains("Check"))
                    {
                        ((MetroCheckBox)item).Checked = checke[checkecount];
                        checkecount -= 1;
                    }
                };

            }


        }

        private void inicializarSalidas()
        {

            var tramaSalidas = listByte[listByte.Count - 1];

            var valueTiempo = tramaSalidas.tramaSalidasTiempo();
            var comboboxValue = Convert.ToInt32(tramaSalidas.Take(1).FirstOrDefault()).decimalBinario().ToString().PadRight(3,'0');
            var Comboxcount = 0;
            var Textcount = 0;
            foreach (var groupBox in SalidasGroupBox)
            {
             

                foreach (var item in groupBox.Controls)
                {
                    if (item.GetType().FullName.Contains("Text"))
                    {
                        ((MetroTextBox)item).Text = valueTiempo[Textcount].ToString();
                        Textcount += 1;
                    }

                    if (item.GetType().FullName.Contains("Combo"))
                    {
                        ((MetroComboBox)item).SelectedValue = Convert.ToInt32(comboboxValue[Comboxcount].ToString());
                        Comboxcount += 1;
                    }
                };

            }


        }
        protected override void OnLoad(EventArgs e)
        {
            //materialLabel1.Text = $"Puesto conectado : {_port?.IsOpen} ";
            

            base.OnLoad(e);
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidatorTxt.txt_KeyPress(sender, e);

        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxBussines.Checked(sender,e,this);
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

            MainFormMDI.evento = "grabar";
          var tramaEntradas= GrabarTrama.ObtenerTramaEntradas(EntradasGroupBox);
          var tramaSalidas = GrabarTrama.ObtenerTramaSalidas(SalidasGroupBox);
          var tramaResult = tramaEntradas.Concat(tramaSalidas);

           var array = new byte[] { 250, 3 };
           var enviar= array.Concat(tramaResult).ToArray();
            _port.Write(enviar, 0, enviar.Length);

        }
    }
}
