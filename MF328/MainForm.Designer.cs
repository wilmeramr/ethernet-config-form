using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace MF328
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuIconList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.materialButton6 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel53 = new MaterialSkin.Controls.MaterialLabel();
            this.MaterialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton5 = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDireccionNew = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.btnConectarCOM = new MaterialSkin.Controls.MaterialButton();
            this.btnDesconectarCOM = new MaterialSkin.Controls.MaterialButton();
            this.cmbPorts = new System.Windows.Forms.ComboBox();
            this.tabPage1.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuIconList
            // 
            this.menuIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuIconList.ImageStream")));
            this.menuIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.menuIconList.Images.SetKeyName(0, "round_assessment_white_24dp.png");
            this.menuIconList.Images.SetKeyName(1, "round_backup_white_24dp.png");
            this.menuIconList.Images.SetKeyName(2, "round_bluetooth_white_24dp.png");
            this.menuIconList.Images.SetKeyName(3, "round_bookmark_white_24dp.png");
            this.menuIconList.Images.SetKeyName(4, "round_build_white_24dp.png");
            this.menuIconList.Images.SetKeyName(5, "round_gps_fixed_white_24dp.png");
            this.menuIconList.Images.SetKeyName(6, "round_http_white_24dp.png");
            this.menuIconList.Images.SetKeyName(7, "round_report_problem_white_24dp.png");
            this.menuIconList.Images.SetKeyName(8, "round_swap_vert_white_24dp.png");
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.materialButton6);
            this.tabPage1.Controls.Add(this.materialLabel53);
            this.tabPage1.Controls.Add(this.MaterialButton3);
            this.tabPage1.Controls.Add(this.materialLabel6);
            this.tabPage1.ImageKey = "round_assessment_white_24dp.png";
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1356, 648);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            // 
            // materialButton6
            // 
            this.materialButton6.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.materialButton6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton6.Depth = 0;
            this.materialButton6.HighEmphasis = true;
            this.materialButton6.Icon = null;
            this.materialButton6.Location = new System.Drawing.Point(332, 565);
            this.materialButton6.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.materialButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton6.Name = "materialButton6";
            this.materialButton6.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.materialButton6.Size = new System.Drawing.Size(144, 36);
            this.materialButton6.TabIndex = 41;
            this.materialButton6.Text = "Show SnackBar";
            this.materialButton6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton6.UseAccentColor = false;
            this.materialButton6.UseVisualStyleBackColor = true;
            this.materialButton6.Click += new System.EventHandler(this.materialButton6_Click);
            // 
            // materialLabel53
            // 
            this.materialLabel53.AutoSize = true;
            this.materialLabel53.Depth = 0;
            this.materialLabel53.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel53.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel53.Location = new System.Drawing.Point(328, 521);
            this.materialLabel53.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel53.Name = "materialLabel53";
            this.materialLabel53.Size = new System.Drawing.Size(69, 19);
            this.materialLabel53.TabIndex = 40;
            this.materialLabel53.Text = "SnackBar";
            // 
            // MaterialButton3
            // 
            this.MaterialButton3.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.MaterialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MaterialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.MaterialButton3.Depth = 0;
            this.MaterialButton3.HighEmphasis = true;
            this.MaterialButton3.Icon = null;
            this.MaterialButton3.Location = new System.Drawing.Point(29, 566);
            this.MaterialButton3.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.MaterialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.MaterialButton3.Name = "MaterialButton3";
            this.MaterialButton3.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.MaterialButton3.Size = new System.Drawing.Size(163, 36);
            this.MaterialButton3.TabIndex = 36;
            this.MaterialButton3.Text = "Open Message box";
            this.MaterialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.MaterialButton3.UseAccentColor = false;
            this.MaterialButton3.UseVisualStyleBackColor = true;
            this.MaterialButton3.Click += new System.EventHandler(this.MaterialButton3_Click);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(25, 522);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(154, 19);
            this.materialLabel6.TabIndex = 35;
            this.materialLabel6.Text = "Flexible Message Box";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ImageList = this.menuIconList;
            this.materialTabControl1.Location = new System.Drawing.Point(4, 79);
            this.materialTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(1364, 683);
            this.materialTabControl1.TabIndex = 18;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1356, 648);
            this.splitContainer1.SplitterDistance = 452;
            this.splitContainer1.TabIndex = 42;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.LawnGreen;
            this.splitContainer2.Panel1.Controls.Add(this.cmbPorts);
            this.splitContainer2.Panel1.Controls.Add(this.materialLabel3);
            this.splitContainer2.Panel1.Controls.Add(this.btnConectarCOM);
            this.splitContainer2.Panel1.Controls.Add(this.btnDesconectarCOM);
            this.splitContainer2.Panel1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer2.Panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1356, 452);
            this.splitContainer2.SplitterDistance = 39;
            this.splitContainer2.TabIndex = 0;
            // 
            // materialButton1
            // 
            this.materialButton1.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(350, 26);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.materialButton1.Size = new System.Drawing.Size(98, 36);
            this.materialButton1.TabIndex = 0;
            this.materialButton1.Text = "CONECTAR";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click_1);
            // 
            // materialButton2
            // 
            this.materialButton2.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(496, 26);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.materialButton2.Size = new System.Drawing.Size(125, 36);
            this.materialButton2.TabIndex = 1;
            this.materialButton2.Text = "DESCONECTAR";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDireccion.Location = new System.Drawing.Point(235, 33);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(101, 22);
            this.txtDireccion.TabIndex = 2;
            this.txtDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(64, 33);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(126, 19);
            this.materialLabel1.TabIndex = 3;
            this.materialLabel1.Text = "Ingrese Direccion:";
            // 
            // materialButton5
            // 
            this.materialButton5.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.materialButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton5.Depth = 0;
            this.materialButton5.HighEmphasis = true;
            this.materialButton5.Icon = null;
            this.materialButton5.Location = new System.Drawing.Point(1127, 26);
            this.materialButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.materialButton5.Size = new System.Drawing.Size(86, 36);
            this.materialButton5.TabIndex = 4;
            this.materialButton5.Text = "CAMBIAR";
            this.materialButton5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton5.UseAccentColor = false;
            this.materialButton5.UseVisualStyleBackColor = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(757, 33);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(175, 19);
            this.materialLabel2.TabIndex = 7;
            this.materialLabel2.Text = "Ingrese Nueva Direccion:";
            // 
            // txtDireccionNew
            // 
            this.txtDireccionNew.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtDireccionNew.Location = new System.Drawing.Point(1012, 33);
            this.txtDireccionNew.Name = "txtDireccionNew";
            this.txtDireccionNew.Size = new System.Drawing.Size(101, 22);
            this.txtDireccionNew.TabIndex = 6;
            this.txtDireccionNew.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDireccionNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.materialLabel2);
            this.splitContainer3.Panel1.Controls.Add(this.materialLabel1);
            this.splitContainer3.Panel1.Controls.Add(this.txtDireccionNew);
            this.splitContainer3.Panel1.Controls.Add(this.materialButton1);
            this.splitContainer3.Panel1.Controls.Add(this.materialButton5);
            this.splitContainer3.Panel1.Controls.Add(this.materialButton2);
            this.splitContainer3.Panel1.Controls.Add(this.txtDireccion);
            this.splitContainer3.Size = new System.Drawing.Size(1356, 409);
            this.splitContainer3.TabIndex = 0;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(399, 15);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(90, 19);
            this.materialLabel3.TabIndex = 7;
            this.materialLabel3.Text = "Puerto COM:";
            // 
            // btnConectarCOM
            // 
            this.btnConectarCOM.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnConectarCOM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConectarCOM.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConectarCOM.Depth = 0;
            this.btnConectarCOM.HighEmphasis = true;
            this.btnConectarCOM.Icon = null;
            this.btnConectarCOM.Location = new System.Drawing.Point(685, 6);
            this.btnConectarCOM.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConectarCOM.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConectarCOM.Name = "btnConectarCOM";
            this.btnConectarCOM.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnConectarCOM.Size = new System.Drawing.Size(98, 36);
            this.btnConectarCOM.TabIndex = 4;
            this.btnConectarCOM.Text = "CONECTAR";
            this.btnConectarCOM.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConectarCOM.UseAccentColor = false;
            this.btnConectarCOM.UseVisualStyleBackColor = false;
            this.btnConectarCOM.Click += new System.EventHandler(this.btnConectarCOM_Click);
            // 
            // btnDesconectarCOM
            // 
            this.btnDesconectarCOM.AccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(129)))));
            this.btnDesconectarCOM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDesconectarCOM.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDesconectarCOM.Depth = 0;
            this.btnDesconectarCOM.HighEmphasis = true;
            this.btnDesconectarCOM.Icon = null;
            this.btnDesconectarCOM.Location = new System.Drawing.Point(831, 6);
            this.btnDesconectarCOM.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDesconectarCOM.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDesconectarCOM.Name = "btnDesconectarCOM";
            this.btnDesconectarCOM.NoAccentTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.btnDesconectarCOM.Size = new System.Drawing.Size(125, 36);
            this.btnDesconectarCOM.TabIndex = 5;
            this.btnDesconectarCOM.Text = "DESCONECTAR";
            this.btnDesconectarCOM.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDesconectarCOM.UseAccentColor = false;
            this.btnDesconectarCOM.UseVisualStyleBackColor = true;
            // 
            // cmbPorts
            // 
            this.cmbPorts.FormattingEnabled = true;
            this.cmbPorts.Location = new System.Drawing.Point(546, 13);
            this.cmbPorts.Name = "cmbPorts";
            this.cmbPorts.Size = new System.Drawing.Size(121, 24);
            this.cmbPorts.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1372, 766);
            this.Controls.Add(this.materialTabControl1);
            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = this.materialTabControl1;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(400, 246);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4, 79, 4, 4);
            this.Text = "MaterialSkin Demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.materialTabControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ImageList menuIconList;
        private TabPage tabPage1;
        private MaterialButton materialButton6;
        private MaterialLabel materialLabel53;
        private MaterialButton MaterialButton3;
        private MaterialLabel materialLabel6;
        private MaterialTabControl materialTabControl1;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private MaterialButton materialButton2;
        private MaterialButton materialButton1;
        private TextBox txtDireccion;
        private MaterialLabel materialLabel1;
        private MaterialLabel materialLabel2;
        private TextBox txtDireccionNew;
        private MaterialButton materialButton5;
        private SplitContainer splitContainer3;
        private MaterialLabel materialLabel3;
        private MaterialButton btnConectarCOM;
        private MaterialButton btnDesconectarCOM;
        private ComboBox cmbPorts;
    }
}
