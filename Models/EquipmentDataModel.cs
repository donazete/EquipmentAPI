using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Echo.Equipment.Api.Models
{
    public class EquipmentDataModel
    {
        public Dictionary<string, object> setMessage(int catId, string catBizKey, string catName, int equipId, string equipBizKey, string subCatName, string description, int lenId, string lenBizKey, string lenName, string lenDisplay, string lenMeasure)
        {
            Dictionary<string, object> subData = new Dictionary<string, object>();
            subData.Add("category_id", catId);
            subData.Add("category_bizkey", catBizKey);
            subData.Add("category_name", catName);
            subData.Add("equipment_id", equipId);
            subData.Add("equipment_bizkey", equipBizKey);
            subData.Add("subcategory_id", subCatName);
            subData.Add("description", description);
            subData.Add("length_id", lenId);
            subData.Add("length_bizkey", lenBizKey);
            subData.Add("length_name", lenName);
            subData.Add("length_display", lenDisplay);
            subData.Add("length_measure", lenMeasure);
            return subData;
        }
    }
}