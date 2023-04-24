using System.Net.Mail;
using System.Net;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using Org.BouncyCastle.Security;
using System.Data.SqlClient;
using System.Reflection;

namespace TaskTracking.Models
{
    public class VerifyMail
    {
        private readonly string connectionString = "Server=104.247.162.242\\MSSQLSERVER2017;Database=akadem58_tadimrehberi;User Id=akadem58_tr;Password=8C4ra!n07;TrustServerCertificate=True";

        public bool SendMail(string Mail, string code)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("Tasktracking@gmail.com");
                    mail.To.Add(Mail);
                    mail.Subject = "Task Tracking Service";
                    mail.Body = code;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp-relay.sendinblue.com"))
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Host = "smtp-relay.sendinblue.com";
                        smtp.Port = 587;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("zachary.chrus07@gmail.com", "NKI8s6cnkbwW30MS");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public string getCode(string Email)
        {


            string code;



            Random rnd = new Random();
            code = "";

            for (int i = 0; i < 6; i++)
            {
                char tmp = Convert.ToChar(rnd.Next(48, 58));
                code += tmp;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("Update Users Set  mail_code = @Mail_code where email = @Email ", connection);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Mail_code", code);
                var reader = command.ExecuteReader();

                return code;
            }
        }
    }
}
