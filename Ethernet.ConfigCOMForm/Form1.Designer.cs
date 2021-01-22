
namespace Ethernet.ConfigCOMForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDesconectar = new MetroFramework.Controls.MetroButton();
            this.btnConectar = new MetroFramework.Controls.MetroButton();
            this.cmbPorts = new MetroFramework.Controls.MetroComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDesconectarEthernet = new MetroFramework.Controls.MetroButton();
            this.btnConectarEthernet = new MetroFramework.Controls.MetroButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCambiarIP = new MetroFramework.Controls.MetroButton();
            this.txtBye1 = new MetroFramework.Controls.MetroTextBox();
            this.txtBye2 = new MetroFramework.Controls.MetroTextBox();
            this.txtBye3 = new MetroFramework.Controls.MetroTextBox();
            this.txtBye4 = new MetroFramework.Controls.MetroTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDesconectar);
            this.groupBox1.Controls.Add(this.btnConectar);
            this.groupBox1.Controls.Add(this.cmbPorts);
            this.groupBox1.Location = new System.Drawing.Point(210, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Puerto COM";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.Enabled = false;
            this.btnDesconectar.Location = new System.Drawing.Point(387, 39);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(110, 34);
            this.btnDesconectar.TabIndex = 7;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(269, 39);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(87, 34);
            this.btnConectar.TabIndex = 6;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // cmbPorts
            // 
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.ItemHeight = 24;
            this.cmbPorts.Location = new System.Drawing.Point(119, 43);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 30);
            this.cmbPorts.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnDesconectarEthernet);
            this.groupBox2.Controls.Add(this.btnConectarEthernet);
            this.groupBox2.Location = new System.Drawing.Point(210, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(593, 176);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuracion Ethernet";
            // 
            // btnDesconectarEthernet
            // 
            this.btnDesconectarEthernet.Enabled = false;
            this.btnDesconectarEthernet.Location = new System.Drawing.Point(481, 10);
            this.btnDesconectarEthernet.Name = "btnDesconectarEthernet";
            this.btnDesconectarEthernet.Size = new System.Drawing.Size(106, 34);
            this.btnDesconectarEthernet.TabIndex = 9;
            this.btnDesconectarEthernet.Text = "Desconectar";
            this.btnDesconectarEthernet.Click += new System.EventHandler(this.btnDesconectarEthernet_Click);
            // 
            // btnConectarEthernet
            // 
            this.btnConectarEthernet.Location = new System.Drawing.Point(387, 10);
            this.btnConectarEthernet.Name = "btnConectarEthernet";
            this.btnConectarEthernet.Size = new System.Drawing.Size(87, 34);
            this.btnConectarEthernet.TabIndex = 8;
            this.btnConectarEthernet.Text = "Conectar";
            this.btnConectarEthernet.Click += new System.EventHandler(this.btnConectarEthernet_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBye4);
            this.groupBox3.Controls.Add(this.txtBye3);
            this.groupBox3.Controls.Add(this.txtBye2);
            this.groupBox3.Controls.Add(this.txtBye1);
            this.groupBox3.Controls.Add(this.btnCambiarIP);
            this.groupBox3.Location = new System.Drawing.Point(40, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 78);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DIreccion IP";
            // 
            // btnCambiarIP
            // 
            this.btnCambiarIP.Enabled = false;
            this.btnCambiarIP.Location = new System.Drawing.Point(435, 15);
            this.btnCambiarIP.Name = "btnCambiarIP";
            this.btnCambiarIP.Size = new System.Drawing.Size(87, 34);
            this.btnCambiarIP.TabIndex = 9;
            this.btnCambiarIP.Text = "Cambiar";
            this.btnCambiarIP.Click += new System.EventHandler(this.btnCambiarIP_Click);
            // 
            // txtBye1
            // 
            this.txtBye1.Enabled = false;
            this.txtBye1.Location = new System.Drawing.Point(79, 22);
            this.txtBye1.Name = "txtBye1";
            this.txtBye1.Size = new System.Drawing.Size(38, 27);
            this.txtBye1.TabIndex = 10;
            this.txtBye1.Click += new System.EventHandler(this.txtBye1_Click);
            this.txtBye1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBye1_KeyDown);
            // 
            // txtBye2
            // 
            this.txtBye2.Enabled = false;
            this.txtBye2.Location = new System.Drawing.Point(123, 22);
            this.txtBye2.Name = "txtBye2";
            this.txtBye2.Size = new System.Drawing.Size(38, 27);
            this.txtBye2.TabIndex = 11;
            // 
            // txtBye3
            // 
            this.txtBye3.Enabled = false;
            this.txtBye3.Location = new System.Drawing.Point(167, 22);
            this.txtBye3.Name = "txtBye3";
            this.txtBye3.Size = new System.Drawing.Size(38, 27);
            this.txtBye3.TabIndex = 12;
            // 
            // txtBye4
            // 
            this.txtBye4.Enabled = false;
            this.txtBye4.Location = new System.Drawing.Point(211, 22);
            this.txtBye4.Name = "txtBye4";
            this.txtBye4.Size = new System.Drawing.Size(38, 27);
            this.txtBye4.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 556);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton btnDesconectar;
        private MetroFramework.Controls.MetroButton btnConectar;
        private MetroFramework.Controls.MetroComboBox cmbPorts;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroTextBox txtBye1;
        private MetroFramework.Controls.MetroButton btnCambiarIP;
        private MetroFramework.Controls.MetroButton btnDesconectarEthernet;
        private MetroFramework.Controls.MetroButton btnConectarEthernet;
        private MetroFramework.Controls.MetroTextBox txtBye4;
        private MetroFramework.Controls.MetroTextBox txtBye3;
        private MetroFramework.Controls.MetroTextBox txtBye2;
    }
}

