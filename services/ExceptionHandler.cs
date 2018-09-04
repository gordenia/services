using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace services
{
    class ExceptionHandler
    {
        public static void SqlExceptionProcess(Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
}
