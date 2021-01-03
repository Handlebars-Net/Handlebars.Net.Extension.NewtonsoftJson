using HandlebarsDotNet.IO;
using Newtonsoft.Json.Linq;

namespace HandlebarsDotNet.Extension.NewtonsoftJson.Formatters
{
    public class JTokenFormatter : IFormatter
    {
        public void Format<T>(T value, in EncodedTextWriter writer)
        {
            var token = value as JToken;
            writer.Write(token!.ToString());
        }
    }
}