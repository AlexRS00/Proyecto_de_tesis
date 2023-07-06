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

namespace Reporte_de_solución
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const string usuario = "alex.rosales@uttn.mx";
        const string password = "Alexzael00";
        string txtDe = "alex.rosales@uttn.mx";
        string txtAsunto = "Tester reparada en celda 16";
        string txtPara = "alexrosales2k@outlook.com, alex.rosales@uttn.mx";

        private static void EnviarCorreo(StringBuilder Mensaje, DateTime FechaDeEnvio, string De, string Para, string Asunto, out string Error)
        {
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
                Error = "Reporte enviado";
                MessageBox.Show(Error);
            }


            catch (Exception ex)
            {
                MessageBox.Show("Verifique que haya internet.", "No hay conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
                return;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNumEmp.Enabled = true;
        }

        private void txtNumEmp_TextChanged(object sender, EventArgs e)
        {
            txtFalla.Enabled = true;
        }

        private void txtFalla_TextChanged(object sender, EventArgs e)
        {
            txtReparar.Enabled = true;
        }

        private void txtReparar_TextChanged_1(object sender, EventArgs e)
        {
            txtObserv.Enabled = true;
        }
        private void txtObserv_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Error = "";
            StringBuilder MensajeBuilder = new StringBuilder();

            MensajeBuilder.AppendLine("NOMBRE: " + txtNombre.Text.Trim());
            MensajeBuilder.AppendLine("NÚMERO DE EMPLEADO: " + txtNumEmp.Text.Trim());
            MensajeBuilder.AppendLine("¿CUÁL FUE LA FALLA? " + txtFalla.Text.Trim());
            MensajeBuilder.AppendLine("¿CÓMO FUE REPARADA? " + txtReparar.Text.Trim());
            MensajeBuilder.AppendLine("OBSERVACIONES: " + txtObserv.Text.Trim());
            EnviarCorreo(MensajeBuilder, DateTime.Now, txtDe.Trim(), txtPara.Trim(), txtAsunto.Trim(), out Error);
            Close();
        }
    }
}
