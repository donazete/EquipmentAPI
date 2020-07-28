using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Echo.Equipment.Api.Models
{
    public class EquipmentData
    {
        Connection connObj = new Connection();
        SqlConnection connect = Connection.getConnection();

        public async Task<string> openConnection()
        {
            string message = null;
            try
            {
                connect.Open();
                message = "Connection Successful!";
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }
            return message;
        }

        public async Task<string> closeConnection()
        {
            string message = null;
            try
            {
                connect.Close();
                message = "Connection closed!";
            }
            catch (Exception ex)
            {
                message = ex.ToString();
            }
            return message;
        }

        public async Task<string> liveness()
        {
            string response = null;
            Dictionary<string, object> reply = new Dictionary<string, object>();
            reply.Add("application", "Equipment API");
            reply.Add("status", "Live");
            reply.Add("timestamp", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            response = JsonConvert.SerializeObject(reply);
            return response;
        }

        public async Task<string> getEquipment(string searchParam)
        {
            string jsonResponse = null;
            string connectMessage = await openConnection();
            SqlDataReader dr;
            string query = "SELECT [CategoryId],[CategoryBusinessKey],[CategoryOptimizerCode],[CategoryName],[EquipmentId],[EquipmentBusinessKey],[SubCategoryName],[Description],[LengthId],[LengthBusinessKey],[Name],[Display],[Measure] FROM equipment.vwEquipmentList WHERE IsActive = 1 AND CategoryName LIKE '%'+@Search+'%'";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.Add("@Search", SqlDbType.VarChar);
            cmd.Parameters["@Search"].Value = searchParam;
            dr = cmd.ExecuteReader();
            Console.WriteLine(dr);
            EquipmentDataModel ed = new EquipmentDataModel();
            Dictionary<string, object> fullData = new Dictionary<string, object>();
            Dictionary<string, object> partData = new Dictionary<string, object>();
            int i = 1;
            string cat = null;

            while (dr.Read())
            {
                cat = dr.GetValue(3).ToString();
                partData.Add("equipment" + i, ed.setMessage(Convert.ToInt32(dr.GetValue(0)), dr.GetValue(1).ToString(), dr.GetValue(3).ToString(), Convert.ToInt32(dr.GetValue(4)), dr.GetValue(5).ToString(), dr.GetValue(6).ToString(), dr.GetValue(7).ToString(), Convert.ToInt32(dr.GetValue(8)), dr.GetValue(9).ToString(), dr.GetValue(10).ToString(), dr.GetValue(11).ToString(), dr.GetValue(12).ToString()));
                i += 1;
            }
            fullData.Add(cat, partData);
            jsonResponse = JsonConvert.SerializeObject(fullData);
            dr.Close();
            cmd.Dispose();
            await closeConnection();
            return jsonResponse;
        }
    }
}