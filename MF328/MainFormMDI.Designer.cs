
namespace MF328
{
    partial class MainFormMDI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormMDI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.conectarAPuertoCOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionPuertoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbPorts = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConectarCOM = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDesconectarCOM = new System.Windows.Forms.ToolStripMenuItem();
            this.cnxDispositivo = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarDIreccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDireccion = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConectarDispositivo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblProcessBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectarAPuertoCOMToolStripMenuItem,
            this.cnxDispositivo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1549, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conectarAPuertoCOMToolStripMenuItem
            // 
            this.conectarAPuertoCOMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionPuertoToolStripMenuItem,
            this.cmbPorts,
            this.toolStripSeparator1,
            this.btnConectarCOM,
            this.btnDesconectarCOM});
            this.conectarAPuertoCOMToolStripMenuItem.Name = "conectarAPuertoCOMToolStripMenuItem";
            this.conectarAPuertoCOMToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.conectarAPuertoCOMToolStripMenuItem.Text = "Conectar a Puerto COM";
            // 
            // seleccionPuertoToolStripMenuItem
            // 
            this.seleccionPuertoToolStripMenuItem.Name = "seleccionPuertoToolStripMenuItem";
            this.seleccionPuertoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.seleccionPuertoToolStripMenuItem.Text = "Seleccion Puerto";
            // 
            // cmbPorts
            // 
            this.cmbPorts.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
          
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 28);
            this.cmbPorts.Click += new System.EventHandler(this.cmbPorts_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // btnConectarCOM
            // 
            this.btnConectarCOM.Image = global::MF328.Properties.Resources.baseline_thumb_up_black_24dp;
            this.btnConectarCOM.Name = "btnConectarCOM";
            this.btnConectarCOM.Size = new System.Drawing.Size(224, 26);
            this.btnConectarCOM.Text = "Conectar";
            this.btnConectarCOM.Click += new System.EventHandler(this.conectarToolStripMenuItem_Click);
            // 
            // btnDesconectarCOM
            // 
            this.btnDesconectarCOM.Name = "btnDesconectarCOM";
            this.btnDesconectarCOM.Size = new System.Drawing.Size(224, 26);
            this.btnDesconectarCOM.Text = "Desconectar";
            this.btnDesconectarCOM.Click += new System.EventHandler(this.btnDesconectarCOM_Click);
            // 
            // cnxDispositivo
            // 
            this.cnxDispositivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarDIreccionToolStripMenuItem,
            this.txtDireccion,
            this.toolStripSeparator2,
            this.btnConectarDispositivo,
            this.toolStripMenuItem2});
            this.cnxDispositivo.Name = "cnxDispositivo";
            this.cnxDispositivo.Size = new System.Drawing.Size(172, 24);
            this.cnxDispositivo.Text = "Conectar a Dispositivo";
            // 
            // ingresarDIreccionToolStripMenuItem
            // 
            this.ingresarDIreccionToolStripMenuItem.Name = "ingresarDIreccionToolStripMenuItem";
            this.ingresarDIreccionToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.ingresarDIreccionToolStripMenuItem.Text = "Ingresar Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(100, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // btnConectarDispositivo
            // 
            this.btnConectarDispositivo.Name = "btnConectarDispositivo";
            this.btnConectarDispositivo.Size = new System.Drawing.Size(212, 26);
            this.btnConectarDispositivo.Text = "Conectar";
            this.btnConectarDispositivo.Click += new System.EventHandler(this.btnConectarDispositivo_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(212, 26);
            this.toolStripMenuItem2.Text = "Desconectar";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProcessBar,
            this.toolStripProgressBar1,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1031);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1549, 24);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblProcessBar
            // 
            this.lblProcessBar.Name = "lblProcessBar";
            this.lblProcessBar.Size = new System.Drawing.Size(0, 18);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(0, 18);
            // 
            // progressBar
            // 
            this.progressBar.AutoToolTip = true;
            this.progressBar.Name = "progressBar";
            this.progressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar.Size = new System.Drawing.Size(900, 16);
            this.progressBar.Step = 100;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // MainFormMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1549, 1055);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainFormMDI";
            this.Text = "MainFormMDI";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem conectarAPuertoCOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionPuertoToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmbPorts;
        private System.Windows.Forms.ToolStripMenuItem btnConectarCOM;
        private System.Windows.Forms.ToolStripMenuItem btnDesconectarCOM;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProgressBar1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripStatusLabel lblProcessBar;
        private System.Windows.Forms.ToolStripMenuItem cnxDispositivo;
        private System.Windows.Forms.ToolStripMenuItem ingresarDIreccionToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtDireccion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem btnConectarDispositivo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}