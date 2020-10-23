using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Threading;

namespace ProjectSadkov
{
    class Code
    {
        public string codeString;
        public string codeTimerString = "00:00";

        public Code()
        {
            this.codeString = "";
            string[] liters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            Random rnd = new Random();
            for (int i = 0; i < 4; i = i + 1) this.codeString += liters[rnd.Next(0, 10)];
        }

        public bool sendCode(string contact)
        {
            if (Validation.validationEmail(contact).Length != 0)
            {
                SqlMaster sqlMaster = new SqlMaster();
                User user = sqlMaster.getUser("login", contact);
                return Email.sendСode(this.codeString, user.email);
            }
            else return Email.sendСode(this.codeString, contact);
        }
    }
}
