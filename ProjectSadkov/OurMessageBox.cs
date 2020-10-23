using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectSadkov
{
    class OurMessageBox : Window1
    {
        public string title;
        public string header;
        public string message;

        public OurMessageBox()
        {
            labelMessage.Visibility = System.Windows.Visibility.Hidden;
            title = "";
            header = "";
            message = "";
        }

        static public void Show(string title, string header, string message)
        {
            Window1 mBox = new Window1();
            mBox.CheckBoxErrorIsVisible.Visibility = Visibility.Hidden;
            mBox.Title = title;
            mBox.labelHeader.Text = header;
            mBox.labelText.Text = message;
            mBox.Show();
        }

        static public void Show(string title, string header, string message, string ex)
        {
            Window1 mBox = new Window1();
            mBox.Title = title;
            mBox.labelHeader.Text = header;
            mBox.labelText.Text = message;
            mBox.labelMessage.Text = ex;
            mBox.Show();
        }
    }
}
