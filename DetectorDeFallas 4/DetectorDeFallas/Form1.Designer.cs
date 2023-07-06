
namespace DetectorDeFallas
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BotonDeColor = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.TimerFailCancel = new System.Windows.Forms.Timer(this.components);
            this.TimerSwitchCancel = new System.Windows.Forms.Timer(this.components);
            this.TimerPassCancel = new System.Windows.Forms.Timer(this.components);
            this.BotonExit = new System.Windows.Forms.Button();
            this.TimerLogica = new System.Windows.Forms.Timer(this.components);
            this.TimerFailFail = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.TimerSwitchFail = new System.Windows.Forms.Timer(this.components);
            this.TimerPassFail = new System.Windows.Forms.Timer(this.components);
            this.TimerReporte = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.BotonExport = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Boton2 = new System.Windows.Forms.Button();
            this.Boton1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.TimerCronometro = new System.Windows.Forms.Timer(this.components);
            this.chartControl1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.NumReporte = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 148);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(271, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Selecciona el puerto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 37);
            this.label4.TabIndex = 6;
            this.label4.Text = "Verificando...";
            // 
            // BotonDeColor
            // 
            this.BotonDeColor.BackColor = System.Drawing.Color.Transparent;
            this.BotonDeColor.Location = new System.Drawing.Point(229, 140);
            this.BotonDeColor.Name = "BotonDeColor";
            this.BotonDeColor.Size = new System.Drawing.Size(66, 56);
            this.BotonDeColor.TabIndex = 7;
            this.BotonDeColor.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(116, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(535, 40);
            this.label5.TabIndex = 8;
            this.label5.Text = "Detector de fallas en lámparas";
            // 
            // TimerFailCancel
            // 
            this.TimerFailCancel.Interval = 5100;
            this.TimerFailCancel.Tick += new System.EventHandler(this.TimerFailCancel_Tick);
            // 
            // TimerSwitchCancel
            // 
            this.TimerSwitchCancel.Interval = 5100;
            this.TimerSwitchCancel.Tick += new System.EventHandler(this.TimerSwitchCancel_Tick);
            // 
            // TimerPassCancel
            // 
            this.TimerPassCancel.Interval = 5100;
            this.TimerPassCancel.Tick += new System.EventHandler(this.TimerPassCancel_Tick);
            // 
            // BotonExit
            // 
            this.BotonExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BotonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonExit.Location = new System.Drawing.Point(513, 345);
            this.BotonExit.Name = "BotonExit";
            this.BotonExit.Size = new System.Drawing.Size(235, 69);
            this.BotonExit.TabIndex = 9;
            this.BotonExit.Text = "Salir del programa";
            this.BotonExit.UseVisualStyleBackColor = false;
            this.BotonExit.Click += new System.EventHandler(this.BotonExit_Click);
            // 
            // TimerLogica
            // 
            this.TimerLogica.Tick += new System.EventHandler(this.TimerLogica_Tick);
            // 
            // TimerFailFail
            // 
            this.TimerFailFail.Interval = 5000;
            this.TimerFailFail.Tick += new System.EventHandler(this.TimerFailFail_Tick_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(63, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "label6";
            this.label6.Visible = false;
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // TimerSwitchFail
            // 
            this.TimerSwitchFail.Interval = 5000;
            this.TimerSwitchFail.Tick += new System.EventHandler(this.TimerSwitchFail_Tick);
            // 
            // TimerPassFail
            // 
            this.TimerPassFail.Interval = 5000;
            this.TimerPassFail.Tick += new System.EventHandler(this.TimerPassFail_Tick);
            // 
            // TimerReporte
            // 
            this.TimerReporte.Interval = 5000;
            this.TimerReporte.Tick += new System.EventHandler(this.TimerReporte_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Location = new System.Drawing.Point(7, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 40);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "0.00V";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Yellow;
            this.button2.Location = new System.Drawing.Point(11, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 40);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "0.00V";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(10, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 40);
            this.button3.TabIndex = 15;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(66, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "0.00V";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(84, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "0.00V";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(85, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "0.00V";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(84, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 25);
            this.label10.TabIndex = 19;
            this.label10.Text = "0.00V";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-6, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 63);
            this.panel1.TabIndex = 20;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.BackgroundImage = global::DetectorDeFallas.Properties.Resources.logo_de_emerson_4k;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(663, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(120, 63);
            this.panel5.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.BackgroundImage = global::DetectorDeFallas.Properties.Resources.logo_de_emerson_4k;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(3, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(117, 63);
            this.panel4.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.BotonDeColor);
            this.panel2.Controls.Add(this.BotonExport);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.Boton2);
            this.panel2.Controls.Add(this.Boton1);
            this.panel2.Location = new System.Drawing.Point(-6, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 256);
            this.panel2.TabIndex = 21;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(160, 186);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 20);
            this.label24.TabIndex = 22;
            this.label24.Text = "label24";
            this.label24.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(230, 210);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(65, 28);
            this.comboBox2.TabIndex = 21;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(84, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 20);
            this.label23.TabIndex = 20;
            this.label23.Text = "label23";
            this.label23.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(71, 186);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 20);
            this.label22.TabIndex = 19;
            this.label22.Text = "label22";
            this.label22.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(692, 83);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 20);
            this.label21.TabIndex = 18;
            this.label21.Text = "label21";
            this.label21.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(692, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 20);
            this.label20.TabIndex = 17;
            this.label20.Text = "label20";
            this.label20.Visible = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(539, 109);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(215, 60);
            this.button4.TabIndex = 16;
            this.button4.Text = "Instrucciones";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BotonExport
            // 
            this.BotonExport.Enabled = false;
            this.BotonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonExport.Location = new System.Drawing.Point(306, 175);
            this.BotonExport.Name = "BotonExport";
            this.BotonExport.Size = new System.Drawing.Size(215, 75);
            this.BotonExport.TabIndex = 15;
            this.BotonExport.Text = "Exportar a excel";
            this.BotonExport.UseVisualStyleBackColor = true;
            this.BotonExport.Click += new System.EventHandler(this.BotonExport_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(160, 216);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 22);
            this.label17.TabIndex = 14;
            this.label17.Text = "0s";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(89, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 22);
            this.label16.TabIndex = 13;
            this.label16.Text = "0m";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(24, 216);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 22);
            this.label15.TabIndex = 12;
            this.label15.Text = "0h";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(435, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(163, 22);
            this.label14.TabIndex = 11;
            this.label14.Text = "Tiempos muertos";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(334, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(351, 64);
            this.listBox1.TabIndex = 3;
            // 
            // Boton2
            // 
            this.Boton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boton2.Location = new System.Drawing.Point(539, 175);
            this.Boton2.Name = "Boton2";
            this.Boton2.Size = new System.Drawing.Size(215, 75);
            this.Boton2.TabIndex = 2;
            this.Boton2.Text = "Reiniciar";
            this.Boton2.UseVisualStyleBackColor = true;
            this.Boton2.Click += new System.EventHandler(this.Boton2_Click);
            // 
            // Boton1
            // 
            this.Boton1.Enabled = false;
            this.Boton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boton1.ForeColor = System.Drawing.Color.Black;
            this.Boton1.Location = new System.Drawing.Point(306, 109);
            this.Boton1.Name = "Boton1";
            this.Boton1.Size = new System.Drawing.Size(215, 60);
            this.Boton1.TabIndex = 1;
            this.Boton1.Text = "Abrir puerto";
            this.Boton1.UseVisualStyleBackColor = true;
            this.Boton1.Click += new System.EventHandler(this.Boton1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 22);
            this.label11.TabIndex = 22;
            this.label11.Text = "Control";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 22);
            this.label12.TabIndex = 23;
            this.label12.Text = "Control";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 22);
            this.label13.TabIndex = 24;
            this.label13.Text = "Control";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.button1);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(-2, 316);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(160, 135);
            this.panel6.TabIndex = 25;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel7.Controls.Add(this.label18);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.button2);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Location = new System.Drawing.Point(158, 316);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(160, 132);
            this.panel7.TabIndex = 26;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(54, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 20);
            this.label18.TabIndex = 24;
            this.label18.Text = "label18";
            this.label18.Visible = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel8.Controls.Add(this.label19);
            this.panel8.Controls.Add(this.button3);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Controls.Add(this.label13);
            this.panel8.Location = new System.Drawing.Point(318, 316);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(170, 132);
            this.panel8.TabIndex = 27;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(54, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 20);
            this.label19.TabIndex = 25;
            this.label19.Text = "label19";
            this.label19.Visible = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel9.Location = new System.Drawing.Point(487, 316);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(297, 129);
            this.panel9.TabIndex = 28;
            // 
            // TimerCronometro
            // 
            this.TimerCronometro.Interval = 1;
            this.TimerCronometro.Tick += new System.EventHandler(this.TimerCronometro_Tick);
            // 
            // chartControl1
            // 
            chartArea4.Name = "ChartArea1";
            this.chartControl1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartControl1.Legends.Add(legend4);
            this.chartControl1.Location = new System.Drawing.Point(780, 67);
            this.chartControl1.Name = "chartControl1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Tiempos muertos";
            this.chartControl1.Series.Add(series4);
            this.chartControl1.Size = new System.Drawing.Size(300, 300);
            this.chartControl1.TabIndex = 29;
            this.chartControl1.Text = "chart1";
            // 
            // NumReporte
            // 
            this.NumReporte.Enabled = true;
            this.NumReporte.Tick += new System.EventHandler(this.NumReporte_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(778, 444);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.BotonExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detector de fallas en lámparas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BotonDeColor;
        private System.Windows.Forms.Label label5;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer TimerFailCancel;
        private System.Windows.Forms.Timer TimerSwitchCancel;
        private System.Windows.Forms.Timer TimerPassCancel;
        private System.Windows.Forms.Button BotonExit;
        private System.Windows.Forms.Timer TimerLogica;
        private System.Windows.Forms.Timer TimerFailFail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer TimerSwitchFail;
        private System.Windows.Forms.Timer TimerPassFail;
        private System.Windows.Forms.Timer TimerReporte;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Timer TimerCronometro;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button Boton2;
        private System.Windows.Forms.Button Boton1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartControl1;
        private System.Windows.Forms.Button BotonExport;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button BotonPuertos;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Timer NumReporte;
    }
}

