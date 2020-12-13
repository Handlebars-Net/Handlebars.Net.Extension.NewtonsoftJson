using System;
using HandlebarsDotNet.IO;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson.Formatters
{
    public class JFormatterProvider : IFormatterProvider
    {
        private static readonly JArrayFormatter JArrayFormatter = new JArrayFormatter();
        private static readonly JObjectFormatter JObjectFormatter = new JObjectFormatter();
        private static readonly JValueFormatter JValueFormatter = new JValueFormatter();

        public bool TryCreateFormatter(Type type, out IFormatter? formatter)
        {
            if (type == typeof(JArray))
            {
                formatter = JArrayFormatter;
                return true;
            }
            
            if (type == typeof(JObject))
            {
                formatter = JObjectFormatter;
                return true;
            }
            
            if (type == typeof(JValue))
            {
                formatter = JValueFormatter;
                return true;
            }

            formatter = null;
            return false;
        }
    }
}