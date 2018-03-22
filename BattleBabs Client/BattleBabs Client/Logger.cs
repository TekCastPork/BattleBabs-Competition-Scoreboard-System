using System;
using System.IO;
using System.Diagnostics;

namespace BattleBabs_Client
{
    /// <summary>
    /// This class will handle log file creation and exception logging to make debugging a little easier hopefully.
    /// </summary>
    class Logger
    {
        static StreamWriter writer;
        static Stopwatch sw;

        /// <summary>
        /// Opens a log file
        /// </summary>
        public static void createLogFile()
        {
            if (Directory.Exists("./Logs"))
            {
                Console.WriteLine("Log folder exists, we don't need to make it.");
            }
            else
            {
                Console.WriteLine("Log folder does not exist, we need to make it.");
                Directory.CreateDirectory("./Logs");
                Console.WriteLine("Log folder created, logs will be stored there");
            }
            DateTime time = DateTime.UtcNow;
            Console.WriteLine("Creating a log file.");
            sw = Stopwatch.StartNew();
            writer = new StreamWriter(String.Format("./Logs/{0}.log", time.ToString().Replace(':', '-').Replace('\\', '-').Replace('/', '-') + " UTC"));
            Console.WriteLine("Log file created as {0}.log", time.ToString().Replace(':', '-') + "UTC");
            writer.WriteLine("[BEGIN] Log File started");
        }

        /// <summary>
        /// Writes a general info log to the log file, if arguments must be added String.Format must be used as the parameter
        /// </summary>
        /// <param name="msg"></param>
        public static void writeGeneralLog(string msg)
        {
            Console.WriteLine("Logging a general message: {0}", msg);
            writer.WriteLine("({0})[INFO] " + msg, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Writes a warning level message to the log file, if arguments must be added String.Format must be used as the parameter
        /// </summary>
        /// <param name="msg"></param>
        public static void writeWarningLog(string msg)
        {
            Console.WriteLine("Logging a warning message: {0}", msg);
            writer.WriteLine("({0})[WARN] " + msg, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Writes a critical level message to the log file, if arguments must be added String.Format must be used
        /// </summary>
        /// <param name="msg"></param>
        public static void writeCriticalLog(string msg)
        {
            Console.WriteLine("Logging a critical message: {0}", msg);
            writer.WriteLine("({0})[CRIT] " + msg, sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Writes data about an Exception to the log file.
        /// </summary>
        /// <param name="ExceptionData"></param>
        public static void writeExceptionLog(Exception e)
        {
            try
            {
                Console.WriteLine("Logging an Exception!");
                writer.WriteLine("({0})[EX] An Exception has occurred!", sw.ElapsedMilliseconds);
                writer.WriteLine("\t" + e.ToString());
                writer.WriteLine("\t" + e.Message);
                writer.WriteLine("Data about the Exception follows.");
                writer.WriteLine("\tSource: " + e.Source);
                writer.WriteLine("\tTarget Site: " + e.TargetSite);
                writer.WriteLine("\tStack Trace: " + e.StackTrace);
                writer.WriteLine("({0})[EX] Exception Logging Complete.", sw.ElapsedMilliseconds);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }

        /// <summary>
        /// Closes the currently open log file.
        /// </summary>
        public static void closeLog()
        {
            Console.WriteLine("Now closing the log file.");
            writer.WriteLine("[END] Log File End.");
            writer.Flush();
            writer.Close();
        }
    }
}
