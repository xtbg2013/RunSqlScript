using System;

namespace RunSqlScript
{
    public class SqlRun
    {
        public static bool Run(string dataSource, string usrId, string pwd, string path, out string msg)
        {
            msg = "";
            const string constr = @"-S {0} -U {1} -P {2}  -i {3}";
            object[] param = { dataSource, usrId, pwd, path };
            try
            {
                var sqlProcess = new System.Diagnostics.Process
                {
                    StartInfo =
                    {
                        FileName = "osql.exe ",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                        RedirectStandardOutput = true,
                        Arguments = string.Format(constr, param)
                    }
                };
                sqlProcess.Start();
                sqlProcess.WaitForExit();
                var sr = sqlProcess.StandardOutput;
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
