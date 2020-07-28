using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace Echo.Equipment.Api.Models
{
    public class Connection
    {
        string message = null;
        SqlConnection conn = null;
        public Connection() { }
        
        private Dictionary<string, object> loadConfig()
        {
            Dictionary<string, object> configInfo = new Dictionary<string, object>();
            using (StreamReader r = new StreamReader(@"./Connection/appsettings.json"))
            {
                string json = r.ReadToEnd();
                configInfo = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            }

            return configInfo;
        }

        public static SqlConnection getConnection()
        {
            Connection newconn = new Connection();
            Dictionary<string, object> config = newconn.loadConfig();
            string connString = @"Data Source=" + config["server"] + "; Initial Catalog=" + config["database"] + "; User ID=" + config["username"] + "; Password=" + config["pass"];
            
            try
            {
                newconn.conn = new SqlConnection(connString);
                newconn.message = "Connection Successful!";
            }
            catch (Exception ex)
            {
                newconn.message = ex.ToString();
            }
            
            return newconn.conn;

        }
    }

    
}