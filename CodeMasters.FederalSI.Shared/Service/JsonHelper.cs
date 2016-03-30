using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeMasters.FederalSI.Shared.Model;
using Newtonsoft.Json;

namespace CodeMasters.FederalSI.Shared.Service
{
    public class JsonHelper
    {
        public static string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T Deserialize<T>(string jsonSolutions)
        {
            return JsonConvert.DeserializeObject<T>(jsonSolutions);
        }
    }
}