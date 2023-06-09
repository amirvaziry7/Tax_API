﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tax_Api.Bussines
{
    public class JsonHelper
    {
        public static Dictionary<string, object> DeserializeAndFlatten(string json)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            JToken token = JToken.ReadFrom(new JsonTextReader(new
StringReader(json)));
            FillDictionaryFromJToken(dict, token, "");
            return dict;
        }
        private static void FillDictionaryFromJToken(Dictionary<string, object>
       dict, JToken token, string prefix)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    foreach (JProperty prop in token.Children<JProperty>())
                    {
                        FillDictionaryFromJToken(dict, prop.Value, Join(prefix, prop.Name));
                    }
                    break;
                case JTokenType.Array:
                    int index = 0;
                    foreach (JToken value in token.Children())
                    {
                        FillDictionaryFromJToken(dict, value, Join(prefix, index.ToString()));
                        index++;
                    }
                    break;
                default:
                    dict.Add(prefix, ((JValue)token).Value);
                    break;
            }
            static string Join(string prefix, string name)
            {
                return (string.IsNullOrEmpty(prefix) ? name : prefix + "." + name);
            }
        }

    }
}
