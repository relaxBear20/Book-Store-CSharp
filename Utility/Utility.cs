using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;
using System.Net.Mail;

namespace prjC
{
    class Utility
    {
        public static string FormatMoney(object money)
        {
            return String.Format("{0:n0}", money);
        }

        public static void SetAllControlsFont(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Controls != null)
                {
                    SetAllControlsFont(control.Controls);
                }
                control.Font = new Font(control.Font.FontFamily, 12);
            }
        }

        public static bool IsPhone(string input)
        {
            return Regex.IsMatch(input, "^[0-9]{10}$");
        }

        public static bool IsFax(string input)
        {
            return Regex.IsMatch(input, "^[0-9]{10}$");
        }

        public static bool IsEmail(string input)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
