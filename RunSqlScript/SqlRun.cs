using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunSqlScript
{
    public class SqlRun
    {
        public static bool Run(string dataSource, string usrId, string pwd, string path, out string msg)
        {
            msg = "";
            string constr = @"-S {0} -U {1} -P {2}  -i {3}";
            object[] param = { dataSource, usrId, pwd, path };
            try
            {
                System.Diagnostics.Process sqlProcess = new System.Diagnostics.Process();
                sqlProcess.StartInfo.FileName = "osql.exe ";
                sqlProcess.StartInfo.UseShellExecute = false;
                sqlProcess.StartInfo.CreateNoWindow = true;
                sqlProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                sqlProcess.StartInfo.RedirectStandardOutput = true;
                sqlProcess.StartInfo.Arguments = string.Format(constr, param);
                sqlProcess.Start();
                sqlProcess.WaitForExit();
                System.IO.StreamReader sr = sqlProcess.StandardOutput;
                msg = sr.ReadToEnd();
                sqlProcess.Close();

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
            return true;
        }
    }
}
