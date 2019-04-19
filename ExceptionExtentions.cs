using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace DotNetExtention
{
    public static class ExceptionExtentions
    {
        public class ExceptionInfo
        {

            public string App { get; set; }
            public string Message { get; set; }
            public int Line { get; set; }
            public string FileName { get; set; }
            public string Class { get; set; }
            public string Method { get; set; }
            public int Column { get; set; }
            public string Info { get; set; }

        }
        static JavaScriptSerializer serializer = new JavaScriptSerializer();
        public static void Log(this Exception ex,string info="")
        {
            try
            {
                var result = GetAllOutFromException(info, ex);
                WriteToEndOfLogFile(result.ToList());
                //SendToWebService(result);
            }
            catch (Exception) { }
        }
        private static IEnumerable<ExceptionInfo> GetAllOutFromException(string info, Exception ex)
        {

            var st = new StackTrace(ex, true); // create the stack trace
            var result = st.GetFrames()         // get the frames
                          .Select(frame => new ExceptionInfo
                          {                   // get the info
                              FileName = frame.GetFileName(),
                              Line = frame.GetFileLineNumber(),
                              Column = frame.GetFileColumnNumber(),
                              Method = frame.GetMethod().Name,
                              Class = frame.GetMethod().DeclaringType.FullName,
                              Info = info,
                              Message = ex.ToString()
                          });
            return result;
        }
        private static void WriteToEndOfLogFile(List<ExceptionInfo> exceptionInfo)
        {

            var path = System.AppDomain.CurrentDomain.BaseDirectory + "\\exLog.htm";
            var content = serializer.Serialize(exceptionInfo);
            File.AppendAllText(path, content);
        }
        private static void SendToWebService(ExceptionInfo exceptionInfo)
        {

        }
    }
}
