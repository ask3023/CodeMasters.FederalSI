using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CodeMasters.FederalSI.Shared.Model;
using Newtonsoft.Json;

namespace CodeMasters.FederalSI.Droid
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