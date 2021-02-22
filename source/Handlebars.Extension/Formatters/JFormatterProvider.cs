using System;
using System.Reflection;
using HandlebarsDotNet.IO;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson.Formatters
{
    public class JFormatterProvider : IFormatterProvider
    {
        private static readonly JTokenFormatter JTokenFormatter = new JTokenFormatter();

        public bool TryCreateFormatter(Type type, out IFormatter? formatter)
        {
            if (typeof(JToken).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
            {
                formatter = JTokenFormatter;
                return true;
            }

            formatter = null;
            return false;
        }
    }
}