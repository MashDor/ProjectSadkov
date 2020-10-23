
using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace ProjectSadkov
{
    class Email
    {
        static private MailAddress from = new MailAddress("pcs71projectdisk@mail.ru");
        static private SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
        static private NetworkCredential networkCredential = new NetworkCredential("pcs71projectdisk@mail.ru", "pcs147854@");
        static public bool sendСode(string code, string emailTo)
        {
            try
            {
                MailAddress to = new MailAddress(emailTo);
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Запрос на изменение пароля.";
                m.Body = "Код для восстановления: " + code;
                m.IsBodyHtml = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = networkCredential;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(m);
                return true;
            }
            catch (Exception e)
            {
                OurMessageBox.Show("Не удача!","Не удалось отправить код","Отсутствует соединение с интернетом или ваш почтовый сервис для уеб...", e.ToString());
                return false;
            }
        }
    }
}
