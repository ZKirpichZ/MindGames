using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games.Forms;

namespace Games
{
    internal class RJMessageBox
    {
        public static DialogResult Show(string text, string caption)
        {
            DialogResult result;
            using (var msgForm = new info(text, caption))
                result = msgForm.ShowDialog();
            return result;
        }
    }
}
