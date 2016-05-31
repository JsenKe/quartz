using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace QuartzWinService
{
    /// <summary>
    ///简单写日志类
    /// </summary>
    public class LogHelp
    {
        /// <summary>
        ///  日志写入
        /// </summary>
        /// <param name="log">日志内容</param>
        /// <param name="strmenu">日志文件名</param>
        public static void SysLog(string log, string strmenu)
        {
            SysLog(log, null, strmenu);
        }
        /// <summary>
        /// 错误日志写入
        /// </summary>
        /// <param name="log">日志内容</param>
        /// <param name="ex">错误串</param>
        /// <param name="strmenu">日志文件名</param>
        public static void SysLog(string log, Exception ex, string strmenu)
        {
            string url = string.Empty;
            Stream fileStream = GetLogFileStream(strmenu);
            var writeAdapter = new StreamWriter(fileStream, Encoding.Default);
            writeAdapter.WriteLine("***********" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "**************************");
            writeAdapter.WriteLine("[日志]:" + log);
            if (ex != null)
            {
                writeAdapter.WriteLine("[异常]:" + ex.Message);
            }
            writeAdapter.WriteLine("***********End******************************************");
            writeAdapter.WriteLine("");
            writeAdapter.Close();
            fileStream.Close();
        }



        private static Stream GetLogFileStream(string strmenu)
        {
            string logfile = "E:\\qzsd\\log\\" + DateTime.Now.ToString("yyyyMM");
            string logurl = logfile + "\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + strmenu + ".log";

            var dir = new DirectoryInfo(logfile);
            if (!dir.Exists)
                dir.Create();
            Stream fileStream = null;
            fileStream = System.IO.File.Open(logurl, FileMode.Append, FileAccess.Write, FileShare.Write);
            return fileStream;
        }

    }
}