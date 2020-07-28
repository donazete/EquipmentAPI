using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Echo.Equipment.Api.Models
{
    public class Logger
    {
        public Logger()
        {
        }
        private static Random random = new Random();

        protected string generateLogId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(System.Linq.Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());

        }

        //Console.WriteLine(generateLogId());

        private string logFormatter(String app, Dictionary<string, object> subData)
        {
            String response = null;
            var jsonMessage = new Dictionary<string, object>();
            //string result = JsonConvert.SerializeObject(x);
            jsonMessage.Add("timestamp", DateTime.Now);
            jsonMessage.Add("level", "DEBUG");
            jsonMessage.Add("response", 200);
            jsonMessage.Add("status", "OK");
            jsonMessage.Add("source", app);
            jsonMessage.Add("message", subData);
            response = JsonConvert.SerializeObject(jsonMessage);
            return response;
        }

        protected void logConsole(string logID, string data, string app, string method, long duration)
        {
            var subData = new Dictionary < string, object>();
            subData.Add("calltime", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            subData.Add("logid", logID);
            subData.Add("data", data);
            subData.Add("source", app);
            subData.Add("method", method);
            subData.Add("duration", duration + " sec");
            Console.WriteLine(logFormatter(app, subData));
            subData.Clear();
        }
    }
}