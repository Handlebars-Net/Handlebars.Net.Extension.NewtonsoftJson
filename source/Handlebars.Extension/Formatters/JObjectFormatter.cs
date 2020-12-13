using System;
using HandlebarsDotNet.IO;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson.Formatters
{
    public class JObjectFormatter : IFormatter
    {
        private static readonly Type Type = typeof(JObject);

        public void Format<T>(T value, in EncodedTextWriter writer)
        {
            writer.Write(Type.ToString(), false);
        }
    }
}