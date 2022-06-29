using System;
using System.Reflection;
using HandlebarsDotNet.IO;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson.Formatters
{
    public class JFormatterProvider : IFormatterProvider
    {
        private static readonly JTokenFormatter JTokenFormatter = new JTokenFormatter();
        private static readonly JValueFormatter JValueFormatter = new JValueFormatter();

        public bool TryCreateFormatter(Type type, out IFormatter? formatter)
        {
            var typeInfo = type.GetTypeInfo();
            if (typeof(JValue).GetTypeInfo().IsAssignableFrom(typeInfo))
            {
                formatter = JValueFormatter;
                return true;
            }
            
            if (typeof(JToken).GetTypeInfo().IsAssignableFrom(typeInfo))
            {
                formatter = JTokenFormatter;
                return true;
            }

            formatter = null;
            return false;
        }
    }
}