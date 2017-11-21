using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunSqlScript
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg;
            string dataSource = string.Format(@"{0}\SQLEXPRESS", System.Environment.MachineName);
            SqlRun.Run(dataSource, "sa", "cml@shg629", "BMS36.sql",out msg);
            Console.WriteLine(msg);
            Console.ReadKey();
        }
    }
}
