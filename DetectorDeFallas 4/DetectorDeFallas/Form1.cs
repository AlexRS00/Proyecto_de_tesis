using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Threading;
using System.IO.Ports;
using Excel = Microsoft.Office.Interop.Excel;

namespace DetectorDeFallas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Boton1.Enabled = true; //habilita el boton de abrir puerto
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Envia un mensaje al iniciar al programa y dependiendo de lo que se seleccione, es lo que hará
            DialogResult resultadoprimero;
            resultadoprimero = MessageBox.Show("Conecta el microcontrolador antes de seguir.", "ADVERTENCIA", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
            if (resultadoprimero == DialogResult.Retry)
            {
                Application.Restart();
            }
            if (resultadoprimero == DialogResult.Abort)
            {
                this.Close();
            }

            //busca todos los nombres de puertos disponibles
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s); //Agrega cada nombre de puerto al comboBox
            }
            ControlBox = false; //Elimina los botones de minimizar, maximizar y cerrar
        }

        private void Boton1_Click(object sender, EventArgs e)
        {
            //Abre el puerto serial
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();                //cierra el puerto serial
                Boton1.Text = "Abrir puerto";       //cambia el texto
                TimerFailCancel.Enabled = false;             //deshabilita los timers
                TimerSwitchCancel.Enabled = false;
                TimerPassCancel.Enabled = false;
                TimerReporte.Enabled = false;
                TimerLogica.Enabled = false;
                TimerFailFail.Enabled = false;
                TimerSwitchFail.Enabled = false;
                TimerPassFail.Enabled = false;
            }
            else
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.Open();                          //abre el puerto serial
                Boton1.Text = "Puerto abierto";              //cambia el texto
                TimerLogica.Enabled = true;              //habilita el timer
                Boton1.Enabled = false;            //bloquea el boton de abrir puerto
                comboBox1.Enabled = false;         //bloquea el ComboBox
            }
        }

        //declaración de variables
        string P0, P1, P2, P3, P4, P5;                                          //Variables auxiliares para almacenar el voltaje
        double Pass, Fail, Switch, PassControl, FailControl, SwitchControl;     //Variables para la logica de las lecturas del voltaje
        double auxChart, auxMin, min;                                           //Variables para graficar los tiempos
        double totalmin, totalseg, totalhora, total, m, s, h;                   //Variables para determinar el tiempo total
        int FailCount, SwitchCount, PassCount;                                  //Variables para determinar el tiempo que dura la falla y envia al correo
        int segundos, minutos, horas;                                           //Variables para determinar el tiempo
        int x, cantidadDefallas = 0, iteraciones = 2, y = 1;                    //Variables para determinar el n# de falla actual
        int n, c;                                                               //Variables para evitar el conteo erroneo del n# de fallas
        int Tol = 2; //tolerancia de deteccion en la lampara VOLTAJE
        int libro = 1;

        //declaracion de variables para correo electronico
        const string usuario = "alex.rosales@uttn.mx";
        const string password = "Alexzael00";
        string txtDe = "alex.rosales@uttn.mx";
        string txtAsunto = "Falla de Tester en Celda 16";
        string txtPara = "alexrosales2k@outlook.com, alex.rosales@uttn.mx";

        private static void EnviarCorreo(StringBuilder Mensaje, DateTime FechaDeEnvio, string De, string Para, string Asunto, out string Error)
        {
            //Sistema de enviado de correo electronico
            Error = "";
            try
            {
                Mensaje.Append(Environment.NewLine);
                Mensaje.Append(string.Format("Este correo ha sido enviado el día {0:dd/MM/yyyy} a las {0:HH:mm:ss} Hrs: \n\n", FechaDeEnvio));
                Mensaje.Append(Environment.NewLine);
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(De);
                mail.To.Add(Para);
                mail.Subject = Asunto;
                mail.Body = Mensaje.ToString();
                SmtpClient smtp = new SmtpClient("smtp.outlook.com");
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(usuario, password);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                Error = "Correo enviado";
                MessageBox.Show(Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifique que haya internet.", "No hay conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
                return;
            }
        }

        private void TimerFailCancel_Tick(object sender, EventArgs e)
        {
            //TIMER PARA QUE NO SE ABRAN VARIOS REPORTES DE SOLUCION DEBIDO A LA LAMPARA FAIL
            for (FailCount = 0; FailCount <= 5100; FailCount++)
            {
                if (FailCount >= 5100) 
                {
                    TimerFailFail.Enabled = false;
                    TimerFailCancel.Enabled = false;
                    BotonExport.Enabled = false;
                    if (c == 0)
                    {
                        n++;
                        y++;
                        c = 1;
                    }
                }
            }
        }

        private void TimerSwitchCancel_Tick(object sender, EventArgs e)
        {
            //TIMER PARA QUE NO SE CICLE EL REPORTE DE SOLUCION, O SEA, QUE NO SE ABRAN
            //2 O MAS DEBIDO A LA LAMPARA SWITCH
            //cuenta cada segundo
            for (SwitchCount = 0; SwitchCount <= 5100; SwitchCount++)

            {
                if (SwitchCount >= 5100)
                {
                    TimerSwitchFail.Enabled = false;
                    TimerSwitchCancel.Enabled = false;
                    BotonExport.Enabled = false;
                    if (c == 0)
                    {
                        n++;
                        y++;
                        c = 1;
                    }
                }
            }
        }
        private void TimerPassCancel_Tick(object sender, EventArgs e)
        {
            //TIMER QUE HACE QUE NO SE ABRAN VARIOS REPORTES DE SOLUCION DEBIDO A LA LAMPARA
            //PASS
            //cuenta cada segundo
            for (PassCount = 0; PassCount <= 5100; PassCount++)

            {
                if (PassCount >= 5100)
                {
                    TimerPassFail.Enabled = false;
                    TimerPassCancel.Enabled = false;
                    BotonExport.Enabled = false;
                    if (c == 0)
                    {
                        n++;
                        y++;
                        c = 1;
                    }
                }
            }

        }
        private void TimerReporte_Tick(object sender, EventArgs e)
        {
            //Grafica
            int z;

            for (z = 0; z < 1; z++)
            {
                totalseg = (s / 3600);
                totalmin = (m / 60);
                totalhora = h;
                total = totalhora + totalmin + totalseg;
                label6.Text = total.ToString("0.0000");
                chartControl1.Series["Tiempos muertos"].Points.AddXY(z, total);
            }

            listBox1.Items.Add(DateTime.Now.ToShortDateString() + "  ||  " + n + ".  " + horas.ToString() + "h  " + minutos.ToString() + "m  " + segundos.ToString() + "s");
            horas = 0;
            minutos = 0;
            segundos = 0;
            m = 0;
            s = 0;
            c = 0;
            iteraciones = 2;
            label15.Text = "0h";
            label16.Text = "0m";
            label17.Text = "0s";
            SwitchCount = 0;
            PassCount = 0;
            FailCount = 0;

            Reporte_de_solución.Form1 p1 = new Reporte_de_solución.Form1();
            p1.Show();

            TimerCronometro.Enabled = false;
            TimerReporte.Enabled = false;
            BotonExport.Enabled = true;
        }

        private void TimerLogica_Tick(object sender, EventArgs e)
        {
            string ErrorPort;
            try
            {
                //LEE EL VOLTAJE QUE SE ESTA SUMINISTRANDO EN LAS ENTRADAS ANALOGICAS
                //DEL MICROCONTROLADOR, DESDE EL A0 AL A5

                serialPort1.Write("5");                         //A0 = LAMPARA PASS
                P0 = serialPort1.ReadLine();
                Pass = 5 * Convert.ToDouble(P0) / 1023;

                serialPort1.Write("4");                         //A1 = LAMPARA FAIL
                P1 = serialPort1.ReadLine();
                Fail = 5 * Convert.ToDouble(P1) / 1023;

                serialPort1.Write("3");                         //A2 = LAMPARA SWITCH
                P2 = serialPort1.ReadLine();
                Switch = 5 * Convert.ToDouble(P2) / 1023;

                serialPort1.Write("2");                         //A3 = RELEVADOR DE LA LAMPARA PASS 
                P3 = serialPort1.ReadLine();
                PassControl = 5 * Convert.ToDouble(P3) / 1023;

                serialPort1.Write("1");                         //A4 = RELEVADOR DE LA LAMPARA FAIL
                P4 = serialPort1.ReadLine();
                FailControl = 5 * Convert.ToDouble(P4) / 1023;

                serialPort1.Write("0");                         //A5 = RELEVADOR DE LA LAMPARA SWITCH
                P5 = serialPort1.ReadLine();
                SwitchControl = 5 * Convert.ToDouble(P5) / 1023;

                //DEPENDIENDO DEL RELEVADOR QUE ESTE CONTROLANDO CADA LAMPARA
                //SE SELECCIONARAN DIFERENTES CASOS

                int deteccion = x;

                if ((SwitchControl < 1 || SwitchControl > 4) & (PassControl < 1 || PassControl > 4) & (FailControl < 1 || FailControl > 4))
                {
                    x = 0;
                    label1.Text = "0.00" + "V";
                    label8.Text = "0.00" + "V";
                    label7.Text = "0.00" + "V";
                    label10.Text = "0.00" + "V";
                    label2.Text = "0.00" + "V";
                    label9.Text = "0.00" + "V";
                    BotonDeColor.BackColor = Color.Transparent;
                }

                if (SwitchControl > 1 & SwitchControl < 4)
                {
                    if (FailControl < 1 || FailControl > 4)
                    {
                       if (PassControl < 1 || PassControl > 4)
                        {
                            x = 1;
                            label2.Text = Switch.ToString("0.00" + "V");
                            label9.Text = SwitchControl.ToString("0.00" + "V");
                            label1.Text = "0.00" + "V";
                            label8.Text = "0.00" + "V";
                            label7.Text = "0.00" + "V";
                            label10.Text = "0.00" + "V";
                            BotonDeColor.BackColor = Color.Yellow;  //cambia el color
                        }
                    }
                }
                if (SwitchControl < 1 || SwitchControl > 4)
                {
                    if (FailControl < 1 || FailControl > 4)
                    {
                        if (PassControl > 1 & PassControl < 4)
                        {
                            x = 2;
                            label1.Text = Pass.ToString("0.00" + "V");
                            label8.Text = PassControl.ToString("0.00" + "V");
                            label7.Text = "0.00" + "V";
                            label10.Text = "0.00" + "V";
                            label2.Text = "0.00" + "V";
                            label9.Text = "0.00" + "V";
                            BotonDeColor.BackColor = Color.Lime;  //cambia el color
                        }
                    }
                }
                if (SwitchControl < 1 || SwitchControl > 4)
                {
                    if (PassControl < 1 || PassControl > 4)
                    {
                        if (FailControl > 1 & FailControl < 4)
                        {
                            x = 3;
                            label7.Text = Fail.ToString("0.00" + "V");
                            label10.Text = FailControl.ToString("0.00" + "V");
                            label2.Text = "0.00" + "V";
                            label9.Text = "0.00" + "V";
                            label1.Text = "0.00" + "V";
                            label8.Text = "0.00" + "V";
                            BotonDeColor.BackColor = Color.Red;  //cambia el color
                        }
                    }
                }

                if (SwitchControl > 1 & SwitchControl < 4)
                {
                    if (PassControl > 1 & PassControl < 4)
                    {
                        if (FailControl < 1 || FailControl > 4)
                        {
                            x = 0;
                            label1.Text = Pass.ToString("0.00" + "V");
                            label8.Text = PassControl.ToString("0.00" + "V");
                            label2.Text = Switch.ToString("0.00" + "V");
                            label9.Text = SwitchControl.ToString("0.00" + "V");
                            label7.Text = "0.00" + "V";
                            label10.Text = "0.00" + "V";
                            BotonDeColor.BackColor = Color.YellowGreen;  //cambia el color
                        }
                    }
                }

                if (SwitchControl > 1 & SwitchControl < 4)
                {
                    if (PassControl < 1 || PassControl > 4)
                    {
                        if (FailControl > 1 & FailControl < 4)
                        {
                            x = 0;
                            label2.Text = Switch.ToString("0.00" + "V");
                            label9.Text = SwitchControl.ToString("0.00" + "V");
                            label7.Text = Fail.ToString("0.00" + "V");
                            label10.Text = FailControl.ToString("0.00" + "V");
                            label1.Text = "0.00" + "V";
                            label8.Text = "0.00" + "V";
                            BotonDeColor.BackColor = Color.Orange;  //cambia el color
                        }
                    }
                }

                if (SwitchControl < 1 || SwitchControl > 4)
                {
                    if (PassControl > 1 & PassControl < 4)
                    {
                        if (FailControl > 1 & FailControl < 4)
                        {
                            x = 0;
                            label1.Text = Pass.ToString("0.00" + "V");
                            label8.Text = PassControl.ToString("0.00" + "V");
                            label7.Text = Fail.ToString("0.00" + "V");
                            label10.Text = FailControl.ToString("0.00" + "V");
                            label2.Text = "0.00" + "V";
                            label9.Text = "0.00" + "V";
                            BotonDeColor.BackColor = Color.OrangeRed;  //cambia el color
                        }
                    }
                }

                if (SwitchControl > 1 & SwitchControl < 4)
                {
                    if (PassControl > 1 & PassControl < 4)
                    {
                        if (FailControl > 1 & FailControl < 4)
                        {
                            x = 7;
                            label1.Text = Pass.ToString("0.00" + "V");
                            label8.Text = PassControl.ToString("0.00" + "V");
                            label2.Text = Switch.ToString("0.00" + "V");
                            label9.Text = SwitchControl.ToString("0.00" + "V");
                            label7.Text = Fail.ToString("0.00" + "V");
                            label10.Text = FailControl.ToString("0.00" + "V");
                            BotonDeColor.BackColor = Color.Black;  //cambia el color
                        }
                    }
                }
                //


                label6.Text = TimerPassFail.Enabled.ToString(); //MUESTRA EL CASE ACTUAL
                label18.Text = TimerSwitchFail.Enabled.ToString();
                label19.Text = TimerFailFail.Enabled.ToString();
                label22.Text = x.ToString();
                label23.Text = TimerReporte.Enabled.ToString();

                //SI EL RELEVADOR QUE CONTROLA A LA LAMPARA, ESTA ENERGIZADO, REALIZA LOS
                //SIGUIENTES CASOS

                switch (deteccion)
                {
                    case 0:
                        //SI NO HAY NINGUN CONTROL ACTIVO, NO HACE NADA
                        TimerFailCancel.Enabled = false;
                        TimerSwitchCancel.Enabled = false;
                        TimerPassCancel.Enabled = false;
                        TimerSwitchFail.Enabled = false;
                        TimerFailFail.Enabled = false;
                        TimerPassFail.Enabled = false;
                        break;

                    case 1: //LAMPARA SWITCH
                        if (Switch > Tol)
                        {
                            //NO HAY FALLA
                            TimerSwitchCancel.Enabled = false;
                            TimerSwitchFail.Enabled = false;

                        }
                        if (Switch < Tol)
                        {
                            //FALLA
                            TimerSwitchCancel.Enabled = true;
                            TimerSwitchFail.Enabled = true;

                            if (SwitchCount >= 5100)
                            {
                                TimerSwitchCancel.Enabled = false;
                                TimerSwitchFail.Enabled = false;
                                TimerCronometro.Enabled = true;//timer para saber el tiempo que lleva
                                                               //caido el equipo
                            }
                        }
                        break;

                    case 2: //LAMPARA PASS
                        if (Pass > Tol)
                        {
                            //NO HAY FALLA
                            TimerPassCancel.Enabled = false;
                            TimerPassFail.Enabled = false;
                        }
                        if (Pass < Tol)
                        {
                            //FALLA
                            TimerPassCancel.Enabled = true;
                            TimerPassFail.Enabled = true;

                            if (PassCount >= 5100)
                            {
                                TimerPassCancel.Enabled = false;
                                TimerPassFail.Enabled = false;
                                TimerCronometro.Enabled = true;//timer para saber el tiempo que lleva
                                                               //caido el equipo
                            }
                        }
                            break;

                    case 3: //LAMPARA FAIL
                        if (Fail > Tol)
                        {
                            //NO HAY FALLA
                            TimerFailCancel.Enabled = false;
                            TimerFailFail.Enabled = false;
                        }
                        if (Fail < Tol)
                        {
                            //FALLA
                            TimerFailCancel.Enabled = true;
                            TimerFailFail.Enabled = true;

                            if (FailCount >= 5100)
                            {
                                TimerFailCancel.Enabled = false;
                                TimerFailFail.Enabled = false;
                                TimerCronometro.Enabled = true;//timer para saber el tiempo que lleva
                                                               //caido el equipo
                            }
                        }
                        break;

                    //EL CASE 4 AL 7 SON CASOS EN LOS QUE EL TECNICO O ING ENCIENDE DE MANERA
                    //MANUAL LAS LAMPARAS DESDE EL PROGRAMA T7 DE LA TESTER
                    //ACTUALMENTE NO SE ENCUENTRA EN FUNCIONAMIENTO, YA QUE, SOLO DETECTA FALLAS DE LAMPARAS 1 A LA VEZ, NO 2 O 3 AL MISMO TIEMPO
                    //CASO 4 AL 6 NO SE ENCUENTRA FUNCIONANDO

                    //case 4: //LAMPARA SWITCH Y PASS
                    //    if (Switch > Tol & Pass > Tol)
                    //    {
                    //        //NO HAY FALLA
                    //        TimerSwitchCancel.Enabled = false;
                    //        TimerPassCancel.Enabled = false;
                    //        TimerSwitchFail.Enabled = false;
                    //        TimerPassFail.Enabled = false;
                    //    }
                    //    if (Switch < Tol & Pass < Tol)
                    //    {
                    //        //FALLA
                    //        TimerSwitchCancel.Enabled = true;
                    //        TimerSwitchFail.Enabled = true;
                    //        TimerPassCancel.Enabled = true;
                    //        TimerPassFail.Enabled = true;

                    //        if (SwitchCount >= 5100)
                    //        {
                    //            TimerSwitchCancel.Enabled = false;
                    //            TimerSwitchFail.Enabled = false;
                    //            TimerCronometro.Enabled = true;//timer para saber el tiempo que lleva
                    //                                           //caido el equipo
                    //        }
                    //        if (PassCount >= 5100)
                    //        {
                    //            TimerPassFail.Enabled = false;
                    //            TimerPassCancel.Enabled = false;
                    //            TimerCronometro.Enabled = true;//timer para saber el tiempo que lleva
                    //        }
                    //    }
                    //    break;


                    ////CASE 5
                    //case 5: //LAMPARA SWITCH Y FAIL
                    //    if (Switch > Tol & Fail > Tol)
                    //    {
                    //        //NO HAY FALLA
                    //        TimerSwitchCancel.Enabled = false;
                    //        TimerFailCancel.Enabled = false;
                    //        TimerSwitchFail.Enabled = false;
                    //        TimerFailFail.Enabled = false;
                    //    }
                    //    if (Switch < Tol & Fail < Tol)
                    //    {
                    //        //FALLA
                    //        TimerSwitchCancel.Enabled = true;
                    //        TimerSwitchFail.Enabled = true;
                    //        TimerFailCancel.Enabled = true;
                    //        TimerFailFail.Enabled = true;

                    //        if (SwitchCount >= 5100)
                    //        {
                    //            TimerSwitchCancel.Enabled = false;
                    //            TimerSwitchFail.Enabled = false;
                    //            TimerCronometro.Enabled = true;//timer para saber el tiempo que lleva
                    //                                           //caido el equipo
                    //        }
                    //        if (FailCount >= 5100)
                    //        {
                    //            TimerFailFail.Enabled = false;
                    //            TimerFailCancel.Enabled = false;
                    //            TimerCronometro.Enabled = true;//timer para saber el tiempo que lleva
                    //                                           //caido el equipo
                    //        }
                    //    }
                    //    break;

                    ////CASE 6
                    //case 6: //LAMPARA PASS Y FAIL
                    //    if (Pass > Tol & Fail > Tol)
                    //    {
                    //        //NO HAY FALLA
                    //        TimerPassCancel.Enabled = false;
                    //        TimerFailCancel.Enabled = false;
                    //        TimerPassFail.Enabled = false;
                    //        TimerFailFail.Enabled = false;
                    //    }
                    //    if (Pass < Tol & Fail < Tol)
                    //    {
                    //        //FALLA
                    //        TimerPassCancel.Enabled = true;
                    //        TimerPassFail.Enabled = true;
                    //        TimerFailCancel.Enabled = true;
                    //        TimerFailFail.Enabled = true;

                    //        if (PassCount >= 5100)
                    //        {
                    //            TimerPassCancel.Enabled = false;
                    //            TimerPassFail.Enabled = false;
                    //            TimerCronometro.Enabled = true;//timer para saber el tiempo que lleva
                    //                                           //caido el equipo
                    //        }
                    //        if (FailCount >= 5100)
                    //        {
                    //            TimerFailFail.Enabled = false;
                    //            TimerFailCancel.Enabled = false;
                    //            TimerCronometro.Enabled = true;//timer para saber el tiempo que lleva
                    //                                           //caido el equipo
                    //        }
                    //    }
                    //    break;

                    //CASE CUANDO TODO ESTA ENCENDIDO, MUESTRA EL REPORTE DE SOLUCION
                    case 7: //LAMPARA PASS Y FAIL
                        if (Pass > Tol & Fail > Tol & Switch > Tol)
                        {
                            //NO HAY FALLA
                            TimerPassCancel.Enabled = false;
                            TimerFailCancel.Enabled = false;
                            TimerPassFail.Enabled = false;
                            TimerFailFail.Enabled = false;
                            TimerSwitchCancel.Enabled = false;
                            TimerSwitchFail.Enabled = false;


                            if (SwitchCount >= 5100 || PassCount >= 5100 || FailCount >= 5100)
                            {
                                TimerReporte.Enabled = true;
                            }

                        }
                        if (Pass < Tol || Fail < Tol || Switch < Tol)
                        {
                            TimerReporte.Enabled = false;
                        }
                        break;

                    default:
                        //no pasa nada
                        break;
                }

            }
            catch (Exception Error)
            {
                ErrorPort = "Error: " + Error.Message;
                return;
            }

        }

        private void TimerFailFail_Tick_1(object sender, EventArgs e)
        {
            //ENVIA CORREO DE LAMPARA FAIL
            string Error = "";
            StringBuilder MensajeBuilder = new StringBuilder();
            MensajeBuilder.Append("Falla en lampara Fail, celda 16".Trim());
            EnviarCorreo(MensajeBuilder, DateTime.Now, txtDe.Trim(), txtPara.Trim(), txtAsunto.Trim(), out Error);
        }
        private void TimerSwitchFail_Tick(object sender, EventArgs e)
        {
            //ENVIA CORREO DE LAMPARA SWITCH
            string Error = "";
            StringBuilder MensajeBuilder = new StringBuilder();
            MensajeBuilder.Append("Falla en lampara Switch, celda 16".Trim());
            EnviarCorreo(MensajeBuilder, DateTime.Now, txtDe.Trim(), txtPara.Trim(), txtAsunto.Trim(), out Error);
        }

        private void TimerPassFail_Tick(object sender, EventArgs e)
        {
            //ENVIA CORREO DE LAMPARA PASS
            string Error = "";
            StringBuilder MensajeBuilder = new StringBuilder();
            MensajeBuilder.Append("Falla en lampara Pass, celda 16".Trim());
            EnviarCorreo(MensajeBuilder, DateTime.Now, txtDe.Trim(), txtPara.Trim(), txtAsunto.Trim(), out Error);
        }


        private void BotonExport_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                //Excel.Range formatRange;
                //formatRange = xlWorkSheet.get_Range("L1", "L" + y.ToString()); 
                //formatRange.NumberFormat = "hh:mm:ss";

                //cambia el heading
                xlWorkSheet.Cells[1, 1] = "Fecha de exportación";
                xlWorkSheet.Cells[2, 1] = DateTime.Now.ToShortDateString();
                xlWorkSheet.Cells[1, 4] = "N# de falla";
                //xlWorkSheet.Cells[1, 6] = "Tiempo muerto (decimal)";
                xlWorkSheet.Cells[1, 7] = "Tiempo muerto (minutos)";
                //xlWorkSheet.Cells[1, 12] = "Tiempo muerto (convertir a tiempo)";

                for (int i = 0; i < chartControl1.Series.Count; i++)
                {
                    for (int j = 0; j < chartControl1.Series[i].Points.Count; j++)
                    {
                        //xlWorkSheet.Cells[j + 2, 6] = chartControl1.Series[i].Points[j].YValues[0].ToString("0.0000");
                        auxChart = chartControl1.Series[i].Points[j].YValues[0];
                        //xlWorkSheet.Cells[j + 2, 12] = "=" + "F" + iteraciones.ToString() + "/" + "24";

                        if (auxChart >= 0)
                        {
                            cantidadDefallas++;
                            iteraciones++;
                            xlWorkSheet.Cells[j + 2, 4] = cantidadDefallas.ToString();
                        }

                        if (auxChart >= 0.0166667) //esto equivale a 60 segundos, 1 minuto
                        {
                            auxMin = auxChart * 60; //multiplica el valor decimal por 60, se obtienen los minutos
                        }

                        min = Convert.ToInt32(auxMin);

                        xlWorkSheet.Cells[j + 2, 7] = min.ToString(); //9
                        xlWorkSheet.Cells[j + 2, 8] = "min";          //10
                    }
                }

                //Excel.Range chartRange;

                //Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                //Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
                //Excel.Chart chartPage = myChart.Chart;

                //chartRange = xlWorkSheet.get_Range("F1", "F" + y.ToString());//update the range here
                //chartPage.SetSourceData(chartRange, misValue);
                //chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
                //
                Excel.Range chartRange2;

                Excel.ChartObjects xlCharts2 = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                Excel.ChartObject myChart2 = (Excel.ChartObject)xlCharts2.Add(350, 80, 300, 250);
                Excel.Chart chartPage2 = myChart2.Chart;

                chartRange2 = xlWorkSheet.get_Range("G1", "G" + y.ToString());//update the range here
                chartPage2.SetSourceData(chartRange2, misValue);
                chartPage2.ChartType = Excel.XlChartType.xlColumnClustered;
                //
                //Excel.Range chartRange3;

                //Excel.ChartObjects xlCharts3 = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                //Excel.ChartObject myChart3 = (Excel.ChartObject)xlCharts3.Add(700, 80, 300, 250);
                //Excel.Chart chartPage3 = myChart3.Chart;

                //chartRange3 = xlWorkSheet.get_Range("L1", "L" + y.ToString());//update the range here
                //chartPage3.SetSourceData(chartRange3, misValue);
                //chartPage3.ChartType = Excel.XlChartType.xlColumnClustered;

                xlWorkBook.SaveAs("Reporte " + libro.ToString());
                xlWorkBook.Close();
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                button3.Enabled = false;
                libro++;
                cantidadDefallas = 0;
                iteraciones = 2;
                MessageBox.Show("Puedes encontrarlo en Mis archivos >> Documentos >> Reporte #", "Archivo de Excel ha sido creado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                cantidadDefallas = 0;
                iteraciones = 2;
                libro = 1;
                MessageBox.Show("No fue posible exportar a Excel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error mientras liberaba objecto " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        string a;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult Reporte;
            Reporte = MessageBox.Show("¿Estás seguro de que ese es el número de reporte?", "Número de reporte", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Reporte == DialogResult.Yes)
            {
               // label24.Text = comboBox2.SelectedItem.ToString();
                a = comboBox2.SelectedItem.ToString();
                libro = Convert.ToInt32(a);
            }
        }

        int report;
        private void NumReporte_Tick(object sender, EventArgs e)
        {
            for (report = 0; report <= 200; report++)
            {
                comboBox2.Items.Add(report);
                if (report == 200)
                {
                    NumReporte.Enabled = false;
                }
            }
        }

        private void TimerCronometro_Tick(object sender, EventArgs e)
        {
            if (s == 60)
            {
                m++;
            }
            if (segundos == 60)
            {
                minutos++;
                label16.Text = minutos.ToString() + "m";
                segundos = 0;
                s = 0;

                if (minutos == 60)
                {
                    minutos = 0;
                    label16.Text = "0m";
                    horas++;
                    label15.Text = horas.ToString() + "h";
                }
            }
            label17.Text = segundos.ToString() + "s";
            segundos++;
            s++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Conectar el microcontrolador por puerto serial, seleccionar puerto y posteriormente, presionar el boton de ABRIR PUERTO.", "¿Cómo iniciar?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show("Si el programa presenta errores, favor de reiniciarlo con el boton de REINICIAR, tienes que estar dado de alta en el código para poder realizar esta acción.", "Reiniciar programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("No sobreescribir los archivos de Excel", "No sobreescribir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Boton2_Click(object sender, EventArgs e)
        {
            Inicio_de_sesión.Form1 p2 = new Inicio_de_sesión.Form1();
            p2.Show();
        }

        private void BotonExit_Click(object sender, EventArgs e)
        {
            //declaracion de variables
            DialogResult resultado;      //variable para almacenar el valor regresado por messagebox

            resultado = MessageBox.Show("¿Estás seguro que deseas salir?", "¿SALIR?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)   //verifica si se presionó el boton OK
                this.Close();                   //cierra el forms1 (this)
        }

        private void label6_Click(object sender, EventArgs e)
        {
            //le piqué por error 
        }
    }
}

