using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace math_game
{
    public class errorHandler
    {
        /// <summary>
        /// Adds the thrown exception to error_log text file 
        /// </summary>
        /// <param name="sClass"> The class that the exception occurred</param>
        /// <param name="sMethod">The method where the exception occurred</param>
        /// <param name="sMessage">The exception  that occurred</param>
        public void logError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                System.IO.File.AppendAllText("error_log.txt", Environment.NewLine + "Class: " + sClass + " Method: " + sMethod + " Message: " + sMessage + DateTime.Now.ToString());
                MessageBox.Show("An error occurred please contact IT.  Thank you", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("logError_log.txt", Environment.NewLine + "Class: " + sClass + " Method: " + sMethod + " Message: " + ex + DateTime.Now.ToString());
                MessageBox.Show("An error occurred please contact IT.  Thank you", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
         
        }

    }
}
