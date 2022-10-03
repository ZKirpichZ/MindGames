using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Games.Forms.Controles
{
    internal class ConnectionString
    {
        public static string ConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Games.Properties.Settings.ConnStr"].ConnectionString;
            }

        }
    }
}
