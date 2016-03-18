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

namespace CodeMasters.FederalSI.Android
{
    public class JsonHelper
    {
        public static string SerializeSolutions(List<Solution> solutions)
        {
            return JsonConvert.SerializeObject(solutions);
        }

        public static List<Solution> DeserializeSolutions(string jsonSolutions)
        {
            return JsonConvert.DeserializeObject<List<Solution>>(jsonSolutions);
        }
    }
}