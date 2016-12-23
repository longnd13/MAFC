using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Prj.Utilities
{
   public class Logger
    {
        public static void ErrorLog(string forderName, string functionName, string message)
        {
            string vFolderName = System.Web.HttpContext.Current.Server.MapPath("/Logs/Error/") + forderName + "\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString("00");
            string vFileName = vFolderName + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + ".txt";
            System.IO.StreamWriter objStreamWriter = null;
            string vStringLog = System.DateTime.Now.ToString() + " : " + functionName;
            try
            {
                if (!System.IO.Directory.Exists(vFolderName))
                {
                    System.IO.Directory.CreateDirectory(vFolderName);
                }

                if (!System.IO.File.Exists(vFileName))
                {
                    System.IO.StreamWriter objFile = System.IO.File.CreateText(vFileName);
                    objFile.Close();
                }

                if (!string.IsNullOrEmpty(message))
                {
                    vStringLog += ", " + message;
                }
                objStreamWriter = System.IO.File.AppendText(vFileName);
                objStreamWriter.WriteLine(vStringLog);
                objStreamWriter.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                objStreamWriter.Close();
            }
        }
        //public static void InfoLog(string FuctionName, string message)
        //{
        //    string vFolderName = System.Web.HttpContext.Current.Server.MapPath("/Logs/") + "Error" + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + "\\" + FuctionName;
        //    string vFileName = vFolderName + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + ".txt";
        //    var log = new LoggerConfiguration()
        //        .WriteTo.RollingFile(vFileName)
        //        .CreateLogger();
        //    log.Information(message);
        //}
        //public static void ErrorLog(string FuctionName, string message)
        //{
        //    string vFolderName = System.Web.HttpContext.Current.Server.MapPath("/Logs/") + "Error" + "\\" +  DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + "\\" + FuctionName;
        //    string vFileName = vFolderName + "\\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + ".txt";
        //    var log = new LoggerConfiguration()
        //        .WriteTo.RollingFile(vFileName)
        //        .CreateLogger();
        //    log.Error(message);
        //}
    }
}
